using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Art_Artisan.Tests
{
    [TestClass()]
    public class SettingGeneratorTests
    {


        [TestMethod()]
        public void SettingGeneratorTest()
        {
            SettingGenerator e = new SettingGenerator();
            
            Assert.IsInstanceOfType(e, typeof(SettingGenerator)); //verify that e is an instance of setting generator
            // the default constuctor.
        }

        [TestMethod()]
        public void createrandomSettingTest()
        {
            SettingGenerator e = new SettingGenerator();
            e.createrandomSetting();//changes the string setting property
            Assert.IsInstanceOfType(e.setting, typeof(string)); //verifys that a string is returned from settinggenerator.setting property

        }

        [TestMethod()]
        public void getStyleImageTest()
        {
            SettingGenerator e = new SettingGenerator();
            var a = e.getStyleImage(); // gets the image
            Assert.IsInstanceOfType(a, typeof(System.Drawing.Bitmap)); //checks to made sure that it is indeed an image returned
          
        }
        //for the load function. 
        [TestMethod()]
        public void getStyleImageTest1()
        {
            SettingGenerator e = new SettingGenerator();
            var a = e.getStyleImage("kitchen"); // gets the image
            var b = e.getStyleImage("ogaji"); // test to fail
            Assert.IsInstanceOfType(a, typeof(System.Drawing.Bitmap)); //checks to made sure that it is indeed an image returned
            Assert.IsInstanceOfType(b, typeof(System.Drawing.Bitmap)); // should fail

        }

    }
}