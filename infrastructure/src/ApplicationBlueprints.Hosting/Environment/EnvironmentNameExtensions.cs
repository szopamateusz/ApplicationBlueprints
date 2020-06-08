using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationBlueprints.Hosting.Environment
{
    public static class EnvironmentNameExtensions
    {
        public static bool IsLocal(this string environmentName)
        {
            return environmentName.Equals(EnvironmentNameConstants.Local, StringComparison.InvariantCultureIgnoreCase);
        }

        public static bool IsDevelopment(this string environmentName)
        {
            return environmentName.Equals(EnvironmentNameConstants.Development, StringComparison.InvariantCultureIgnoreCase);
        }
        public static bool IsTest(this string environmentName)
        {
            return environmentName.Equals(EnvironmentNameConstants.Test, StringComparison.InvariantCultureIgnoreCase);
        }
        public static bool IsUAT(this string environmentName)
        {
            return environmentName.Equals(EnvironmentNameConstants.UAT, StringComparison.InvariantCultureIgnoreCase);
        }
        public static bool IsPreProd(this string environmentName)
        {
            return environmentName.Equals(EnvironmentNameConstants.PreProd, StringComparison.InvariantCultureIgnoreCase);
        }
        public static bool IsProduction(this string environmentName)
        {
            return environmentName.Equals(EnvironmentNameConstants.Production, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
