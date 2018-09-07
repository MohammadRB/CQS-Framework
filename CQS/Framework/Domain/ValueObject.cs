using System;
using System.Collections.Generic;
using System.Linq;

namespace CQS.Framework.Domain
{
    public interface IValueObject
    {
    }

    public abstract class ValueObject<T> : IValueObject
    {
        public static bool operator ==(ValueObject<T> left, ValueObject<T> right)
        {
            if (ReferenceEquals(left, null) ^ ReferenceEquals(right, null))
            {
                return false;
            }

            return ReferenceEquals(left, null) || left.Equals(right);
        }

        public static bool operator !=(ValueObject<T> left, ValueObject<T> right)
        {
            return !(left == right);
        }

        public override bool Equals(object other)
        {
            if (other == null || other.GetType() != GetType())
            {
                return false;
            }

            var otherValueType = (ValueObject<T>) other;

            var thisFields = _FetchAtomicFields();
            var otherFields = otherValueType._FetchAtomicFields();

            if (thisFields.Count == 0 || otherFields.Count == 0)
            {
                throw new InvalidOperationException($"Use {nameof(AddAtomicField)} function to add fields.");
            }

            if (thisFields.Count != otherFields.Count)
            {
                return false;
            }

            for (int i = 0; i < thisFields.Count; ++i)
            {
                var thisField = thisFields[i];
                var otherField = otherFields[i];

                if (ReferenceEquals(thisField, null) ^ ReferenceEquals(otherField, null))
                {
                    return false;
                }

                bool areEquals = ReferenceEquals(thisField, null) || thisField.Equals(otherField);
                if (!areEquals)
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var fields = _FetchAtomicFields();
            if (fields.Count == 0)
            {
                throw new InvalidOperationException($"Use {nameof(AddAtomicField)} function to add fields.");
            }

            var hash = fields.Aggregate(0, (a, b) => a ^ b.GetHashCode());
            return hash;
        }

        protected abstract void AddAtomicFields();

        protected ValueObject<T> AddAtomicField<TField>(TField field)
        {
            _fields.Add(field);
            return this;
        }

        private List<Object> _FetchAtomicFields()
        {
            _fields = new List<object>();
            AddAtomicFields();

            return _fields;
        }
        
        private List<Object> _fields;
    }
}