namespace UniversityRegistrationProcess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssignTeachers",
                c => new
                    {
                        CourseAssignTeacherId = c.Int(nullable: false, identity: true),
                        DepartmentId = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: false),
                        CreditTaken = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RemainingCredit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CourseCode = c.String(nullable: false),
                        Name = c.String(),
                        Credit = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.CourseAssignTeacherId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AssignTeachers");
        }
    }
}
