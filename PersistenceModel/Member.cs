using System;
using System.Collections.Generic;

namespace PersistenceModel
{
    public class Member
    {
        public int MemberId { get; set; }
        public string SurName { get; set; }
        public string FirstName { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string Telephone { get; set; }
        public int RecommendedBy { get; set; }
        public Member MemberSelf { get; set; }
        public virtual ICollection<Member> Members { get; set; }
        public DateTime Joindate { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
