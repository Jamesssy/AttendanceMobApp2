using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace AttendanceMobApp2.ViewModel
{
    class MainPageViewModel : INotifyPropertyChanged
    {

        private string labelText = "Hello";

        public string LabelText
        {
            get { return labelText; }
            set
            {
                labelText = value; 
                OnPropertyChanged();
            }
        }



        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        public DateTime CheckedIn { get; set; }
        public string RegistrationCode { get; set; }

        public MainPageViewModel()
        {
            FirstName = "James";
            LastName = "Johansson";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        }
    }
}
