namespace EventFinal.Repositories
{
    public interface IFlowerRepository
    {
        Task<Flower> AddFlowerAsync(Flower flower);
    }
}
