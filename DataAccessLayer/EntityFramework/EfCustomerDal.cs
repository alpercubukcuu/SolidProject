using DataAccessLayer.Abstract;
using DataAccessLayer.Concretes;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.EntityFramework
{
    public class EfCustomerDal : GenericRepository<Customer>, ICustomerDal
    {
        public List<Customer> GetCustomerListWithJob()
        {
            using (var c = new Context())
            {
                return c.Customers.Include(p => p.Job).ToList();
            }
        }
    }
}
