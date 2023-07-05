using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_18
{
    public interface IModel
    {
        List<IAnimal> Animals { get; }
        void Add(IAnimal animal);
        void Remove(IAnimal animal);
        void Edit(IAnimal animal);
    }
}
