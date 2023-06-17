using System.ComponentModel.DataAnnotations;
namespace EventFinal.Models
{
    public partial class Registration:BaseDOM
    {
        public int ID { get; set; }
        [Required(AllowEmptyStrings = true)]
        [Display(Name = "FullName")]
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Mobileno { get; set; }
        public string EmailID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Gender { get; set; }
        public Nullable<System.DateTime> Birthdate { get; set; }
        public Nullable<int> RoleID { get; set; }
    }
}
