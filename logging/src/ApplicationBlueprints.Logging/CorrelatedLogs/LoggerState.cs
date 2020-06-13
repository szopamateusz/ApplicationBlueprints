using System.Collections.Generic;
using System.Text;

namespace ApplicationBlueprints.Logging.CorrelatedLogs
{
    internal class LoggerState : Dictionary<string, object>
    {
        public override string ToString()
        {
            var builder = new StringBuilder();
            foreach (var item in this)
                builder.Append($"{item.Key}:{item.Value}");

            return builder.ToString();
        }
    }
}
