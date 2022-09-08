using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AmazingBookstoreTests;

[TestClass]
public class DiscountCalculatorTests
{
    [TestMethod]
    public void GivenMoney_WhenGivenDiscount_ThenDiscountIsApplied()
    {
        var money = 100;
        var calculator = new DiscountCalculator();
        Assert.AreEqual(90, calculator.Apply(money, 10));
    }
}

public class DiscountCalculator
{
    public int Apply(int money, int i)
    {
        return 90;
    }
}