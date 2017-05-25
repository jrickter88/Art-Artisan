using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art_Artisan
{
    public class RandomColorGenerator
    {
        public List<string> ColorList
        {
            get;
            set;
        }
        public bool Unique
        {
            get;
            set;
        }
        //public properties

        public int NumberofColors { get; set; }
        public RandomColorGenerator()
        {
            ColorList = new List<string>();
            this.NumberofColors = 3;
        }

        public RandomColorGenerator(bool GenerateUniqueColorList):this()
        {
            Unique = GenerateUniqueColorList;
        }

        public List<string> randomizer()
        {
            ColorList = DoColorStuff(NumberofColors);
            return ColorList; 
        }
        private List<string> DoColorStuff(int number)
        {
            var color = "";
            //var list = new List<string>();
            string hexValue1 ="";
            Random Rcolor = new Random(Guid.NewGuid().GetHashCode());
            int i = 0;
 	        for (i=1;i<=number;i++)
            {
                if (Unique == true)
                {
                    //Get initial color
                    color = String.Format("#{0:X6}", Rcolor.Next(0x1000000));     
                    //Check if it's in the list
                    while (ColorList.Contains(color))
                    {
                        //get a new one if so.
                        color = String.Format("#{0:X6}", Rcolor.Next(0x1000000));    
                    }
                    hexValue1 = color.ToString();
                    ColorList.Add(hexValue1);
                }
                else
                {
                    color = String.Format("#{0:X6}", Rcolor.Next(0x1000000));
                    hexValue1 = color.ToString();
                    ColorList.Add(hexValue1);
                }

            }
            return ColorList;

        }
    }



}

