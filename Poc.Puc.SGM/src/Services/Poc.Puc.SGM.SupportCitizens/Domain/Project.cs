using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace Poc.Puc.SGM.SupportCitizens.Domain
{
    public class Project
    {

        public Guid Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; }

        public decimal Budget { get; set; }

        public string Status { get; set; }

        public string RequesterName { get; set; }
        public string RequesterEmail { get; set; }
        public string RequesterPhone { get; set; }

        public IList<History> Histories { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public DateTime UpdateDate { get; set; } = DateTime.Now;

        public void ChangeStatus(string employee, string status)
        {
            if (Histories is null)
            {
                Histories = new List<History>();
            }

            var history = new History() { Employee = employee, Status = status, UpdateDate = DateTime.Now };

            Histories.Add(history);
        }
    }

    public class History
    {
        public string Employee { get; set; }

        public DateTime UpdateDate { get; set; }

        public string Status { get; set; }
    }
}
