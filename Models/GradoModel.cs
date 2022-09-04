using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteDemo.Models
{
    public class GradoModel
    {
        [PrimaryKey, AutoIncrement]
        public int GradoID { get; set; }
        public string Descripcion { get; set; }
      
    }
}

