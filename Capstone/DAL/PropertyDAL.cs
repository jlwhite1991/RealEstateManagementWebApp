using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAL
{
    public class PropertyDAL
    {
        private string connectionString;

        public PropertyDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }
    }
}
