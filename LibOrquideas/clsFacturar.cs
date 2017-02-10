using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibOrquideas
{
    public class clsFacturar
    {
        #region "Atributos"
        private float fltValorDocena;
        private int intCantidad;
        private float fltPorcIVA;
        private float fltSubTotal;
        private float fltValorDescuento;
        private float fltValorIVA;
        private float fltTotalPagar;
        private string strError;
        #endregion

        #region "Constructores"
        //Constructor vacio
        public clsFacturar()
        {
            fltValorDocena = 0;
            intCantidad = 0;
            fltPorcIVA = 0;
            fltSubTotal = 0;
            fltValorDescuento = 0;
            fltValorIVA = 0;
            fltTotalPagar = 0;
            strError = string.Empty;
        }
        #endregion

        #region "Propiedades"
        // Entrada
        public float VrDocena
        {
            set { fltValorDocena = value; }
        }
        public int Cantidad
        {
            set { intCantidad = value; }
        }
        public float PorcIVA
        {
            set { fltPorcIVA = value; }
        }
        // Salida
        public float SubTotal
        {
            get { return fltSubTotal; }
        }
        public float VrDscto
        {
            get { return fltValorDescuento; }
        }
        public float VrIVA
        {
            get { return fltValorIVA; }
        }
        public float TotalAPagar
        {
            get { return fltTotalPagar; }
        }
        public string Error
        {
            get { return strError; }
        }
        #endregion

        #region "Metodos Privados"
        private bool Validar()
        {
            if (fltValorDocena <= 0)
            {
                strError = "El valor de la docena no es válido";
                return false;
            }
            if (intCantidad <= 0)
            {
                strError = "La cantidad de unidades no es válida";
                return false;
            }
            if (fltPorcIVA <= 0 || fltPorcIVA > 100)
            {
                strError = "El valor del IVA no es válido";
                return false;
            }
            return true;
        }
        #endregion

        #region "Metodos Publicos"
        public bool Facturar()
        {
            try
            {

                float fltCantDoc;
                float fltPorcD = 0;
                float fltVrUnit = Convert.ToSingle(fltValorDocena / 12.0);

                if ( ! Validar() )
                    return false;

                fltSubTotal = intCantidad * fltVrUnit;

                fltCantDoc = Convert.ToSingle(intCantidad / 12.0);

                if (fltCantDoc <= 1) fltPorcD = 0;
                else if (fltCantDoc <= 2) fltPorcD = 0.1f;
                else if (fltCantDoc <= 3) fltPorcD = 0.15f;
                else fltPorcD = 0.2f;

                fltValorDescuento = fltSubTotal * fltPorcD;

                fltValorIVA = (fltSubTotal - fltValorDescuento) * Convert.ToSingle(fltPorcIVA / 100.0);

                fltTotalPagar = fltSubTotal - fltValorDescuento + fltValorIVA;

                return true;

            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
        }
        #endregion
    }
}
