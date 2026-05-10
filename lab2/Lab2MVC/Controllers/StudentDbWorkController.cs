using Lab2MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab2MVC.Controllers
{
    public class StudentDbWorkController : Controller
    {
        private static List<StudentDbWork> works = new List<StudentDbWork>(); //ЧАСТЬ 2 ПУНКТ 1

        public ActionResult ShowAll()
        {
            return View(works);
        }
        public ActionResult ShowAllInternal() //////
        {
            return View(works);              ////// ЧАСТЬ 3 ПУНКТ 2
        }                                    //////
        public ActionResult ShowAllExternal()////ЧАСТЬ 3 ПУНКТ 2
        {
            return View(works);
        }
        public ActionResult ShowAllSwitch()////ЧАСТЬ 3 ПУНКТ 3
        {
            ViewData["UseInternalHelper"] = true;
            return View(works);
        }
        public ActionResult Details(StudentDbWork model)
        {
            return View(model);
        }

        public ActionResult Create()
        {
            return View(new StudentDbWork());
        }

        [HttpPost]
        public ActionResult Create(StudentDbWork model)
        {
            model.Id = works.Count + 1;
            works.Add(model);

            return View("Details", model);
        }

        public ActionResult Edit()
        {
            return View(new StudentDbWork());
        }

        [HttpPost]
        public ActionResult Edit(StudentDbWork model)
        {
            return View("Details", model);
        }

        public ActionResult Index()
        {
            return View();
        }
        
    }
}