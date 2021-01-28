using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.BusinessLayer.Repository.Abstract;
using UnitOfWork.BusinessLayer.Repository.Concrete;
using UnitOfWork.DataLayer;

namespace UnitOfWork.BusinessLayer.Business
{
    public class ShipperBusiness
    {
        private IRepository<Shipper> _shipperRepository;
        private IUnitOfWork _shipperUnitOfWork;
        private DbContext _dbContext;

        public ShipperBusiness()
        {
            _dbContext = new NorthwindEntities();
            _shipperUnitOfWork = new EFUnitOfWork(_dbContext);
            _shipperRepository = _shipperUnitOfWork.GetRepository<Shipper>();
        }

        public List<Shipper> GetShippers()
        {
            return _shipperRepository.GetAll().ToList();
        }

        public void AddShipper(Shipper _shipper)
        {
            _shipperRepository.Insert(_shipper);
            _shipperUnitOfWork.SaveChanges();
        }

        public void Remove(int id)
        {
            _shipperRepository.Delete(id);
            _shipperUnitOfWork.SaveChanges();
        }

        public void Edit(Shipper _shipper)
        {
            var ship = _shipperRepository.GetById(_shipper.ShipperID);
            ship.Phone = _shipper.Phone;
            ship.CompanyName = _shipper.CompanyName;
            _shipperRepository.Update(ship);
            _shipperUnitOfWork.SaveChanges();
        }

        public Shipper GetShipper(int id)
        {
            return _shipperRepository.Get(ship => ship.ShipperID == id);
        }
    }
}
