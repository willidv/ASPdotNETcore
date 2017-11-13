using logreg.Models;
using System.Collections.Generic;

namespace logreg.Factory
{
    public interface IFactory<T> where T : BaseEntity
    {
    }
}