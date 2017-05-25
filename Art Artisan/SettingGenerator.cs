using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Specialized;
using System.Drawing;

namespace Art_Artisan
{

   
    public class SettingGenerator
    {


        public SettingGenerator()
        {
            createrandomSetting();
            getStyleImage();





        }


        public void createrandomSetting()
        {


            StringCollection sSetting = new StringCollection();
            File_Reader fileSetting = new File_Reader("setting.txt");
            string[] output = fileSetting.text;


            sSetting.AddRange(output);

            Random intrand = new Random(Guid.NewGuid().GetHashCode());

            int index = intrand.Next(0, output.GetLength(0));
            setting = sSetting[index];


        }






        public string setting
        {
            get;
            set;

            

        } = "normal";

        public Image getStyleImage()
        {

            string imagedirectory = @"C:\c#\Art Artisan\Setting Images\";

            imagedirectory = imagedirectory + setting + ".jpg";
            
            return Image.FromFile(imagedirectory);

            
            
        }
        //used for the load function. 
        public Image getStyleImage(string name)
        {

            string imagedirectory = @"C:\c#\Art Artisan\Setting Images\";
            imagedirectory = imagedirectory + name + ".jpg";


            Image picture = Image.FromFile(imagedirectory);

            return picture;



        }
    }


}
