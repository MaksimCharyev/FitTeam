using System.ComponentModel.DataAnnotations;
using System.Text.Json;
namespace FitTeamAPI.Models
{
    namespace Worker
    {
        public class Worker
        {
            [Key]
            public int UUID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string MiddleName { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
        }
        public class Worker_know_doc
        {
            [Key]
            public int WDID;
            public DateTime KnowledgeTime { get; set; }
            public Worker? Worker { get; set; }
            public int WorkerID { get; set; }
            public Document.Document? Document { get; set; }
            public int DocumentID { get; set; }
        }
        public class Worker_does_norm
        {
            [Key]
            public int WNID { get; set; }
            public Worker? Worker { get; set; }
            public int WorkerID { get; set; }
            public Norm.Norm? Norm { get; set; }
            public int NormID { get; set; }
            public DateTime NormTime { get; set; }
            public string Mark { get; set; }
            public Worker? Host { get; set; }
            public int HostID { get; set; }

        }
        public class Worker_has_role
        {
            [Key]
            public int WRID { get; set; }
            public Worker? Worker { get; set; }
            public Role.Role? Role { get; set; }
        }
        public class Worker_on_event
        {
            [Key]
            public int WEID { get; set; }
            public Worker? Worker { get; set; }
            public int WorkerID { get; set; }
            public Event.Event? Event { get; set; }
            public int EventID { get; set; }
        }
        public class Worker_complete_course
        {
            [Key]
            public int WCoID { get; set; }
            public Worker? Worker { get; set; }
            public int WorkerID { get; set; }
            public Course.Course? Course { get; set; }
            public int CourseID { get; set; }
            public DateTime DoneTime { get; set; }
            public string Mark { get; set; }

        }
        public class Worker_did_test
        {
            [Key]
            public int WTID { get; set; }
            public Worker? Worker { get; set; }
            public int WorkerID { get; set; }
            public TestNQuestions.Test? Test { get; set; }
            public int TestID { get; set; }
            public DateTime Begin { get; set; }
            public DateTime End { get; set; }
            public string Mark { get; set; }
        }
        public class Worker_has_comment
        {
            [Key]
            public int WCID { get; set; }
            public Worker? To { get; set; }
            public int ToID { get; set; }
            public Comment.Comment? Comment { get; set; }
            public int CommentID { get; set; }
            public Worker? From { get; set; }
            public int FromID { get; set; }

        }
    }
    namespace Role
    {
        public class Role
        {
            [Key]
            public int RoleID { get; set; }
            public string RoleName { get; set; }
            public string RoleDescription { get; set; }

        }
        public class Role_on_event
        {
            [Key]
            public int REID { get; set; }
        }
        public class Role_has_perm
        {
            public int RPID { get; set; }
        }
        public class Role_has_norm
        {
            public int RNID { get; set; }
        }
        public class Role_has_doc
        {
            public int RDID { get; set; }
        }
        public class Role_has_test
        {
            public int RTID { get; set; }
        }
        public class Role_has_course
        {
            public int RCoID { get; set; }
        }
    }
    namespace Permission
    {
        public class Permission
        {
            [Key]
            public int PermissionID { get; set; }
            public string PermissionName { get; set; }
            public string PermissionDescription { get; set; }
        }
        
    }
    namespace Subdivision
    {
        public class Subdivision
        {
            [Key]
            public int SubdivisionID { get; set; }
            public string SubdivisionName { get; set; }
            public string SubdivisionDescription { get; set; }
        }
        public class Subdivision_on_event
        {
            [Key]
            public int SEID { get; set; }
        }
        public class Subdivision_has_doc
        {
            public int SDID { get; set; }
        }
        public class Subdivision_has_test
        {
            public int STID { get; set; }
        }
        public class Subdivision_has_course
        {
            public int SCoID { get; set;}
        }
        public class Subdivision_has_norm
        {
            public int SNID { get; set; }
        }
        public class Subdivision_has_plan
        {
            public int SPID { get; set; }
        }
       
    }
    namespace Document
    {
        public class Document
        {
            [Key]
            public int DocumentID { get; set; }
            public string DocumentName { get; set; }
        }
        
    }
    namespace TestNQuestions
    {
        public class Test
        {
            [Key]
            public int TestID { get; set; }
            public string TestName { get; set; }
            public string TestDescription { get; set; }
            public DateTime CreationTime { get; set; }
            public bool isCertification { get; set; }
        }
        public class Test_has_question
        {
            [Key]
            public int TQID { get; set; }
        }
        public class Question
        {
            [Key]
            public int QuestionID { get; set; }
            public string QuestionDescription { get; set; }
            public int QuestionType { get; set; }
            public string Answers { get; set; }

        }
    }
    namespace Event
    {
        public class Event
        {
            [Key]
            public int EventID { get; set; }
            public string EventName { get; set; }
            public string EventDescription { get; set; }
            public DateTime EventTime { get; set; }
        }
       
    }
    namespace SalePlan
    {
        public class SalePlan
        {
            [Key]
            public int SalePlanID { get; set; }
            public string SalePlanName { get; set; }
            public string URL { get; set; }
        }
    }
    namespace Comment
    {
        public class Comment
        {
            [Key]
            public int CommentID { get; set; }
            public string CommentDescription { get; set; }
            public int CommentType { get; set; }
            public bool IsClosed { get; set; }
        }
    }
    namespace Norm
    {
        public class Norm
        {
            [Key]
            public int NormID { get; set; }
            public string NormName { get; set; }
            public string NormDescription { get; set; }
        }
    }
    namespace Course
    {
        public class Course
        {
            [Key]
            public int CourseID { get; set; }
            public string CourseName { get; set; }
            public DateTime CreationTime { get; set; }
            public DateTime DeadLine { get; set; }
            public JsonDocument JsonCourse { get; set; }
        }
    }
}
