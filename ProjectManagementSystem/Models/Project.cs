using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagementSystem.Models
{
    public class Project
    {
        [Key]
        public int PrjctId { get; set; }

        public string PrjctTitle { get; set; }
        public string PrjctDesc { get; set; }
        public int ProjectVelueId { get; set; }
        public ProjectVelue ProjectVelue { get; set; }
        public int ProjctManadger { get; set; }
        public int ProjctWorkgroup { get; set; }
        public string PrjctCustomer { get; set; }
        public string PrjctExecuter { get; set; }
        public DateTime PrjctBegining {get; set;}
        public DateTime PrjctEnding { get; set; }
        public string PrjctStatus { get; set; }
        public Employee Employee { get; set; }
       
    }
}