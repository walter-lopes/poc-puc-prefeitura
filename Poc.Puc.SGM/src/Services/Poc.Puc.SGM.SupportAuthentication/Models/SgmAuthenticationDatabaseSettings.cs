using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppAuthenticationSGM.Models
{
    public class SgmAuthenticationDatabaseSettings : ISgmAuthenticationDatabaseSettings
    {
        public string SgmCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
    public interface ISgmAuthenticationDatabaseSettings
    {
        string SgmCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
