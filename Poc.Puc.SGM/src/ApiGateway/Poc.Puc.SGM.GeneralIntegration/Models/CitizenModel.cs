﻿namespace Poc.Puc.SGM.GeneralIntegration.Models
{
    public class CitizenModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Identifier { get; set; }

        public decimal Tax { get; set; }

        public string Zone { get; set; }

        public decimal Fee { get; set; }

        public string Kind { get; set; }

        public string KindOfFee { get; set; }

        public Address Address { get; set; }
    }

    public class Address
    {
        public int Number { get; set; }
        public string Street { get; set; }
        public int PostalCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
