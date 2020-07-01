using System;
using System.Web.Mvc;
using WebAppMVC.Bll.RegraNegocio;
using WebAppMVC.Model;

namespace WebAppMVC.UI.Controllers
{
    public class TimeController : Controller
    {
        regranegocioTime regranegocioTime;


        #region "Get"

        [HttpGet]
        public ActionResult Index()
        {


            try
            {
                regranegocioTime = new regranegocioTime();

                var lstTimes = regranegocioTime.Pesquisar();

                ModelState.Clear();

                return View(lstTimes);
            }
            catch (Exception)
            {
                throw;
            }



        }

        [HttpGet]
        public ActionResult Create()
        {
            try
            {
                return View(new Time());
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public ActionResult Update(int id)
        {

            try
            {
                regranegocioTime = new regranegocioTime();
                var time = regranegocioTime.Pesquisar().Find(t => t.TimeID == id);
                return View(time);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {

            Time objTime = null;

            try
            {
                regranegocioTime = new regranegocioTime();
                objTime = new Time();

                objTime.TimeID = id;

                if (regranegocioTime.Deletar(objTime))
                {
                    ViewBag.Mensagem = "Time Excluido com Sucesso.";

                }


                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return View("Index");
            }
        }

        #endregion

        #region "Post"

        [HttpPost]
        public ActionResult Create(Time objTime)
        {


            try
            {
                if (ModelState.IsValid)
                {
                    regranegocioTime = new regranegocioTime();


                    if (regranegocioTime.Adicionar(objTime))
                    {
                        ViewBag.Mensagem = "Time Cadastrado com Sucesso.";
                    }

                }

                return View();
            }
            catch (Exception)
            {

                return View("Index");
            }
        }

        [HttpPost]
        public ActionResult Update(int id, Time objTime)
        {


            try
            {
                regranegocioTime = new regranegocioTime();

                regranegocioTime.Atualizar(objTime);

                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return View("Index");
            }
        }


        #endregion


    }
}