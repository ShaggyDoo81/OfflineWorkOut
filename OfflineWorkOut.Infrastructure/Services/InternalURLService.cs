using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfflineWorkOut.Infrastructure.Services
{
    public class InternalURLService
    {
        public string GetUrl(string url, params object[] parameters)
        { 
            return string.Format(url, parameters);
        }
    }
}
