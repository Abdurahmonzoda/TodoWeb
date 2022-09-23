using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Emtities
{
    public class TodoDto
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string Status { get; set; }
    }
}
