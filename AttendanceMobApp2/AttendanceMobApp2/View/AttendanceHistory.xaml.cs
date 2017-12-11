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
	public partial class AttendanceHistory : ContentPage
	{
		public AttendanceHistory ()
		{
			InitializeComponent ();
		    BindingContext = new AttendanceHistoryViewModel();
		}

	    private void DeleteClicked(object sender, EventArgs e)
	    {
	        throw new NotImplementedException();
	    }
	}
}