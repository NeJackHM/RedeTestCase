using RedeTestCase.Domain.Common;

namespace RedeTestCase.Domain.Models
{
    public class JobCategory : BaseDomainModel
    {
        public string Description { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
