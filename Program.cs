using System;
using System.Xml;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace DustloopFDScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            var html = @"http://www.dustloop.com/wiki/index.php?title=BBTag/Frame_Data";

            HtmlWeb web = new HtmlWeb();

            var htmlDoc = web.Load(html);
            var nodes = htmlDoc.DocumentNode.SelectNodes("//body//a");
            Regex characterNameSearch = new Regex(@"(?<=\/wiki\/index\.php\?title=BBTag\/).+(?=\/Frame_Data)");
            var characterFDLinks = new Dictionary<string, string>();
            Regex linkSearch = new Regex(@"/wiki/index.php\?title=BBTag/.+/Frame_Data");
            foreach (var node in nodes) {
                try
                {
                    
                    Match linkMatch = linkSearch.Match(node.Attributes["href"].Value);
                    
                    //Console.WriteLine(imageMatch.Value);
                    if (linkMatch.Value != "")
                    {
                        Console.WriteLine(linkMatch.Value);
                        Match characterName= characterNameSearch.Match(linkMatch.Value);
                        Console.WriteLine(characterName.Value);
                        try
                        {
                            characterFDLinks.Add(linkMatch.Value, characterName.Value);
                        }
                        catch (ArgumentException)
                        {
                           // Console.WriteLine("An element with Key = \"txt\" already exists.");
                        }
                    }
                    //Console.WriteLine(node.Attributes["href"].Value);
                }
                catch (Exception e) { }
            }
            Console.WriteLine("HID");
            foreach (var c in characterFDLinks.Keys) {
                Console.WriteLine(c);
            }
        }
    }
}
