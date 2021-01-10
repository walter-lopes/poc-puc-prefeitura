using System;
using System.Collections.Generic;

namespace Poc.Puc.SGM.GeneralIntegration.Models
{
    public class CreateProjectModel
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public decimal Budget { get; set; }

        public string Status { get; set; }

        public string RequesterName { get; set; }
        public string RequesterEmail { get; set; }
        public string RequesterPhone { get; set; }

        public IList<History> Histories { get; set; }

        public DateTime Date { get; set; } 

        public DateTime UpdateDate { get; set; } 


        public string Codigo { get; set; }
    }
    public class History
    {
        public string Employee { get; set; }

        public DateTime UpdateDate { get; set; }

        public string Status { get; set; }
    }
}
