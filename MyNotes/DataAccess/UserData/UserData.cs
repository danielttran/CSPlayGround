﻿using DataAccess.DbAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UserData
{
    public class UserData
    {

        private readonly ISqliteDataAccess _db;

        public UserData()
        {
            _db = new SqliteDataAccess("Data Source=data.db3;");
            
        }

        public Task<IEnumerable<TreeModel>> GetTreeData(int Parent_Id = 0)
        {
            string query = "SELECT * FROM Tree ";
            if (Parent_Id > 0)
            {
                query += "WHERE Parent_Id = @Parent_Id";
            }
            else
            {
                query += "WHERE Parent_Id IS NULL";
            }
            return _db.LoadData<TreeModel, dynamic>(query, new { Parent_Id });
        }

        public Task<IEnumerable<TreeModel>> GetTreeData()
        {
            string query = "SELECT * FROM Tree ORDER BY Parent_Id ASC";
            return _db.LoadData<TreeModel, dynamic>(query, new { });
        }
    }
}