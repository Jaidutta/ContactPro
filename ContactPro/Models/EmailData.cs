using System.ComponentModel.DataAnnotations;

namespace ContactPro.Models
{
    public class EmailData
    {
        [Required]
        public string EmailAddress { get; set; } = "";

        [Required]
        public string Subject { get; set; } = "";


        [Required]
        public string Body { get; set; } = "";

        public int? Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? GroupName { get; set; }
    }
}


/* This model is not attached to the database. It is only used to pass information 
 * from the Controller to the View. EmailContactViewModel is also not attached to the 
 * database
 * There are a couple of them. The reason we are have a couple is because when we get to
 * EmailCategory we are going to be using these there as well. So these are used in 2 places
 * EmailContact, EmailCategory
 */

