﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.ModelDTO.Task
{
    public class TaskCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        //public DateTime CreatedDate { get; set; }
        //public DateTime ModifiedDate { get; set; }
        //public int CreatedBy { get; set; }
        //public int ModifiedBy { get; set; }
        public bool IsActive { get; set; }

    }
}
