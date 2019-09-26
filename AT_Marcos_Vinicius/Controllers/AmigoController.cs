using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;

namespace AT_Marcos_Vinicius.Controllers
{
    public class AmigoController : Controller
    {

        private AmigoRepositorio repositorio;
        public ActionResult Index()
        {
            repositorio = new AmigoRepositorio();
            ModelState.Clear();
            return View(repositorio.ListarAmigo());
        }


        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Amigos amigoObj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repositorio = new AmigoRepositorio();
                    if (repositorio.InserirAmigo(amigoObj))
                    {
                        ViewBag.Message = "Amigo inserido com sucesso!";
                    }
                }
                return View();

            }
            catch (Exception)
            {
                return View("Index");
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            repositorio = new AmigoRepositorio();

            return View(repositorio.ListarAmigo().Find(t => t.Id == id));
        }


        [HttpPost]
        public ActionResult Edit(int id, Amigos amigoObj)
        {
            try
            {
                repositorio = new AmigoRepositorio();
                repositorio.AtualizarAmigo(amigoObj);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View("Index");
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View();
        }


        [HttpPost]
        public ActionResult Delete(int id, Amigos amigo)
        {
            try
            {
                repositorio = new AmigoRepositorio();
                if (repositorio.ExcluirAmigo(id))
                {
                    ViewBag.Message = "Amigo excluído com sucesso!";
                }

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View("Index");
            }
        }
    }
}
