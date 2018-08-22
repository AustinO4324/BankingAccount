namespace BankAccountNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix_term : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AccountDetails", "TermDepositID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AccountDetails", "TermDepositID");
        }
    }
}
