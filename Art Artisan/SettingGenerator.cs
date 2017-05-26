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
        ResourceManager rm = Properties.Resources.ResourceManager;
        string[] stringSeparators = new string[] { "\r\n" };


        public SettingGenerator()
        {
            createrandomSetting();
            getStyleImage();





        }


        public void createrandomSetting()
        {

            var settings = Properties.Resources.setting;

          
            string[] output = settings.Split(stringSeparators, StringSplitOptions.None);
            StringCollection sSetting = new StringCollection();

        


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


            Bitmap myImage = (Bitmap)rm.GetObject(setting);


            return myImage;
            
        }
        //used for the load function. 
        public Image getStyleImage(string name)
        {

 
            Bitmap myImage = (Bitmap)rm.GetObject(setting);


            return myImage;



        }
    }


}
