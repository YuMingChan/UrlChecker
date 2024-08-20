using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        var blockedUrls = new List<string> { "blocked.com", "test.com" };
        var toCheckUrls = new List<string> { "https://notblocked.com", "https://subdomain.blocked.com/path", "https://blocked.com", "https://test.com" };

        var urlChecker = new UrlChecker.UrlChecker(blockedUrls);
        var filteredUrls = urlChecker.FilterBlockedUrls(toCheckUrls);

        foreach (var url in filteredUrls)
        {
            Console.WriteLine(url);
        }
        Console.ReadLine ();
    }
}