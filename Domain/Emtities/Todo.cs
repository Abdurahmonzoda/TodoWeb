﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Emtities
{
    public class Todo
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public Status Status { get; set; }


    }

    public enum Status
    {
        Todo,
        InPostrress,
        Complete
    };
}
