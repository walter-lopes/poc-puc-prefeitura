using Poc.Puc.SGM.SupportCitizens.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poc.Puc.SGM.SupportCitizens.Services
{
    public class STURService
    {
        private IEnumerable<Citizen> Citizens;

        public STURService()
        {
            Citizens = new List<Citizen>()
            {
                new Citizen() { Identifier = "44166763930", FirstName = "João", LastName = "Silva", Fee = 100, Tax = 10, Zone = "Rural" },
                new Citizen() { Identifier = "44166763933", FirstName = "Leonardo", LastName = "Silva", Fee = 100, Tax = 10, Zone = "Cidade" },
                new Citizen() { Identifier = "44166763932", FirstName = "Maria", LastName = "Silva", Fee = 100, Tax = 10, Zone = "Desconhecido" },
                new Citizen() { Identifier = "44166763931", FirstName = "´José", LastName = "Silva", Fee = 100, Tax = 10, Zone = "Cidade" },
            };
        }

        public Citizen GetByIdentifier(string identifier)
        {
            return Citizens.FirstOrDefault(x => x.Identifier == identifier);
        }
    }
}
