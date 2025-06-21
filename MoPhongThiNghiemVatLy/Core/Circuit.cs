using MoPhongThiNghiemVatLy.AddWindow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Media3D;

namespace MoPhongThiNghiemVatLy
{
    internal class Circuit
    {
        static double mainCircuitVoltage;
        static double mainCircuitEROC; // Equivalent resistance of circuit
        static double mainCircuitAmperage;

        public static double MainCurcuitVoltage
        {
            get { return mainCircuitVoltage; }
            set { mainCircuitVoltage = value; }
        }
        public static double MainCircuitEROC
        {
            get { return mainCircuitEROC; }
            set { mainCircuitEROC = value; }
        }
        public static double MainCircuitAmperage
        {
            get { return mainCircuitAmperage; }
            set { mainCircuitAmperage = value; }
        }
        public static double EquivalentResistance(List<CircuitDiagram> list)
        {
            double EROC = 0; // Điện trở tương đương toàn mạch
            bool doneSection = false;
            /* Liệt kê tắt cả các case cần làm rõ
             * 1: node R/L node => skip các case là A và switch
             * 2: node R-R+ node => không có vol kế
             * 3: node V+ R/L => Có vol kế nhưng chỉ có 1 điện trở hoặc đèn (dĩ nhiên là vẫn skip case A và switch)
             * 4: node V+ R-R+ node => Có vol kế và là cụm song song
            */
            /// Bắt đầu loop duyệt mảng
            for (int i = 0; i < list.Count; i++)
            {
                doneSection = false;
                if (list[i].Type == DEFINE.TYPE_Node && i + 1 >= list.Count && !doneSection)
                    break; // Chạm node cuối, tranh trường hợp truy xuất vượt quá kích thước mạch

                // case 1: node R/L node
                if (list[i].Type == DEFINE.TYPE_Node && !doneSection)
                {
                    if ((list[i].Type == DEFINE.TYPE_Node) && (list[i + 1].Type != DEFINE.TYPE_Node) && (list[i + 2].Type == DEFINE.TYPE_Node))
                    {
                        if (list[i + 1].Type == DEFINE.TYPE_Res || list[i + 1].Type == DEFINE.TYPE_Light)
                        {
                            EROC += list[i + 1].Resistance;
                            i += 1; continue;
                        }
                        else
                        {
                            i += 1; continue;
                        }
                    }
                }
                //case 2: node R-R+ node
                if (list[i].Type == DEFINE.TYPE_Node && !doneSection)
                {
                    if (list[i + 1].Type == DEFINE.TYPE_Res)
                    {
                        int numberInner = 0;
                        double eropc = 0;
                        // tính điện trở tương đương của cụm
                        for (int j = i + 1; j < list.Count; j++)
                        {
                            if (list[j].Type == DEFINE.TYPE_Node)
                                break;
                            if (list[j].Type == DEFINE.TYPE_Res)
                            {
                                eropc += (1 / list[j].Resistance);
                                numberInner++;
                            }
                        }
                        eropc = 1 / eropc; // nghịch đảo lại cho đúng ct 1/Rtd = 1/R1 + 1/R2 ... + 1/Rn;
                        EROC += eropc; // Cộng vào R toàn mạch

                        //Lưu lại eropc để dùng cho bước tính cường độ dòng điện cho từng điện trở
                        for (int j = i + 1; j < list.Count; j++)
                        {
                            if (list[j].Type == DEFINE.TYPE_Node)
                                break;
                            if (list[j].Type == DEFINE.TYPE_Res)
                            {
                                list[j].Eropc = eropc;
                            }
                        }
                        i += numberInner;
                        continue;
                    }
                }

                //case 3: node V+ R/L  node
                if (list[i].Type == DEFINE.TYPE_Node && !doneSection)
                {
                    if (list[i + 1].Type == DEFINE.TYPE_Vol)
                    {
                        for (int j = i + 1; j < list.Count; j++)
                        {
                            if (list[j].Type == DEFINE.TYPE_Node) break;

                            if ((list[j].Type == DEFINE.TYPE_Vol) && (list[j + 1].Type == DEFINE.TYPE_Res || list[j + 1].Type == DEFINE.TYPE_Light) && (list[j + 2].Type == DEFINE.TYPE_Node))
                            {
                                EROC += list[j + 1].Resistance;
                                doneSection = true;
                                i += j + 1;
                                break;
                            }
                        }
                    }
                }
                //case 4: 
                if (!doneSection && list[i].Type == DEFINE.TYPE_Node)
                {
                    if (list[i + 1].Type == DEFINE.TYPE_Vol)
                    {
                        for (int k = i + 1; k < list.Count; k++)
                        {
                            if ((list[k].Type == DEFINE.TYPE_Vol) && (list[k + 1].Type == DEFINE.TYPE_Res) && (list[k + 2].Type == DEFINE.TYPE_Res))
                            {
                                int numberInner = 0;
                                double eropc = 0;
                                // tính điện trở tương đương của cụm
                                for (int j = k + 1; j < list.Count; j++)
                                {
                                    if (list[j].Type == DEFINE.TYPE_Node)
                                        break;
                                    if (list[j].Type == DEFINE.TYPE_Res)
                                    {
                                        eropc += (1 / list[j].Resistance);
                                        numberInner++;
                                    }
                                }
                                eropc = 1 / eropc; // nghịch đảo lại cho đúng ct 1/Rtd = 1/R1 + 1/R2 ... + 1/Rn;
                                EROC += eropc; // Cộng vào R toàn mạch

                                //Lưu lại eropc để dùng cho bước tính cường độ dòng điện cho từng điện trở
                                for (int j = i + 1; j < list.Count; j++)
                                {
                                    if (list[j].Type == DEFINE.TYPE_Node)
                                        break;
                                    if (list[j].Type == DEFINE.TYPE_Res)
                                    {
                                        list[j].Eropc = eropc;
                                    }
                                }
                                i += numberInner;
                                continue;
                            }
                        }
                    }
                }
            }
            return EROC;
        }
        public static void CalculateForAllDetails(List<CircuitDiagram> list, double mcAmperage)
        {
            IndexForShowResult.Reset();
            bool doneSection = false;
            //Chia case tương tự. Tuy nhiên sẽ có thêm vài chi tiết vd như Ampe
            for (int i = 0; i < list.Count; i++)
            {
                doneSection = false;
                if (list[i].Type == DEFINE.TYPE_Node && i + 1 >= list.Count && !doneSection)
                    break;
                // case 1: node R/L/A node
                if (list[i].Type == DEFINE.TYPE_Node && !doneSection)
                {
                    if ((list[i].Type == DEFINE.TYPE_Node) && (list[i + 1].Type != DEFINE.TYPE_Node) && (list[i + 2].Type == DEFINE.TYPE_Node))
                    {
                        if (list[i + 1].Type == DEFINE.TYPE_Res || list[i + 1].Type == DEFINE.TYPE_Light || list[i + 1].Type == DEFINE.TYPE_Ampe)
                        {
                            i += 1;
                            list[i].Amperage = mcAmperage;
                        }
                        continue;
                    }
                }
                //case 2: node R-R+  node
                if (list[i].Type == DEFINE.TYPE_Node && !doneSection)
                {
                    if (list[i + 1].Type == DEFINE.TYPE_Res)
                    {
                        for (int j = i + 1; j < list.Count; j++)
                        {
                            if (list[j].Type == DEFINE.TYPE_Node)
                                break;
                            list[j].Amperage = (mcAmperage * list[j].Eropc) / list[j].Resistance;
                        }
                    }
                }
                //case 3: 
                if (list[i].Type == DEFINE.TYPE_Node && !doneSection)
                {
                    if (list[i + 1].Type == DEFINE.TYPE_Vol)
                    {
                        for (int j = i + 1; j < list.Count; j++)
                        {
                            if (list[j].Type == DEFINE.TYPE_Node)
                                break;

                            if ((list[j].Type == DEFINE.TYPE_Vol) && (list[j + 1].Type == DEFINE.TYPE_Res || list[j + 1].Type == DEFINE.TYPE_Light) && (list[j + 2].Type == DEFINE.TYPE_Node))
                            {
                                list[j + 1].Amperage = mcAmperage;
                                doneSection = true;
                                i = j + 1;
                                break;
                            }
                        }
                    }
                }
                //case 4: 
                if (!doneSection && list[i].Type == DEFINE.TYPE_Node)
                {
                    if (list[i + 1].Type == DEFINE.TYPE_Vol)
                    {
                        for (int k = i + 1; k < list.Count; k++)
                        {
                            if ((list[k].Type == DEFINE.TYPE_Vol) && (list[k + 1].Type == DEFINE.TYPE_Res) && (list[k + 2].Type == DEFINE.TYPE_Res))
                            {
                                for (int j = k + 1; j < list.Count; j++)
                                {
                                    if (list[j].Type == DEFINE.TYPE_Node)
                                        break;
                                    list[j].Amperage = (mcAmperage * list[j].Eropc) / list[j].Resistance;
                                }
                            }
                        }
                    }
                }
            }
            //loop 1 để tính toàn bộ các chi tiết trước
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Type != DEFINE.TYPE_Vol)
                {
                    list[i].Caculate();
                }
            }
            MainWindow.Instance.LightPercentData.Clear();
            //loop 2 để tính Vol và % đèn vì cần phải có các chỉ số của chi tiết trước.
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Type == DEFINE.TYPE_Vol)
                {
                    list[i].Caculate();
                }
                else if (list[i].Type == DEFINE.TYPE_Light)
                {
                    list[i].CheckDen();
                }
            }

        }

    }
}
