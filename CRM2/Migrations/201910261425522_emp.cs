namespace CRM2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class emp : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Emp_Salary",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Vacation = c.String(),
                        Employee_ID = c.Int(nullable: false),
                        Month = c.DateTime(nullable: false),
                        Year = c.DateTime(nullable: false),
                        salary = c.Int(nullable: false),
                        Wage = c.Int(nullable: false),
                        Net = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Employee_data", t => t.Employee_ID, cascadeDelete: true)
                .Index(t => t.Employee_ID);
            
            CreateTable(
                "dbo.Employee_data",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Insurance_number = c.Int(nullable: false),
                        Job_Title = c.String(),
                        Full_Name = c.String(nullable: false, maxLength: 100),
                        Gender = c.String(),
                        Street = c.String(),
                        Date_of_birth = c.DateTime(nullable: false),
                        Post_number = c.Int(nullable: false),
                        Landline_Number = c.Int(nullable: false),
                        Email = c.String(),
                        Phone_Mobile = c.String(nullable: false),
                        Mobile = c.String(),
                        Nationality = c.String(),
                        Country_proof_of_personality = c.String(),
                        Personal_identification_number = c.Int(nullable: false),
                        Type_of_proof_of_personality = c.String(),
                        Work_Permit = c.String(),
                        Social_Security = c.String(),
                        Bank = c.String(),
                        Valid_to_date = c.DateTime(nullable: false),
                        Address = c.String(nullable: false, maxLength: 100),
                        Identification_Card = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Personal_Status",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Employee_ID = c.Int(nullable: false),
                        Status = c.String(),
                        From = c.DateTime(nullable: false),
                        To = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Employee_data", t => t.Employee_ID, cascadeDelete: true)
                .Index(t => t.Employee_ID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Emp_Salary", "Employee_ID", "dbo.Employee_data");
            DropForeignKey("dbo.Personal_Status", "Employee_ID", "dbo.Employee_data");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Personal_Status", new[] { "Employee_ID" });
            DropIndex("dbo.Emp_Salary", new[] { "Employee_ID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Personal_Status");
            DropTable("dbo.Employee_data");
            DropTable("dbo.Emp_Salary");
        }
    }
}
