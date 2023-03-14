using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBangumi.Core.Exceptions;
internal class IndexBangumiUncompleteException : BaseUncompleteException
{
    public IndexBangumiUncompleteException(ExceptionType reason) : base(reason) { }
    public IndexBangumiUncompleteException(ExceptionType reason, Exception ex) : base(reason, ex) { }
}
