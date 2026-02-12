using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Documents_Bartova.Model
{
    public class Document
    {
        public int Id { get; set; }
        public string Scr { get; set; }
        public string Name { get; set; }
        public string User { get; set; }
        public int IdDocument { get; set; }
        public DateTime Date { get; set; }
        public int Status { get; set; }
        public int Description { get; set; }
    }
}
