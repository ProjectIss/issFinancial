namespace issFinacial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountGroups",
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
                        AccountName = c.String(),
                        accountgroupId = c.Int(nullable: false),
                        openingBalance = c.String(),
                        type = c.String(),
                        GroupName = c.String(),
                        ReceiptEntry_id = c.Int(),
                        VoucherEntry_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.AccountGroups", t => t.accountgroupId, cascadeDelete: true)
                .ForeignKey("dbo.ReceiptEntries", t => t.ReceiptEntry_id)
                .ForeignKey("dbo.VoucherEntries", t => t.VoucherEntry_id)
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
                        siNo = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Age = c.Int(nullable: false),
                        FatherName = c.String(),
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
                .ForeignKey("dbo.Areas", t => t.areaNameEnglishId, cascadeDelete: true)
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
                "dbo.Installments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        loanNumber = c.Int(nullable: false),
                        DueDate = c.String(),
                        dueStatus = c.String(),
                        dueAmount = c.String(),
                        Intrest = c.String(),
                        numberofDue = c.String(),
                        totalAmount = c.String(),
                        loanAmount = c.String(),
                        phoneNumbers = c.String(),
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
                "dbo.TblMasters",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        EntryDate = c.DateTime(nullable: false),
                        PaymentType = c.String(),
                        AccountID = c.Int(nullable: false),
                        GroupID = c.Int(nullable: false),
                        Description = c.String(),
                        Expenses = c.Int(nullable: false),
                        Income = c.Int(nullable: false),
                        UGroup = c.String(),
                        Type = c.String(),
                        FinancialYear = c.String(),
                        CompanyName = c.String(),
                        User = c.String(),
                        ETime = c.DateTime(),
                        DTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.VechicleLoanCollections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CollectionDate = c.DateTime(),
                        PaymentType = c.String(),
                        vehicleLoanId = c.Int(nullable: false),
                        DueStatus = c.String(),
                        Name = c.String(),
                        Address = c.String(),
                        PhoneNo = c.String(),
                        VehicleName = c.String(),
                        VechicleNumber = c.String(),
                        VehicleMake = c.String(),
                        NumberOfInstallmentsId = c.Int(nullable: false),
                        SelectDueNumberId = c.Int(nullable: false),
                        DueDate = c.DateTime(),
                        PrincipleAmount = c.Single(nullable: false),
                        IntrestAmount = c.Single(nullable: false),
                        DueAmount = c.Single(nullable: false),
                        TotaldueAmount = c.Single(nullable: false),
                        LateDays = c.String(),
                        LateDaysAmount = c.Single(nullable: false),
                        Penalty = c.String(),
                        Discount = c.Single(nullable: false),
                        NetAmount = c.Single(nullable: false),
                        MonthLoan = c.Single(nullable: false),
                        numberofDue_id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Installments", t => t.numberofDue_id)
                .ForeignKey("dbo.Installments", t => t.SelectDueNumberId, cascadeDelete: true)
                .ForeignKey("dbo.VehicleLoanEntries", t => t.vehicleLoanId, cascadeDelete: true)
                .Index(t => t.vehicleLoanId)
                .Index(t => t.SelectDueNumberId)
                .Index(t => t.numberofDue_id);

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
                    totalDueAmount = c.String(),
                    totalAmount = c.String(),
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
                    typeOfLoan = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.id);
               
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
            DropForeignKey("dbo.VechicleLoanCollections", "vehicleLoanId", "dbo.VehicleLoanEntries");
            DropForeignKey("dbo.VehicleLoanEntries", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.VehicleLoanEntries", "shareHolderId", "dbo.Shareholders");
            DropForeignKey("dbo.VehicleLoanEntries", "InsuranceId", "dbo.InsuranceCompanies");
            DropForeignKey("dbo.VehicleLoanEntries", "customerNameId", "dbo.Customers");
            DropForeignKey("dbo.VehicleLoanEntries", "customerId", "dbo.Customers");
            DropForeignKey("dbo.VehicleLoanEntries", "brokerNameId", "dbo.Brokers");
            DropForeignKey("dbo.VehicleLoanEntries", "brokerId", "dbo.Brokers");
            DropForeignKey("dbo.VehicleLoanEntries", "areaId", "dbo.Areas");
            DropForeignKey("dbo.VehicleLoanEntries", "agentId", "dbo.Agents");
            DropForeignKey("dbo.VechicleLoanCollections", "SelectDueNumberId", "dbo.Installments");
            DropForeignKey("dbo.VechicleLoanCollections", "numberofDue_id", "dbo.Installments");
            DropForeignKey("dbo.AccountLedgers", "ReceiptEntry_id", "dbo.ReceiptEntries");
            DropForeignKey("dbo.Customers", "areaNameEnglishId", "dbo.Areas");
            DropForeignKey("dbo.AccountLedgers", "accountgroupId", "dbo.AccountGroups");
            DropIndex("dbo.VehicleLoanEntries", new[] { "VehicleId" });
            DropIndex("dbo.VehicleLoanEntries", new[] { "InsuranceId" });
            DropIndex("dbo.VehicleLoanEntries", new[] { "areaId" });
            DropIndex("dbo.VehicleLoanEntries", new[] { "brokerNameId" });
            DropIndex("dbo.VehicleLoanEntries", new[] { "brokerId" });
            DropIndex("dbo.VehicleLoanEntries", new[] { "agentId" });
            DropIndex("dbo.VehicleLoanEntries", new[] { "customerNameId" });
            DropIndex("dbo.VehicleLoanEntries", new[] { "customerId" });
            DropIndex("dbo.VehicleLoanEntries", new[] { "shareHolderId" });
            DropIndex("dbo.VechicleLoanCollections", new[] { "numberofDue_id" });
            DropIndex("dbo.VechicleLoanCollections", new[] { "SelectDueNumberId" });
            DropIndex("dbo.VechicleLoanCollections", new[] { "vehicleLoanId" });
            DropIndex("dbo.Customers", new[] { "areaNameEnglishId" });
            DropIndex("dbo.AccountLedgers", new[] { "VoucherEntry_id" });
            DropIndex("dbo.AccountLedgers", new[] { "ReceiptEntry_id" });
            DropIndex("dbo.AccountLedgers", new[] { "accountgroupId" });
            DropTable("dbo.VoucherEntries");
            DropTable("dbo.Vehicles");
            DropTable("dbo.VehicleLoanEntries");
            DropTable("dbo.VechicleLoanCollections");
            DropTable("dbo.TblMasters");
            DropTable("dbo.Shareholders");
            DropTable("dbo.ReceiptEntries");
            DropTable("dbo.LoanEntries");
            DropTable("dbo.ItemMasters");
            DropTable("dbo.InsuranceCompanies");
            DropTable("dbo.Installments");
            DropTable("dbo.GramRates");
            DropTable("dbo.Customers");
            DropTable("dbo.Brokers");
            DropTable("dbo.Areas");
            DropTable("dbo.Agents");
            DropTable("dbo.AccountLedgers");
            DropTable("dbo.AccountGroups");
        }
    }
}
