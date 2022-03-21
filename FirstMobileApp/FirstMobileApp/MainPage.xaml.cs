using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FirstMobileApp
{
    public partial class MainPage : ContentPage
    {
        Button box_btn, entry_btn, timer_btn, date_btn, ss_btn, rgb_sl_btn, frame_btn, img_btn;
        public MainPage()
        {
            //создаём первую кнопку
            box_btn = new Button
            {
                Text = "BoxPage",
                BackgroundColor = Color.Red
            };
            //box_btn.Clicked += Box_btn_Clicked; //связь кнопки с методом
            box_btn.Clicked += Start_Pages;

            entry_btn = new Button
            {
                Text = "Entry",
                BackgroundColor = Color.Orange,
            };
            entry_btn.Clicked += Start_Pages;

            timer_btn = new Button
            {
                Text = "Timer",
                BackgroundColor = Color.Yellow
            };
            timer_btn.Clicked += Start_Pages;

            date_btn = new Button
            {
                Text = "Date/Time",
                BackgroundColor = Color.Green
            };
            date_btn.Clicked += Start_Pages;

            ss_btn = new Button
            {
                Text = "Stepper-Slider",
                BackgroundColor = Color.LightBlue
            };
            ss_btn.Clicked += Start_Pages;

            rgb_sl_btn = new Button
            {
                Text = "RGB Color Sliders",
                BackgroundColor = Color.Blue,
                TextColor = Color.White
            };
            rgb_sl_btn.Clicked += Start_Pages;

            frame_btn = new Button
            {
                Text = "Frame Page",
                BackgroundColor = Color.Purple,
                TextColor = Color.White
            };
            frame_btn.Clicked += Start_Pages;

            img_btn = new Button
            {
                Text = "Image Slider",
                BackgroundColor = Color.Purple,
                TextColor = Color.White
            };
            img_btn.Clicked += Start_Pages;


            //В Layout добавляем созданные ранее элементы
            StackLayout st = new StackLayout
            {
                Children = { box_btn, entry_btn, timer_btn, date_btn, ss_btn, rgb_sl_btn, frame_btn, img_btn }
            };
            st.BackgroundColor = Color.Beige;

            //Привязка к Content = видим элементы
            Content = st;
        }

        private async void Start_Pages(object sender, EventArgs e)
        {
            Button btn = (Button)sender; //проверяем не нажали ли на какую-нибудь кнопку
            if (sender==entry_btn)
            {
                await Navigation.PushAsync(new Entry_Page()); //создаём страницу Entry_Page
            }
            else if (sender==box_btn)
            {
                await Navigation.PushAsync(new Box_Page()); //создаём страницу Box_Page
            }
            else if (sender==timer_btn)
            {
                await Navigation.PushAsync(new Timer_Page());
            }
            else if (sender==date_btn)
            {
                await Navigation.PushAsync(new Data_Page()); //создаём страницу Data_Page
            }
            else if (sender==ss_btn)
            {
                await Navigation.PushAsync(new Step_Slid_Page());
            }
            else if (sender== rgb_sl_btn)
            {
                await Navigation.PushAsync(new RGB_Sliders_Page());
            }
            else if (sender==frame_btn)
            {
                await Navigation.PushAsync(new Frames_Page());
            }
            else if( sender == img_btn)
            {
                await Navigation.PushAsync(new Images_Page());
            }

        }

    }
}
