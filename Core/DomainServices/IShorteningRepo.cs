using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DomainServices
{
    public interface IShorteningRepo
    {
        /// <summary>
        /// Get the full URL based on a short one
        /// </summary>
        /// <param name="shortUrl"></param>
        /// <returns>Full URL</returns>
        string GetUrl(string shortUrl);

        /// <summary>
        /// Creates a new short URL based on the full one.
        /// If the URL has already been shortened, that one will be returned.
        /// </summary>
        /// <param name="fullUrl"></param>
        /// <returns>Shortened URL</returns>
        string CreateUrl(string fullUrl);
    }
}
