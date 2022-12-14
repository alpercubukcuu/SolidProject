using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLayer.Abstract
{
    public interface ICustomerService : IGenericService<Customer>
    {
        List<Customer> GetCustomersWithJob();
    }
}
