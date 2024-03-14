using lab4_CRUD_hw.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab4_CRUD_hw.Controllers
{
    public class HomeController : Controller

    {
        lab3DbEntities _context = new lab3DbEntities();
        public ActionResult Index()
        {

            var listofData = _context.Students.ToList();
            return View(listofData);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student model)
        {
            _context.Students.Add(model);
            _context.SaveChanges();
            ViewBag.Message = "DATA INSERTED SUCCESSFULLY!!";
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        { 
        var data= _context.Students.Where(x => x.sId==id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Student model)
        {
            var data = _context.Students.Where(x => x.sId == model.sId).FirstOrDefault();
            if (data != null)
            {
                data.address = model.address;
                data.sName = model.sName;
                data.cgpa = model.cgpa;
                _context.SaveChanges();
            }
            return RedirectToAction("index");
        }

        [HttpGet]
        ActionResult Detail(int id)
        {
            var data = _context.Students.Where(x => x.sId == id).FirstOrDefault();
            return View(data);
        }

        public ActionResult Delete(int id)
        {
            var data = _context.Students.Where(x => x.sId == id).FirstOrDefault();
            _context.Students.Remove(data);
            _context.SaveChanges();
            ViewBag.Message = "Record Deleted Successfully";
            return RedirectToAction("index");
        }

       
    }
}