﻿namespace DataAccess.Models
{
    public class DataModel : IDisposable
    {
        public int Id { get; set; }
        public int Tree_Id { get; set; }
        public string? Data { get; set; }
        public int? Type { get; set; }

        public void Dispose()
        {

        }
    }
}
