using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetDistributedCaching.Infrastructure.Core.Options
{
    public class MongoOptions
    {
        public string ConnectionString { get; set; }
        public string Db { get; set; }
        public string Collection { get; set; }
    }
}
