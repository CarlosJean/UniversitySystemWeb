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

        [HttpPost]
        public ActionResult NewSelection(StudentView studentView)
        {
            studentView = Session["selectionView"] as StudentView;
            var student = db.Students.Find(studentView.Student.StudentID);

            //foreach (var item in studentView.Subjects)
            //{

            //    var subject = db.Subjects.Find(item.SubjectID);
            //    subject.Students.Add(student);
            //    db.SaveChanges();

            //}

            foreach (var item in studentView.Subjects)
            {
                var subject = db.Subjects.Find(item.SubjectID);
                student.Subjects.Add(subject);
                db.SaveChanges();
            }

            studentView.Student = new Student();
            studentView.Subjects = new List<Subject>();

            return View(studentView);
        }

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

            var selectionView = Session["selectionView"] as StudentView;
            selectionView.Student = student;

            return result;
        }

        public string StudentName(Student student)
        {
            try
            {
                string studentName = student.FullName;
                return studentName;
            }
            catch (Exception)
            {
               
                return "Estudiante no encontrado.";
            }
          
        }

        [HttpDelete]
        public ActionResult RemoveSubject(int subjectID)
        {
            var selectionView = Session["selectionView"] as StudentView;
            var subject = selectionView.Subjects.Find(s => s.SubjectID == subjectID);

                selectionView.Subjects.Remove(subject);


            return View("SubjectSelected", selectionView);
        }


        public ActionResult SubjectRemoval()
        {

            return View();
        }
         

    }
}