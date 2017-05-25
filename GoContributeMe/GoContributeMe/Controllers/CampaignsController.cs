using GoContributeMe.Context;
using GoContributeMe.Models.Model;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace GoContributeMe.Controllers
{
    public class CampaignsController : Controller
    {
        private GoContributeMeDB db = new GoContributeMeDB();


        // GET: Campaigns
        public ActionResult Index()
        {
            var campaign = db.Campaign.Include(c => c.Category).Include(c => c.Contribution);
            return View(campaign.ToList());
        }

        // GET: Campaigns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Campaign campaign = db.Campaign.Find(id);
            if (campaign == null)
            {
                return HttpNotFound();
            }
            return View(campaign);
        }

        // GET: Campaigns/Create

        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Category, "CategoryID", "Name");
            ViewBag.ContributionID = new SelectList(db.Contribution, "ContributionID", "Name");
            return View();
        }

        // POST: Campaigns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Campaign campaign)
        {
            TempData.Clear();
            TempData["aCampaign"] = campaign;
            return RedirectToAction("FundRecipient");
        }

        public ActionResult FundRecipient()
        {

            return View();
        }
        [HttpPost]
        public ActionResult FundRecipient(Campaign aCampaigna)
        {
            Campaign aCampaignCreate = (Campaign)TempData["aCampaign"];
            if (aCampaigna.RecipientName != null)
            {
                aCampaigna.Tittle = aCampaignCreate.Tittle;
                aCampaigna.CategoryID = aCampaignCreate.CategoryID;
                aCampaigna.ContributionID = aCampaignCreate.ContributionID;
                aCampaigna.Descriptions = aCampaignCreate.Descriptions;

                db.Campaign.Add(aCampaigna);
                db.SaveChanges();
                ModelState.Clear();
                return RedirectToAction("Account", "User");
            }

            return HttpNotFound();
        }

        // GET: Campaigns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Campaign campaign = db.Campaign.Find(id);
            if (campaign == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Category, "CategoryID", "Name", campaign.CategoryID);
            ViewBag.ContributionID = new SelectList(db.Contribution, "ContributionID", "Name", campaign.ContributionID);
            return View(campaign);
        }

        // POST: Campaigns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CampaignID,Tittle,CategoryID,Descriptions,ContributionID,RecipientFirstName,RecipientLastName,RecipientNID,Email,MobileNo,TargetAmount,CampaignClosingDate")] Campaign campaign)
        {
            if (ModelState.IsValid)
            {
                db.Entry(campaign).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Category, "CategoryID", "Name", campaign.CategoryID);
            ViewBag.ContributionID = new SelectList(db.Contribution, "ContributionID", "Name", campaign.ContributionID);
            return View(campaign);
        }

        // GET: Campaigns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Campaign campaign = db.Campaign.Find(id);
            if (campaign == null)
            {
                return HttpNotFound();
            }
            return View(campaign);
        }

        // POST: Campaigns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Campaign campaign = db.Campaign.Find(id);
            db.Campaign.Remove(campaign);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
