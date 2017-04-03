using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQS.Framework.Command;

namespace CQS.Framework.App
{
    public interface ICrudMessageResolver
    {
        CrudResults ResolveCommandResult(ICommandResult commandResult);
    }
}
