using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStudentManagement.Entity
{
    public class Student
    {
        public string MaSo { get; set; }
        public string HoTen { get; set; }
        public DateTime NamSinh { get; set; }
        public bool GioiTinh { get; set; }
        public ClassRoom LopChuQuan { get; set; }
        public override string ToString()
        {
            return HoTen;
        }
    }
}
