using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AttendanceMobApp2.Model;
using AttendanceMobApp2.View;
using Xamarin.Forms;

namespace AttendanceMobApp2
{
	public partial class App : Application
	{
	    
        public App ()
		{
		    
            InitializeComponent();
		    if (Application.Current.Properties.ContainsKey("regCode"))
		    {
		        string id = Application.Current.Properties["regCode"] as string;
		        //id = null;
		        if (!string.IsNullOrEmpty(id))
		        {
		            MainPage = new NavigationPage(new MainPage());
                }
		        else
		        {
		            MainPage = new NavigationPage(new RegistrationPage());
		        }

		        
                //MainPage = new NavigationPage(new MainPage());
            }

		    if (!Application.Current.Properties.ContainsKey("regCode"))
		    {
		        MainPage = new NavigationPage(new RegistrationPage());
            }
		    
            //MainPage = new NavigationPage(new RegistrationPage());

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
