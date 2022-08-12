namespace Band.ViewModels.Catalog.VaiTro
{
    public class VaiTroViewModel
    {
        public int IdVaiTro { get; set; }
        public string TenVaiTro { get; set; }
        public override string ToString()
        {
            return TenVaiTro;
        }
    }
}