using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab12RelationalDatabases.Data
{
    public class AsyncHotelsDbContext : DbContext
    {
        public AsyncHotelsDbContext(DbContextOptions<AsyncHotelsDbContext> options) : base (options)
        {
            
        }


    }
}
