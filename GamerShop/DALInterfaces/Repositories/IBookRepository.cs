﻿using DALInterfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALInterfaces.Repositories
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAll();
        void Save(Book book);
    }
}