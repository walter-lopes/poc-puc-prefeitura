using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace Poc.Puc.SGM.SupportCitizens.Domain
{
    public class Project
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Budget { get; set; }

        public string Status { get; set; }

        public string Responsible { get; set; }

        public IList<History> Histories { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public void ChangeStatus(string employee, string status)
        {
            Responsible = employee;

            if (Histories is null)
            {
                Histories = new List<History>();
            }

            var history = new History() { EmployeeMail = Responsible, Status = status, UpdateDate = DateTime.Now };

            Histories.Add(history);
        }
    }

    public class History
    {
        public string EmployeeMail { get; set; }

        public DateTime UpdateDate { get; set; }

        public string Status { get; set; }
    }
}
