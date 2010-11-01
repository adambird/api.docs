using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace api.docs.data
{
    public class FieldDoc : Entity
    {
        public virtual string Language { get; set; }
        public virtual string Description { get; set; }

        public virtual Field Field { get; set; }
    }
}
