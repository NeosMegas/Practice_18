using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_18
{
    public interface IAnimal
    {
        long Id { get; set; }
        string AnimalType { get; set; }
        string Name { get; set; }
    }
}
