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
        public MainPage()
        {
            //создаём первую кнопку
            Button box_btn = new Button
            {
                Text = "BoxPage",
                BackgroundColor = Color.Crimson
            };
            box_btn.Clicked += Box_btn_Clicked; //связь кнопки с методом

            Button entry_btn = new Button
            {
                Text = "Entry",
                BackgroundColor = Color.Blue,
            };
            entry_btn.Clicked += Entry_btn_Clicked;

                //В Layout добавляем созданные ранее элементы
                StackLayout st = new StackLayout
            {
                Children = { box_btn, entry_btn }
            };
            st.BackgroundColor = Color.Beige;
            
            //Привязка к Content = видим элементы
            Content = st;
        }

        private async void Entry_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Entry_Page()); //создаём страницу Entry_Page
        }

        private async void Box_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Box_Page()); //создаём страницу Box_Page
        }
    }
}
