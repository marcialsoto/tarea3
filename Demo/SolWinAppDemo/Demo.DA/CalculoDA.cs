using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BE
{
    public class CalculoDA
    {
        public Int32 RegistrarDetalleCliente(AlumnoBE alumno)
        {
            Int32 id = 0;
            try
            {
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxDesa"].ConnectionString))
                {
                    cn.Open();
                    using (SqlCommand cm = new SqlCommand("PA_ALUMNO_INSERT", cn))
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("@Nombres", alumno.Nombres);
                        cm.Parameters.AddWithValue("@Apellidos", alumno.apellidos);
                        cm.Parameters.AddWithValue("@Practica1", alumno.Practica1);
                        cm.Parameters.AddWithValue("@Practica2", alumno.Practica2);
                        cm.Parameters.AddWithValue("@Practica3", alumno.Practica3);
                        cm.Parameters.AddWithValue("@Practica4", alumno.Practica4);
                        cm.Parameters.AddWithValue("@MenorPractica", alumno.MenorPractica);
                        cm.Parameters.AddWithValue("@ExamenParcial", alumno.ExamenParcial);
                        cm.Parameters.AddWithValue("@ExamenFinal", alumno.ExamenFinal);
                        cm.Parameters.AddWithValue("@PromedioPracticas", alumno.PromedioPracticas);
                        cm.Parameters.AddWithValue("@PromedioFinal", alumno.PromedioFinal);
                        cm.Parameters.AddWithValue("@Estado", alumno.Estado);
                        id = cm.ExecuteNonQuery();
                    }
                    cn.Close();
                }
            }
            catch (Exception excepcion)
            {
                throw (excepcion);
            }
            return id;
        }

    }
}
