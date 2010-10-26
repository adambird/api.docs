using System;
using api.docs.data.Repository;

namespace api.docs.data
{
    public class ResourceDoc : Entity
    {
        public virtual string Language { get; set; }
        public virtual string Summary { get; set; }

        public virtual Resource Resource {get;set;}
    }
}
