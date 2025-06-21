using MoPhongThiNghiemVatLy.AddWindow;
using MoPhongThiNghiemVatLy.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Documents.DocumentStructures;
using System.Windows.Media.Media3D;
using System.Xml.Linq;

namespace MoPhongThiNghiemVatLy
{
    internal class MainCircuit
    {
        public static int indexOfNode = 0;
        public static int indexOfRes = 0;
        public static int indexOfVol = 0;
        public static int indexOfAmpe = 0;
        public static int indexOfSwitch = 0;
        public static int indexOfLight = 0;

        public static List<CircuitDiagram> mainCircuit = new List<CircuitDiagram>();
        public static Stack<BackUpCore> history = new Stack<BackUpCore>();  // Lịch sử các hành động (cho undo)
        public static Stack<BackUpCore> redoStack = new Stack<BackUpCore>();  // Lịch sử các hành động đã undo (cho redo)

        public static void AddSeries(List<CircuitDiagram> list, double value)
        {
            BackUpBeforeEachBahavior();
            indexOfRes += 1;
            list.Add(new Resistor(value, indexOfRes));
            indexOfNode += 1;
            list.Add(new Node(indexOfNode));
        }
        public static void AddParallel(List<CircuitDiagram> list, double value)
        {
            indexOfRes += 1;
            list.Add(new Resistor(value, indexOfRes));
        }
        public static void AddVolmeter(List<CircuitDiagram> list, int l, int r)
        {
            BackUpBeforeEachBahavior();
            int index = 0;
            for (int i = 0; i < list.Count; i++)
            {

                if (list[i].Type == DEFINE.TYPE_Node)
                {
                    if (list[i].Indexer == l)
                    {
                        index = i + 1;
                    }
                }
            }
            indexOfVol += 1;
            list.Insert(index, new Volmeter(l, r, indexOfVol));
            CustomizeMessageBox customMessageBox = new CustomizeMessageBox($"Đã thêm vol kế thứ {indexOfVol}. Mặc tại node: {l} và {r}");
            customMessageBox.ShowDialog();
        }
        public static void AddAmmeter(List<CircuitDiagram> list)
        {
            BackUpBeforeEachBahavior();
            indexOfAmpe += 1;
            list.Add(new Ammeter(indexOfAmpe));
            indexOfNode += 1;
            list.Add(new Node(indexOfNode));
        }
        public static void AddLight(List<CircuitDiagram> list, double[] data)
        {
            BackUpBeforeEachBahavior();
            indexOfLight += 1;
            list.Add(new Light(indexOfLight, data));
            indexOfNode += 1;
            list.Add(new Node(indexOfNode));
        }
        public static void AddSwitch(List<CircuitDiagram> list)
        {
            BackUpBeforeEachBahavior();
            indexOfSwitch += 1;
            list.Add(new Switch(indexOfSwitch));
            indexOfNode += 1;
            list.Add(new Node(indexOfNode));
        }

