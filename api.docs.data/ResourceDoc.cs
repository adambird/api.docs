using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace api.docs.data
{
    public class ResourceDoc
    {
        public int Id { get; set; }
        public int ResourceId { get; set; }
        public string Language { get; set; }
        public string Region { get; set; }
        public string Summary { get; set; }
    }
}
