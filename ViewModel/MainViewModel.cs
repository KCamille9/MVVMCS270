using MVVMExample.Model;
using MVVMExample.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;

namespace MVVMExample
{


    //Data Binding is gonna happen through here

    public class MainViewModel : ViewModelBase
    {
        //Person's properties val
        private Person person_ = null;
        private int aidi_ = 0;
        private String name_ = null;
        private int age_ = 0;
        private String profession_ = null;
        public String searchBoxText_ = null;

        private List<String> myList_ = null;
        private List<String> usual_ = null;



        //Person list
        public ObservableCollection<Person> personList_ = new ObservableCollection<Person>();


        //Selected Person
        public Person SelectedPerson { get; set; } 

        //Person properties binded in XAML<------------------>
        public String NameX
        {
            get
            {
                return name_;
            }
            set
            {
                name_ = value;
                OnPropertyChanged("NameX");
            }
        }

        public int AgeX
        {
            get
            {
                return age_;
            }
            set
            {
                age_ = value;
                OnPropertyChanged("AgeX");
            }
        }

        public String ProfessionX
        {
            get
            {
                return profession_;
            }
            set
            {
                profession_ = value;
                OnPropertyChanged("ProfessionX");
            }
        }

        public ObservableCollection<Person> PersonList
        {
            get
            {
                if (SearchBoxText != null)
                {
                    var list = personList_
                        .Where(person => person.Name.ToLower().Contains(SearchBoxText.ToLower()) ||
                        person.Proffesions.ToLower().Contains(SearchBoxText.ToLower()))
                        .ToList();

                    return new ObservableCollection<Person>(list);
                }
                return personList_;

            }
        }


        //Search textbox
        public String SearchBoxText
        {
            get
            {
                return searchBoxText_;
            }
            set
            {
                searchBoxText_ = value;
                OnPropertyChanged("SearchBoxText");
                OnPropertyChanged("PersonList");
            }
        }


        /// <summary>
        /// /////////////////////////////////////////////////////////////////////////////
        /// </summary>


        //Airplane's property values
        private AirPlane airplane_ = null;
        private int aidi2_ = 0;

        private String companyName_ = null;
        public String CompanyName
        {
            get
            {
                return companyName_;
            }
            set
            {
                companyName_ = value; OnPropertyChanged("CompanyName");
            }
        }
        private int numOfPlane_ = 0;
        public int NumOfPlanes
        {
            get
            {
                return numOfPlane_;
            }
            set
            {
                numOfPlane_ = value;
                OnPropertyChanged("NumOfPlanes");
            }
        }
        private String typeOfPlane_ = null;
        public String TypeOfPlanes
        {
            get
            {
                return typeOfPlane_;
            }
            set
            {
                typeOfPlane_ = value; OnPropertyChanged("TypeOfPlanes");
            }
        }
        public String searchBoxText2_ = null;

        //Search textbox
        public String SearchBoxText2
        {
            get
            {
                return searchBoxText2_;
            }
            set
            {
                searchBoxText2_ = value;
                OnPropertyChanged("SearchBoxText2");
                OnPropertyChanged("AirPlaneList");
            }
        }


        //Airplane list
        public ObservableCollection<AirPlane> airplaneList_ = new ObservableCollection<AirPlane>();

        public ObservableCollection<AirPlane> AirPlaneList
        {
            get
            {
                if (SearchBoxText2 != null)
                {
                    var list2 = airplaneList_
                        .Where(airplane => airplane.CompanyNameModel.ToLower().Contains(SearchBoxText2.ToLower()) ||
                        airplane.TypeOfPlaneModel.ToLower().Contains(SearchBoxText2.ToLower()))
                        .ToList();

                    return new ObservableCollection<AirPlane>(list2);
                }

                return airplaneList_;

            }
        }

        //Selected Airplane
        public AirPlane SelectedAirPlane { get; set; }




        //Command to display name to the screen
        public ICommand AddButtonClicked
        {
            get
            {
                return new DelegateCommand(DisplayName);
            }
        }

