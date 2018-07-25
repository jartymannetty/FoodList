using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;


namespace FoodList
{
    public class NavigationDrawer : MasterDetailPage
    {
        private ListView listView;
        public NavigationDrawer()
        {
            this.Title = "Please select";
            string[] myPageNames = { "Home", "Search", "Log Food" };
            listView = new ListView
            {
                ItemsSource = myPageNames
            };
            this.Master = new ContentPage
            {
                Title = "Options",
                Content = listView
            };
            listView.ItemTapped += TapAction;
            this.Detail = new NavigationPage(new HomePage());
        }
        private void TapAction(object sender, ItemTappedEventArgs e)
        {
            ContentPage gotoPage;
            switch (e.Item.ToString())
            {
                case "Home":
                    gotoPage = new HomePage();
                    break;
                case "Search":
                    gotoPage = new Search();
                    break;
                case "Log Food":
                    Food food = new Food
                    {
                        ID = -1
                    };
                    gotoPage = new LogFood(food);
                    break;
                default:
                    gotoPage = new MainPage();
                    break;
            }
            this.Detail = new NavigationPage(gotoPage);
            ((ListView)sender).SelectedItem = null;
            this.IsPresented = false;
        }
    }
}