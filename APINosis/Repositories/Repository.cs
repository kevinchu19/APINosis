using APINosis.Entities;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APINosis.Repositories
{
    public class Repository
    {

        public ApiNosisContext Context { get; }
        public IConfiguration Configuration { get; }
        public ILogger Logger { get; }

        public Repository(ApiNosisContext context, IConfiguration configuration, Serilog.ILogger logger)
        {
            Context = context;
            Configuration = configuration;
            Logger = logger;
        }

    }
}
