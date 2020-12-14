namespace SGM_MVC.Models.Cidadao
{
    public class Property
    {
        public string Kind { get; set; }
        public string KindOfFee { get; set; }
        public decimal FeeValue { get; set; }
        public string Zone { get; set; }
        public Address Address { get; set; }
    }
}