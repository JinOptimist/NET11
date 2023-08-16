﻿using BusinessLayerInterfaces.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayerInterfaces.UserServices
{
    public interface ICarServices
    {
        IEnumerable<CarBlm> GetAll();

        void Save(CarBlm model);

        void Remove(int id);
    }
}