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

        [Required(ErrorMessage = "A unit ID is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a valid number")]
        [Display(Name = "Please enter the unit ID of the residence you are interested in: ")]
        public int UnitID { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "First Name: ")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Last Name: ")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "A SSN is required")]
        [Range(1, 999999999, ErrorMessage = "Please provide a valid SSN")]
        [Display(Name = "Social Security Number: ")]
        public int SocialSecurityNumber { get; set; }

        [Required(ErrorMessage = "A phone number is required")]
        [Display(Name = "Phone Number: ")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "An email address is required")]
        [Display(Name = "Email Address: ")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "A Landlord name is required")]
        [Display(Name = "Please enter the name of your last Landlord: ")]
        public string LastResidenceOwner { get; set; }

        [Required(ErrorMessage = "A contact number is required")]
        [Display(Name = "Please enter the contact number of your last Landlord: ")]
        public string LastResidenceContactPhoneNumber { get; set; }

        [Required(ErrorMessage = "A start date is required")]
        [Display(Name = "Please enter the tenancy start date for your last residence: ")]
        public string LastResidenceTenancyStartDate { get; set; }

        [Required(ErrorMessage = "An end date is required")]
        [Display(Name = "Please enter the tenancy start date for your last residence: ")]
        public string LastResidenceTenancyEndDate { get; set; }

        [Display(Name = "Check if you are currently employed: ")]
        public bool EmploymentStatus { get; set; }

        [Required(ErrorMessage = "An employer name is required")]
        [Display(Name = "Employer Name: ")]
        public string EmployerName { get; set; }

        [Required(ErrorMessage = "A contact number is required")]
        [Display(Name = "Employer Contact Number: ")]
        public string EmployerContactPhoneNumber { get; set; }

        [Required(ErrorMessage = "Annual income is required")]
        [Display(Name = "Annual Income: ")]
        public string AnnualIncome { get; set; }

        [Required(ErrorMessage = "Number of residents is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a valid number")]
        [Display(Name = "Number of Residents: ")]
        public int NumberOfResidents { get; set; }

        [Required(ErrorMessage = "Number of cats is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a valid number")]
        [Display(Name = "Number of Cats: ")]
        public int NumberOfCats { get; set; }

        [Required(ErrorMessage = "Number of dogs is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a valid number")]
        [Display(Name = "Number of Dogs: ")]
        public int NumberOfDogs { get; set; }

        public bool ApplicationApprovalStatus { get; set; }
    }
}
