using EmergencyManagementSystem.SAMU.Entities.Enums;
using EmergencyManagementSystem.SAMU.Entities.Interfaces;

namespace EmergencyManagementSystem.SAMU.Entities.Entities
{
    public class Patient : IEntity<long>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public int EmergencyId { get; set; }
    }
}
