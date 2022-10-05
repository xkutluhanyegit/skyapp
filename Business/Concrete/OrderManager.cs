using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constant;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }
        public IResult Add(Order order)
        {
            //Business code
            _orderDal.Add(order);
            return new SuccessResult(Messages.AddedSuccess);
        }

        public IResult Delete(Order order)
        {
            //Business code
            _orderDal.Delete(order);
            return new SuccessResult(Messages.AddedSuccess);

        }

        public Order Get(Guid id)
        {
            return _orderDal.Get(c=>c.ID == id);
        }

        public List<Order> GetAll()
        {
            
            return _orderDal.GetAll();
        }

        public IResult Update(Order order)
        {
            //Business code
             _orderDal.Update(order);
             return new SuccessResult(Messages.AddedSuccess);
        }
    }
}