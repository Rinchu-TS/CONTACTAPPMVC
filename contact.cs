using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CONTACTAPPMVC.Models
{
    public class contact
    {   public int Id { get; set; }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        [StringLength(7)]
        public string DialCode { get; set; }
        [StringLength(10)]
        public string Number { get; set; }

        public string Address { get; set; }    }
    public class MVCF : DbContext
    {       public DbSet<contact> contacts { get; set; }    }}