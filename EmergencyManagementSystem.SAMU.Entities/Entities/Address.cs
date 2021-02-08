using EmergencyManagementSystem.SAMU.Entities.Interfaces;

namespace EmergencyManagementSystem.SAMU.Entities.Entities
{
    public class Address : IEntity<long>
    {
        public long Id { get; set; }
        public string CEP { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string Reference { get; set; }
    }
}
