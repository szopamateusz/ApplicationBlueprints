using System;

namespace ApplicationBlueprints.Infrastructure.DesignByContract
{
    public class DesignByContractException : Exception
    {
        public DesignByContractException()
        {
        }

        public DesignByContractException(string message) : base(message)
        {
        }

        public DesignByContractException(string message, Exception innerException): base(message, innerException)
        {
        }
    }
}
