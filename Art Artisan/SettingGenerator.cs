using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Specialized;
using System.Drawing;
using System.Resources;

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

            ResourceManager rm = Properties.Resources.ResourceManager;
            Bitmap myImage = (Bitmap)rm.GetObject(setting);

            //string imagedirectory = @"./images\";

            //  imagedirectory = imagedirectory + setting + ".jpg";

            //    return Image.FromFile(imagedirectory);

            return myImage;
            
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
