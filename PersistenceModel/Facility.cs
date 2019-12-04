using System.Collections.Generic;

namespace PersitanceModel
{
    public class Facility
    {
        public int FacId { get; set; }
        public string Name { get; set; }
        public int MemberCost { get; set; }
        public int GustCost { get; set; }
        public int Initialoutlay { get; set; }
        public int MonthlyMaintenance { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}