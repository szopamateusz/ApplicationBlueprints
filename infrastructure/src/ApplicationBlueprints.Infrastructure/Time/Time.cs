using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationBlueprints.Infrastructure.Time
{
    public interface ITime
    {
        DateTime Now { get; }
        DateTime UtcToday { get; }
        DateTime UtcNow { get; }
    }
   
    public class Time : ITime
    {
        public DateTime Now => DateTime.Now;
        public DateTime UtcToday => DateTime.UtcNow.Date;
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
