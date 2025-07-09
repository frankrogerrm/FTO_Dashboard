using Microsoft.VisualStudio.TestTools.UnitTesting;
using ftodashboard.Data;
using ftodashboard.Models;

namespace ftodashboard.Tests
{
    [TestClass]
    public class ShirtTest
    {
        public static string User { get; set; }
        public static LoggingContext Db { get; set; }

        [TestMethod]
        public void IsGetFormattedTaxedPriceReturnsCorrectly()
        {
            Shirt shirt = new()
            {
                Price = 10F,
                Tax = 1.2F
            };

            string taxedPrice = shirt.GetFormattedTaxedPrice();

            Assert.AreEqual("$12.00", taxedPrice);
        }
    }
    //[TestClass]
    //public class ShirtTestFail
    //{
    //    public static string User { get; set; }
    //    public static LoggingContext Db { get; set; }

    //    [TestMethod]
    //    public void IsGetFormattedTaxedPriceReturnsIncorrectly()
    //    {
    //        Shirt shirt = new Shirt
    //        {
    //            Price = 10F,
    //            Tax = 1.2F
    //        };

    //        string taxedPrice = shirt.GetFormattedTaxedPrice();

    //        Assert.AreEqual("$10.00", taxedPrice);
    //    }
    //}
}
