using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Studentportal.Data;
using Studentportal.Models;
using Studentportal.Models.Entities;

namespace Studentportal.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public StudentsController( ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> Add(AddStudentViewModel viewModel)
        {
            var student = new Student
            {
                Name = viewModel.Name,
                Email = viewModel.Email,
                School = viewModel.School,
                Phone = viewModel.Phone,
                Province = viewModel.Province,
                PreferredTimeslot = viewModel.PreferredTimeslot,


            };
            await dbContext.Students.AddAsync(student);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("List", "Students");
        }

         [HttpGet]
        public async Task<IActionResult> List()
        {
            var students=await dbContext.Students.ToListAsync();
            return View(students);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(Guid id)
        {
           var student= await dbContext.Students.FindAsync(id);
            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Student viewmodel)
        {
            var student = await dbContext.Students.FindAsync(viewmodel.ID);

            if (student != null)
            {
                student.Name = viewmodel.Name;
                student.Email = viewmodel.Email;
                student.School = viewmodel.School;
                student.Phone = viewmodel.Phone;
                student.Province = viewmodel.Province;
                student.PreferredTimeslot = viewmodel.PreferredTimeslot;

                await dbContext.SaveChangesAsync();

                return RedirectToAction("List", "Students");
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Student viewmodel)
        {
            var student = await dbContext.Students
                 .AsNoTracking()
                .FirstOrDefaultAsync(x=>x.ID ==viewmodel.ID );
            if (student != null) { 
            dbContext.Students.Remove(viewmodel);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Students");
        }
    }
}
