using System;
using System.Collections.Generic;
using System.Linq;

namespace UrlChecker
{
    public class UrlChecker
    {
        private readonly List<string> blockedUrls;
        private readonly char[] specialChars;

        public UrlChecker(List<string> blockedUrls)
        {
            this.blockedUrls = blockedUrls;
            specialChars = Enumerable.Range(0, 65535)
                                     .Select(i => (char)i)
                                     .Where(c => !char.IsLetterOrDigit(c) && !char.IsWhiteSpace(c))
                                     .ToArray();
        }

        public bool IsBlocked(string url)
        {
            foreach (var blockedUrl in blockedUrls)
            {
           
                int index = url.IndexOf(blockedUrl);
                if (index >= 0) // Found the blocked URL
                {
                    int nextCharIndex = index + blockedUrl.Length;
                    if (specialChars.Contains(url[index - 1]) &&(nextCharIndex >= url.Length || specialChars.Contains(url[nextCharIndex]))  )
                    {
                        return true; // Blocked if no character or special character before or follows
                    }
                  
                }

               
            }
            return false;
        }
        public List<string> FilterBlockedUrls(List<string> toCheckUrls)
        {
            return toCheckUrls.Where(url => !IsBlocked(url)).ToList();
        }
    }
}
