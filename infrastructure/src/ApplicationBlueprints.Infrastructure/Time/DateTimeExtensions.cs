using System;

namespace ApplicationBlueprints.Infrastructure.Time
{
    public static class DateTimeExtensions
    {
        public static DateTime AssumeUtc(this DateTime dateTime)
        {
            return new DateTime(
                dateTime.Year,
                dateTime.Month,
                dateTime.Day,
                dateTime.Hour,
                dateTime.Minute,
                dateTime.Second,
                dateTime.Millisecond,
                DateTimeKind.Utc);
        }
    }
}
