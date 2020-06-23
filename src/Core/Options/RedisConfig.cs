using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetDistributedCaching.Infrastructure.Core.Options
{
    public class RedisConfig
    {
        public string Configuration { get; set; }
        public string InstanceName { get; set; }
    }
}
