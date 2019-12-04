using System;

namespace PersitanceModel
{
    public class Booking
    {
        public int FacId { get; set; }
        public virtual Facility Facility  { get; set; }
        public int MemId { get; set; }
        public virtual Member Member {get; set;}
        public DateTime StartTime { get; set; }
        public int Slots { get; set; }
    }
}