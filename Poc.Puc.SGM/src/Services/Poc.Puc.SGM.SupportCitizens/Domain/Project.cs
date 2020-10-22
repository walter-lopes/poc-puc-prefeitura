using System;

namespace Poc.Puc.SGM.SupportCitizens.Domain
{
    public class Project
    {
        public string Name { get; set; }

        public decimal Budget { get; set; }

        public string Status { get; set; }

        public Employee Responsible { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }
    }
}
