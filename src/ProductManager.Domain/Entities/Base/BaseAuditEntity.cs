
namespace ProductManager.Domain.Entities.Base
{
    public abstract class BaseAuditEntity<TKey> : AuditEntity, IBaseEntity<TKey>
    {
        public virtual TKey Id { get; set; }
    }
}
