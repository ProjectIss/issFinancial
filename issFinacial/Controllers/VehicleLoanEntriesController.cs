using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using issFinacial.Models;

namespace issFinacial.Controllers
{
    public class VehicleLoanEntriesController : Controller
    {
        private issModel db = new issModel();

        // GET: VehicleLoanEntries
        public async Task<ActionResult> Index()
        {
            var vehicleLoanEntries = db.VehicleLoanEntries.Include(v => v.agent).Include(v => v.area).Include(v => v.broker).Include(v => v.brokerName).Include(v => v.Customer).Include(v => v.Insurance).Include(v => v.shareHoldere).Include(v => v.vehicle).OrderByDescending(x => x.id);
            return View(await vehicleLoanEntries.ToListAsync());
        }

        // GET: VehicleLoanEntries/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleLoanEntry vehicleLoanEntry = await db.VehicleLoanEntries.FindAsync(id);
            if (vehicleLoanEntry == null)
            {
                return HttpNotFound();
            }
            return View(vehicleLoanEntry);
        }

        // GET: VehicleLoanEntries/Create
        public ActionResult Create()
        {
            ViewBag.agentId = new SelectList(db.Agents, "id", "name");
            ViewBag.areaId = new SelectList(db.Areas, "id", "name");
            ViewBag.brokerId = new SelectList(db.Brokers, "id", "id");
            ViewBag.brokerNameId = new SelectList(db.Brokers, "id", "name");
            ViewBag.ageId = new SelectList(db.Customers, "id", "Age");
            ViewBag.phoneNoId = new SelectList(db.Customers, "id", "phoneno");
            ViewBag.addressId = new SelectList(db.Customers, "id", "address");
            ViewBag.fatherNameId = new SelectList(db.Customers, "id", "fathername");
            ViewBag.customerId = new SelectList(db.Customers, "id", "id");
            ViewBag.customerNameId = new SelectList(db.Customers, "id", "customerName");
            ViewBag.InsuranceId = new SelectList(db.InsuranceCompanies, "id", "name");
            ViewBag.shareHolderId = new SelectList(db.Shareholders, "id", "name");
            ViewBag.VehicleId = new SelectList(db.Vehicles, "id", "name");
            //  ViewBag.paymentMode = new SelectList(db.AccountGroupings, "id", "accountGroup");
            var grouplist = (from account in db.AccountGroupings
                             join ledger in db.AccountLedgers on account.id equals ledger.accountgroupId
                             where account.accountGroup == "Cash-in-hand"
                             || account.accountGroup == "Bank Accounts"
                             select new
                             {
                                 Id = ledger.id,
                                 Name = ledger.AccountName
                             }).ToList();
            List<SelectListItem> payment = new List<SelectListItem>();
            foreach (var item in grouplist)
            {
                payment.Add(new SelectListItem { Text = item.Name, Value = item.Id.ToString() });
            }
            ViewBag.paymentMode = payment;//new SelectList(db.AccountLedgers.Where(x => x.accountgroupId ==  || x.accountgroupId == Bank Accounts).ToList(), "id", "accountGroup");
            return View();
        }

