using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Media;
using System.Windows;
using System.Xml.Linq;

namespace MoPhongThiNghiemVatLy.Animation
{
    internal class AnimationApplicator
    {
        public static void ApplyHoverAnimation(UIElement[] elements, UIElement element2, double duration)
        {
            bool isClicked = false;  // Cờ xác định phần tử đã được click
            bool isHovered = false;

            foreach (var element in elements)
            {
                // Đảm bảo phần tử có TransformGroup
                if (element.RenderTransform == null || !(element.RenderTransform is TransformGroup transformGroup))
                {
                    transformGroup = new TransformGroup
                    {
                        Children = new TransformCollection
                        {
                            new ScaleTransform(1, 1),        // Zoom
                            new TranslateTransform(0, 0)    // Di chuyển
                        }
                    };
                    element.RenderTransform = transformGroup;
                }

                // Gắn sự kiện hover
                element.MouseEnter += (s, e) =>
                {
                    if (!isClicked && !isHovered) // Nếu chưa click thì hiển thị animation
                    {
                        StoryboardHelper.CreateShowAnimation(element2, duration).Begin();
                    }
                };

                element.MouseLeave += (s, e) =>
                {
                    isHovered = false;
                    if (!isClicked) // Nếu chưa click thì ẩn animation
                    {
                        if (!isHovered) // Nếu đang hover
                        {
                            StoryboardHelper.CreateHideAnimation(element2, duration).Begin();
                        }
                    }
                };

                element.MouseDown += (s, e) =>
                {
                    isClicked = true;
                };
            }
        }
    }
}
