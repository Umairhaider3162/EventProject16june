namespace EventFinal.ViewModel
{
    public class FlowerViewModel
    {
        public string FlowerName { get; set; }
        public string FlowerFilename { get; set; }=String.Empty;
        public string FlowerFilePath { get; set; }=String.Empty;
        public Nullable<int> FlowerCost { get; set; }
        public IFormFile Photo { get; set; }
        public int Createdby { get; set; }
    }
}
