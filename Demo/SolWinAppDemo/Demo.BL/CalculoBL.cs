using Demo.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BL
{
    public class CalculoBL
    {
        public Int32 RegistrarDetalleCliente(AlumnoBE alumno) 
        {
            try
            {
                CalculoDA objDA = new CalculoDA();
                return objDA.RegistrarDetalleCliente(alumno);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
