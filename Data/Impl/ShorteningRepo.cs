using Core.DomainServices;
using Data.Entities;
using LenesKlinik.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Impl
{
    public class ShorteningRepo : IShorteningRepo
    {
        private readonly DataContext _ctx;

        // ENCODE/DECODE STUFF FOR THE SHORT URL
        public static readonly string Alphabet = "abcdefghijklmnopqrstuvwxyz0123456789";
        public static readonly int Base = Alphabet.Length;

        public ShorteningRepo(DataContext ctx)
        {
            _ctx = ctx;
        }

        public string CreateUrl(string fullUrl)
        {
            var exist = checkUrlExist(fullUrl);

            if (!exist)
            {
                _ctx.Url.Attach(new UrlRelation() { FullUrl = fullUrl });
                _ctx.SaveChanges();
            }

            return Encode(_ctx.Url.FirstOrDefault(url => url.FullUrl == fullUrl).Id);

            throw new Exception("Failed to create/find a short URL...");
        }


        public string GetUrl(string shortUrl)
        {
            var id = Decode(shortUrl);

            return _ctx.Url.FirstOrDefault(url => url.Id == id).FullUrl;
        }


        public static string Encode(int i)
        {
            if (i == 0) return Alphabet[0].ToString();

            var s = string.Empty;

            while (i > 0)
            {
                s += Alphabet[i % Base];
                i = i / Base;
            }

            return string.Join(string.Empty, s.Reverse());
        }

        public static int Decode(string s)
        {
            var i = 0;

            foreach (var c in s)
            {
                i = (i * Base) + Alphabet.IndexOf(c);
            }

            return i;
        }


        private bool checkUrlExist(string fullUrl)
        {
            return _ctx.Url.FirstOrDefault(url => url.FullUrl == fullUrl) == null ? false : true;
        }
    }
}