        public void DisplayName()
        {
            person_ = new Person(aidi_, NameX, AgeX, ProfessionX);
            String personStr = person_.Sentence;
            personList_.Add(person_);

            aidi_++;

            //Resseting values
            NameX = "";
            AgeX = 0;
            ProfessionX = "";

        }

        //Command to display airplane to the screen
        public ICommand AddButton2Clicked
        {
            get
            {
                return new DelegateCommand(DisplayAirp);
            }
        }

        public void DisplayAirp()
        {
            if(CompanyName == "" || TypeOfPlanes == "" || NumOfPlanes == 0)
            {
                MessageDialog msgDialog = new MessageDialog("Please fill all fields");
                msgDialog.ShowAsync();
            }
            airplane_ = new AirPlane(aidi2_, CompanyName, NumOfPlanes, TypeOfPlanes);
            String personStr = airplane_.Sentence;
            AirPlaneList.Add(airplane_);

            aidi2_++;

            //Resseting values
            CompanyName = "";
            NumOfPlanes = 0;
            TypeOfPlanes = "";

        }


        //Command to delete a person
        public ICommand DeleteButtonClicked
        {
            get
            {
                return new DelegateCommand(DeletePerson);
            }
        }

        public void DeletePerson()
        {

            if (SelectedPerson != null)
            {
                PersonList.Remove(SelectedPerson);
                personList_.Remove(SelectedPerson);
            }
        }

        //Command to delete an airplane
        public ICommand DeleteButton2Clicked
        {

            get
            {
                return new DelegateCommand(DeleteAirp);
            }
        }

        public void DeleteAirp()
        {

            if (SelectedAirPlane != null)
            {
                airplaneList_.Remove(SelectedAirPlane);
                AirPlaneList.Remove(SelectedAirPlane);
            }
        }

        //Command to edit a customer
        public ICommand EditButtonClicked
        {
            get
            {
                return new DelegateCommand(EditPerson);
            }
        }

        public void EditPerson()
        {
            if (SelectedPerson != null)
            {
                NameX = SelectedPerson.Name;
                AgeX = SelectedPerson.Age;
                ProfessionX = SelectedPerson.Proffesions;

            }
        }

        //Command to update a customer
        public ICommand SaveButtonClicked
        {
            get
            {
                return new DelegateCommand(UpdatePerson);
            }
        }

        public void UpdatePerson()
        {
            int oldID = SelectedPerson.ID;

            if (SelectedPerson != null)
            {
                personList_.Remove(SelectedPerson);

            }

            person_ = new Person(oldID, NameX, AgeX, ProfessionX);
            personList_.Add(person_);
            aidi_++;

            //Resseting values
            NameX = "";
            AgeX = 0;
            ProfessionX = "";
        }


        //Command to edit an airplane
        public ICommand EditButton2Clicked
        {
            get
            {
                return new DelegateCommand(EditAirp);
            }
        }

        public void EditAirp()
        {
            if (SelectedAirPlane != null)
            {
                CompanyName = SelectedAirPlane.CompanyNameModel;
                TypeOfPlanes = SelectedAirPlane.TypeOfPlaneModel;
                NumOfPlanes = SelectedAirPlane.NumOfPlanesModel;

            }
        }

        //Command to update an airplane
        public ICommand SaveButton2Clicked
        {
            get
            {
                return new DelegateCommand(UpdateAirp);
            }
        }

        public void UpdateAirp()
        {
            int oldID = SelectedAirPlane.iD;

            if (SelectedAirPlane != null)
            {
                airplaneList_.Remove(SelectedAirPlane);

            }

            airplane_ = new AirPlane(oldID, CompanyName, NumOfPlanes, TypeOfPlanes);
            String personStr = airplane_.Sentence;
            AirPlaneList.Add(airplane_);

            aidi_++;

            //Resseting values
            CompanyName = "";
            NumOfPlanes = 0;
            TypeOfPlanes = "";
        }
    }
}
