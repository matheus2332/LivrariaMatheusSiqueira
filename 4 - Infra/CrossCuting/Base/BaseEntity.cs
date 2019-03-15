using CrossCutting.MainErrors;
using System.ComponentModel.DataAnnotations;

namespace CrossCutting.Base
{
    public class BaseEntity<T> : MainError, IBaseEntity<T>
    {
        [Key]
        public T Id { get; private set; }

        public void SetId(T id)
        {
            Id = id;
        }
    }
}