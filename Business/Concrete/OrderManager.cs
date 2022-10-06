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
            if (order.Brand.Length < 2)
            {
                return new ErrorResult(Messages.AddedError);
            }
            _orderDal.Add(order);
            return new SuccessResult(Messages.AddedSuccess);
        }

        public IResult Delete(Order order)
        {
            _orderDal.Delete(order);
            return new SuccessResult("Başarıyla silindi");

        }

        public IDataResult<Order> Get(Guid id)
        
        {
            var data = _orderDal.Get(o=>o.ID == id);
            if(data==null){
                return new ErrorDataResult<Order>(data,"Order bulunamadı!");
            }
            
            return new SuccessDataResult<Order>(data);
        }

        public IDataResult<List<Order>> GetAll()
        {
            var res = new DataResult<List<Order>>(_orderDal.GetAll(),true,"Order listeleme işlemi başarılı");
            return res;
        }

        public IResult Update(Order order)
        {
            _orderDal.Update(order);
            return new SuccessResult("Güncelleme başarılı");
        }
    }
}