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
                new Citizen() { Identifier = "44166763930", FirstName = "João", LastName = "Domingues", Fee = 100, Tax = 7, Zone = "Rural", Kind = "Casa",KindOfFee = "ITR",
                    Address = new Address(){ Street = "Estrada do Limoeiro", City = "Bom Destino", Number = 32, PostalCode = 93311333, State = "São Paulo" } },

                new Citizen() { Identifier = "44166763933", FirstName = "Leonardo", LastName = "Da Silva", Fee = 100, Tax = 20, Zone = "Cidade",Kind = "Apto",KindOfFee = "IPTU",
                 Address = new Address(){ Street = "Av Nossa Senhora", City = "Bom Destino", Number = 430, PostalCode = 93321332, State = "São Paulo" } },

                new Citizen() { Identifier = "44166763932", FirstName = "Maria", LastName = "do Rosario", Fee = 100, Tax = 10, Zone = "Desconhecido",Kind = "Casa",KindOfFee = "ITR",
                 Address = new Address(){ Street = "Av das Açucenas", City = "Bom Destino", Number = 554, PostalCode = 93321434, State = "São Paulo" }},

                new Citizen() { Identifier = "44166763931", FirstName = "José", LastName = "Manoel", Fee = 100, Tax = 10, Zone = "Cidade",Kind = "Casa",KindOfFee = "IPTU",
                 Address = new Address(){ Street = "Rua Aparecido de Oliveira", City = "Bom Destino", Number = 55, PostalCode = 93321432, State = "São Paulo" }},
            };
        }

        public Citizen GetByIdentifier(string identifier)
        {
            return Citizens.FirstOrDefault(x => x.Identifier == identifier);
        }
    }
}
