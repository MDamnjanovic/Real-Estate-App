using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Realty.Data.ContainerConfig;

namespace Realty.Business
{
    public abstract class BaseBsn
    {
        public IContainer Container
        {
            get
            {
                return ContainerConfig.Configure();
            }
        }

        public int IntTryParse(string value)
        {
            bool parsable = int.TryParse(value, out int intValue);
            if (parsable)
            {
                return intValue;
            }
            else
            {
                return -1;
            }
        }
        public double DoubleTryParse(string value)
        {
            bool parsable = double.TryParse(value, out double doubleValue);
            if (parsable)
            {
                return doubleValue;
            }
            else
            {
                return -1;
            }
        }
        public short ShortTryParse(string value)
        {
            bool parsable = short.TryParse(value, out short shortValue);
            if (parsable)
            {
                return shortValue;
            }
            else
            {
                return -1;
            }
        }
        public decimal DecimalTryParse(string value)
        {
            bool parsable = decimal.TryParse(value, out decimal decimalValue);
            if (parsable)
            {
                return decimalValue;
            }
            else
            {
                return -1;
            }
        }
    }
}
