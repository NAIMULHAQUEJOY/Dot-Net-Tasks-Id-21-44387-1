using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task_1_21_44387_1.Models;

namespace Task_1_21_44387_1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Education()
        {

            var s2 = new Student();
            s2.degree = "IGCSE";
            s2.year = "2016";
            s2.institute = "British Columbia School";

            var s3 = new Student();
            s3.degree = "IAL";
            s3.year = "2019";
            s3.institute = "British Columbia School";



            ViewBag.Students = new Student[] { s2,s3 };
            return View();
        }

      

       

        public ActionResult Project()
        {
            var s4 = new Student();
            var s5 = new Student();
            var s6 = new Student();

            s4.project = "Completed Filling Station Management Project, using C# language";
            s5.project = "Completed Fertilizer Inventory Management System, using Java";
            s6.project = "Completed Madrasa Management, using PHP, JS, HTML";
            ViewBag.Students = new Student[] { s4, s5, s6 };
            return View();

        }
        public ActionResult Reference()
        {
            var r1 = new teacherRef();
            var r2= new teacherRef();
            r1.tName = "1. Umme Marzia Haque";
            r1.desig = "Assistant Professor, American International University Bangladesh";
            r1.email = "umme@aiub.edu";

            r2.tName = "2. Zahiduddin Ahmed";
            r2.desig = "Assistant Professor, American International University Bangladesh";
            r2.email = "zahid@aiub.edu";

            ViewBag.Ref = new teacherRef[] { r1,r2};



            return View();
        }

        public ActionResult Personal()
        {
            var s1 = new Student();
            s1.name = "Mohammad Naimul Haque";
            s1.fatherName ="Md Nazmul Haque";
            s1.motherName = "Nasira Haque";
            s1.bloodGroup = "Ab +ve";
            s1.contact = "01717771181";

      
            ViewBag.Students = new Student[] { s1};


            //string name = "Tanvir";
            //string id = "123";
            //float cgpa = 2.34f;

            //ViewBag.Name = name;
            //ViewBag.Id = id;
            //ViewBag.Cgpa = cgpa;
            return View();
        }
    }
}





