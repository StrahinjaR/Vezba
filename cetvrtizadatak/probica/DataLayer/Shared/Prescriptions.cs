using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Shared
{
    public class Prescriptions
    {
        public int Id {  get; set; }
        public String PatientName { get; set; }
        public String Prescribed { get; set; }
        public DateTime PrescrpitonDate { get; set; }
        public decimal Price { get; set; }

    }
}
