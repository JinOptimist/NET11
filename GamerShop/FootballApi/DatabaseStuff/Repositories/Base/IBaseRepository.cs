﻿using ChatApi.DatabaseStuff.Models;

namespace FootballApi.Repositories
{
    public interface IBaseRepository<DbModel> where DbModel : BaseModel
    {
		DbModel Get(int id);

		IEnumerable<DbModel> GetAll();

        void Save(DbModel model);

        void Remove(int id);

		void Update(DbModel model);

		int Count();

        void SaveRange(IEnumerable<DbModel> models);

        DbModel GetLast();

        bool Any();
    }
}
