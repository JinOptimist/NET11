using BusinessLayerInterfaces.BusinessModels;
using BusinessLayerInterfaces.UserServices;
using DALInterfaces.Models;
using DALInterfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.UserServices
{
    public class CarServices : ICarServices
    {
        ICarRepository _carRepository;
        CarServices(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public IEnumerable<CarBlm> GetAll()
                =>_carRepository
                .GetAll()
                .Select(car => new CarBlm()
                {
                    Id = car.Id,
                    NameCar = car.NameCar,
                    InfoAboutCar = car.InfoAboutCar
                    
                })
                .ToList();
        
        public void Remove(int id)
        {
            _carRepository.Remove(id);
        }

        public void Save(CarBlm model)
        {
            var dbCar = new Car()
            {
                NameCar = model.NameCar,
                InfoAboutCar= model.InfoAboutCar
            };
            _carRepository.Save(dbCar);
        }
    }
}
