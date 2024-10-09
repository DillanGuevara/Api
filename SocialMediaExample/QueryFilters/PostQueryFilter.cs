using System;

namespace SocialMediaExample.QueryFilters
{
    public class PostQueryFilter
    {
        public int? IdUser { get; set; }
        public DateTime? Date { get; set; }
        public string Description { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int CurrentPage { get; set; }
    }
}
