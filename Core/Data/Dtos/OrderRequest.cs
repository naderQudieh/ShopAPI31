using System.Collections.Generic;

namespace Core.Dtos
{
    public class OrderRequest
    {
        public List<long> ProductIds { get; set; }
    }
}
