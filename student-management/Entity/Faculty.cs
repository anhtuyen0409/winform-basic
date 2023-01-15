using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStudentManagement.Entity
{
    
    public class Faculty
    {
        public string MaKhoa { get; set; }
        public string TenKhoa { get; set; }
        public Dictionary<string,ClassRoom> Lops
        {
            get;set;
        }
        public Faculty()
        {
            Lops = new Dictionary<string, ClassRoom>();
        }
        public override string ToString()
        {
            return TenKhoa;
        }
    }
}
