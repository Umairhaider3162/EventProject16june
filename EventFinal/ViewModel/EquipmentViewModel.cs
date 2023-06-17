namespace EventFinal.ViewModel
{
    public class EquipmentViewModel
    {
        public string EquipmentName { get; set; }
        public string EquipmentFilename { get; set; }=String.Empty;
        public string EquipmentFilePath { get; set; }=String.Empty;
        public Nullable<int> EquipmentCost { get; set; }
        public IFormFile Photo { get; set; }
        public Nullable<int> Createdby { get; set; }
        
    }
}
