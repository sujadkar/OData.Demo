using OData.Demo.Data.Entities;

namespace OData.Demo.Data
{
    public interface IGadgetsRepository
    {
        Task<IEnumerable<Gadgets>> GetSomeSimpleStuff();
    }
}
