using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
		}

	    private void Button_OnClickedAddRegistration(object sender, EventArgs e)
	    {
	        rpvm.AddToRegistrationString();
	        Navigation.PushAsync(new MainPage());
	    }
	}
}