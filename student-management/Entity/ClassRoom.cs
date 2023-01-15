using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStudentManagement.Entity
{
    public class ClassRoom
    {
        public string MaLop { get; set; }
        public string TenLop { get; set; }
        public string GiangVienCoVan { get; set; }
        public Dictionary<string, Student> Students
        {
            get;set;
        }
        public ClassRoom()
        {
            Students = new Dictionary<string, Student>();
        }
        public override string ToString()
        {
            return TenLop;
        }
        public Faculty KhoaChuQuan { get; set; }
    }
}
