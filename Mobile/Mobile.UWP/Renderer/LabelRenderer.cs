using Mobile.Gestures;
using Mobile.UWP.Renderer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(Label), typeof(LabelRender))]
namespace Mobile.UWP.Renderer
{

    public class LabelRender : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                if (!e.NewElement.GestureRecognizers.Any())
                    return;

                if (e.NewElement.GestureRecognizers.Any(x => x.GetType() == typeof(PressedGestureRecognizer)))
                    Control.PointerPressed += Control_PointerPressed;

                if (e.NewElement.GestureRecognizers.Any(x => x.GetType() == typeof(ReleasedGestureRecognizer)))
                    Control.PointerReleased += Control_PointerReleased;
            }
        }



        private void Control_PointerPressed(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            foreach (var recognizer in this.Element.GestureRecognizers.Where(x => x.GetType() == typeof(PressedGestureRecognizer)))
            {
                var gesture = recognizer as PressedGestureRecognizer;
                if (gesture != null)
                    if (gesture.Command != null)
                        gesture.Command.Execute(gesture.CommandParameter);
            }
        }

        private void Control_PointerReleased(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            foreach (var recognizer in this.Element.GestureRecognizers.Where(x => x.GetType() == typeof(ReleasedGestureRecognizer)))
            {
                var gesture = recognizer as ReleasedGestureRecognizer;
                if (gesture != null)
                    if (gesture.Command != null)
                        gesture.Command.Execute(gesture.CommandParameter);
            }
        }
    }
}
