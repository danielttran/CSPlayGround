﻿namespace DataAccess.DbAccess
{
    public interface ISqliteDataAccess
    {
        Task<IEnumerable<T>> LoadData<T, U>(string query, U parameters);
        Task SaveData<T>(string query, T parameters);
    }
}