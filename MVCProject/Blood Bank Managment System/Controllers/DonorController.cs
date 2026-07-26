using Blood_Bank_Managment_System.EF;
using Blood_Bank_Managment_System.EF.Tables;
using Microsoft.AspNetCore.Mvc;

namespace Blood_Bank_Managment_System.Controllers
{
    public class DonorController : Controller
    {
        BloodBankDbContext db;
        public DonorController(BloodBankDbContext db)
        {
            this.db = db;
        }

        // Create Donor - Block
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Donor d)
        {
            if (ModelState.IsValid)
            {
                db.Donors.Add(d);
                var rs = db.SaveChanges();
                if (rs > 0)
                {
                    TempData["msg"] = "<script>alert('Donor Added Successfully');</script>";
                }
                else
                {
                    TempData["msg"] = "<script>alert('Error While Adding Donor');</script>";
                }
                return RedirectToAction("List");
            }
            return View(d);
        }

        // Get Donors - Block
        public IActionResult List()
        {
            var donordata = db.Donors.ToList();
            return View(donordata);
        }

        // Edit Donor - Block
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var donor = db.Donors.Find(id);
            if(donor == null)
            {
                return NotFound();
            }
            return View(donor);
        }

        [HttpPost]
        public IActionResult Edit(Donor d)
        {
            if (ModelState.IsValid)
            {
                db.Donors.Update(d);
                var rs = db.SaveChanges();
                if (rs > 0)
                {
                    TempData["msg"] = "<script>alert('Donor Updated Successfully');</script>";
                }
                else
                {
                    TempData["msg"] = "<script>alert('Error While Updating Donor');</script>";
                }
                return RedirectToAction("List");
            }
            return View(d);
        }

        // Delete Donor - Block
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var donor = db.Donors.Find(id);
            if (donor == null) 
            {
                return NotFound();
            }
            return View(donor);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var donor = db.Donors.Find(id);
            if (donor == null)
            {
                return NotFound();
            }

            db.Donors.Remove(donor);
            var rs = db.SaveChanges();
            if (rs > 0)
            {
                TempData["msg"] = "<script>alert('Donor Deleted Successfully');</script>";
            }
            else
            {
                TempData["msg"] = "<script>alert('Error While Deleting Donor');</script>";
            }
            return RedirectToAction("List");
        }
    }
}
