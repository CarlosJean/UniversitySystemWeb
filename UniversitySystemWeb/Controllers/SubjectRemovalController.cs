using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversitySystemWeb.Models;
using UniversitySystemWeb.ViewModels;


namespace UniversitySystemWeb.Controllers
{
    public class SubjectRemovalController : Controller
    {
        UniversityDb db = new UniversityDb();
        // GET: SubjectRemoval
        public ActionResult SubjectRemoval()
        {
            var selectionView = new StudentView
            {
                Student = new Student(),
                Subjects = new List<Subject>()
            };
            Session["removalView"] = selectionView;

            return View(selectionView);
        }

        [HttpPost]
        public ActionResult SubjectRemoval(FormCollection form)
        {

            var studentView = Session["removalView"] as StudentView;

            var student = db.Students.Find(int.Parse(Request["Student.StudentID"]));
            studentView.Student = student;
            foreach (var subject in student.Subjects)
            {
                
                studentView.Subjects.Add(subject);


            }
                

            return View(studentView);
        }

    }
}