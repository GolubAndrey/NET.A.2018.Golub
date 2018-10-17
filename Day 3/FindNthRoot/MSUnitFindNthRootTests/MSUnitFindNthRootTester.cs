using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using FindNthRoot;

namespace MSUnitFindNthRootTests
{
    [TestClass]
    public class MSUnitFindNthRootTester
    {
        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        const string dataDriver = "System.Data.OleDb";
        const string connectionStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=TestData.xlsx;Extended Properties=\"Excel 12.0 Xml;HDR=YES\";";

        [TestMethod]
        [DataSource(dataDriver, connectionStr, "Shit$", DataAccessMethod.Sequential)]
        public void FindNthRoot_ValidArgumentValues()
        {
            double number = Convert.ToDouble(TestContext.DataRow["number"].ToString());
            double power = Convert.ToDouble(TestContext.DataRow["power"].ToString());
            double accurancy = Convert.ToDouble(TestContext.DataRow["accurancy"].ToString());
            double expectedResult = Convert.ToDouble(TestContext.DataRow["expectedResult"].ToString());
            double result = Root.RootNPower(number, power, accurancy);

            Assert.IsTrue(Math.Abs(expectedResult - result) < 0.1);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FindNthRoot_InvalidNumber()
        {
            Root.RootNPower(-1, 2, 0.01);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FindNthRoot_InvalidPower()
        {
            Root.RootNPower(1, -2, 0.01);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FindNthRoot_InvalidAccurancy()
        {
            Root.RootNPower(1, 2, -0.01);
        }
    }
}
