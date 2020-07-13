using System;
using System.Collections.Generic;

namespace StepperTask.Models
{
    public partial class Steps
    {
        public Steps()
        {
            Items = new HashSet<Items>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Items> Items { get; set; }
    }
}
