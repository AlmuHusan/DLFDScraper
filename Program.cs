using System;
using System.Xml;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DustloopFDScraper
{
    class Program
    {
        public static string fileDirectory = @"C:\Users\owner\Desktop\BBTAGCharData\";
        static void Main(string[] args)
        {
            var frameDataPage = @"http://www.dustloop.com/wiki/index.php?title=BBTag/Frame_Data";
            HtmlWeb web = new HtmlWeb();
            var dustloopPage = @"http://www.dustloop.com";
            var FrameDataHtmlDoc = web.Load(frameDataPage);
            var FrameDataNodes = FrameDataHtmlDoc.DocumentNode.SelectNodes("//body//a");
            Regex characterNameSearch = new Regex(@"(?<=\/wiki\/index\.php\?title=BBTag\/).+(?=\/Frame_Data)");
            var characterFDLinks = new Dictionary<string, string>();
            Regex linkSearch = new Regex(@"/wiki/index.php\?title=BBTag/.+/Frame_Data");
            Console.WriteLine("Grabbing links....");
            foreach (var node in FrameDataNodes)
            {
                try
                {
                    Match linkMatch = linkSearch.Match(node.Attributes["href"].Value);
                    if (linkMatch.Value != "")
                    {
                        Match characterName = characterNameSearch.Match(linkMatch.Value);
                        try
                        {
                            if (!characterFDLinks.ContainsKey(characterName.Value))
                            {
                                characterFDLinks.Add(characterName.Value, linkMatch.Value);
                            }
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                }
                catch (Exception e) { }
            }

            foreach (var c in characterFDLinks.Keys)
            {
                var CharacterDataHtmlDoc = web.Load(dustloopPage + characterFDLinks[c]);
                var CharacterDataNodes = CharacterDataHtmlDoc.DocumentNode.SelectNodes("//tr[count(td) >12]/*");
                grabCharacterData(CharacterDataNodes,c);
            }
            
        }

        static void grabCharacterData(HtmlNodeCollection cDataNodes,string cName)
        {
            Console.WriteLine("Grabbing Frame Data for: " + cName);
            int dataTypeNumber = 1;
            List<CharacterMove> moves = new List<CharacterMove>();
            CharacterMove characterMove = new CharacterMove();
            foreach (var CharacterDataNode in cDataNodes)
            {
                //Console.WriteLine(CharacterDataNode.InnerText);
                switch (dataTypeNumber)
                {
                    case 1:
                        characterMove.character = cName;
                        characterMove.move = Utils.CleanMove(CharacterDataNode.InnerText.Trim());
                        dataTypeNumber++;
                        break;
                    case 2:
                        characterMove.damage = CharacterDataNode.InnerText.Trim();
                        dataTypeNumber++;
                        break;
                    case 3:
                        characterMove.cancel = CharacterDataNode.InnerText.Trim();
                        dataTypeNumber++;
                        break;
                    case 4:
                        characterMove.p1 = CharacterDataNode.InnerText.Trim();
                        dataTypeNumber++;
                        break;
                    case 5:
                        characterMove.p2 = CharacterDataNode.InnerText.Trim();
                        dataTypeNumber++;
                        break;
                    case 6:
                        characterMove.attribute = CharacterDataNode.InnerText.Trim();
                        dataTypeNumber++;
                        break;
                    case 7:
                        characterMove.guard = CharacterDataNode.InnerText.Trim();
                        dataTypeNumber++;
                        break;
                    case 8:
                        characterMove.startup = CharacterDataNode.InnerText.Trim();
                        dataTypeNumber++;
                        break;
                    case 9:
                        characterMove.active = CharacterDataNode.InnerText.Trim();
                        dataTypeNumber++;
                        break;
                    case 10:
                        characterMove.recovery = CharacterDataNode.InnerText.Trim();
                        dataTypeNumber++;
                        break;
                    case 11:
                        characterMove.frameAdv = CharacterDataNode.InnerText.Trim();
                        dataTypeNumber++;
                        break;
                    case 12:
                        characterMove.level = CharacterDataNode.InnerText.Trim();
                        dataTypeNumber++;
                        break;
                    case 13:
                        characterMove.blockstun = CharacterDataNode.InnerText.Trim();
                        dataTypeNumber++;
                        break;
                    case 14:
                        characterMove.hitstun = CharacterDataNode.InnerText.Trim();
                        dataTypeNumber++;
                        break;
                    case 15:
                        characterMove.untech = CharacterDataNode.InnerText.Trim();
                        dataTypeNumber++;
                        break;
                    case 16:
                        characterMove.hitstop = CharacterDataNode.InnerText.Trim();
                        dataTypeNumber++;
                        break;
                    case 17:
                        characterMove.invul = CharacterDataNode.InnerText.Trim();
                        dataTypeNumber++;
                        break;
                    case 18:
                        characterMove.hitbox = CharacterDataNode.InnerText.Trim();
                        dataTypeNumber = 1;
                        moves.Add(characterMove);
                        characterMove = new CharacterMove();
                        break;
                    default:
                        Console.WriteLine("Something went wrong");
                        break;

                }

            }
            Console.WriteLine("Creating JSON for: " + cName);
            var json = JsonConvert.SerializeObject(moves.ToArray());
            System.IO.File.WriteAllText(fileDirectory + cName+".json", json);
        }
    }
}