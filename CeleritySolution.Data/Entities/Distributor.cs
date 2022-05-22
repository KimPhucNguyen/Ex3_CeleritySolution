using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeleritySolution.Data.Entities
{
    public class Distributor
    {
        public int Id { get; set; }
        public string DistributorName { get; set; }

        public List<Agreement> Agreements { get; set; }
    }
}
