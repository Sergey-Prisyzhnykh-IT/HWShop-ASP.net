namespace HW2OnlineShop.Time
{
    public class RealTime : IRealTime
    {
        public DateTime GetRealTime()
        {
            DateTime dateNow = DateTime.Now;

            return TimeZoneInfo.ConvertTimeToUtc(dateNow);
        }
    }
}
