using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetDistributedCaching.Infrastructure.Core.Options
{
    public class AppConfig
    {
        public MongoOptions Mongo { get; set; } 
        public RedisConfig Redis { get; set; }
    }
}
