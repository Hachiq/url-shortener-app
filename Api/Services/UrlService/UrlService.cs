using Api.Repositories.UrlRepository;
using Microsoft.EntityFrameworkCore;
using System;

namespace Api.Services.UrlService
{
    public class UrlService : IUrlService
    {
        private readonly IUrlRepository _urlRepository;

        public UrlService(IUrlRepository urlRepository)
        {
            _urlRepository = urlRepository;
        }

        private readonly Random _random = new Random();
        public async Task<string> GenerateUniqueCode()
        {
            var codeChars = new char[ShortLinkSettings.Length];
            int maxValue = ShortLinkSettings.Symbols.Length;


            while (true)
            {
                for (var i = 0; i < ShortLinkSettings.Length; i++)
                {
                    var randomIndex = _random.Next(maxValue);

                    codeChars[i] = ShortLinkSettings.Symbols[randomIndex];
                }
                var code = new string(codeChars);

                if (await _urlRepository.CodeIsUnique(code))
                {
                    return code;
                }
            }
            
        }
    }
}
