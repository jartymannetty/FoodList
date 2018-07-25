using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace FoodList
{
    public class AddData : ContentPage
    {
        private Button btnAdd;
        private Button btnBack;
        private Entry name;
        private Entry description;
        private Entry notes;
        private Entry price;
        private Entry location;
        private Button btnDelete;
        Food updateFood;

        public AddData()
        {
            name = new Entry
            {
                Placeholder = "Enter Food Name",
                Text = "",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Entry)),
            };
            description = new Entry
            {
                Placeholder = "Enter Food Description",
                Text = "",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Entry)),
            };
            notes = new Entry
            {
                Placeholder = "Enter Note",
                Text = "",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Entry)),
                Keyboard = Keyboard.Text,
            };
            price = new Entry
            {
                Placeholder = "Enter Food Price",
                Text = "",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Entry)),
                Keyboard = Keyboard.Numeric,
            };
            location = new Entry
            {
                Placeholder = "Enter Food Location",
                Text = "",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Entry)),
                Keyboard = Keyboard.Text,
            };
            btnAdd = new Button
            {
                Text = "Add Food",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button)),
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            btnAdd.Clicked += AddItem;
            btnBack = new Button
            {
                Text = "Back",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button)),
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            btnBack.Clicked += BackButton;
            Content = new StackLayout
            {
                Children = {
                    name, description, notes, price, location, btnAdd, btnBack
                }
            };
            this.Padding = 20;
            this.Appearing += TitlePage_Appearing;
        }

        public AddData(Food food)
        {
            updateFood = food;
            name = new Entry
            {
                Placeholder = "Enter Food Name",
                Text = food.Name,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Entry)),
            };
            description = new Entry
            {
                Placeholder = "Enter Food Description",
                Text = food.Description,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Entry)),
            };
            notes = new Entry
            {
                Placeholder = "Enter Note",
                Text = food.Notes,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Entry)),
                Keyboard = Keyboard.Text,
            };
            price = new Entry
            {
                Placeholder = "Enter Food Price",
                Text = food.Price,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Entry)),
                Keyboard = Keyboard.Numeric,
            };
            location = new Entry
            {
                Placeholder = "Enter Location",
                Text = food.Location,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Entry)),
                Keyboard = Keyboard.Text,
            };
            btnAdd = new Button
            {
                Text = "Update Foods",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button)),
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            btnAdd.Clicked += UpdateItem;
            btnBack = new Button
            {
                Text = "Cancel",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button)),
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            btnBack.Clicked += BackButton;

            btnDelete = new Button
            {
                Text = "Delete",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button)),
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            btnDelete.Clicked += DeleteButton;
            Content = new StackLayout
            {
                Children = {
                    name, description, notes, price, location, btnAdd, btnBack, btnDelete
                }
            };
            this.Padding = 20;

        }
        private void TitlePage_Appearing(object sender, EventArgs e)
        {
            name.Text = "";
            description.Text = "";
            notes.Text = "";
            price.Text = "";
            location.Text = "";
        }
        private async void DeleteButton(object sender, EventArgs e)
        {
            var varFood = updateFood;
            await App.Database.DeleteItemAsync(varFood);
            Food food = new Food
            {
                ID = -1
            };
            await Navigation.PushAsync(new LogFood(food));

        }
        private async void AddItem(object sender, EventArgs e)
        {
            if (name.Text == "")
            {
                await DisplayAlert("Missing Value", "Enter a Food Name", "OK");
            }
            else if (description.Text == "")
            {
                await DisplayAlert("Missing Value", "Enter aFood Description", "OK");
            }
            else if (notes.Text == "")
            {
                await DisplayAlert("Missing Value", "Enter a Note", "OK");
            }
            else if (price.Text == "")
            {
                await DisplayAlert("Missing Value", "Enter an Food Price", "OK");
            }
            else if (location.Text == "")
            {
                await DisplayAlert("Missing Value", "Enter an Food Location", "OK");
            }
            else
            {
                Food food = new Food
                {
                    Name = name.Text,
                    Description = description.Text,
                    Notes = notes.Text,
                    Price = price.Text,
                    Location = location.Text
                };

                await Navigation.PushAsync(new LogFood(food));
            }
        }
        private async void UpdateItem(object sender, EventArgs e)
        {
            updateFood.Name = name.Text;
            updateFood.Description = description.Text;
            updateFood.Notes = notes.Text;
            updateFood.Price = price.Text;
            updateFood.Location = location.Text;
            if (name.Text == "")
            {
                await DisplayAlert("Missing Value", "Enter a Food Name", "OK");
            }
            else if (description.Text == "")
            {
                await DisplayAlert("Missing Value", "Enter aFood Description", "OK");
            }
            else if (notes.Text == "")
            {
                await DisplayAlert("Missing Value", "Enter a Note", "OK");
            }
            else if (price.Text == "")
            {
                await DisplayAlert("Missing Value", "Enter an Food Price", "OK");
            }
            else if (location.Text == "")
            {
                await DisplayAlert("Missing Value", "Enter an Food Location", "OK");
            }
            else
            {
                var todoFood = updateFood;
                await App.Database.SaveItemAsync(todoFood);
                Food food = new Food
                {
                    ID = -1
                };


                await Navigation.PushAsync(new LogFood(food));
            }
        }
        private async void BackButton(object sender, EventArgs e)
        {
            Food food = new Food
            {
                ID = -1
            };
            await Navigation.PushAsync(new LogFood(food));
        }
    }
}