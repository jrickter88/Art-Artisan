using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Specialized;



namespace Art_Artisan
{
    class ArtStyle
    {





        public string style
        {
            get; set;
        } = "small";
        public ArtStyle()
        {


        }

       

        public void createrandomStyle()
        {


            StringCollection sStyle = new StringCollection();
            File_Reader fileStyle = new File_Reader("style.txt");
            string[] output = fileStyle.text;


            sStyle.AddRange(output);

            Random intrand = new Random(Guid.NewGuid().GetHashCode());

            int index = intrand.Next(0, output.GetLength(0));
            style = sStyle[index];


        }






    }
}
