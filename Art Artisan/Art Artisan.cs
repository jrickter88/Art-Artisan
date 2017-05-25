using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace Art_Artisan
{
    public partial class Form1 : Form
    {

        
        public Form1()
        {
            InitializeComponent();       
            this.Text = "Art Artisan                                     By Reid Fulton";
            numofcolor = 3;
            
        }




        //private vars
        public bool GenerateUniqueColors
        {
            get;
            set;
        }

        public int numofcolor
        {
            get;
            set;

        }

        public Image settingImage
        {
            get;
            set;

        }

        public List<string> colors
        {
            get;
            set;


        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            UncheckOtherToolStripMenuItems((ToolStripMenuItem)sender);
            this.numofcolor = 3;
        }
        private void FiveColors_Click(object sender, EventArgs e)
        {
            UncheckOtherToolStripMenuItems((ToolStripMenuItem)sender);
            this.numofcolor = 5;
        }
        private void NineColors_Click(object sender, EventArgs e)
        {
            UncheckOtherToolStripMenuItems((ToolStripMenuItem)sender);
            this.numofcolor = 9;
        }

        public void UncheckOtherToolStripMenuItems(ToolStripMenuItem selectedMenuItem)
        {
            selectedMenuItem.Checked = true;

            // Select the other MenuItens from the ParentMenu(OwnerItens) and unchecked this,
            // The current Linq Expression verify if the item is a real ToolStripMenuItem
            // and if the item is a another ToolStripMenuItem to uncheck this.
            foreach (var ltoolStripMenuItem in (from object
                                                    item in selectedMenuItem.Owner.Items
                                                let ltoolStripMenuItem = item as ToolStripMenuItem
                                                where ltoolStripMenuItem != null
                                                where !item.Equals(selectedMenuItem)
                                                select ltoolStripMenuItem))
                (ltoolStripMenuItem).Checked = false;

            // This line is optional, for show the mainMenu after click
            selectedMenuItem.Owner.Show();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {

            //clears previous colors for next button click
            tbColorNumber1.Text = string.Empty;
            tbColorNumber2.Text = string.Empty;
            tbColorNumber3.Text = string.Empty;
            tbColorNumber4.Text = string.Empty;
            tbColorNumber5.Text = string.Empty;
            tbColorNumber6.Text = string.Empty;
            tbColorNumber7.Text = string.Empty;
            tbColorNumber8.Text = string.Empty;
            tbColorNumber9.Text = string.Empty;
            tbColor1.BackColor = SystemColors.Control;
            tbColor2.BackColor = SystemColors.Control;
            tbColor3.BackColor = SystemColors.Control;
            tbColor4.BackColor = SystemColors.Control;
            tbColor5.BackColor = SystemColors.Control;
            tbColor6.BackColor = SystemColors.Control;
            tbColor7.BackColor = SystemColors.Control;
            tbColor8.BackColor = SystemColors.Control;
            tbColor9.BackColor = SystemColors.Control;

            RandomColorGenerator ColorGen = new RandomColorGenerator(GenerateUniqueColors);
          //  List<string> colors = new List<string>();
            //Use something better for this...

            ColorGen.NumberofColors = numofcolor;

            



            //By now we already know how many we need.
            colors = ColorGen.randomizer();
            int i=1;
            for(i=1;i<=ColorGen.NumberofColors;i++)
            {
                TextBox numberBox = this.Controls.Find("tbColorNumber" + i.ToString(), true).FirstOrDefault() as TextBox;
                numberBox.Text = colors[i - 1];

                TextBox colorBox = this.Controls.Find("tbColor" + i.ToString(), true).FirstOrDefault() as TextBox;
                colorBox.BackColor = System.Drawing.ColorTranslator.FromHtml(colors[i - 1]);
            }

        }    


        private void button2_Click(object sender, EventArgs e)
        {


            MoodGenerator moodsbox = new MoodGenerator();

            moodsbox.createrandomMood();
            moodTextBox.Text = moodsbox.getsetMood;





        }

        private void generateMediumButton_Click(object sender, EventArgs e)
        {

            MediumGenerator MediumBox = new MediumGenerator();

            MediumBox.createrandomMedium();
            MediumTextBox.Text = MediumBox.getsetMood;
            
        }

        private void uniqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.GenerateUniqueColors = Convert.ToBoolean(uniqueToolStripMenuItem.CheckState);

        }

        private void generateCanvasButton_Click(object sender, EventArgs e)
        {
            CanvasSize canvasbox = new CanvasSize();

            canvasbox.createrandomCanvas();
            CanvasTextBox.Text = canvasbox.size;



        }

        private void generateStyleButton_Click(object sender, EventArgs e)
        {

            ArtStyle artbox = new ArtStyle();

            artbox.createrandomStyle();
            styleTextBox.Text = artbox.style;



        }

        private void generateSettingButtom_Click(object sender, EventArgs e)
        {

            SettingGenerator settingbox = new SettingGenerator();
            settingbox.createrandomSetting();
            settingTextBox.Text = settingbox.setting;


            settingImage = settingbox.getStyleImage();
            settingPictureBox.Image = settingImage;
            settingPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;



        }

        private void generateAllButton_Click(object sender, EventArgs e)
        {

            generateSettingButtom_Click(sender, e);
            generateStyleButton_Click(sender, e);
            generateCanvasButton_Click(sender, e);
            generateMediumButton_Click(sender, e);
            button2_Click(sender, e);
            button1_Click(sender, e);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
        //C:\c#\Art Artisan\saves



            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    StreamWriter output = new StreamWriter(myStream);
                    string combined = null;
                    for(int i = 0; i < numofcolor; i++)
                    {

                        combined += colors[i] + "/n"; 
                        
                    }



                    combined += "END" + "/n"; //to seperate the colors from the rest, because we don't know how many colors until we load
                    

                    combined += moodTextBox.Text+ "/n"; 

  

                    combined += MediumTextBox.Text+ "/n"; 



                    combined += CanvasTextBox.Text + "/n";

    

                    combined += styleTextBox.Text + "/n";



                    combined += settingTextBox.Text + "/n";


                    testingbox.Text = combined;

                    string encryptedstring = EncryptStringSample.StringCipher.Encrypt(combined, "yolo");

                    output.WriteLine(encryptedstring);


                    // Code to write the stream goes here.
                    output.Close();
                    myStream.Close();
                }
            }



        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream mystream;

            

            OpenFileDialog openfiledialog1 = new OpenFileDialog();
            openfiledialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openfiledialog1.FilterIndex = 2;
            openfiledialog1.RestoreDirectory = true;


            if (openfiledialog1.ShowDialog() == DialogResult.OK)
            {
                if ((mystream = openfiledialog1.OpenFile()) != null)
                {

                    StreamReader input = new StreamReader(mystream);

                    string temp = null;

            

                    temp = input.ReadToEnd();






                    string decrypted = EncryptStringSample.StringCipher.Decrypt(temp, "yolo");

                    string[] tokens = decrypted.Split(new[] { "/n" }, StringSplitOptions.None);

                    testingbox.Text = Convert.ToString(tokens.Length);



                    //find out length of list to initialize
                    colors = new List<string>();

                    //reset iterator
                    int i = 1;
                    while (tokens[i - 1] != "END")
                    {
                        tbColorNumber1.Text = tokens[i - 1];
                        TextBox numberBox = this.Controls.Find("tbColorNumber" + i.ToString(), true).FirstOrDefault() as TextBox;
                        numberBox.Text = tokens[i - 1];

                        TextBox colorBox = this.Controls.Find("tbColor" + i.ToString(), true).FirstOrDefault() as TextBox;
                        colorBox.BackColor = System.Drawing.ColorTranslator.FromHtml(tokens[i - 1]);
                        i++;

                    }
                     //to skip the "END" seperator
                
                    moodTextBox.Text = tokens[i];
                    i++;

                    // combined += moodTextBox.Text + "/n";
                    MediumTextBox.Text = tokens[i];
                    i++;


                    //  combined += MediumTextBox.Text + "/n";
                    CanvasTextBox.Text = tokens[i];
                    i++;


                    //   combined += CanvasTextBox.Text + "/n";
                    styleTextBox.Text = tokens[i];
                    i++;

                    //   combined += styleTextBox.Text + "/n";
                    settingTextBox.Text = tokens[i];
                    i++;


                    //   combined += settingTextBox.Text + "/n";

                    SettingGenerator settingbox = new SettingGenerator();
                    settingImage = settingbox.getStyleImage(settingTextBox.Text);
                    settingPictureBox.Image = settingImage;
                    settingPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;





                    input.Close();
                    mystream.Close();
                }
            }



      
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.Close();
            

        }
    }
}
