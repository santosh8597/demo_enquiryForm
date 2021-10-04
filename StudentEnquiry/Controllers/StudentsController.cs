using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentEnquiry.Models;
using StudentEnquiry.BL;
using System.Data.Entity;
namespace StudentEnquiry.Controllers
{
    [Authorize]
    public class StudentsController : Controller
    {
        Services<StudentDetail, int> studentRepo;

        public StudentsController()
        {
            studentRepo = new Services<StudentDetail, int>(new StudenquiryDbEntities()); 
        }



        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Delete()
        {
            return View();
        }
        public ActionResult Views(int id)
        {
            ViewBag.id = id;

            return View();
        }
        [HttpPost]
        public string AddStudentData( StudentDetail s)
        {
            studentRepo.Create(s);

            return "Student Added Successfully";
        }
        [HttpGet]
        public JsonResult GetStudents()
        {

            return Json(studentRepo.GetAll(), JsonRequestBehavior.AllowGet);
        }
       
        public JsonResult ViewStudent(int id)
        {
            return Json(studentRepo.GetById(id),JsonRequestBehavior.AllowGet);
        }

        public string DeleteStudent(int id)
        {
            studentRepo.Delete(id);

            return "Studetn Deleted Successfully";
        }
        public string UpdateStudent(StudentDetail s)
        {
           studentRepo.Update(s);
            return "Student Updated Successfully";
        }
	}
}