namespace HealthWare.ActiveASSIST.Entities.Mappings
{
    public class ScreenTenantMapping
    {
        public long Id { get; set; }
        public TenantDetails Tenant { get; set; }
        public DynamicScreens Screen { get; set; }
        public int Order { get; set; }
        public int RecordStatus { get; set; }
    }
}
