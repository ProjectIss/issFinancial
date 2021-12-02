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
            var vehicleLoanEntries = db.VehicleLoanEntries.Include(v => v.agent).Include(v => v.area).Include(v => v.broker).Include(v => v.brokerName).Include(v => v.Customer).Include(v => v.customerName).Include(v => v.Insurance).Include(v => v.shareHoldere).Include(v => v.vehicle).OrderByDescending(x => x.id);
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
            ViewBag.brokerId = new SelectList(db.Brokers, "id", "name");
            ViewBag.brokerNameId = new SelectList(db.Brokers, "id", "name");
            ViewBag.customerId = new SelectList(db.Customers, "id", "customerName");
            ViewBag.customerNameId = new SelectList(db.Customers, "id", "customerName");
            ViewBag.InsuranceId = new SelectList(db.InsuranceCompanies, "id", "name");
            ViewBag.shareHolderId = new SelectList(db.Shareholders, "id", "name");
            ViewBag.VehicleId = new SelectList(db.Vehicles, "id", "name");
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
                        newInstallment.loanNumber = lastId.ToString();
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
                                
                                loanamount = loanamount - Dueamount ;
                                Instrest = (loanamount * instrestofAmount / 100) / 12;
                            }
                            totalAmount = loanamount;
                        }
                        decimal loandue = Dueamount + (Instrest * ins);
                        Installment newInstallment = new Installment();
                        newInstallment.dueAmount = (Dueamount + Instrest).ToString();
                        newInstallment.dueStatus = "Pending";
                        newInstallment.DueDate = firstDate;
                        newInstallment.loanNumber = lastId.ToString();
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
            ViewBag.brokerId = new SelectList(db.Brokers, "id", "name", vehicleLoanEntry.brokerId);
            ViewBag.brokerNameId = new SelectList(db.Brokers, "id", "name", vehicleLoanEntry.brokerNameId);
            ViewBag.customerId = new SelectList(db.Customers, "id", "customerName", vehicleLoanEntry.customerId);
            ViewBag.customerNameId = new SelectList(db.Customers, "id", "customerName", vehicleLoanEntry.customerNameId);
            ViewBag.InsuranceId = new SelectList(db.InsuranceCompanies, "id", "name", vehicleLoanEntry.InsuranceId);
            ViewBag.shareHolderId = new SelectList(db.Shareholders, "id", "name", vehicleLoanEntry.shareHolderId);
            ViewBag.VehicleId = new SelectList(db.Vehicles, "id", "name", vehicleLoanEntry.VehicleId);
            return View(vehicleLoanEntry);
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
            ViewBag.brokerId = new SelectList(db.Brokers, "id", "name", vehicleLoanEntry.brokerId);
            ViewBag.brokerNameId = new SelectList(db.Brokers, "id", "name", vehicleLoanEntry.brokerNameId);
            ViewBag.customerId = new SelectList(db.Customers, "id", "customerName", vehicleLoanEntry.customerId);
            ViewBag.customerNameId = new SelectList(db.Customers, "id", "customerName", vehicleLoanEntry.customerNameId);
            ViewBag.InsuranceId = new SelectList(db.InsuranceCompanies, "id", "name", vehicleLoanEntry.InsuranceId);
            ViewBag.shareHolderId = new SelectList(db.Shareholders, "id", "name", vehicleLoanEntry.shareHolderId);
            ViewBag.VehicleId = new SelectList(db.Vehicles, "id", "name", vehicleLoanEntry.VehicleId);
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
            ViewBag.brokerId = new SelectList(db.Brokers, "id", "name", vehicleLoanEntry.brokerId);
            ViewBag.brokerNameId = new SelectList(db.Brokers, "id", "name", vehicleLoanEntry.brokerNameId);
            ViewBag.customerId = new SelectList(db.Customers, "id", "customerName", vehicleLoanEntry.customerId);
            ViewBag.customerNameId = new SelectList(db.Customers, "id", "customerName", vehicleLoanEntry.customerNameId);
            ViewBag.InsuranceId = new SelectList(db.InsuranceCompanies, "id", "name", vehicleLoanEntry.InsuranceId);
            ViewBag.shareHolderId = new SelectList(db.Shareholders, "id", "name", vehicleLoanEntry.shareHolderId);
            ViewBag.VehicleId = new SelectList(db.Vehicles, "id", "name", vehicleLoanEntry.VehicleId);
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
