namespace issFinacial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountGroupings",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        accountGroup = c.String(),
                        parentGroup = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.AccountLedgers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ledger = c.String(),
                        accountgroupId = c.Int(nullable: false),
                        openingBalance = c.String(),
                        type = c.String(),
                        ReceiptEntry_id = c.Int(),
                        VoucherEntry_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                //.ForeignKey("dbo.AccountGroupings", t => t.accountgroupId, cascadeDelete: true)
                //.ForeignKey("dbo.ReceiptEntries", t => t.ReceiptEntry_id)
                //.ForeignKey("dbo.VoucherEntries", t => t.VoucherEntry_id)
                .Index(t => t.accountgroupId)
                .Index(t => t.ReceiptEntry_id)
                .Index(t => t.VoucherEntry_id);
            
            CreateTable(
                "dbo.Agents",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        address = c.String(),
                        cellNo = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Areas",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Brokers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        address = c.String(),
                        cellNo = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        siNo = c.String(),
                        customerNameTamil = c.String(),
                        customerName = c.String(),
                        customerRelation = c.String(),
                        customerAddressTamil = c.String(),
                        customerAddress = c.String(),
                        permanantAddressTamil = c.String(),
                        permanantAddress = c.String(),
                        areaNameTamil = c.String(),
                        areaNameEnglishId = c.Int(nullable: false),
                        contactNo = c.String(),
                        introduceName = c.String(),
                        identityProof = c.String(),
                        identityNumber = c.String(),
                        customerType = c.String(),
                        dateofJoin = c.String(),
                        nomineeName = c.String(),
                        nomineeAddress = c.String(),
                        nomineeNumber = c.String(),
                        starRate = c.String(),
                        remark = c.String(),
                        thump = c.String(),
                        memberImage = c.String(),
                        itemImage = c.String(),
                        nomineeImage = c.String(),
                        memberSignatureImage = c.String(),
                        nomineeSignatureImage = c.String(),
                    })
                .PrimaryKey(t => t.id)
                //.ForeignKey("dbo.Areas", t => t.areaNameEnglishId, cascadeDelete: true)
                .Index(t => t.areaNameEnglishId);
            
            CreateTable(
                "dbo.GramRates",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        date = c.String(),
                        gramRate = c.String(),
                        itemType = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.InsuranceCompanies",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.ItemMasters",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        itemName = c.String(),
                        itemNameTamil = c.String(),
                        itemType = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.LoanEntries",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        code = c.String(),
                        name = c.String(),
                        fatherName = c.String(),
                        address = c.String(),
                        areaName = c.String(),
                        identityproof = c.String(),
                        type = c.String(),
                        loanDate = c.DateTime(),
                        billNo = c.String(),
                        sNo = c.String(),
                        itemName = c.String(),
                        itemType = c.String(),
                        gramValue = c.String(),
                        queality = c.String(),
                        grossWeight = c.String(),
                        netWeight = c.String(),
                        itemValue = c.String(),
                        totalGrams = c.String(),
                        value = c.String(),
                        principle = c.String(),
                        intrest = c.String(),
                        intrestAmount = c.String(),
                        deducation = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.ReceiptEntries",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        No = c.String(),
                        date = c.DateTime(),
                        type = c.String(),
                        name = c.String(),
                        amount = c.String(),
                        description = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Shareholders",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        address = c.String(),
                        phoneNo = c.String(),
                        date = c.DateTime(),
                        amount = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.VehicleLoanEntries",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        shareHolderId = c.Int(nullable: false),
                        customerId = c.Int(nullable: false),
                        customerNameId = c.Int(nullable: false),
                        fatherName = c.String(),
                        address = c.String(),
                        phoneNo = c.String(),
                        age = c.String(),
                        agentId = c.Int(nullable: false),
                        agentName = c.String(),
                        conductPerson = c.String(),
                        brokerId = c.Int(nullable: false),
                        brokerNameId = c.Int(nullable: false),
                        brokerAddress = c.String(),
                        brokerPhoneNo = c.String(),
                        areaId = c.Int(nullable: false),
                        areaName = c.String(),
                        guardianName = c.String(),
                        guardianAddress = c.String(),
                        guardianPhoneNo = c.String(),
                        dateofAgreement = c.DateTime(),
                        dateOfDue = c.DateTime(),
                        advanceEmi = c.String(),
                        paymentMode = c.String(),
                        checkNo = c.String(),
                        amountOfLoan = c.String(),
                        rateOfIntrestperentage = c.String(),
                        numberOfInstallments = c.String(),
                        amountOfIntrest = c.String(),
                        totalloanAmount = c.String(),
                        dueAmount = c.String(),
                        documentAmount = c.String(),
                        commisionAmount = c.String(),
                        InsuranceId = c.Int(nullable: false),
                        policyNo = c.String(),
                        policyAmount = c.String(),
                        premiumAmount = c.String(),
                        insuredNo = c.DateTime(),
                        insureExpiryOn = c.DateTime(),
                        policyReceived = c.String(),
                        vehicleNo = c.String(),
                        engineNo = c.String(),
                        chaseNo = c.String(),
                        registeredAt = c.String(),
                        registeredDate = c.DateTime(),
                        rtoOfficeRefNO = c.String(),
                        endosmentOn = c.DateTime(),
                        documentWith = c.String(),
                        VehicleId = c.Int(nullable: false),
                        vehicleName = c.String(),
                        vehicleColor = c.String(),
                        endosmentDone = c.String(),
                        duplicateKeyRecd = c.String(),
                        policyCircle = c.String(),
                        vehicleType = c.String(),
                        taxExpiryDate = c.DateTime(),
                        permitExpiryDate = c.DateTime(),
                        fcExpiryDate = c.DateTime(),
                        insuranceExpityDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.id)
                //.ForeignKey("dbo.Agents", t => t.agentId, cascadeDelete: true)
                //.ForeignKey("dbo.Areas", t => t.areaId, cascadeDelete: true)
                //.ForeignKey("dbo.Brokers", t => t.brokerId, cascadeDelete: true)
                //.ForeignKey("dbo.Brokers", t => t.brokerNameId, cascadeDelete: true)
                //.ForeignKey("dbo.Customers", t => t.customerId, cascadeDelete: true)
                //.ForeignKey("dbo.Customers", t => t.customerNameId, cascadeDelete: true)
                //.ForeignKey("dbo.InsuranceCompanies", t => t.InsuranceId, cascadeDelete: true)
                //.ForeignKey("dbo.Shareholders", t => t.shareHolderId, cascadeDelete: true)
                //.ForeignKey("dbo.Vehicles", t => t.VehicleId, cascadeDelete: true)
                .Index(t => t.shareHolderId)
                .Index(t => t.customerId)
                .Index(t => t.customerNameId)
                .Index(t => t.agentId)
                .Index(t => t.brokerId)
                .Index(t => t.brokerNameId)
                .Index(t => t.areaId)
                .Index(t => t.InsuranceId)
                .Index(t => t.VehicleId);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.VoucherEntries",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        No = c.String(),
                        name = c.String(),
                        date = c.DateTime(),
                        type = c.String(),
                        description = c.String(),
                        amount = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AccountLedgers", "VoucherEntry_id", "dbo.VoucherEntries");
            DropForeignKey("dbo.VehicleLoanEntries", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.VehicleLoanEntries", "shareHolderId", "dbo.Shareholders");
            DropForeignKey("dbo.VehicleLoanEntries", "InsuranceId", "dbo.InsuranceCompanies");
            DropForeignKey("dbo.VehicleLoanEntries", "customerNameId", "dbo.Customers");
            DropForeignKey("dbo.VehicleLoanEntries", "customerId", "dbo.Customers");
            DropForeignKey("dbo.VehicleLoanEntries", "brokerNameId", "dbo.Brokers");
            DropForeignKey("dbo.VehicleLoanEntries", "brokerId", "dbo.Brokers");
            DropForeignKey("dbo.VehicleLoanEntries", "areaId", "dbo.Areas");
            DropForeignKey("dbo.VehicleLoanEntries", "agentId", "dbo.Agents");
            DropForeignKey("dbo.AccountLedgers", "ReceiptEntry_id", "dbo.ReceiptEntries");
            DropForeignKey("dbo.Customers", "areaNameEnglishId", "dbo.Areas");
            DropForeignKey("dbo.AccountLedgers", "accountgroupId", "dbo.AccountGroupings");
            DropIndex("dbo.VehicleLoanEntries", new[] { "VehicleId" });
            DropIndex("dbo.VehicleLoanEntries", new[] { "InsuranceId" });
            DropIndex("dbo.VehicleLoanEntries", new[] { "areaId" });
            DropIndex("dbo.VehicleLoanEntries", new[] { "brokerNameId" });
            DropIndex("dbo.VehicleLoanEntries", new[] { "brokerId" });
            DropIndex("dbo.VehicleLoanEntries", new[] { "agentId" });
            DropIndex("dbo.VehicleLoanEntries", new[] { "customerNameId" });
            DropIndex("dbo.VehicleLoanEntries", new[] { "customerId" });
            DropIndex("dbo.VehicleLoanEntries", new[] { "shareHolderId" });
            DropIndex("dbo.Customers", new[] { "areaNameEnglishId" });
            DropIndex("dbo.AccountLedgers", new[] { "VoucherEntry_id" });
            DropIndex("dbo.AccountLedgers", new[] { "ReceiptEntry_id" });
            DropIndex("dbo.AccountLedgers", new[] { "accountgroupId" });
            DropTable("dbo.VoucherEntries");
            DropTable("dbo.Vehicles");
            DropTable("dbo.VehicleLoanEntries");
            DropTable("dbo.Shareholders");
            DropTable("dbo.ReceiptEntries");
            DropTable("dbo.LoanEntries");
            DropTable("dbo.ItemMasters");
            DropTable("dbo.InsuranceCompanies");
            DropTable("dbo.GramRates");
            DropTable("dbo.Customers");
            DropTable("dbo.Brokers");
            DropTable("dbo.Areas");
            DropTable("dbo.Agents");
            DropTable("dbo.AccountLedgers");
            DropTable("dbo.AccountGroupings");
        }
    }
}
