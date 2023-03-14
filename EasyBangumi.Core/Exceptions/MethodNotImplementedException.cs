using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBangumi.Core.Exceptions;
public class MethodNotImplementedException : Exception
{
    public MethodNotImplementedException(string method)
        : base($"{method}: Can not use this method.")
    {

    }
}
