
namespace ProductManager.Domain.Entities.Base
{
    public interface IBaseEntity<TKey>
    {
        TKey Id { get; set; }
    }
}
