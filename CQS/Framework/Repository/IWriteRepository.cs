using CQS.Framework.Domain;

namespace CQS.Framework.Repository
{
    public interface IWriteRepository<in TAroot> where TAroot : AggregateRoot
    {
        void Insert(TAroot entity);

        void Update(TAroot entity);

        void Delete(TAroot entity);
    }
}