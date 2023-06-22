namespace ProductManagerDatabase.Database.Interfaces
{
    public interface IHasPrimaryKey
    {
        void SetPrimaryKey<TKeyType>(TKeyType key);

    }

}
