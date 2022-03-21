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

    public partial class Data_Page : ContentPage
    {
        DatePicker dp;
        Label lbl;
        TimePicker tp;
        public Data_Page()
        {
            lbl = new Label
            {
                Text = "Vali mingi kuupäev või kellaaeg",
                BackgroundColor = Color.LightCoral
            };

            dp = new DatePicker
            {
                Format = "D",
                MinimumDate = DateTime.Now.AddDays(-5), //дней назад
                MaximumDate = DateTime.Now.AddDays(+15) //дней вперёд
            };

            dp.DateSelected += Dp_DateSelected;

            tp = new TimePicker
            {
                Time = new TimeSpan(12, 30, 00)
            };
            tp.PropertyChanged += Tp_PropertyChanged;
            AbsoluteLayout abs = new AbsoluteLayout
            {
                Children = { dp, lbl, tp}
            };

            AbsoluteLayout.SetLayoutBounds(dp, new Rectangle(0.1, 0.4, 300, 70));
            AbsoluteLayout.SetLayoutFlags(dp, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(lbl, new Rectangle(0.1, 0.6, 300, 70));
            AbsoluteLayout.SetLayoutFlags(lbl, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(tp, new Rectangle(0.1, 0.8, 300, 70));
            AbsoluteLayout.SetLayoutFlags(tp, AbsoluteLayoutFlags.PositionProportional);
            Content = abs;
        }

        private void Tp_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            lbl.Text = "Oli valitud aeg: " + dp.Date.ToString("G") + tp.Time;
        }

        private void Dp_DateSelected(object sender, DateChangedEventArgs e) //sender - DataPicker, e - аргумент
        {
            lbl.Text = "Oli valitud päev: " + e.NewDate.ToString("G") + tp.Time; //берем выбранную пользователем дату и переобразуем её в текст + формат
        }
    }
}