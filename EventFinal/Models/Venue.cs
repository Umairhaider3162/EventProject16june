namespace EventFinal.Models
{
    public partial class Venue
    {
        public int VenueID { get; set; }
        public string VenueName { get; set; }
        public string VenueFilename { get; set; }
        public string VenueFilePath { get; set; }
        public Nullable<int> Createdby { get; set; }
        public Nullable<System.DateTime> Createdate { get; set; }
        public Nullable<int> VenueCost { get; set; }
    }
}
