namespace EventFinal.Models
{
    public partial class Flower
    {
        public int FlowerID { get; set; }
        public string FlowerName { get; set; }
        public string FlowerFilename { get; set; }
        public string FlowerFilePath { get; set; }
        public Nullable<int> Createdby { get; set; }
        public Nullable<System.DateTime> Createdate { get; set; }
        public Nullable<int> FlowerCost { get; set; }
    }
}
