using SocialMedia.Core.QueryFilters;
using System;

namespace SocialMedia.Infrastructure.Interfaces
{
    public interface IUriService
    {
        public Uri GetPostPaginationUri(PostQueryFilter filter, string actionUrl);
    }
}
