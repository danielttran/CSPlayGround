using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class DataModel
    {
        public int Id { get; set; }
        public byte?[] Data { get; set; }
        public byte?[] Attachment { get; set; }

    }
}
