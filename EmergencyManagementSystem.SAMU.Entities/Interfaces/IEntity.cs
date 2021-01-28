namespace EmergencyManagementSystem.SAMU.Entities.Interfaces
{
    public interface IEntity<T> where T : struct
    {
        T Id { get; set; }
    }
}
