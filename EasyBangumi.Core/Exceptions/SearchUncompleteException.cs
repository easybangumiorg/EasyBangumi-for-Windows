using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBangumi.Core.Exceptions;
public class SearchUncompleteException : BaseUncompleteException
{
    public SearchUncompleteException(ExceptionType reason) : base(reason) { }
    public SearchUncompleteException(ExceptionType reason, Exception ex) : base(reason, ex) { }
}
