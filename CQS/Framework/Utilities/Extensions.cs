using System.Collections.Generic;
using System.Linq;
using CQS.Framework.Domain;

namespace CQS.Framework.Utilities
{
    public static class Extensions
    {
        public static void Update<T>(this ICollection<T> source, IEnumerable<T> updatedSource) 
            where T : ValueObject<T>
        {
            source.Update(updatedSource, out var x, out var y);
        }

        public static void Update<T>(this ICollection<T> source, 
            IEnumerable<T> updatedSource, 
            out IEnumerable<T> addedObjects, 
            out IEnumerable<T> removedObjects) 
            where T : ValueObject<T>
        {
            addedObjects = updatedSource.Except(source).ToList();
            removedObjects = source.Except(updatedSource).ToList();

            foreach (var addedObject in addedObjects)
            {
                source.Add(addedObject);
            }

            foreach (var removedObject in removedObjects)
            {
                source.Remove(removedObject);
            }
        }
    }
}