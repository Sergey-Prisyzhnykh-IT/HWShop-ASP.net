namespace HW2OnlineShop.Time
{
    public class RealTime : IRealTime
    {
        public DateTime GetRealTime()
        {
            return DateTime.Now;
        }
    }
}
