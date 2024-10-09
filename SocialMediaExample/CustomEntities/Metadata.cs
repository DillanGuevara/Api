﻿namespace SocialMediaExample.CustomEntities
{
    public class Metadata
    {
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }
        public required string NextPageUrl { get; set; }
        public required string PreviousPageUrl { get; set; }
    }
}
