using SignalR.DataAccess.Abstract;
using SignalR.DataAccess.Concrete;
using SignalR.DataAccess.Repositories;
using SignalR.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccess.EntityFramework
{
    public class EfContentDal : GenericRepository<Contact>, IContactDal
    {
        public EfContentDal(SignalRContext context) : base(context)
        {
        }
    }
}
