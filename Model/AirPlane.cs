using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMExample.Model
{
    public class AirPlane
    {
        public String CompanyNameModel { get; set; }
        public String TypeOfPlaneModel { get; set; }
        public int NumOfPlanesModel { get; set; }
        public int iD { get; set; }

        
        public AirPlane(int id, String companyName, int numOfPlanes, String typeOfPlane)
        {
            this.iD = id;
            this.CompanyNameModel = companyName;
            this.NumOfPlanesModel = numOfPlanes;
            this.TypeOfPlaneModel = typeOfPlane;
        }

       
        //= new List<AirPlanes>();


        public String Sentence
        {
            get
            {

                return "ID #" + iD +
                    "\nCompany: " + CompanyNameModel + "\nPlanes #: " + NumOfPlanesModel + ", Type: " + TypeOfPlaneModel + "\n";
            }
        }
    }
}
