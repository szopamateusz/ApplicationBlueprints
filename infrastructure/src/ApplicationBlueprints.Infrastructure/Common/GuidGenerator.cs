using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationBlueprints.Infrastructure.Common
{
    public interface IGuidGenerator
    {
        Guid Create();
        Guid CreateEmpty();
    }
    public class GuidGenerator : IGuidGenerator
    {
        public Guid Create()
        {
            return Guid.NewGuid();
        }

        public Guid CreateEmpty()
        {
            return Guid.Empty;
        }
    }
}
