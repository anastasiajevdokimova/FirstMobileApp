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
    public partial class RGB_Sliders_Page : ContentPage
    {
        Label lbl_rgb, lbl_red, lbl_green, lbl_blue;
        Slider sl_red, sl_green, sl_blue;
        Button btn;
        Random rnd;

        public RGB_Sliders_Page()
        {
            lbl_rgb = new Label
            {
                BackgroundColor = Color.FromRgb(0, 0, 0),
                WidthRequest = 500,
                HeightRequest = 500
                //HorizontalOptions = LayoutOptions.CenterAndExpand,
                //VerticalOptions = LayoutOptions.CenterAndExpand
            };

            //бегунок, отвечающий за красный
            sl_red = new Slider
            {
                Minimum = 0,
                Maximum = 255,
                Value = 1,
                MinimumTrackColor = Color.Red,
                MaximumTrackColor = Color.Red,
                ThumbColor = Color.Red
            };
            sl_red.ValueChanged += OnSliderValueChanged;

            lbl_red = new Label
            {
                Text = "Text red", //text RED = NUMBER
                HorizontalOptions = LayoutOptions.Center
            };

            //бегунок, отвечающий за зеленый
            sl_green = new Slider
            {
                Minimum = 0,
                Maximum = 255,
                Value = 1,
                MinimumTrackColor = Color.Green,
                MaximumTrackColor = Color.Green,
                ThumbColor = Color.Green
            };
            sl_green.ValueChanged += OnSliderValueChanged;

            lbl_green = new Label
            {
                Text = "Text green", //text GREEN = NUMBER
                HorizontalOptions = LayoutOptions.Center
            };

            //бегунок, отвечающий за синий
            sl_blue = new Slider
            {
                Minimum = 0,
                Maximum = 255,
                Value = 1,
                MinimumTrackColor = Color.Blue,
                MaximumTrackColor = Color.Blue,
                ThumbColor = Color.Blue
            };
            sl_blue.ValueChanged += OnSliderValueChanged;

            lbl_blue = new Label
            {
                Text = "Text blue", //text BLUE = NUMBER
                HorizontalOptions = LayoutOptions.Center
            };

            btn = new Button
            {
                Text = "Random!",
                TextColor = Color.White,
                BackgroundColor = Color.Purple,
                HorizontalOptions = LayoutOptions.Center
            };
            btn.Clicked += RandomColors;

            StackLayout st = new StackLayout
            {
                Children = { lbl_rgb, sl_red, lbl_red, sl_green, lbl_green, sl_blue, lbl_blue, btn }
            };
            Content = st;

        }

        private void RandomColors(object sender, EventArgs e)
        {
            rnd = new Random();
            //lbl_rgb.BackgroundColor = Color.FromRgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
            
            //с помощью рандома изменяем значения каждого из ползунков
            sl_red.Value = Convert.ToInt32(rnd.Next(0, 255));
            sl_green.Value = Convert.ToInt32(rnd.Next(0, 255));
            sl_blue.Value = Convert.ToInt32(rnd.Next(0, 255));
        }

        private void OnSliderValueChanged(object sender, ValueChangedEventArgs args)
        {
            if (sender == sl_red)
            {
                lbl_red.Text = String.Format("Red = {0:X2}", Convert.ToInt32(args.NewValue).ToString());
                //sl_red.Value = args.NewValue;
            }
            else if (sender == sl_green)
            {
                lbl_green.Text = String.Format("Green = {0:X2}", Convert.ToInt32(args.NewValue).ToString());
                //sl_green.Value = args.NewValue;
            }
            else if (sender == sl_blue)
            {
                lbl_blue.Text = String.Format("Blue = {0:X2}", Convert.ToInt32(args.NewValue).ToString());
                //sl_blue.Value = args.NewValue;
            }

             lbl_rgb.BackgroundColor = Color.FromRgb(sl_red.Value = Convert.ToInt32(args.NewValue), 
                sl_green.Value = Convert.ToInt32(args.NewValue), sl_blue.Value = Convert.ToInt32(args.NewValue));
        }
    }
}