using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBangumi.Core.Exceptions;
internal class CalendarUncompleteException: BaseUncompleteException
{

    public CalendarUncompleteException(ExceptionType reason) : base(reason) { }
    public CalendarUncompleteException(ExceptionType reason, Exception ex) : base(reason, ex) { }
}
