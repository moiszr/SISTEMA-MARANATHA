using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio;
using Entidades;

namespace Presentacion.Data
{
    public class Cuotas
    {
        private decimal total;
        private decimal cuotamensual;
        private decimal inicialPago;
        private decimal tasadeinteres = 5;
        private decimal totalinteres;
        private int plazomeses;
        private DateTime fecha = DateTime.Today;

        public Cuotas(decimal total, decimal inicialPago, int plazomeses)
        {
            this.total = total;
            this.inicialPago = inicialPago;
            this.plazomeses = plazomeses;

            Operaciones_cal();
            TablaAmortizada();
        }

        public void Operaciones_cal()
        {
            total = total - inicialPago;
            totalinteres = total * (tasadeinteres / 100);
            cuotamensual = ((plazomeses * totalinteres) + total) / plazomeses;
        }

        public void TablaAmortizada()
        {
            for (int i = 1; i <= plazomeses; i++)
            {
                decimal pagointeres = totalinteres / plazomeses;
                decimal pagocapital = cuotamensual - pagointeres;
                total = total - pagocapital;
                fecha = fecha.AddDays(30);

                if (total < 1)
                {
                    total = 0;
                }

               DataCredito.ListCredito.Add(new E_Credito
                {
                    No_Pago = i,
                    Fecha = fecha,
                    Cuotas = cuotamensual,
                    Capital = pagocapital,
                    Interes = pagointeres,
                    Mora = 0
                });
            }
        }
    }
}
