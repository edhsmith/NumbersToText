using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AKQA.Test
{
    [TestClass]
    [TestCategory("Test Number Object")]
    public class TestNumberObject
    {
        [TestMethod]
        public void TestValidDecimalNumberText()
        {            
            var obj = BL.Numbers.Convert<string>("237.45");
            bool pass = obj is null ? false : true;
            Assert.IsTrue(pass);
        }


        [TestMethod]
        public void TestValidWholeNumberText()
        {
            var obj = BL.Numbers.Convert<string>("377");

            bool pass = obj is null ? false : true;
            Assert.IsTrue(pass);

        }

        [TestMethod]
        public void TestInvalidNumberText()
        {
            var obj = BL.Numbers.Convert<string>("345B9");
            bool pass = obj is null ? false : true;
            Assert.IsFalse(pass);
        }

        [TestMethod]
        public void OneHundredNumberToText()
        {
            var obj = BL.Numbers.Convert<string>("100");
            var value = obj.ToString();

            Assert.AreEqual("ONE HUNDRED", value);
        }

        [TestMethod]
        public void WholeHundredNumberToText()
        {
            var obj = BL.Numbers.Convert<string>("377");
            var value = obj.ToString();

            Assert.AreEqual("THREE HUNDRED AND SEVENTY-SEVEN", value);
        }

        [TestMethod]
        public void OneThousandNumberToText()
        {
            var obj = BL.Numbers.Convert<string>("1000");
            var value = obj.ToString();

            Assert.AreEqual("ONE THOUSAND", value);
        }

        [TestMethod]
        public void WholeThousandNumberToText()
        {
            var obj = BL.Numbers.Convert<string>("7725");
            var value = obj.ToString();

            Assert.AreEqual("SEVEN THOUSAND SEVEN HUNDRED AND TWENTY-FIVE", value);
        }


        [TestMethod]
        public void OneHundredThousandNumberToText()
        {
            var obj = BL.Numbers.Convert<string>("100000");
            var value = obj.ToString();

            Assert.AreEqual("ONE HUNDRED THOUSAND", value);
        }

        [TestMethod]
        public void HundredThousandNumberToText()
        {
            var obj = BL.Numbers.Convert<string>("265952");
            var value = obj.ToString();

            Assert.AreEqual("TWO HUNDRED AND SIXTY-FIVE THOUSAND NINE HUNDRED AND FIFTY-TWO", value);
        }


        [TestMethod]
        public void OneMillionNumberToText()
        {
            var obj = BL.Numbers.Convert<string>("1000000");
            var value = obj.ToString();

            Assert.AreEqual("ONE MILLION", value);
        }


        [TestMethod]
        public void MillionNumberToText()
        {
            var obj = BL.Numbers.Convert<string>("1275490");
            var value = obj.ToString();

            Assert.AreEqual("ONE MILLION TWO HUNDRED AND SEVENTY-FIVE THOUSAND FOUR HUNDRED AND NINETY", value);
        }

        [TestMethod]
        public void TeenNumberToText()
        {
            var obj = BL.Numbers.Convert<string>("17");
            var value = obj.ToString();

            Assert.AreEqual("SEVENTEEN", value);
        }

        [TestMethod]
        public void MoreThanTeenNumberToText()
        {
            var obj = BL.Numbers.Convert<string>("31");
            var value = obj.ToString();

            Assert.AreEqual("THIRTY-ONE", value);
        }
    }
}
