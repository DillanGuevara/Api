using SocialMediaExample.QueryFilters;
using System;

namespace SocialMediaExample.Interfaces
{
    public interface IUriService
    {
        public Uri GetPostPaginationUri(PostQueryFilter filter, string actionUrl);
    }
}
