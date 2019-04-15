using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Application
    {
        public int ApplicationID { get; set; }

        [Required(ErrorMessage = "Please provide the Unit ID")]
        [Display(Name = "Enter The Unit ID: ")]
        public int UnitID { get; set; }

        [Required(ErrorMessage = "Please provide your First Name")]
        [Display(Name = "Enter your First Name: ")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please provide your Last Name")]
        [Range(1, 999999999, ErrorMessage = "Please provide a valid SSN")]
        [Display(Name = "Enter your Last Name: ")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please provide a Social Security Number")]
        [Display(Name = "Enter your Social Security: ")]
        public int SocialSecurityNumber { get; set; }

        [Required(ErrorMessage = "Please provide Phone Number")]
        [Display(Name = "Enter your Phone Number: ")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please provide Email Address")]
        [Display(Name = "Enter your Email Address: ")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Please provide Landlord Name")]
        [Display(Name = "Enter the Name of your previous/current Landlord: ")]
        public string LastResidenceOwner { get; set; }

        [Required(ErrorMessage = "Please provide Contact Number for Landlord")]
        [Display(Name = "Enter previous Landlord's Contact Number: ")]
        public string LastResidenceContactPhoneNumber { get; set; }

        [Required(ErrorMessage = "Please provide lease Start Date")]
        [Display(Name = "Enter previous lease Start Date: ")]
        public string LastResidenceTenancyStartDate { get; set; }

        [Required(ErrorMessage = "Please provide lease End Date")]
        [Display(Name = "Enter previous lease End Date: ")]
        public string LastResidenceTenancyEndDate { get; set; }

        [Required(ErrorMessage = "Please provide an Employment Status")]
        [Display(Name = "Enter current Employment Status: ")]
        public bool EmploymentStatus { get; set; }

        [Required(ErrorMessage = "Please provide Employer Name")]
        [Display(Name = "Enter Employer Name: ")]
        public string EmployerName { get; set; }

        [Required(ErrorMessage = "Please provide Employer Contact Number")]
        [Display(Name = "Enter Employer Contact Number: ")]
        public string EmployerContactPhoneNumber { get; set; }

        [Required(ErrorMessage = "Please provide Annual Income")]
        [Display(Name = "Enter Annual Income: ")]
        public string AnnualIncome { get; set; }

        [Required(ErrorMessage = "Please provide number of Residents")]
        [Display(Name = "Enter Number of Residents: ")]
        public int NumberOfResidents { get; set; }

        [Required(ErrorMessage = "Please provide number of Cats")]
        [Display(Name = "Enter Number of Cats: ")]
        public int NumberOfCats { get; set; }

        [Required(ErrorMessage = "Please provide number of Dogs")]
        [Display(Name = "Enter Number of Dogs: ")]
        public int NumberOfDogs { get; set; }

        public bool ApplicationApprovalStatus { get; set; }
    }
}
