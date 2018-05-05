using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversitySystemWeb.Models;

namespace UniversitySystemWeb.Controllers
{
    public class SubjectSelectionController : Controller
    {
        UniversityDb db = new UniversityDb();
        // GET: SubjectSelection
        public ActionResult AddSubject()
        {
            return View();
        }

        [HttpGet]
        public ActionResult NewSelection()
        {
            return View();
        }


        //public ActionResult NewSelection(Student student)
        //{
        //    return View();
        //}


        public JsonResult SearchStudent(int id)
        {
            var student = db.Students.Find(id);

            if (id==0)
            {
                return null;

            }
            var result = new JsonResult
            {
                Data = new {Student= studentName(student) }
            };

            

            return result;
        }

        public string studentName(Student student)
        {
            string studentName = student.Name.ToString() +" "+ student.LastName.ToString();
            return studentName;
        }


    }
}