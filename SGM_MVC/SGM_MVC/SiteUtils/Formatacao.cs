using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGM_MVC.SiteUtils
{
    public static class Formatacao
    {
        public static string CpfCnpj(int cpfCnpj)
        {                                                                               //##.###.###/####-##
            string sCpfCnpj = cpfCnpj.ToString();
            return cpfCnpj == 11 ? 
                   String.Format("{0}.{1}.{2}-{3}", sCpfCnpj.Substring(0,2), sCpfCnpj.Substring(3, 5), sCpfCnpj.Substring(6, 8), sCpfCnpj.Substring(9, 10)) : 
                   String.Format("{0}.{1}.{2}/{3}-{4}", sCpfCnpj.Substring(0, 1), sCpfCnpj.Substring(2, 4), sCpfCnpj.Substring(5, 7), sCpfCnpj.Substring(8, 11), sCpfCnpj.Substring(12, 13));
        }
    }
}
