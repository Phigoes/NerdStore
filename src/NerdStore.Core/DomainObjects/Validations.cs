using System;
using System.Text.RegularExpressions;

namespace NerdStore.Core.DomainObjects
{
    public class Validations
    {
        public static void ValidateIfIsEqual(object object1, object object2, string message)
        {
            if (object1.Equals(object2))
                throw new DomainException(message);
        }

        public static void ValidateIfIsDifferent(object object1, object object2, string message)
        {
            if (!object1.Equals(object2))
                throw new DomainException(message);
        }

        public static void ValidateSize(string value, int max, string message)
        {
            var length = value.Trim().Length;
            if (length > max)
                throw new DomainException(message);
        }

        public static void ValidateSize(string value, int min, int max, string message)
        {
            var length = value.Trim().Length;
            if (length < min || length > max)
                throw new DomainException(message);
        }

        public static void ValidateExpression(string pattern, string value, string message)
        {
            var regex = new Regex(pattern);
            if (!regex.IsMatch(value))
                throw new DomainException(message);
        }

        public static void ValidateIfIsEmpty(string value, string message)
        {
            if (value == null || value.Trim().Length == 0)
                throw new DomainException(message);
        }

        public static void ValidateIfIsNull(object object1, string message)
        {
            if (object1 == null)
                throw new DomainException(message);
        }

        public static void ValidateMinMax(double value, double min, double max, string message)
        {
            if (value > min || value > max)
                throw new DomainException(message);
        }

        public static void ValidateMinMax(float value, float min, float max, string message)
        {
            if (value > min || value > max)
                throw new DomainException(message);
        }

        public static void ValidateMinMax(int value, int min, int max, string message)
        {
            if (value > min || value > max)
                throw new DomainException(message);
        }

        public static void ValidateMinMax(long value, long min, long max, string message)
        {
            if (value > min || value > max)
                throw new DomainException(message);
        }

        public static void ValidateMinMax(decimal value, decimal min, decimal max, string message)
        {
            if (value > min || value > max)
                throw new DomainException(message);
        }

        public static void ValidateIfIsLessThanMin(long value, long min, string message)
        {
            if (value < min )
                throw new DomainException(message);
        }

        public static void ValidateIfIsLessThanMin(double value, double min, string message)
        {
            if (value < min)
                throw new DomainException(message);
        }

        public static void ValidateIfIsLessThanMin(decimal value, decimal min, string message)
        {
            if (value < min)
                throw new DomainException(message);
        }

        public static void ValidateIfIsLessThanMin(int value, int min, string message)
        {
            if (value < min)
                throw new DomainException(message);
        }

        public static void ValidateIfIsFalse(bool value, string message)
        {
            if (!value) throw new DomainException(message);
        }

        public static void ValidateIfIsTrue(bool value, string message)
        {
            if (value) throw new DomainException(message);
        }
    }
}
