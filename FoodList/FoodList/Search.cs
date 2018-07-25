using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace FoodList
{
    public class Search : ContentPage
    {
        Entry search;
        Button btnSearch;
        ListView listView;

        public Search()
        {
            this.Title = "Search";
            search = new Entry
            {
                Placeholder = "Search for Food",
                Text = "",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Entry)),
                Keyboard = Keyboard.Text,
            };
            btnSearch = new Button
            {
                Text = "Search",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button)),
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            btnSearch.Clicked += SearchButton;


            listView = new ListView();
            Content = new StackLayout
            {
                Children = {
                    search, btnSearch, listView
                }
            };
            this.Padding = 5;
        }
        private async void SearchButton(object sender, EventArgs e)
        {

            listView.ItemsSource = await App.Database.GetItemsBySearchAsync(search.Text);

        }
    }


}