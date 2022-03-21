using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FirstMobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Timer_Page : ContentPage
    {
        TimePicker tp;
        Label lbl;
        Button btn_start, btn_stop;
        AbsoluteLayout abs;

        public Timer_Page()
        {
            tp = new TimePicker
            {
                Time = new TimeSpan(12, 30, 00)
            };
            tp.PropertyChanged += Tp_PropertyChanged;

            lbl = new Label
            {
                Text = "Palun vali kellaaeg",
                BackgroundColor = Color.LightCoral
            };

            btn_start = new Button
            {
                Text = "Go!"
            };
            btn_start.Clicked += Btn_start_Clicked;

            btn_stop = new Button
            {
                Text = "STOP",
                TextColor = Color.Red
            };
            btn_stop.Clicked += Btn_stop_Clicked;
              

            abs = new AbsoluteLayout
            {
                Children = { lbl, tp, btn_start }
            };

            AbsoluteLayout.SetLayoutBounds(lbl, new Rectangle(0.1, 0.6, 300, 70));
            AbsoluteLayout.SetLayoutFlags(lbl, AbsoluteLayoutFlags.PositionProportional);

            AbsoluteLayout.SetLayoutBounds(tp, new Rectangle(0.1, 0.8, 300, 70));
            AbsoluteLayout.SetLayoutFlags(tp, AbsoluteLayoutFlags.PositionProportional);

            AbsoluteLayout.SetLayoutBounds(btn_start, new Rectangle(0.2, 0.8, 300, 70));
            AbsoluteLayout.SetLayoutFlags(btn_start, AbsoluteLayoutFlags.PositionProportional);

            AbsoluteLayout.SetLayoutBounds(btn_stop, new Rectangle(0.2, 0.8, 300, 70));
            AbsoluteLayout.SetLayoutFlags(btn_stop, AbsoluteLayoutFlags.PositionProportional);
            Content = abs;
        }

        private void Btn_stop_Clicked(object sender, EventArgs e)
        {
            tp.Time = new TimeSpan(00, 00, 00);
            lbl.Text = "Palun vali kellaaeg";
            lbl.TextColor = Color.LightCoral;
            abs.Children.Add(btn_start);
        }

        private async void Btn_start_Clicked(object sender, EventArgs e)
        {
            var time = (int)(tp.Time.TotalSeconds - DateTime.Now.TimeOfDay.TotalSeconds);
            while (time != 0)
            {
                await Task.Delay(1000);
                lbl.Text = time.ToString();
                time = (int)(tp.Time.TotalSeconds - DateTime.Now.TimeOfDay.TotalSeconds);
                if (time == 0)
                {
                    lbl.BackgroundColor = Color.Red;
                    var dur = TimeSpan.FromSeconds(0.3);
                    Vibration.Vibrate(dur);
                    abs.Children.Add(btn_stop);
                }
            }

        }

        private void Tp_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            lbl.Text = "Oli valitud aeg: " + tp.Time;
        }



        //public Timer_Page()
        //{
        //    Button tagasi = new Button
        //    {
        //        Text = "Tagasi"
        //    };
        //    tagasi.Clicked += Tagasi_Clicked;
        //    StackLayout st = new StackLayout { Children = { tagasi } };
        //}
        //    bool on_off = true;

        //    private async void ShowTime()
        //    {
        //        while (on_off)
        //        {
        //            timer_btn.Text = DateTime.Now.ToString("T");
        //            await Task.Delay(1000);
        //        }
        //    }
        //    private void timer_btn_Clicked(object sender, EventArgs e)
        //    {
        //        if (on_off)
        //        {
        //            on_off = false;
        //        }
        //        else
        //        {
        //            on_off = true;
        //            ShowTime();
        //        }
        //    }
        //    private async void Tagasi_Clicked(object sender, EventArgs e)
        //    {
        //        await Navigation.PushAsync(new MainPage());
        //    }


        //    private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        //    {
        //        lbl.Text = "Vajutatud";
        //    }
    }
}