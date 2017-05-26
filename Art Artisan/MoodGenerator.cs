using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Specialized;

namespace Art_Artisan
{
    class MoodGenerator
    {

        private string mood = null;
        string[] stringSeparators = new string[] { "\r\n" };



        public MoodGenerator()
        {

            mood = "boring";
            
        }


        public string getsetMood
        {

            get{
                return mood;
            
            }


            set{
                mood = value;
            }



        }

        public void createrandomMood()
        {


            StringCollection moods = new StringCollection();

            var inputMood = Properties.Resources.moods;


            string[] output = inputMood.Split(stringSeparators, StringSplitOptions.None);
      

            moods.AddRange(output);

            Random intrand = new Random(Guid.NewGuid().GetHashCode());

            int index = intrand.Next(0, output.GetLength(0));
            mood = moods[index];

            
        }
        
    }
}
