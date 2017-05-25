using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Specialized;

namespace Art_Artisan
{
    public class CanvasSize
    {

        public string size
        {
            get; set;
        } = "small";
        public CanvasSize()
        {
            

        }




        public void createrandomCanvas()
        {


            StringCollection scanvas = new StringCollection();
            File_Reader filecanvas = new File_Reader("canvas.txt");
            string[] output = filecanvas.text;


            scanvas.AddRange(output);

            Random intrand = new Random(Guid.NewGuid().GetHashCode());

            int index = intrand.Next(0, output.GetLength(0));
            size = scanvas[index];
            

        }






    }
}
