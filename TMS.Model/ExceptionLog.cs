﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Model
{
    public class ExceptionLog
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }
        public string Source { get; set; }
        public string Url { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
