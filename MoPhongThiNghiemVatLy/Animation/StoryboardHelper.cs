using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using System.Windows;

namespace MoPhongThiNghiemVatLy.Animation
{
    internal class StoryboardHelper
    {

        public static Storyboard CreateShowAnimation(UIElement element, double duration)
        {
            var storyboard = new Storyboard();

            // Fade In
            var fadeIn = AnimationHelper.CreateFadeAnimation(0, 1, duration);
            Storyboard.SetTarget(fadeIn, element);
            Storyboard.SetTargetProperty(fadeIn, new PropertyPath("Opacity"));

            // Zoom In
            var zoomInX = AnimationHelper.CreateZoomAnimation(0.8, 1, duration);
            Storyboard.SetTarget(zoomInX, element);
            Storyboard.SetTargetProperty(zoomInX, new PropertyPath("(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)"));

            var zoomInY = AnimationHelper.CreateZoomAnimation(0.8, 1, duration);
            Storyboard.SetTarget(zoomInY, element);
            Storyboard.SetTargetProperty(zoomInY, new PropertyPath("(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)"));

            // Di chuyển chéo lên
            var moveUp = AnimationHelper.CreateMoveAnimation(20, 0, duration);
            Storyboard.SetTarget(moveUp, element);
            Storyboard.SetTargetProperty(moveUp, new PropertyPath("(UIElement.RenderTransform).(TransformGroup.Children)[1].(TranslateTransform.Y)"));

            // Thêm animation vào Storyboard
            storyboard.Children.Add(fadeIn);
            storyboard.Children.Add(zoomInX);
            storyboard.Children.Add(zoomInY);
            storyboard.Children.Add(moveUp);

            return storyboard;
        }

        public static Storyboard CreateHideAnimation(UIElement element, double duration)
        {
            var storyboard = new Storyboard();

            // Fade Out
            var fadeOut = AnimationHelper.CreateFadeAnimation(1, 0, duration);
            Storyboard.SetTarget(fadeOut, element);
            Storyboard.SetTargetProperty(fadeOut, new PropertyPath("Opacity"));

            // Zoom Out
            var zoomOutX = AnimationHelper.CreateZoomAnimation(1, 0.8, duration);
            Storyboard.SetTarget(zoomOutX, element);
            Storyboard.SetTargetProperty(zoomOutX, new PropertyPath("(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)"));

            var zoomOutY = AnimationHelper.CreateZoomAnimation(1, 0.8, duration);
            Storyboard.SetTarget(zoomOutY, element);
            Storyboard.SetTargetProperty(zoomOutY, new PropertyPath("(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)"));

            // Di chuyển chéo xuống
            var moveDown = AnimationHelper.CreateMoveAnimation(0, 20, duration);
            Storyboard.SetTarget(moveDown, element);
            Storyboard.SetTargetProperty(moveDown, new PropertyPath("(UIElement.RenderTransform).(TransformGroup.Children)[1].(TranslateTransform.Y)"));

            // Thêm animation vào Storyboard
            storyboard.Children.Add(fadeOut);
            storyboard.Children.Add(zoomOutX);
            storyboard.Children.Add(zoomOutY);
            storyboard.Children.Add(moveDown);

            return storyboard;
        }
    }
}
