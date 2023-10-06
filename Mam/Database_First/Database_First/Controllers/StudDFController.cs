using Database_First.Models;
using Microsoft.AspNetCore.Mvc;

namespace Database_First.Controllers
{
    public class StudDFController : Controller
    {
        private ApplicationDbContext _db;
        public StudDFController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            
            List<StudDF> obj = _db.StudDF1.ToList();
           
            return View(obj);
           
        
        }
        public IActionResult Add()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Add(StudDF stud)
        {
            if(ModelState.IsValid)
            { 
            _db.StudDF1.Add(stud);
            _db.SaveChanges();
                return RedirectToAction("Index");

            }
           
            return View();
        }

        [HttpGet]
        [Route("studdf/View/{id}")]
        public IActionResult View(int Id)
        {
              var stud = _db.StudDF1.FirstOrDefault(s=>s.Stud_id==Id);
            if(stud != null)
            {
                var viewmodel = new Update() 
                {
                    Stud_id=stud.Stud_id,
                    Name= stud.Name,
                    Address= stud.Address,
                };

                return View(viewmodel);
            }

            return RedirectToAction("Index");
        }
        
        [HttpPut]
        [Route("studdf/view/update")]
        public IActionResult Update(Update update)
        {

            var stud = _db.StudDF1.Find(update.Stud_id);
            if(stud != null)
            {
               
                stud.Name=update.Name;
                stud.Address=update.Address;
                _db.SaveChanges();
                return RedirectToAction("Index");
            };

            return RedirectToAction("Index");
        }
       
        //public IActionResult Delete(StudDF update)
        //{

        //    var stud = _db.StudDF1.FirstOrDefault(s=>s.Stud_id==update.Stud_id);
        //    if (stud != null)
        //    {

        //        _db.StudDF1.Remove(stud);
        //        _db.SaveChanges();
        //        return RedirectToAction("Index");
        //    };

        //    return RedirectToAction("Index");
        //}
        // new line
        // second line
        // third line
        
        public IActionResult Delete(int id)
        {

            var stud = _db.StudDF1.FirstOrDefault(s => s.Stud_id==id);
            if (stud != null)
            {

                _db.StudDF1.Remove(stud);
                _db.SaveChanges();
                return RedirectToAction("Index");
            };

            return RedirectToAction("Index");
        }
    }
}


