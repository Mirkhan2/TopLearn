using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopLearn.DataLayeer.Entities.Order;

namespace TopLearn.Core.Services.Interfaces
{
    public interface IOrderService
    {
        int AddOrder(string userName, int courseId);
        void UpdatePriceOrder(int OrderId);
      
        Order GetOrderForUserPanel(string userName, int orderId);
        bool FinalyOrder(string userName,int OrderId);
    }
}
