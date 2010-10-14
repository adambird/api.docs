using System;
using api.docs.data.Repository;

namespace api.docs.data
{
    public class ResourceDoc : Entity
    {
        //public virtual Guid ResourceId { get; set; }
        public virtual string Language { get; set; }
        public virtual string Region { get; set; }
        public virtual string Summary { get; set; }
        public virtual string CultureString
        {
            get { return Region == null ? Language : string.Format("{0}-{1}", Language, Region); }   
        }
    }
}
