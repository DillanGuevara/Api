namespace SocialMedia.Infrastructure.Interfaces
{
    internal interface IHttpContextAccesor
    {
        object HttpContext { get; set; }
    }
}