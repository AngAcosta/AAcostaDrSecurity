using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Usuario usuario = new ML.Usuario();
            ML.Result result = BL.Usuario.GetAll();


            if (result.Correct)
            {
                usuario.Usuarios = result.Objects;
                return View(usuario);
            }
            else
            {
                return View(usuario);
            }
        }

        [HttpGet]
        public ActionResult Form(int? IdUsuario)
        {
            //ML.Result resultArea = BL.EstadoNacimiento.GetAll();

            ML.Usuario usuario = new ML.Usuario();
            //usuario.EstadoNacimiento = new ML.EstadoNacimiento();

            //if (resultArea.Correct)
            //{
            //    usuario.EstadoNacimiento.EstadoNacimientos = resultArea.Objects;
            //}
            if (IdUsuario == null)
            {
                //add //formulario vacio
                return View(usuario);
            }
            else
            {
                //getById
                ML.Result result = BL.Usuario.GetById(IdUsuario.Value);

                if (result.Correct)
                {
                    usuario = (ML.Usuario)result.Object; //unboxing
                    //usuario.EstadoNacimiento.EstadoNacimientos = resultArea.Objects;

                    //update
                    return View(usuario);
                }
                else
                {
                    ViewBag.Message = "Ocurrio al consultar la informacion del Departamento";
                    return View("Modal");
                }
            }
        }

        [HttpPost]
        public ActionResult Form(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            if (usuario.IdUsuario == 0)
            {
                //add
                result = BL.Usuario.Add(usuario);

                if (result.Correct)
                {
                    ViewBag.Message = "Se Completo del Registro";
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al Insertar el Registro";
                }
                return View("Modal");
            }
            else
            {
                //update
                result = BL.Usuario.Update(usuario);

                if (result.Correct)
                {
                    ViewBag.Message = "Se Actualizo el Registro";
                    return View("Modal");
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al Actualizar el Registro";
                    return View("Modal");
                }
                return View("Modal");
            }
        }

        [HttpGet]
        public ActionResult Delete(int IdUsuario)
        {
            ML.Result result = BL.Usuario.Delete(IdUsuario);

            if (result.Correct)
            {
                ViewBag.message = "Se elimino el registro";
                return View("modal");
            }
            else
            {
                ViewBag.message = "No se elimino el registro";
            }
            return View("Model");
        }
    }
}