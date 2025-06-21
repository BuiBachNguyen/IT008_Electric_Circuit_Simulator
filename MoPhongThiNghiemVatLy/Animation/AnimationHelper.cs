using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace MoPhongThiNghiemVatLy.Animation
{
    internal class AnimationHelper
    {
        // Tạo Fade Animation
        public static DoubleAnimation CreateFadeAnimation(double from, double to, double durationInSeconds)
        {
            return new DoubleAnimation
            {
                From = from,
                To = to,
                Duration = TimeSpan.FromSeconds(durationInSeconds),
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseInOut }
            };
        }

        // Tạo Zoom Animation (Scale)
        public static DoubleAnimation CreateZoomAnimation(double from, double to, double durationInSeconds)
        {
            return new DoubleAnimation
            {
                From = from,
                To = to,
                Duration = TimeSpan.FromSeconds(durationInSeconds),
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseInOut }
            };
        }

        // Tạo Move Animation (Translate)
        public static DoubleAnimation CreateMoveAnimation(double from, double to, double durationInSeconds)
        {
            return new DoubleAnimation
            {
                From = from,
                To = to,
                Duration = TimeSpan.FromSeconds(durationInSeconds),
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseInOut }
            };
        }
    }
}
