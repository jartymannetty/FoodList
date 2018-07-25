using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace FoodList.Test
{
	public class AppInitializer
	{
		public static IApp StartApp(Platform platform)
		{
            if (platform == Platform.Android)
            {
                return ConfigureApp
                   .Android
                   .EnableLocalScreenshots()
                   .ApkFile("../../../FoodList/FoodList.Android/bin/Debug/com.companyname.FoodList-Signed.apk")
                   .StartApp();
            }

            return ConfigureApp
               .iOS
               .EnableLocalScreenshots()
               .StartApp();
        }
    }
}