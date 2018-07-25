using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Util;
using FoodList.Droid;
using System.Threading;
using System.Threading.Tasks;

namespace Splash_Screen
{

    [Activity(Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory = true)]
    public class SplashScreen : AppCompatActivity
    {
        static readonly string TAG = "X:" + typeof(SplashScreen).Name;

        public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistentState)
        {
            base.OnCreate(savedInstanceState, persistentState);
           
        }

       
        protected override void OnResume()
        {
            base.OnResume();
            Task startupWork = new Task(() => { SimulateStartup(); });
            startupWork.Start();
        }

        
        async void SimulateStartup()
        {
            
            await Task.Delay(1); 
            
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
        }
    }
}