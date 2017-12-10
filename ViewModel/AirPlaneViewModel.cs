using MVVMExample.ViewModel;
using MVVMExample.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace MVVMExample
{


    //Data Binding is gonna happen through here

    public class AirPlaneViewModel : AirPlaneViewModelBase

    {
        //AirPlane's properties val
        private String finder_ = null;
        private AirPlane airPlane_ = null;
        private int aidi_ = 0;
        private String CompanyName_ = null;
        private int NumOfPlanes_ = 0;
        private String TypeOfPlanes_ = null;

        //Airplane list
        public ObservableCollection<AirPlane> airPlaneList_ = new ObservableCollection<AirPlane>();
        public ObservableCollection<AirPlane> AirPlaneList
        {
            get
            {
                return airPlaneList_;
            }
        }
        //public ObservableCollection<AirPlane> AirPlaneList => this.airPlaneList_;
        public AirPlane SelectedAirPlane { get; set; }
        //public int thatAirPlane;
        //private DelegateCommand deleteAirPlane_;

        //Displays value to screen
        //private String result_ = null;
        /*
        private bool isAddClicked_ = false;
        private bool isDeleteClicked_ = false;
        private bool isEditClicked_ = false;
        private bool isSearchClicked_ = false;

        private bool isCompanyNameFilled_ = false;
        private bool isNumOfPlanesFilled_ = false;
        private bool isTypeOfPlanesFilled_ = false;
        private bool isValue4Filled_ = false;
        */

        //Person properties binded in XAML<------------------>
        public String CompanyName
        {
            get { return CompanyName_; }
            set { CompanyName_ = value; OnPropertyChanged("CompanyName"); }
        }   
        public String Finder
        {
            get { return finder_; }
            set { finder_ = value; OnPropertyChanged("Finder"); }
        }
        public int NumOfPlanes
        {
            get { return NumOfPlanes_; }
            set { NumOfPlanes_ = value; OnPropertyChanged("NumOfPlanes"); }
        }
        public String TypeOfPlanes
        {
            get { return TypeOfPlanes_; }
            set { TypeOfPlanes_ = value; OnPropertyChanged("TypeOfPlanes"); }
        }
        //Command to display name to the screen
        public ICommand AddButtonClicked
        {
            get { return new DelegateCommand(DisplayName); }
        }
        //Display Name
        public void DisplayName()
        {
            airPlane_ = new AirPlane(aidi_, CompanyName, NumOfPlanes, TypeOfPlanes);
            airPlaneList_.Add(airPlane_);
            aidi_++;
            //Resetting Values
            CompanyName = "";
            NumOfPlanes = 0;
            TypeOfPlanes = "";

        }
        /* //Button Methods
         public bool AddButtonClicked2
         {
             get { return isAddClicked_; }
             set
             {
                 if (value != isAddClicked_)
                 {
                     /*isNumOfPlanesFilled_ = value;
                     AddButtonClicked2 = true;
                     OnPropertyChanged("IsAddClicked");
                 }
             }
         } 

         public bool DeleteButtonClicked
         {
             get { return isDeleteClicked_; }
             set
             {
                 if (value != isDeleteClicked_)
                 {
                     /*isNumOfPlanesFilled_ = value;
                     DeleteButtonClicked = true;
                     OnPropertyChanged("IsDeleteClicked");
                 }
             }
         }

         public bool EditButtonClicked
         {
             get { return isEditClicked_; }
             set
             {
                 if (value != isEditClicked_)
                 {
                     isNumOfPlanesFilled_ = value;
                     EditButtonClicked = true;
                     OnPropertyChanged("IsEditClicked");
                 }
             }
         }

         public bool SearchButtonClicked
         {
             get { return isSearchClicked_; }
             set
             {
                 if (value != isSearchClicked_)
                 {
                     /*isNumOfPlanesFilled_ = value;
                     SearchButtonClicked = true;
                     OnPropertyChanged("IsSearchClicked");
                 }
             }
         }
 */

        //Command to delete a person
        public ICommand DeleteButtonClicked
        {

            get
            {
                return new DelegateCommand(DeleteAirPlane);
            }
        }

        public void DeleteAirPlane()
        {

            if (SelectedAirPlane != null)
            {
                AirPlaneList.Remove(SelectedAirPlane);
                airPlaneList_.Remove(SelectedAirPlane);
            }
        }
        //Command to edit a customer
        public ICommand EditButtonClicked
        {
            get
            {
                return new DelegateCommand(EditAirplane);
            }
        }
        public void EditAirplane()
        {
            if (SelectedAirPlane != null)
            {
                CompanyName = SelectedAirPlane.CompanyNameModel;
                NumOfPlanes = SelectedAirPlane.NumOfPlanesModel;
                TypeOfPlanes = SelectedAirPlane.TypeOfPlaneModel;

                /*airPlane_ = new AirPlane(aidi_, CompanyName, NumOfPlanes, TypeOfPlanes);
                AirPlaneList.Add(airPlane_);*/
            }
        }
        public ICommand SaveButtonClicked
        {
            get
            {
                return new DelegateCommand(UpdateAirPlane);
            }
        }
        public void UpdateAirPlane()
        {
            int oldiD = SelectedAirPlane.iD;

            if (SelectedAirPlane != null)
            {
                airPlaneList_.Remove(SelectedAirPlane);
            }
            airPlane_ = new AirPlane(oldiD, CompanyName, NumOfPlanes, TypeOfPlanes);
            airPlaneList_.Add(airPlane_);
            aidi_++;
        }
        public ICommand SearchButtonClicked
        {
            get
            {
                return new DelegateCommand(SearchAirplane);
            }
        }
        public void SearchAirplane()
        {
          //  finder_ = new SearchFind();
            String userText = finder_.ToString().ToLower();
/*
            foreach (String item in AirPlaneList)
            {
                String[] sentence = item.Split('\n', ' ');

                foreach (String word in sentence)
                {
                    if (word.ToLower().Equals(userText))
                    {
                        ListView.item);
                    }
                }
            }*/
        }
        
    }
}