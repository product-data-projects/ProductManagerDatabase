namespace ProductManagerDatabase.Database.Interfaces
{
    public interface IHasSoftDelete
    {
        DateTimeOffset? DeletedAt { get; set; }
    }
}