        public static void RemoveDetail(List<CircuitDiagram> list, int type, int index)
        {
            if (type == DEFINE.TYPE_Switch && type == DEFINE.TYPE_Node) return;
            BackUpBeforeEachBahavior();
            /*
            Liệt kê các case cần breakdown
            - Case 1: Xóa vol kế (lý do phải break V ra 1 case riêng là vì )
            - Case 2: Xóa chi tiết nằm giữa 2 node ( node diagram node ) => có A, 1R, K, Light
            - Case 3: Xóa chi tiết dạng node/V+ V diagram node
            - Case 4: Xóa chi tiết dạng Node R-R Node
            */
            //Case 1: xóa vol kế
            if (type == DEFINE.TYPE_Vol)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Type == type && list[i].Indexer == index)
                    {
                        list.RemoveAt(i);
                        ReplaceInformation(list, type);
                        return;
                    }
                }
            } // return ngay vì không cần hiệu chỉnh gì nữa cả


            bool wasDeleted = false; // check có xóa node ko. nếu có thì sẽ phải hiệu chỉnh l-r props của vol kế
            int indexOfNodeHadDeleted = 0; // index của node bị xóa nếu có. 
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Type == DEFINE.TYPE_Node && i + 1 == list.Count)
                    break; // Break tránh out index

                if (list[i].Type == type && list[i].Indexer == index)
                {
                    //Case 2: xóa chi tiết nằm giữa 2 node
                    if (list[i - 1].Type == DEFINE.TYPE_Node && list[i + 1].Type == DEFINE.TYPE_Node)
                    {
                        list.RemoveAt(i);
                        indexOfNodeHadDeleted = list[i].Indexer;
                        list.RemoveAt(i);
                        wasDeleted = true;
                        break;
                    }
                    //Case 3: xóa dạng V diagram node 
                    if (list[i - 1].Type == DEFINE.TYPE_Vol && list[i + 1].Type == DEFINE.TYPE_Node)
                    {
                        list.RemoveAt(i);
                        indexOfNodeHadDeleted = list[i].Indexer;
                        list.RemoveAt(i);
                        wasDeleted = true;
                        break;
                    }
                    //Case 3: xóa dạng R-R-Node  và Case 4: R-R-R
                    if ((list[i - 1].Type == DEFINE.TYPE_Res && list[i + 1].Type == DEFINE.TYPE_Node)
                       || (list[i - 1].Type == DEFINE.TYPE_Res && list[i + 1].Type == DEFINE.TYPE_Res))
                    {
                        list.RemoveAt(i);
                    }

                }
            }
            ReplaceInformation(list, type);
            if (wasDeleted)
            {
                ModifyAllVolAfterErasingNode(list, indexOfNodeHadDeleted);
            }
        }
        private static void ModifyAllVolAfterErasingNode(List<CircuitDiagram> list, int index)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Type != DEFINE.TYPE_Vol) continue;
                int[] pos = list[i].LeftRight();
                int l = pos[0];
                int r = pos[1];
                if (index <= l)
                {
                    l -= 1; r -= 1;
                }
                else if (index <= r)
                    r -= 1;
                // sau hiệu chỉnh 
                if (l <= 0 || l >= r)
                {
                    RemoveVolmeterIfCantModify(list, DEFINE.TYPE_Vol, list[i].Indexer);
                }
                else
                    list[i] = new Volmeter(l, r, list[i].Indexer);
            }
            ReplaceInformation(list, DEFINE.TYPE_Vol);
            return;
        }
        //xử lý case làm V không còn khả thi
        private static void RemoveVolmeterIfCantModify(List<CircuitDiagram> list, int type, int index)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Type == type && list[i].Indexer == index)
                {
                    list.RemoveAt(i);
                    return;
                }
            }
        }

        private static void ReplaceInformation(List<CircuitDiagram> list, int type)
        {
            //đánh lại index node
            indexOfNode = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Type == DEFINE.TYPE_Node)
                {
                    indexOfNode++;
                    list[i].Indexer = indexOfNode;
                }
            }
            //đánh lại chi tiết bị gỡ
            int newIndex = 0;
            switch (type)
            {
                case DEFINE.TYPE_Res:
                    indexOfRes -= 1;
                    break;
                case DEFINE.TYPE_Ampe:
                    indexOfAmpe -= 1;
                    break;
                case DEFINE.TYPE_Vol:
                    indexOfVol -= 1;
                    break;
                case DEFINE.TYPE_Light:
                    indexOfLight -= 1;
                    break;
                case DEFINE.TYPE_Switch:
                    indexOfSwitch -= 1;
                    break;
            }
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Type == type)
                {
                    newIndex++;
                    list[i].Indexer = newIndex;
                }
            }
        }

        public static void BackUpBeforeEachBahavior()
        {
            //history.Push(mainCircuit.ToList());
            history.Push(new BackUpCore(indexOfNode,
                                        indexOfRes,
                                        indexOfVol,
                                        indexOfAmpe,
                                        indexOfSwitch,
                                        indexOfLight,
                                        mainCircuit));
        }
        public static void Undo()
        {
            if (history.Count == 0) return;
            redoStack.Push(new BackUpCore(indexOfNode,
                                        indexOfRes,
                                        indexOfVol,
                                        indexOfAmpe,
                                        indexOfSwitch,
                                        indexOfLight,
                                        mainCircuit));
            history.Pop().ReturnValue();
            RefillIndexOfNode(mainCircuit);
        }
        public static void Redo()
        {
            if (redoStack.Count == 0) return;
            BackUpBeforeEachBahavior();
            redoStack.Pop().ReturnValue();
        }
        private static void RefillIndexOfNode(List<CircuitDiagram> list)
        {
            indexOfNode = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Type == DEFINE.TYPE_Node)
                {
                    indexOfNode++;
                    list[i].Indexer = indexOfNode;
                }
            }
        }

    }
}
