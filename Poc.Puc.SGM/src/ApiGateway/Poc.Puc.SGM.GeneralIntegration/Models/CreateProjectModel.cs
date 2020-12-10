namespace Poc.Puc.SGM.GeneralIntegration.Models
{
    public class CreateProjectModel
    {
        public string Name { get; set; }

        public decimal Budget { get; set; }

        public string Status { get; set; }

        public string RequesterName { get; set; }
        public string RequesterEmail { get; set; }
        public string RequesterPhone { get; set; }
    }
}
