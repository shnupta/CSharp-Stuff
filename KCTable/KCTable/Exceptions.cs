using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCTable
{
    public class DataTypeNotSupportedException : Exception
    {
        public DataTypeNotSupportedException(string message = null) : base(message)
        {

        }
    }

    public class KeyNotFoundException : Exception
    {
        public KeyNotFoundException(string message = null) : base(message)
        {

        }

    }
}
