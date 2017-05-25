using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Specialized;

namespace Art_Artisan
{
    class MediumGenerator
    {

        private string medium = "Ink";



        public MediumGenerator()
        {
            
        }

       
        public string getsetMood
        {

            get{
                return medium;
            
            }


            set{
                medium = value;
            }



        }

        public void createrandomMedium()
        {


            StringCollection sMediums = new StringCollection();
            File_Reader fileMedium = new File_Reader("mediums.txt");
            string[] output = fileMedium.text;

            
            sMediums.AddRange(output);

            Random intrand = new Random(Guid.NewGuid().GetHashCode());

            int index = intrand.Next(0, output.GetLength(0));
            medium = sMediums[index];







        }





    }
}
