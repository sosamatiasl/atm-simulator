using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Simulator_WPF.Model
{
    public class CuentaModel
    {
        public int ID { get; set; }
        public string NumeroCuenta { get; set; } = string.Empty;
        public string PIN { get; set; } = string.Empty;
        public decimal Saldo { get; set; }
    }
}
