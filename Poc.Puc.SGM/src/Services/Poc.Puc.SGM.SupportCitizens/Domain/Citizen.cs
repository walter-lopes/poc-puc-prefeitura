namespace Poc.Puc.SGM.SupportCitizens.Domain
{
    public class Citizen
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

        public void CalcTax()
        {
            decimal tax;

            if (Zone is "Rural")
            {
                tax = 20;
            }
            else if (Zone is "Cidade")
            {
                tax = 30;
            }
            else
            {
                tax = 25;
            }

            Tax = tax;
        }
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
