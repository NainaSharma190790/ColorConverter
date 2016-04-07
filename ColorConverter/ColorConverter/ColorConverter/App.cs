using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ColorConverter
{
	public class App : Application
	{
		#region All Fields 
		public static int ScreenHeight;// for device height
		public static int ScreenWidth;// for device width
		#endregion

		public App ()
		{
            // The root page of your application
			MainPage = new ColorConverterPage();
		}
        public static App Instance
        {
            get
            {
                return (App)Xamarin.Forms.Application.Current;
            }
        }
        public void Alert(string message, string title = null, string closeButton = null)
        {
            if (string.IsNullOrEmpty(closeButton))
                closeButton = "OK";

             MainPage.DisplayAlert(title, message, closeButton);
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
