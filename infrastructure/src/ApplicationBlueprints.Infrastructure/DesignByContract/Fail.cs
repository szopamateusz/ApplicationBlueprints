using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace ApplicationBlueprints.Infrastructure.DesignByContract
{
    public static class Fail
    {
        public static void Always(string message = null, Exception innerException = null)
        {
            throw new DesignByContractException(message, innerException);
        }

        public static void IfNull(object value, string message = null, Exception innerException = null)
        {
            if (value != null)
                return;

            if (string.IsNullOrEmpty(message))
                message = FailMessages.ValueCannotBeNull;

            throw new DesignByContractException(message, innerException);
        }

        public static void IfNullOrEmpty<T>(IEnumerable<T> value, string message = null, Exception innerException = null)
        {
            if (value != null && value.Any())
                return;

            if (string.IsNullOrEmpty(message))
                message = FailMessages.ValueCannotBeNullOrEmpty;

            throw new DesignByContractException(message, innerException);
        }

        public static void IfNotNull(object value, string message = null, Exception innerException = null)
        {
            if (value == null)
                return;

            if (string.IsNullOrEmpty(message))
                message = FailMessages.ValueShouldBeNull;

            throw new DesignByContractException(message, innerException);
        }

        public static void IfNullOrEmpty(string value, string message = null, Exception innerException = null)
        {
            if(!string.IsNullOrEmpty(value))
                return;

            if (string.IsNullOrEmpty(message))
                message = FailMessages.ValueCannotBeNullOrEmpty;

            throw new DesignByContractException(message, innerException);
        }

        public static void If(bool condition, string message = null, Exception innerException = null)
        {
            if (!condition)
                return;

            if (string.IsNullOrEmpty(message))
                message = FailMessages.ValueCannotMeetTheCondition;

            throw new DesignByContractException(message, innerException);
        }

        public static void IfTrue(bool value, string message = null, Exception innerException = null)
        {
            if (!value)
                return;

            if (string.IsNullOrEmpty(message))
                message = FailMessages.ValueCannotBeTrue;

            throw new DesignByContractException(message, innerException);
        }

        public static void IfFalse(bool value, string message = null, Exception innerException = null)
        {
            if (value)
                return;

            if (string.IsNullOrEmpty(message))
                message = FailMessages.ValueCannotBeFalse;

            throw new DesignByContractException(message, innerException);
        }

        public static void IfEqual(object left, object right, string message = null, Exception innerException = null)
        {
            if(!left.Equals(right))
                return;

            if (string.IsNullOrEmpty(message))
                message = FailMessages.ValuesCannotBeEqual;

            throw new DesignByContractException(message, innerException);
        }

        public static void IfNotEqual(object left, object right, string message = null, Exception innerException = null)
        {
            if (left.Equals(right))
                return;

            if (string.IsNullOrEmpty(message))
                message = FailMessages.ValuesShouldBeEqual;

            throw new DesignByContractException(message, innerException);
        }

        public static void IfEnumIsNotDefined(Type enumType, object value, string message = null, Exception innerException = null)
        {
            if(Enum.IsDefined(enumType, value))
                return;

            if (string.IsNullOrEmpty(message))
                message = FailMessages.EnumShouldBeDefined;

            throw new DesignByContractException(message, innerException);
        }

        public static void IfEmpty<T>(IEnumerable<T> value, string message = null, Exception innerException = null)
        {
            if (value.Any())
                return;

            if (string.IsNullOrEmpty(message))
                message = FailMessages.ValueCannotBeEmpty;

            throw new DesignByContractException(message, innerException);
        }
    }
}
