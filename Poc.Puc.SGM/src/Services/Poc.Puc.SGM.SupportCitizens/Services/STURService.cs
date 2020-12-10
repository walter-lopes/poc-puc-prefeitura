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
                new Citizen() { Identifier = "44166763930", FirstName = "João", LastName = "Silva", Fee = 100, Tax = 10, Zone = "Rural", Kind = "Casa",KindOfFee = "ITR",
                    Address = new Address(){ Street = "Av nossa senhora", City = "SP", Number = 1, PostalCode = 0111, State = "Indaiatuba" } },


                new Citizen() { Identifier = "44166763933", FirstName = "Leonardo", LastName = "Silva", Fee = 100, Tax = 10, Zone = "Cidade",Kind = "Apto",KindOfFee = "IPTU",
                 Address = new Address(){ Street = "Av nossa senhora", City = "SP", Number = 1, PostalCode = 0111, State = "São Paulo" } },

                new Citizen() { Identifier = "44166763932", FirstName = "Maria", LastName = "Silva", Fee = 100, Tax = 10, Zone = "Desconhecido",Kind = "Casa",KindOfFee = "ITR",
                 Address = new Address(){ Street = "Av nossa senhora", City = "SP", Number = 1, PostalCode = 0111, State = "Ava" }},

                new Citizen() { Identifier = "44166763931", FirstName = "´José", LastName = "Silva", Fee = 100, Tax = 10, Zone = "Cidade",Kind = "Casa",KindOfFee = "IPTU",
                 Address = new Address(){ Street = "Av nossa senhora", City = "SP", Number = 1, PostalCode = 0111, State = "São Paulo" }},
            };
        }

        public Citizen GetByIdentifier(string identifier)
        {
            return Citizens.FirstOrDefault(x => x.Identifier == identifier);
        }
    }
}