        // POST: VehicleLoanEntries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,shareHolderId,customerId,customerNameId,fatherName,address,phoneNo,age,agentId,agentName,conductPerson,brokerId,brokerNameId,brokerAddress,brokerPhoneNo,areaId,areaName,guardianName,guardianAddress,guardianPhoneNo,dateofAgreement,dateOfDue,advanceEmi,paymentMode,checkNo,amountOfLoan,rateOfIntrestperentage,numberOfInstallments,amountOfIntrest,totalloanAmount,totalAmount,dueAmount,documentAmount,commisionAmount,InsuranceId,policyNo,policyAmount,premiumAmount,insuredNo,insureExpiryOn,policyReceived,vehicleNo,engineNo,chaseNo,registeredAt,registeredDate,rtoOfficeRefNO,endosmentOn,documentWith,VehicleId,vehicleName,vehicleColor,totalDueAmount,endosmentDone,duplicateKeyRecd,policyCircle,vehicleType,taxExpiryDate,permitExpiryDate,fcExpiryDate,insuranceExpityDate,typeOfLoan")] VehicleLoanEntry vehicleLoanEntry)
        {
            if (ModelState.IsValid)
            {
                db.VehicleLoanEntries.Add(vehicleLoanEntry);
                TblMaster tblMaster = new TblMaster();
                //tblMaster.id = vehicleLoanEntry.id;
                tblMaster.EntryDate = (DateTime)vehicleLoanEntry.dateofAgreement;
                tblMaster.AccountID = 33;
                tblMaster.GroupID = 13;
                tblMaster.UGroup = "12";
                tblMaster.PaymentType = vehicleLoanEntry.paymentMode;
                if (vehicleLoanEntry.customerId != 0)
                {
                    var cName = db.Customers.Where(x => x.id == vehicleLoanEntry.customerNameId).FirstOrDefault();
                    tblMaster.Description = cName.customerName;
                }
                tblMaster.Expenses = Convert.ToInt32(vehicleLoanEntry.amountOfLoan);
                tblMaster.Income = 0;
                tblMaster.Type = "Loan Entry";
                tblMaster.FinancialYear = "2020-2021";
                if (vehicleLoanEntry.InsuranceId != 0)
                {
                    var Insure = db.InsuranceCompanies.Where(x => x.id == vehicleLoanEntry.InsuranceId).FirstOrDefault();
                    tblMaster.CompanyName = Insure.name;
                }

                tblMaster.EntryTime = DateTime.UtcNow;
                tblMaster.DeleteTime = DateTime.UtcNow;
                db.TblMasters.Add(tblMaster);
                await db.SaveChangesAsync();
                //////////////////////////////////////////////Document charge////////////////////
                TblMaster document = new TblMaster();
                //tblMaster.id = vehicleLoanEntry.id;
                document.EntryDate = (DateTime)vehicleLoanEntry.dateofAgreement;
                document.AccountID = 44;
                document.GroupID = 11;
                document.UGroup = "10";
                document.PaymentType = vehicleLoanEntry.paymentMode;
                if (vehicleLoanEntry.customerId != 0)
                {
                    var cName = db.Customers.Where(x => x.id == vehicleLoanEntry.customerNameId).FirstOrDefault();
                    document.Description = cName.customerName;
                }
                document.Expenses = 0;
                document.Income = Convert.ToInt32(vehicleLoanEntry.documentAmount);
                document.Type = "Loan Entry";
                document.FinancialYear = "2020-2021";
                if (vehicleLoanEntry.InsuranceId != 0)
                {
                    var Insure = db.InsuranceCompanies.Where(x => x.id == vehicleLoanEntry.InsuranceId).FirstOrDefault();
                    document.CompanyName = Insure.name;
                }

                document.EntryTime = DateTime.UtcNow;
                document.DeleteTime = DateTime.UtcNow;
                db.TblMasters.Add(document);
                await db.SaveChangesAsync();
                ///////////////////////////////Commission Amount///////////
                TblMaster commision = new TblMaster();
                //tblMaster.id = vehicleLoanEntry.id;
                commision.EntryDate = (DateTime)vehicleLoanEntry.dateofAgreement;
                commision.AccountID = 34;
                commision.GroupID = 11;
                commision.UGroup = "10";
                commision.PaymentType = vehicleLoanEntry.paymentMode;
                if (vehicleLoanEntry.customerId != 0)
                {
                    var cName = db.Customers.Where(x => x.id == vehicleLoanEntry.customerNameId).FirstOrDefault();
                    commision.Description = cName.customerName;
                }
                commision.Expenses = 0;
                commision.Income = Convert.ToInt32(vehicleLoanEntry.commisionAmount);
                commision.Type = "Loan Entry";
                commision.FinancialYear = "2020-2021";
                if (vehicleLoanEntry.InsuranceId != 0)
                {
                    var Insure = db.InsuranceCompanies.Where(x => x.id == vehicleLoanEntry.InsuranceId).FirstOrDefault();
                    commision.CompanyName = Insure.name;
                }

                commision.EntryTime = DateTime.UtcNow;
                commision.DeleteTime = DateTime.UtcNow;
                db.TblMasters.Add(commision);
                await db.SaveChangesAsync();
                /////////////////////Intrest Amount///////////
                TblMaster intrest = new TblMaster();
                //tblMaster.id = vehicleLoanEntry.id;
                intrest.EntryDate = (DateTime)vehicleLoanEntry.dateofAgreement;
                intrest.AccountID = 43;
                intrest.GroupID = 11;
                intrest.UGroup = "10";
                intrest.PaymentType = vehicleLoanEntry.paymentMode;
                if (vehicleLoanEntry.customerId != 0)
                {
                    var cName = db.Customers.Where(x => x.id == vehicleLoanEntry.customerNameId).FirstOrDefault();
                    intrest.Description = cName.customerName;
                }
                intrest.Expenses = 0;
                intrest.Income = Convert.ToInt32(vehicleLoanEntry.amountOfIntrest);
                intrest.Type = "Loan Entry";
                intrest.FinancialYear = "2020-2021";
                if (vehicleLoanEntry.InsuranceId != 0)
                {
                    var Insure = db.InsuranceCompanies.Where(x => x.id == vehicleLoanEntry.InsuranceId).FirstOrDefault();
                    intrest.CompanyName = Insure.name;
                }

                intrest.EntryTime = DateTime.UtcNow;
                intrest.DeleteTime = DateTime.UtcNow;
                db.TblMasters.Add(intrest);
                //ending ///
                await db.SaveChangesAsync();
                int lastId = db.VehicleLoanEntries.Max(x => x.id);
                int ins = !string.IsNullOrEmpty(vehicleLoanEntry.numberOfInstallments) ? Convert.ToInt32(vehicleLoanEntry.numberOfInstallments) : 0;
                string firstDate = vehicleLoanEntry.dateOfDue.ToString();
                if (string.IsNullOrEmpty(firstDate))
                {
                    firstDate = DateTime.UtcNow.ToShortDateString();
                }
                decimal Dueamount, Instrest, totalAmount, loanamount = 0;

                Dueamount = !string.IsNullOrEmpty(vehicleLoanEntry.dueAmount) ? Convert.ToDecimal(vehicleLoanEntry.dueAmount) : 0;
                Instrest = !string.IsNullOrEmpty(vehicleLoanEntry.amountOfIntrest) ? Convert.ToDecimal(vehicleLoanEntry.amountOfIntrest) : 0;
                totalAmount = !string.IsNullOrEmpty(vehicleLoanEntry.totalAmount) ? Convert.ToDecimal(vehicleLoanEntry.totalAmount) : 0;
                loanamount = !string.IsNullOrEmpty(vehicleLoanEntry.amountOfLoan) ? Convert.ToInt32(vehicleLoanEntry.amountOfLoan) : 0;
                decimal instrestofAmount = !string.IsNullOrEmpty(vehicleLoanEntry.rateOfIntrestperentage) ? Convert.ToDecimal(vehicleLoanEntry.rateOfIntrestperentage) : 0; ;
                for (int i = 1; i <= ins; i++)
                {
                    if (vehicleLoanEntry.typeOfLoan == 1)
                    {
                        decimal dueamounts, instrests, totalAmounts, loanamounts = 0;
                        dueamounts = !string.IsNullOrEmpty(vehicleLoanEntry.totalDueAmount) ? Convert.ToDecimal(vehicleLoanEntry.totalDueAmount) : 0;
                        instrests = !string.IsNullOrEmpty(vehicleLoanEntry.amountOfIntrest) ? Convert.ToDecimal(vehicleLoanEntry.amountOfIntrest) : 0;
                        totalAmounts = !string.IsNullOrEmpty(vehicleLoanEntry.totalAmount) ? Convert.ToDecimal(vehicleLoanEntry.totalAmount) : 0;

                        loanamounts = !string.IsNullOrEmpty(vehicleLoanEntry.amountOfLoan) ? Convert.ToInt32(vehicleLoanEntry.amountOfLoan) : 0;
                        decimal loandue = dueamounts + (instrests * ins);
                        Installment newInstallment = new Installment();
                        newInstallment.dueAmount = (dueamounts).ToString();
                        newInstallment.dueStatus = "Pending";
                        newInstallment.DueDate = firstDate;
                        newInstallment.loanNumber = lastId;
                        newInstallment.numberofDue = i.ToString();
                        newInstallment.Intrest = (instrests).ToString();
                        newInstallment.loanAmount = (loanamounts).ToString();
                        newInstallment.totalAmount = (totalAmounts).ToString();
                        DateTime nextDate = Convert.ToDateTime(firstDate);
                        firstDate = nextDate.AddDays(30).ToString();
                        db.Installments.Add(newInstallment);
                    }
                    else
                    {

                        decimal interstVal = 0;
                        if (i != 1)
                        {
                            if (i <= ins)
                            {

                                loanamount = loanamount - Dueamount;
                                Instrest = (loanamount * instrestofAmount / 100) / 12;
                            }
                            totalAmount = loanamount;
                        }
                        decimal loandue = Dueamount + (Instrest * ins);
                        Installment newInstallment = new Installment();
                        newInstallment.dueAmount = (Dueamount + Instrest).ToString();
                        newInstallment.dueStatus = "Pending";
                        newInstallment.DueDate = firstDate;
                        newInstallment.loanNumber = lastId;
                        newInstallment.numberofDue = i.ToString();
                        newInstallment.Intrest = (Instrest).ToString();
                        newInstallment.totalAmount = (totalAmount).ToString();
                        newInstallment.loanAmount = (loanamount).ToString();
                        DateTime nextDate = Convert.ToDateTime(firstDate);
                        firstDate = nextDate.AddDays(30).ToString();
                        db.Installments.Add(newInstallment);
                    }
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.agentId = new SelectList(db.Agents, "id", "name", vehicleLoanEntry.agentId);
            ViewBag.areaId = new SelectList(db.Areas, "id", "name", vehicleLoanEntry.areaId);
            ViewBag.brokerId = new SelectList(db.Brokers, "id", "id", vehicleLoanEntry.brokerId);
            ViewBag.brokerNameId = new SelectList(db.Brokers, "id", "name", vehicleLoanEntry.brokerNameId);
            ViewBag.customerId = new SelectList(db.Customers, "id", "id", vehicleLoanEntry.customerId);
            ViewBag.customerNameId = new SelectList(db.Customers, "id", "customerName", vehicleLoanEntry.customerNameId);
            ViewBag.InsuranceId = new SelectList(db.InsuranceCompanies, "id", "name", vehicleLoanEntry.InsuranceId);
            ViewBag.shareHolderId = new SelectList(db.Shareholders, "id", "name", vehicleLoanEntry.shareHolderId);
            ViewBag.VehicleId = new SelectList(db.Vehicles, "id", "name", vehicleLoanEntry.VehicleId);
            ViewBag.paymentMode = new SelectList(db.AccountGroupings, "id", "accountGroup");
            return View(vehicleLoanEntry);
        }
        [HttpPost]
        public JsonResult customerName(int NAME)
        {
            if (NAME > 0)
            {
                var resp = db.Customers.Where(x => x.id == NAME).ToList();
                return Json(resp, JsonRequestBehavior.AllowGet);
            }
            else return Json("NoData", JsonRequestBehavior.AllowGet);
        }

        // GET: VehicleLoanEntries/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleLoanEntry vehicleLoanEntry = await db.VehicleLoanEntries.FindAsync(id);
            if (vehicleLoanEntry == null)
            {
                return HttpNotFound();
            }
            ViewBag.agentId = new SelectList(db.Agents, "id", "name", vehicleLoanEntry.agentId);
            ViewBag.areaId = new SelectList(db.Areas, "id", "name", vehicleLoanEntry.areaId);
            ViewBag.brokerId = new SelectList(db.Brokers, "id", "id", vehicleLoanEntry.brokerId);
            ViewBag.brokerNameId = new SelectList(db.Brokers, "id", "name", vehicleLoanEntry.brokerNameId);
            ViewBag.customerId = new SelectList(db.Customers, "id", "id", vehicleLoanEntry.customerId);
            ViewBag.customerNameId = new SelectList(db.Customers, "id", "customerName", vehicleLoanEntry.customerNameId);
            ViewBag.InsuranceId = new SelectList(db.InsuranceCompanies, "id", "name", vehicleLoanEntry.InsuranceId);
            ViewBag.shareHolderId = new SelectList(db.Shareholders, "id", "name", vehicleLoanEntry.shareHolderId);
            ViewBag.VehicleId = new SelectList(db.Vehicles, "id", "name", vehicleLoanEntry.VehicleId);
            ViewBag.paymentMode = new SelectList(db.AccountGroupings, "id", "accountGroup");
            return View(vehicleLoanEntry);
        }

        // POST: VehicleLoanEntries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,shareHolderId,customerId,customerNameId,fatherName,address,phoneNo,age,agentId,agentName,conductPerson,brokerId,brokerNameId,brokerAddress,brokerPhoneNo,areaId,areaName,guardianName,guardianAddress,guardianPhoneNo,dateofAgreement,dateOfDue,advanceEmi,paymentMode,checkNo,amountOfLoan,rateOfIntrestperentage,numberOfInstallments,amountOfIntrest,totalloanAmount,totalAmount,dueAmount,documentAmount,commisionAmount,InsuranceId,policyNo,policyAmount,premiumAmount,insuredNo,insureExpiryOn,policyReceived,vehicleNo,engineNo,chaseNo,registeredAt,registeredDate,rtoOfficeRefNO,endosmentOn,documentWith,VehicleId,vehicleName,vehicleColor,endosmentDone,totalDueAmount,duplicateKeyRecd,policyCircle,vehicleType,taxExpiryDate,permitExpiryDate,fcExpiryDate,insuranceExpityDate")] VehicleLoanEntry vehicleLoanEntry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicleLoanEntry).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.agentId = new SelectList(db.Agents, "id", "name", vehicleLoanEntry.agentId);
            ViewBag.areaId = new SelectList(db.Areas, "id", "name", vehicleLoanEntry.areaId);
            ViewBag.brokerId = new SelectList(db.Brokers, "id", "id", vehicleLoanEntry.brokerId);
            ViewBag.brokerNameId = new SelectList(db.Brokers, "id", "name", vehicleLoanEntry.brokerNameId);
            ViewBag.customerId = new SelectList(db.Customers, "id", "id", vehicleLoanEntry.customerId);
            ViewBag.customerNameId = new SelectList(db.Customers, "id", "customerName", vehicleLoanEntry.customerNameId);
            ViewBag.InsuranceId = new SelectList(db.InsuranceCompanies, "id", "name", vehicleLoanEntry.InsuranceId);
            ViewBag.shareHolderId = new SelectList(db.Shareholders, "id", "name", vehicleLoanEntry.shareHolderId);
            ViewBag.VehicleId = new SelectList(db.Vehicles, "id", "name", vehicleLoanEntry.VehicleId);
            ViewBag.paymentMode = new SelectList(db.AccountGroupings, "id", "accountGroup");
            return View(vehicleLoanEntry);
        }

        // GET: VehicleLoanEntries/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleLoanEntry vehicleLoanEntry = await db.VehicleLoanEntries.FindAsync(id);
            if (vehicleLoanEntry == null)
            {
                return HttpNotFound();
            }
            return View(vehicleLoanEntry);
        }

        // POST: VehicleLoanEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            VehicleLoanEntry vehicleLoanEntry = await db.VehicleLoanEntries.FindAsync(id);
            db.VehicleLoanEntries.Remove(vehicleLoanEntry);
            await db.SaveChangesAsync();
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
