using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {
        public static ML.Result Add(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.AAcostaDrSecurityEntities context =  new DL.AAcostaDrSecurityEntities())
                {
                    var query = context.UsuarioAdd(usuario.Nombre,usuario.ApellidoPaterno,usuario.ApellidoMaterno,usuario.FechaNacimiento,usuario.Sexo,usuario.EstadoNacimiento,usuario.Telefono,usuario.Direccion,usuario.CURP);
                    
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se Inserto el usuario";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public static ML.Result Update(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.AAcostaDrSecurityEntities context = new DL.AAcostaDrSecurityEntities())
                {
                    var query = context.UsuarioUpdate(usuario.IdUsuario,usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.FechaNacimiento, usuario.Sexo, usuario.EstadoNacimiento, usuario.Telefono, usuario.Direccion, usuario.CURP);
                    
                    if (query >= 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se Modifico el usuario";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
            }
            return result;
        }


        public static ML.Result Delete(int IdUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.AAcostaDrSecurityEntities context = new DL.AAcostaDrSecurityEntities())
                {
                    var query = context.UsuarioDelete(IdUsuario);

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se Elimino el usuario";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
            }
            return result;
        }


        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.AAcostaDrSecurityEntities context = new DL.AAcostaDrSecurityEntities())
                {
                    var query = context.UsuarioGetAll().ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        
                        foreach (var obj in query)
                        {
                            ML.Usuario usuario = new ML.Usuario();

                            usuario.IdUsuario = obj.IdUsuario;
                            usuario.Nombre = obj.Nombre;
                            usuario.ApellidoPaterno = obj.ApellidoPaterno;
                            usuario.ApellidoMaterno = obj.ApellidoMaterno;
                            usuario.FechaNacimiento = obj.FechaNacimiento.ToString();
                            usuario.Sexo = obj.Sexo;
                            usuario.EstadoNacimiento = obj.EstadoNacimiento;

                            //usuario.EstadoNacimiento = new ML.EstadoNacimiento();
                            //usuario.EstadoNacimiento.IdEstadoNacimiento = obj.IdEstadoNacimiento.Value;
                            //usuario.EstadoNacimiento.NombreEstado = obj.NombreEstado;

                            usuario.Telefono = obj.Telefono;
                            usuario.Direccion = obj.Direccion;
                            usuario.CURP = obj.CURP;

                            result.Objects.Add(usuario);
                        }
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public static ML.Result GetById(int IdUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.AAcostaDrSecurityEntities context = new DL.AAcostaDrSecurityEntities())
                {
                    var query = context.UsuarioGetById(IdUsuario).FirstOrDefault();

                    if (query != null)
                    {
                        ML.Usuario usuario = new ML.Usuario();

                        usuario.IdUsuario = query.IdUsuario;
                        usuario.Nombre = query.Nombre;
                        usuario.ApellidoPaterno = query.ApellidoPaterno;
                        usuario.ApellidoMaterno = query.ApellidoMaterno;
                        usuario.FechaNacimiento = query.FechaNacimiento.ToString();
                        usuario.Sexo = query.Sexo;
                        usuario.EstadoNacimiento = query.EstadoNacimiento;

                        //usuario.EstadoNacimiento = new ML.EstadoNacimiento();
                        //usuario.EstadoNacimiento.IdEstadoNacimiento = query.IdEstadoNacimiento.Value;
                        //usuario.EstadoNacimiento.NombreEstado = query.NombreEstado;

                        usuario.Telefono = query.Telefono;
                        usuario.Direccion = query.Direccion;
                        usuario.CURP = query.CURP;

                        result.Object = usuario;
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
            }
            return result;
        }
    }
}