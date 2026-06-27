namespace Job_management_system.Models
{
    public class Job
    {
        public int Id { get; set; }
        public String Name { get; set; }

        public int MunicipalAddressId { get; set; }
        public MunicipalAddress MunicipalAddress { get; set; }

        public List<Employee> Employees { get; set; }
    }
}
