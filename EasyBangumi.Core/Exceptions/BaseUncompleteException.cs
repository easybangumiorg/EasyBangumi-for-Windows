using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBangumi.Core.Exceptions;
public class BaseUncompleteException : Exception
{
    public ExceptionType Reason
    {
        get;
    }

    public BaseUncompleteException(ExceptionType reason)
    : base(reason.ToString())
    {
        Reason = reason;
    }

    public BaseUncompleteException(ExceptionType reason, Exception ex)
        : base(reason.ToString(), ex)
    {
        Reason = reason;
    }
}
