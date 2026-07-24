using Blood_Bank_Managment_System.EF;
using Microsoft.AspNetCore.Mvc;

namespace Blood_Bank_Managment_System.Controllers
{
    public class ReportController : Controller
    {
        BloodBankDbContext db;

        public ReportController(BloodBankDbContext db)
        {
            this.db = db;
        }


        // Filter Donors by Blood Group - Block
        public IActionResult FilterByBloodGroup(string bloodGroup)
        {
            var donors = string.IsNullOrEmpty(bloodGroup) 
                ? db.Donors.ToList() 
                : db.Donors.Where(d => d.BloodGroup == bloodGroup).ToList();
            
            ViewBag.SelectedBloodGroup = bloodGroup;
            return View(donors);
        }


        // Sort Donors by Last Donation Date - Block
        public IActionResult SortedByDate()
        {
            var donors = db.Donors.OrderBy(d => d.LastDonationDate).ToList();
            return View(donors);
        }


        // Count Donations per Donor - Block
        public IActionResult DonationCount()
        {
            var rs = db.Donors.Select(d => new 
            {
                d.FullName,
                d.BloodGroup,
                TotalDonations = d.Donations.Count(),
            })
                .ToList();

            ViewBag.Title = rs;
            return View();
        }

        // 4. Total volume collected
        public IActionResult TotalVolume()
        {
            var total = db.Donations.Sum(d => d.VolumeMl);
            ViewBag.TotalVolume = total;
            return View();
        }

    }
}
