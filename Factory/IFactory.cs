using dojoDiner.Models;
using System.Collections.Generic;

namespace dojoDiner.Factory
{
    public interface IFactory<T> where T : BaseEntity
    {
    }
}