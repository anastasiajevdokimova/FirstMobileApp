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
    public partial class Box_Page : ContentPage
    {
        BoxView box;
        Random rnd;
        public Box_Page()
        {
            box = new BoxView
            {
                Color = Color.FromHex("#FFCC99"),
                CornerRadius = 20,
                WidthRequest = 100,
                HeightRequest = 200,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            //нажатие
            TapGestureRecognizer tap = new TapGestureRecognizer();
            tap.Tapped += Tap_Tapped;
            box.GestureRecognizers.Add(tap); //добавляем к распознавателю жестов

            StackLayout st = new StackLayout
            {
                Children = {box}
            };
            Content = st;
        }

        private void Tap_Tapped(object sender, EventArgs e)
        {
            rnd = new Random();
            box.Color = Color.FromRgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
            box.Rotation += 25;
            try
            {
                Vibration.Vibrate(); //вибрация при нажатии
                var dur = TimeSpan.FromSeconds(0.3); //вибрация с паузой
                Vibration.Vibrate(dur);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}