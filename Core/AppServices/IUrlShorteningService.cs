using System;
using System.Collections.Generic;
using System.Text;

namespace Core.AppServices
{
    public interface IUrlShorteningService
    {
        /// <summary>
        /// Get the full URL based on a short one
        /// </summary>
        /// <param name="shortUrl"></param>
        /// <returns></returns>
        string GetUrl(string shortUrl);

        /// <summary>
        /// Creates a new short URL based on the full one.
        /// If the URL has already been shortened, that one will be returned.
        /// </summary>
        /// <param name="fullUrl"></param>
        /// <returns></returns>
        string CreateUrl(string fullUrl);
    }
}
