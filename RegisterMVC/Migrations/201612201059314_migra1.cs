namespace RegisterMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migra1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GradeList",
                c => new
                    {
                        GradeListID = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GradeListID);
            
            CreateTable(
                "dbo.Grade",
                c => new
                    {
                        GradeID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Weight = c.Int(nullable: false),
                        DateGrade = c.DateTime(nullable: false),
                        MySubjectID = c.Int(nullable: false),
                        StudentID = c.Int(nullable: false),
                        GradeListID = c.Int(nullable: false),
                        Teacher_TeacherID = c.Int(),
                    })
                .PrimaryKey(t => t.GradeID)
                .ForeignKey("dbo.GradeList", t => t.GradeListID, cascadeDelete: true)
                .ForeignKey("dbo.Student", t => t.StudentID, cascadeDelete: true)
                .ForeignKey("dbo.Teacher", t => t.Teacher_TeacherID)
                .Index(t => t.StudentID)
                .Index(t => t.GradeListID)
                .Index(t => t.Teacher_TeacherID);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        StudentID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        SClassID = c.Int(nullable: false),
                        ParentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentID)
                .ForeignKey("dbo.Parent", t => t.ParentID, cascadeDelete: true)
                .ForeignKey("dbo.SClass", t => t.SClassID, cascadeDelete: true)
                .Index(t => t.SClassID)
                .Index(t => t.ParentID);
            
            CreateTable(
                "dbo.Parent",
                c => new
                    {
                        ParentID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                    })
                .PrimaryKey(t => t.ParentID);
            
            CreateTable(
                "dbo.SClass",
                c => new
                    {
                        SClassID = c.Int(nullable: false),
                        Name = c.String(),
                        TeacherID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SClassID)
                .ForeignKey("dbo.Teacher", t => t.SClassID)
                .Index(t => t.SClassID);
            
            CreateTable(
                "dbo.Subject",
                c => new
                    {
                        SubjectID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MySubjectID = c.Int(nullable: false),
                        SClassID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubjectID);
            
            CreateTable(
                "dbo.MySubject",
                c => new
                    {
                        MySubjectID = c.Int(nullable: false, identity: true),
                        TeacherID = c.Int(nullable: false),
                        SubjectID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MySubjectID)
                .ForeignKey("dbo.Subject", t => t.SubjectID, cascadeDelete: true)
                .ForeignKey("dbo.Teacher", t => t.TeacherID, cascadeDelete: true)
                .Index(t => t.TeacherID)
                .Index(t => t.SubjectID);
            
            CreateTable(
                "dbo.Teacher",
                c => new
                    {
                        TeacherID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SClassID = c.Int(),
                    })
                .PrimaryKey(t => t.TeacherID);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        NewsID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        TeacherID = c.String(),
                        Teacher_TeacherID = c.Int(),
                    })
                .PrimaryKey(t => t.NewsID)
                .ForeignKey("dbo.Teacher", t => t.Teacher_TeacherID)
                .Index(t => t.Teacher_TeacherID);
            
            CreateTable(
                "dbo.Question",
                c => new
                    {
                        QuestionID = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        GoodAnswer = c.String(),
                        BadAnswer = c.String(),
                        Points = c.Int(nullable: false),
                        TeacherID = c.Int(nullable: false),
                        QuizID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuestionID)
                .ForeignKey("dbo.Quiz", t => t.QuizID, cascadeDelete: true)
                .ForeignKey("dbo.Teacher", t => t.TeacherID, cascadeDelete: true)
                .Index(t => t.TeacherID)
                .Index(t => t.QuizID);
            
            CreateTable(
                "dbo.Quiz",
                c => new
                    {
                        QuizID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Timer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuizID);
            
            CreateTable(
                "dbo.SubjectSClass",
                c => new
                    {
                        Subject_SubjectID = c.Int(nullable: false),
                        SClass_SClassID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Subject_SubjectID, t.SClass_SClassID })
                .ForeignKey("dbo.Subject", t => t.Subject_SubjectID, cascadeDelete: true)
                .ForeignKey("dbo.SClass", t => t.SClass_SClassID, cascadeDelete: true)
                .Index(t => t.Subject_SubjectID)
                .Index(t => t.SClass_SClassID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SClass", "SClassID", "dbo.Teacher");
            DropForeignKey("dbo.SubjectSClass", "SClass_SClassID", "dbo.SClass");
            DropForeignKey("dbo.SubjectSClass", "Subject_SubjectID", "dbo.Subject");
            DropForeignKey("dbo.MySubject", "TeacherID", "dbo.Teacher");
            DropForeignKey("dbo.Question", "TeacherID", "dbo.Teacher");
            DropForeignKey("dbo.Question", "QuizID", "dbo.Quiz");
            DropForeignKey("dbo.News", "Teacher_TeacherID", "dbo.Teacher");
            DropForeignKey("dbo.Grade", "Teacher_TeacherID", "dbo.Teacher");
            DropForeignKey("dbo.MySubject", "SubjectID", "dbo.Subject");
            DropForeignKey("dbo.Student", "SClassID", "dbo.SClass");
            DropForeignKey("dbo.Student", "ParentID", "dbo.Parent");
            DropForeignKey("dbo.Grade", "StudentID", "dbo.Student");
            DropForeignKey("dbo.Grade", "GradeListID", "dbo.GradeList");
            DropIndex("dbo.SubjectSClass", new[] { "SClass_SClassID" });
            DropIndex("dbo.SubjectSClass", new[] { "Subject_SubjectID" });
            DropIndex("dbo.Question", new[] { "QuizID" });
            DropIndex("dbo.Question", new[] { "TeacherID" });
            DropIndex("dbo.News", new[] { "Teacher_TeacherID" });
            DropIndex("dbo.MySubject", new[] { "SubjectID" });
            DropIndex("dbo.MySubject", new[] { "TeacherID" });
            DropIndex("dbo.SClass", new[] { "SClassID" });
            DropIndex("dbo.Student", new[] { "ParentID" });
            DropIndex("dbo.Student", new[] { "SClassID" });
            DropIndex("dbo.Grade", new[] { "Teacher_TeacherID" });
            DropIndex("dbo.Grade", new[] { "GradeListID" });
            DropIndex("dbo.Grade", new[] { "StudentID" });
            DropTable("dbo.SubjectSClass");
            DropTable("dbo.Quiz");
            DropTable("dbo.Question");
            DropTable("dbo.News");
            DropTable("dbo.Teacher");
            DropTable("dbo.MySubject");
            DropTable("dbo.Subject");
            DropTable("dbo.SClass");
            DropTable("dbo.Parent");
            DropTable("dbo.Student");
            DropTable("dbo.Grade");
            DropTable("dbo.GradeList");
        }
    }
}
