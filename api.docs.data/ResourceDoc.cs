using api.docs.data.Repository;

namespace api.docs.data
{
    public class ResourceDoc : IModel
    {
        public int Id { get; set; }
        public int ResourceId { get; set; }
        public string Language { get; set; }
        public string Region { get; set; }
        public string Summary { get; set; }
        //public Resource Resource { get; set; }
    }
}
