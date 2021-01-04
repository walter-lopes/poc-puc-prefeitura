using SGM_MVC.Models.Servidor;
using System;

namespace SGM_MVC.Models.Servico
{
    public class Histories
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public string UpdateDate { get; set; }
        public string EmployeeMail { get; set; }
        public string Employee { get; set; }
    }
}