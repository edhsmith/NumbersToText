using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AKQA.Test
{
    [TestClass]
    [TestCategory("Test NumberStructure Object")]
    public class TestNumberStructure
    {
        [TestMethod]
        public void TestInitialisation()
        {
            var T = BL.NumericalStructure.Initialise();
            if(T == null)
            {
                Assert.Fail("Numerical Initialisation failed");
            }
        }

        [TestMethod]        
        public void TestSampleDataLoad()
        {       
            var T = BL.NumericalStructure.Initialise();
            int[] testNumbers = new int[] {0,1,2,6,8,10,13,17,50,60,100,1000 };
            string[] testText = new string[] { "ZERO", "ONE", "TWO","SIX","EIGHT","TEN", "THIRTEEN", "SEVENTEEN", "FIFTY", "SIXTY", "HUNDRED", "THOUSAND" };

            bool pass = true;
            int count = testNumbers.Length;
            for(int i = 0; i < count; i++)
            {
                if (T.ContainsKey(testText[i]))
                {
                    if (!T[testText[i]].Equals(testNumbers[i]))
                    {
                        pass = false;
                    }
                }
                else
                {
                    pass = false;
                }

            }

            Assert.IsTrue(pass, "Sample Data Test Failed.");

        }
    }
}
