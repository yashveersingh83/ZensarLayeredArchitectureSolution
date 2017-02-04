using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zensar.Common
{
    public interface ILogger
    {
        void LogException(Exception ex);
        void LogExceptionAsWarning(Exception ex);
        void LogInformation(String message);
    }
}
