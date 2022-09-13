namespace AmazingBookstore
{
    public class DiscountCalculator
    {
        public object ApplyMoneyDiscount(Money money, Money moneyDiscount)
        {
            return money - moneyDiscount;
        }

        public Money ApplyPercentageDiscount(Money money, int percentDiscount)
        {
            if (percentDiscount == 0) return money;
            
            return money - ((money * percentDiscount) / 100);
        }
    }
}