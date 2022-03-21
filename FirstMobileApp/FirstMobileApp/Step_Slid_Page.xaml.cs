using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FirstMobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Step_Slid_Page : ContentPage
    {
        Label lbl;
        Stepper stp;
        Slider sl;
        public Step_Slid_Page()
        {
            lbl = new Label
            {
                Text = "Text",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            sl = new Slider
            {
                Minimum = 0,
                Maximum = 100,
                Value = 50,
                MaximumTrackColor = Color.Red,
                MinimumTrackColor = Color.Green,
                ThumbColor = Color.White
            };
            sl.ValueChanged += TextRotation;
            stp = new Stepper
            {
                Minimum = 0,
                Maximum = 100,
                Increment = 10,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.EndAndExpand
            };
            stp.ValueChanged += TextRotation;

            this.Content = new StackLayout { Children = { sl, lbl, stp } };
        }

        private void TextRotation(object sender, ValueChangedEventArgs e)
        {
            lbl.Text = String.Format("Slideri väärtus on {0:F1}", e.NewValue);
            lbl.FontSize = e.NewValue;
            lbl.Rotation = e.NewValue * 3.6;
        }

        /*private void Stp_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            lbl.Text = String.Format("Slideri väärtus on {0:F1}", e.NewValue);
            lbl.FontSize = e.NewValue;
            lbl.Rotation = e.NewValue * 3.6;
        }

        private void Sl_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            lbl.Text = String.Format("Slideri väärtus on {0:F1}", e.NewValue);
            lbl.FontSize = e.NewValue;
            lbl.Rotation = e.NewValue * 3.6;
        }*/
    }
}