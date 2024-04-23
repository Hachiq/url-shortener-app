using Api.DTOs;
using Api.Models;

namespace Api.Mappers
{
    public class UrlMapper
    {
        public ShortenedUrlDetailsDto MapShortenedUrlDetailsToDto(ShortenedUrl url)
        {
            if (url is null)
            {
                return null;
            }

            return new ShortenedUrlDetailsDto
            {
                Id = url.Id.ToString(),
                LongUrl = url.LongUrl,
                ShortUrl = url.ShortUrl,
                Code = url.Code,
                Creator = url.Creator.Username,
                CreatedOn = url.CreatedOn
            };
        }
        public ShortenedUrlDto MapShortenedUrlToDto(ShortenedUrl url)
        {
            if (url is null)
            {
                return null;
            }

            return new ShortenedUrlDto
            {
                LongUrl = url.LongUrl,
                ShortUrl = url.ShortUrl
            };
        }
        public List<ShortenedUrlDto> MapUrlListToDtoList(List<ShortenedUrl> urls)
        {
            return urls.Select(MapShortenedUrlToDto).ToList();
        }
    }
}
