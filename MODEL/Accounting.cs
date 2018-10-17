using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Accounting
    {
        public int AccountingID { get; set; }
        public string AccountingName { get; set; }
        public DateTime AccountingTime { get; set; }
        public decimal AccountingCost { get; set; }
        public int MemberID { get; set; }
    }
}
