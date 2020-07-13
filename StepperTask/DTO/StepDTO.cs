using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StepperTask.DTO
{
    public class StepDTO
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ItemDTO> Items { get; set; }
    }
}
