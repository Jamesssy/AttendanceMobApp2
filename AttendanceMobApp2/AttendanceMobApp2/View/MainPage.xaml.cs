using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttendanceMobApp2.Data;
using AttendanceMobApp2.Model;
using AttendanceMobApp2.View;
using AttendanceMobApp2.ViewModel;
using Xamarin.Forms;

namespace AttendanceMobApp2
{
	public partial class MainPage : ContentPage
	{
        private List<Attendance> attendances { get; set; } =
            new List<Attendance>();

        //private static int ids = 0;

        private MainPageViewModel vm;
		public MainPage()
		{
			InitializeComponent();
            //LoadRegCode();
		    //((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.Black;
		    //((NavigationPage)Application.Current.MainPage).BarTextColor = Color.DeepSkyBlue;
            vm = new MainPageViewModel();
		    BindingContext = vm;
            
		}

	    protected override void OnAppearing()
	    {
	        base.OnAppearing();
	        ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.Black;
	        ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.DeepSkyBlue;

	    }

        private void Button_OnClickedAttHistory(object sender, EventArgs e)
	    {
	        Navigation.PushAsync(new AttendanceHistory(), true);
	    }

	    private void Button_OnClickedCheckInRefresh(object sender, EventArgs e)
	    {
	        throw new NotImplementedException();
	    }

	    private void Button_OnClickedCheckIn(object sender, EventArgs e)
	    {
	        vm.GetCurrentLocation();
            AddToAttendanceList();
	        GetAllAttendancesToList();
            vm.CheckIfCheckedInString();
	        vm.CheckIfCheckedInImage();
            vm.CheckLastCheckedIn();
            
	        //Navigation.PushAsync(new MainPage());

	    }
        public void AddToAttendanceList()
        {

            //Attendance attendance = new Attendance();
            //attendance.AttendanceDate = DateTime.Now;
            //attendance.ImageSource = "ok4.jpg";
            //attendance.Id = ids++;
            //Attendance.Attendances.Add(attendance);
            //attendances.Add(attendance);
            //var repo = new AttendanceRepository();
            //repo.Save(attendances);

        }

	    public void GetAllAttendancesToList()
	    {
	        var repo = new AttendanceRepository();
	        var Attendances = repo.GetAll();
	        foreach (var attendance in Attendances)
	        {
	            attendances.Add(attendance);
	        }
	    }

	    public void LoadRegCode()
	    {
	        if (Application.Current.Properties.ContainsKey("regCode"))
	        {
	            string id = Application.Current.Properties["regCode"] as string;
	            if (string.IsNullOrEmpty(id)) Navigation.PushAsync(new MainPage(), true);

	            Navigation.PushAsync(new RegistrationPage(), true);
                //Application.Current.MainPage = new NavigationPage(new MainPage());
	        }





            var repo = new RegistrationCodeRepository();
	        var checkIfExist = repo.GetAll().First().RegistrationCode;

	        if (checkIfExist != null)
	        {
	            Navigation.PushAsync(new MainPage(), true);


	        }
	        else
	        {
	            Navigation.PushAsync(new RegistrationPage(), true);
	        }

	    }


    }
}
