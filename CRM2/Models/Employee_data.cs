using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CRM2.Models
{
    public class Employee_data
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int Insurance_number{ get; set; }

        public string Job_Title { get; set; }

        [Required(ErrorMessage = "Please Enter Full Name "), MaxLength(100)]
        public string Full_Name { get; set; }

        public string Gender { get; set; }

        public string Street { get; set; }

        [Display(Name = "Date of Birthday")]
        [DataType(DataType.Date)]
        public DateTime Date_of_birth { get; set; }

        public int Post_number{ get; set; }

        public int Landline_Number { get; set; }

        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$",
                              ErrorMessage = "Entered Email format is not valid.")]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number Required!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                   ErrorMessage = "Entered phone format is not valid.")]
        public string Phone_Mobile { get; set; }

        public string Mobile { get; set; }



        public string Nationality{ get; set; }

        [Display(Name = "Country proof of personality")]
        public string Country_proof_of_personality{ get; set; }

        [Display(Name = "Personal identification number")]
        public int Personal_identification_number{ get; set; }

        [Display(Name = " Type of proof of personality")]
        public string Type_of_proof_of_personality{ get; set; }

        [Display(Name = "Work Permit")]
        public string Work_Permit { get; set; }

        [Display(Name = "Social Security")]
        public string Social_Security{ get; set; }

        public string Bank { get; set; }

        [Display(Name = "Valid to date")]
        [DataType(DataType.Date)]
        public DateTime Valid_to_date{ get; set; }

        [Required(ErrorMessage = "Please enter Address"), MaxLength(100)]
        public string Address { get; set; }

        [Display(Name = "Identification Card")]
        public string Identification_Card { get; set; }

        

        
                public virtual ICollection<Emp_Salary> emp_Salary { get; set; }
        public virtual ICollection<Personal_Status> personal_status { get; set; }

    }
}