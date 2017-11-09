using Form_Submission.Models;
using System.Collections.Generic;

namespace Form_Submission.Factory
{
    public interface IFactory<T> where T : BaseEntity
    {
    }
}