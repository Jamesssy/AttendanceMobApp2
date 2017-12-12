using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttendanceMobApp2.Model;
using AttendanceMobApp2.View;
using AttendanceMobApp2.ViewModel;
using Xamarin.Forms;

namespace AttendanceMobApp2
{
	public partial class MainPage : ContentPage
	{
	    
        private MainPageViewModel vm;
		public MainPage()
		{
			InitializeComponent();
            vm = new MainPageViewModel();
		    BindingContext = vm;
		}

	    private void Button_OnClickedAttHistory(object sender, EventArgs e)
	    {
	        Navigation.PushAsync(new AttendanceHistory());
	    }

	    private void Button_OnClickedCheckInRefresh(object sender, EventArgs e)
	    {
	        throw new NotImplementedException();
	    }

	    private void Button_OnClickedCheckIn(object sender, EventArgs e)
	    {
	        vm.AddToAttendance();
	        Navigation.PushAsync(new MainPage());

        }

	   
    }
}
