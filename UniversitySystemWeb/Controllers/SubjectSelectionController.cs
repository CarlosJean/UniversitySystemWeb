using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversitySystemWeb.Models;
using UniversitySystemWeb.ViewModels;

namespace UniversitySystemWeb.Controllers
{
    public class SubjectSelectionController : Controller
    {
       private UniversityDb db = new UniversityDb();
        // GET: SubjectSelection
        public ActionResult AddSubject()
        {
            var subjects = db.Subjects;
            return View(subjects.ToList());
        }

        [HttpGet]
        public ActionResult NewSelection()
        {
            var selectionView = new StudentView();
            selectionView.Student = new Student();
            selectionView.Subjects = new List<Subject>();
            Session["selectionView"] = selectionView;
            return View(selectionView);
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

            StudentView studentView = new StudentView();
            studentView.Student = student;

            return result;
        }

        public string studentName(Student student)
        {
            string studentName = student.Name.ToString() +" "+ student.LastName.ToString();
            return studentName;
        }


    }
}