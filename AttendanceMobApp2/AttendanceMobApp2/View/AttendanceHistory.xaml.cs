using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
	public partial class AttendanceHistory : ContentPage
	{
        //public ObservableCollection<AttendanceListItem> HistoryOfAttendances { get; set; } =
        //    new ObservableCollection<AttendanceListItem>();

	    private AttendanceHistoryViewModel vm;
        public AttendanceHistory(List<DateTime> attendancies)
		{
		    //foreach (var item in attendancies)
		    //{
		    //    HistoryOfAttendances.Add(new AttendanceListItem() { Date = item, ImageSource = "ok4.jpg" });

		    //}

            InitializeComponent();
            //((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.Black;
            //((NavigationPage)Application.Current.MainPage).BarTextColor = Color.DeepSkyBlue;
            //GetAllAttendances();

            //BindingContext = this;

		    vm = new AttendanceHistoryViewModel(attendancies);
		    BindingContext = vm;
        }
	    protected override void OnAppearing()
	    {
	        base.OnAppearing();
	        ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.Black;
	        ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.DeepSkyBlue;

	    }

        private void DeleteClicked(object sender, EventArgs e)
	    {
	        throw new NotImplementedException();
	    }

	    private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
	    {
	        if (e.SelectedItem == null)
	        {
	            return; // Catch deselection
	        }

            Attendance attendance = e.SelectedItem as Attendance;
	        //DisplayAlert("Selected", attendance.AttendanceDate.ToString() , "OK");

	    }

	    public void GetAllAttendances()
	    {
	        //var repo = new AttendanceRepository();
	        //var attendances = repo.GetAll();
	        //foreach (var attendance in attendances)
	        //{
	        //    HistoryOfAttendances.Add(attendance);
	        //}
	    }

	}
}