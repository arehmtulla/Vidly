namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
<<<<<<< HEAD
        public string Name { get; set; }
=======

        [Required(ErrorMessage = "Please enter customer name.")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public MembershipType MembershipType { get; set; }
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        [Display(Name = "Date of Birth")]
        [Min18YearsIfMember]
        public System.DateTime? Birthdate { get; set; }
>>>>>>> 0dc5fc4abdb3499de42248cddfb94b2a22ab5525

    }
}