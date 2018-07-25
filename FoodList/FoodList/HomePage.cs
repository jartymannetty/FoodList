using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace FoodList
{
    public class HomePage : ContentPage
    {
        public HomePage()
        {
            this.Title = "Home";
            Label blank = new Label
            {
                Text = " ",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            Label welcome = new Label
            {
                Text = "Welcome to FoodList",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };
            
            Image logo = new Image
            {
                Source = "logo.png",
                Aspect = Aspect.AspectFit,
            };
            Content = new StackLayout
            {
                Children = {
                    blank,
                    welcome,
                    //blank,
                    //logo
                }
            };
            this.Padding = 5;
        }
    }
}