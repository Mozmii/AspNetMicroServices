using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admins.Foundations.Mapper.Enum.Generic
{
    public class GenericParams
    {
        public string Table_Name { get; set; }
        public string PrimaryKeyColumn { get; set; }
        public int StartFrom { get; set; }
        public int? EndTo { get; set; }
        public string IsExistColumnName { get; set; }
    }
}
