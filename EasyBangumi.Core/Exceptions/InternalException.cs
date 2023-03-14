using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBangumi.Core.Exceptions;
internal class InternalException : Exception
{
    public ExceptionType EType
    {
        get;
    }

    public InternalException(Exception ex, ExceptionType exceptionType)
        : base(exceptionType.ToString(), ex)
    {
        EType = exceptionType;
    }
}
