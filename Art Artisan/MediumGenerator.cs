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
        string[] stringSeparators = new string[] { "\r\n" };



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

            var inputMedium = Properties.Resources.mediums;


            string[] output = inputMedium.Split(stringSeparators, StringSplitOptions.None);
            sMediums.AddRange(output);

            Random intrand = new Random(Guid.NewGuid().GetHashCode());

            int index = intrand.Next(0, output.GetLength(0));
            medium = sMediums[index];
            
        }





    }
}
