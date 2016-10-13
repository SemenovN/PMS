using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagementSystem.Models
{
    public class ProjectVelue
    {
        [Key]
        public int ProjectVelueId { get; set; }

        public int StatusVel { get; set; }
    }
}