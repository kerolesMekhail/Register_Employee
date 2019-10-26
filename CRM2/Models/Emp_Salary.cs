using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CRM2.Models
{
    public class Emp_Salary
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Vacation { get; set; }
        [ForeignKey("employee_data")]
        public int Employee_ID { get; set; }

        [DataType(DataType.Date)]
        public DateTime Month { get; set; }
        [DataType(DataType.Date)]
        public DateTime Year { get; set; }

        public int salary { get; set; }
        public int Wage { get; set; }
        public int Net { get; set; }

        public virtual Employee_data employee_data { get; set; }

    }
}