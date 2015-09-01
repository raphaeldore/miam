using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Miam.Domain.Entities;

namespace Miam.DataLayer
{
    public interface IApplicationContext : IDisposable
    {
    }
}
