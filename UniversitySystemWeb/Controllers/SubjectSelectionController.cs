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
        [HttpPost]
        public ActionResult AddSubject(FormCollection formCollection)
        {

            var subjectID = int.Parse(Request["item.SubjectID"]);
            var selectionView = Session["selectionView"] as StudentView;

            var subject = db.Subjects.Find(subjectID);

            if (!selectionView.Subjects.Any(s => s.SubjectID== subject.SubjectID))
            {

                selectionView.Subjects.Add(subject);
            }

            return View("NewSelection", selectionView);
        }

        public ActionResult NewSelection()
        {
            var selectionView = new StudentView
            {
                Student = new Student(),
                Subjects = new List<Subject>()
            };
            Session["selectionView"] = selectionView;

            return View(selectionView);
        }

        //public ActionResult NewSelection(StudentView studentView)
        //{
        //    var selectionView = new StudentView
        //    {
        //        Student = new Student(),
        //        Subjects = new List<Subject>()
        //    };
        //    Session["selectionView"] = selectionView;

        //    return View(selectionView);
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
                Data = new {Student= StudentName(student) }
            };

            //StudentView studentView = new StudentView
            //{
            //    Student = student
            //};

            var selectionView = Session["selectionView"] as StudentView;

            selectionView.Student = student;
            return result;
        }

        public string StudentName(Student student)
        {
            string studentName = student.FullName;
            return studentName;
        }


    }
}