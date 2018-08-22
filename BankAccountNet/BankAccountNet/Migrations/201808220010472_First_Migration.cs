namespace BankAccountNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First_Migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountDetails",
                c => new
                    {
                        AccountID = c.Int(nullable: false, identity: true),
                        AccountType = c.String(nullable: false, maxLength: 20),
                        CreationDate = c.DateTime(nullable: false),
                        Balance = c.Double(nullable: false),
                        CustomerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccountID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 20),
                        LastName = c.String(maxLength: 20),
                        UserID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.Loans",
                c => new
                    {
                        LoanId = c.Int(nullable: false, identity: true),
                        LoanAmount = c.Double(nullable: false),
                        CustomerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LoanId)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.TermDeposits",
                c => new
                    {
                        TermDepositID = c.Int(nullable: false, identity: true),
                        Deposit = c.Double(nullable: false),
                        TermCreation = c.DateTime(nullable: false),
                        AccountDetail_AccountID = c.Int(),
                    })
                .PrimaryKey(t => t.TermDepositID)
                .ForeignKey("dbo.AccountDetails", t => t.AccountDetail_AccountID)
                .Index(t => t.AccountDetail_AccountID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TermDeposits", "AccountDetail_AccountID", "dbo.AccountDetails");
            DropForeignKey("dbo.Loans", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.AccountDetails", "CustomerID", "dbo.Customers");
            DropIndex("dbo.TermDeposits", new[] { "AccountDetail_AccountID" });
            DropIndex("dbo.Loans", new[] { "CustomerID" });
            DropIndex("dbo.AccountDetails", new[] { "CustomerID" });
            DropTable("dbo.TermDeposits");
            DropTable("dbo.Loans");
            DropTable("dbo.Customers");
            DropTable("dbo.AccountDetails");
        }
    }
}
