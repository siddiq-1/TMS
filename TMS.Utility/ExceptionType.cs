using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Utility
{
    public enum ExceptionType
    {
        // Default status code for unknown exceptions
        InternalServerError = 500, 

        // System exceptions
        ArgumentException = 400,
        ArgumentNullException = 400,
        ArgumentOutOfRangeException = 400,
        FormatException = 400,
        InvalidCastException = 400,
        InvalidOperationException = 400,
        NotImplementedException = 501,
        NullReferenceException = 500,
        OutOfMemoryException = 500,
        OverflowException = 500,
        StackOverflowException = 500,
        TimeoutException = 408,
        UnauthorizedAccessException = 403,

        // IO exceptions
        FileNotFoundException = 404,

        // Collection exceptions
        KeyNotFoundException = 404,
        IndexOutOfRangeException = 400,

        // Arithmetic exceptions
        DivideByZeroException = 400,
    }
}
