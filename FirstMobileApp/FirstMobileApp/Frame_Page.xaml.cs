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
    public partial class Frames_Page : ContentPage
    {
        Frame frame;
        Label lbl;
        Grid grid;
        BoxView b;

        public Frames_Page()
        {
            lbl = new Label
            {
                Text = "Raami kujundus",
                FontSize = Device.GetNamedSize(NamedSize.Title, typeof(Label)), //используем размер лейбла устройства
                HorizontalOptions = LayoutOptions.Center
            };

            grid = new Grid
            {
                RowDefinitions =
                {
                    //row - высота, column - ширина
                    new RowDefinition{Height = new GridLength(2, GridUnitType.Star)},
                    new RowDefinition{Height = new GridLength(1, GridUnitType.Star)},
                    new RowDefinition{Height = new GridLength(1, GridUnitType.Star)}
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition{Width = new GridLength(2, GridUnitType.Star)},
                    new ColumnDefinition{Width = new GridLength(1, GridUnitType.Star)}
                }
            };

            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 2; c++)
                {
                    b = new BoxView { Color = Color.AliceBlue };
                    grid.Children.Add(b, c, r);
                    TapGestureRecognizer tap = new TapGestureRecognizer();
                    tap.Tapped += Tap_Tapped;
                    b.GestureRecognizers.Add(tap);
                }
            }
            //grid.Children.Add(new BoxView { Color = Color.Red }, 0, 0); //0,0 - колонка, ряд
            //grid.Children.Add(new BoxView { Color = Color.Green }, 1, 0);
            //grid.Children.Add(new BoxView { Color = Color.Blue }, 0, 1);
            //grid.Children.Add(new BoxView { Color = Color.Yellow }, 1, 1);
            //grid.Children.Add(new BoxView { Color = Color.MediumPurple }, 0, 2);
            //grid.Children.Add(new BoxView { Color = Color.Beige }, 1, 2);

            frame = new Frame
            {
                Content = grid,
                BorderColor = Color.Chartreuse,
                CornerRadius = 30,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            StackLayout st = new StackLayout
            {
                Children = { lbl, frame }
            };

            Content = st;
        }

        private void Tap_Tapped(object sender, EventArgs e)
        {
            var b = (BoxView)sender;
            var r = Grid.GetRow(b); //определяем координату 
            var c = Grid.GetColumn(b);
            b.Color = Color.Black;
        }
    }
}