namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_changeNameContentValue : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contents", "ContentValue", c => c.String(maxLength: 1000));
            DropColumn("dbo.Contents", "ContentName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contents", "ContentName", c => c.String(maxLength: 1000));
            DropColumn("dbo.Contents", "ContentValue");
        }
    }
}
