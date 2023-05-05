using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class EstadoNacimiento
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.AAcostaDrSecurityEntities context = new DL.AAcostaDrSecurityEntities())
                {
                    var query = context.EstadoNacimientoGetAll().ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach(var obj in query)
                        {
                            ML.EstadoNacimiento estadoNacimiento = new ML.EstadoNacimiento();

                            estadoNacimiento.IdEstadoNacimiento = obj.IdEstadoNacimiento;
                            estadoNacimiento.NombreEstado = obj.NombreEstado;

                            result.Objects.Add(estadoNacimiento);
                        }
                    }
                }
                result.Correct = true;
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
            }
            return result;
        }
    }
}