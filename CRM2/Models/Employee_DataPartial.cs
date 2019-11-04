using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CRM2.Models
{
    public partial class Employee_data
    {
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}