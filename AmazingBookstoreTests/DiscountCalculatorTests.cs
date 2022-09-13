using AmazingBookstore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AmazingBookstoreTests;

[TestClass]
public class DiscountCalculatorTests
{
    [TestMethod, Ignore]
    public void GivenMoney_WhenGivenDiscount_ThenDiscountIsApplied()
    {
        var money = new Money(100, 0);
        var calculator = new DiscountCalculator();
        Assert.AreEqual(new Money(90, 0), calculator.Apply(money, 10));
    }
}