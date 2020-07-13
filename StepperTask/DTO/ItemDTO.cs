using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StepperTask.DTO
{
    public class ItemDTO
    {
        public int ?Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int StepId { get; set; }

    }
}

