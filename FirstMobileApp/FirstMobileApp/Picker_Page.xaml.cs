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
    public partial class Picker_Page : ContentPage
    {
        Picker picker;
        WebView webView;
        StackLayout st;
        Frame frame;
        Entry entry;
        Button lisa;
        ImageButton kodu, tagasi, edasi;
        String veeb;
        List<string> lehed = new List<string> { "https://tahvel.edu.ee/", "https://moodle.edu.ee/", "https://www.tthk.ee/", "https://www.google.com/" };

        public Picker_Page()
        {
            picker = new Picker
            {
                Title = "★ Minu järjehoidjad",
                BackgroundColor = Color.Lavender,
                WidthRequest = 300
            };
            picker.Items.Add("tahvel.edu.ee");
            picker.Items.Add("moodle.edu.ee");
            picker.Items.Add("tthk.ee");
            //picker.Items.Add("Google"):
            picker.SelectedIndexChanged += Picker_SelectedIndexChanged;

            //кнопка на добавление новой закладки
            lisa = new Button
            {
                Text = "★",
                TextColor = Color.Magenta,
                FontSize = 20,
                BackgroundColor = Color.White,
                WidthRequest = 40,
                HeightRequest = 40
            };
            lisa.Clicked += Lisa_Clicked;

            kodu = new ImageButton
            {
                Source = "home.png",
                HeightRequest = 40,
                WidthRequest = 40
            };
            kodu.Clicked += Kodu_Clicked;

            tagasi = new ImageButton
            {
                Source = "back.jpg",
                HeightRequest = 40,
                WidthRequest = 40
            };
            tagasi.Clicked += Tagasi_Clicked;

            edasi = new ImageButton
            {
                Source = "forward.jpg",
                HeightRequest = 40,
                WidthRequest = 40
            };
            edasi.Clicked += Edasi_Clicked;

            webView = new WebView { };
            SwipeGestureRecognizer swipe = new SwipeGestureRecognizer();
            swipe.Swiped += Swipe_Swiped;
            swipe.Direction = SwipeDirection.Right;

            entry = new Entry { Placeholder = "🔍 Otsi...", WidthRequest = 150, HeightRequest = 30 };
            entry.Completed += Entry_Completed; //функция срабатывает при нажатии на Enter

            //сюда добавляем элементы т.н. меню - поиск и кнопки. Его добавляем во frame!
            StackLayout buttons = new StackLayout
            {
                Children = {entry, lisa, kodu, tagasi, edasi},
                Orientation = StackOrientation.Horizontal
            };
            
            frame = new Frame
            {
                Content = buttons,
                BorderColor = Color.AliceBlue,
                CornerRadius = 20,
                HeightRequest = 50,
                WidthRequest = 500,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                HasShadow = true
            };
            st = new StackLayout
            {
                Children = { frame, picker }
            };
            frame.GestureRecognizers.Add(swipe);
            Content = st;
        }

        private void Edasi_Clicked(object sender, EventArgs e)
        {
            if (webView.CanGoForward)
            {
                webView.GoForward();
            }
        }

        private void Tagasi_Clicked(object sender, EventArgs e)
        {
            if (webView.CanGoBack)
            {
                webView.GoBack();
            }
        }

        private void Kodu_Clicked(object sender, EventArgs e)
        {
            webView.Source = new UrlWebViewSource { Url = lehed[3] };

        }

        private async void Lisa_Clicked(object sender, EventArgs e)
        {
            if(entry.Text != "")
            {
                lehed.Add("https://" + entry.Text);
                picker.Items.Add(entry.Text);
                await DisplayAlert("★", "Uus järjehoidja oli lisatud!", "OK");
            }
            else
            {
                await DisplayAlert("Hoiatus!", "Veebiaadress ei ole sisestanud! Ei ole võimalik järjehoidjat lisada!!", "Sain aru");
            }

        }

        private void Entry_Completed(object sender, EventArgs e)
        {
            webView.Source = "https://" + entry.Text;
            st.Children.Add(webView);
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            //удаляем и пересоздаём webView
            if (webView != null)
            {
                st.Children.Remove(webView);
            }
            webView = new WebView
            {
                Source = new UrlWebViewSource { Url = lehed[picker.SelectedIndex] },
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            st.Children.Add(webView);
        }
        

        private void Swipe_Swiped(object sender, SwipedEventArgs e)
        {
            //при свайпе открывается Google
            webView.Source = new UrlWebViewSource { Url = lehed[3] };
        }

    }
}