using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttendanceMobApp2.Data;
using AttendanceMobApp2.Model;
using AttendanceMobApp2.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AttendanceMobApp2.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegistrationPage : ContentPage
	{
	    private RegistrationPageViewModel rpvm;
		public RegistrationPage ()
		{
			InitializeComponent ();
		    
            rpvm = new RegistrationPageViewModel();
		    BindingContext = rpvm;
            LoadRegCode();

        }

	    protected override void OnAppearing()
	    {
	        base.OnAppearing();
	        ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.Black;
	        ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.DeepSkyBlue;

        }

	    private void Button_OnClickedAddRegistration(object sender, EventArgs e)
	    {
	        rpvm.AddToRegistrationString();
	        Application.Current.MainPage = new NavigationPage(new MainPage());
	    }

	    public void LoadRegCode()
	    {
	        var repo = new RegistrationCodeRepository();
	        var checkIfExist = repo.GetAll().First().RegistrationString;
            
	        if (checkIfExist != null)
	        {
	            Navigation.PushAsync(new MainPage());


	        }

	    }

	   


    }
}