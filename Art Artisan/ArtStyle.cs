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


        string[] stringSeparators = new string[] { "\r\n" };


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

            var inputStyle = Properties.Resources.style;


            string[] output = inputStyle.Split(stringSeparators, StringSplitOptions.None);

            sStyle.AddRange(output);

            Random intrand = new Random(Guid.NewGuid().GetHashCode());

            int index = intrand.Next(0, output.GetLength(0));
            style = sStyle[index];


        }






    }
}
