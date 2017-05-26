using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.IO;

namespace Art_Artisan
{
   public class File_Reader
    {
        

        public File_Reader(string tempfile)
        {

            string directory = @"C:\c#\Art Artisan\Raw Text\";
            string combined = directory + tempfile;
            string errordefault = @"C:\c#\Art Artisan\Raw Text\error.txt";



            if (new FileInfo(combined).Length == 0)
            { text = System.IO.File.ReadAllLines(errordefault); }
            else {
                text = System.IO.File.ReadAllLines(combined);
            }
        
                        
        }

        public string[] text
        {
            get;
            set;

        }
        


    }
}
