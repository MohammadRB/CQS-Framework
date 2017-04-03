using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQS.Framework.App
{
    public struct CrudResult
    {
        public bool WasSuccessed { get; set; }
        public string Message { get; set; }

        public CrudResult(bool wasSuccessed, string message) 
            : this()
        {
            WasSuccessed = wasSuccessed;
            Message = message;
        }
    }

    public struct CrudResults
    {
        public bool WasSuccessed { get { return Operations.All(o => o.WasSuccessed); } }

        public object Extra { get; set; }

        public IEnumerable<CrudResult> Operations { get; set; }

        public CrudResults(params CrudResult[] operations)
            : this()
        {
            Operations = operations;
        }

        public CrudResults(IEnumerable<CrudResult> operations)
            : this()
        {
            Operations = operations;
        }
    }
}
