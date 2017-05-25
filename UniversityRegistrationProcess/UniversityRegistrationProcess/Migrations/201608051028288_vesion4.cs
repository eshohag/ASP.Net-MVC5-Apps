namespace UniversityRegistrationProcess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vesion4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false, maxLength: 500),
                        ContactNo = c.String(nullable: false),
                        Date = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentId);
            
            DropTable("dbo.AssignTeachers");
            DropTable("dbo.Courses");
            DropTable("dbo.Teachers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TeacherId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false, maxLength: 500),
                        ContactNo = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        DesignationId = c.String(nullable: false),
                        DepartmentId = c.String(nullable: false),
                        CriditToBeTaken = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.TeacherId);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 50),
                        Name = c.String(nullable: false),
                        Cridit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        SemesterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseId);
            
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
            
            DropTable("dbo.Students");
        }
    }
}
