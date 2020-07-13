using System;
using System.Collections.Generic;

namespace StepperTask.Models
{
    public partial class Items
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int StepId { get; set; }

        public virtual Steps Step { get; set; }
    }
}
