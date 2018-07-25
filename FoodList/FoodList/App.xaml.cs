using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using System.IO;

//[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace FoodList
{
	public partial class App : Application
	{
        static MyDatabase database;

        public static MyDatabase Database
        {

            get
            {
                if (database == null)
                {
                    database = new MyDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "FoodList.db3"));
                }
                return database;

            }


        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationDrawer();
        }

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
