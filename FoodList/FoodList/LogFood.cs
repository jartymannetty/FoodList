using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace FoodList
{

    public class LogFood : ContentPage
    {
        ListView listView;
        Button btnAdd;


        public LogFood(Food food)
        {

            this.Title = "Log Food";
            btnAdd = new Button
            {
                Text = "Add food",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button)),
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            btnAdd.Clicked += Addfood;
            this.Padding = 5;
            
            if (food.ID != -1)
            {
                App.Database.Insert(food);
            }

            listView = new ListView();
            Content = new StackLayout
            {
                Children = {
                    btnAdd, listView
                }
            };

            listView.ItemTapped += Selected;
            food = (Food)listView.SelectedItem;


        }
        private async void Selected(object sender, ItemTappedEventArgs e)
        {
            Food food = (Food)listView.SelectedItem;
            await Navigation.PushAsync(new AddData(food));

        }

        protected override async void OnAppearing()
        {
            listView.ItemsSource = await App.Database.SelectAll();
        }
        private async void Addfood(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddData());
        }
    }
}