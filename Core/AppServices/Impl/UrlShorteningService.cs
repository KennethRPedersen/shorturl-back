using Core.DomainServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.AppServices.Impl
{
    public class UrlShorteningService : IUrlShorteningService
    {
        private readonly IShorteningRepo _repo;

        public UrlShorteningService(IShorteningRepo repo)
        {
            _repo = repo;
        }

        public string CreateUrl(string fullUrl)
        {
            return _repo.CreateUrl(fullUrl);
        }

        public string GetUrl(string shortUrl)
        {
            return _repo.GetUrl(shortUrl);
        }
    }
}
