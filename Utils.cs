using System;
using System.Collections.Generic;
using System.Text;
using HtmlAgilityPack;
namespace DustloopFDScraper
{
    class Utils
    {
        public static string[] moveList = new string[]
        {
            "236B+C","214B+C","BackThrow","FowardThrow", "AirReversalAction","ReversalAction", "j.236C","j.236A","j.236B","j.214B","j.214A","j.214C","6P","4P","5P",  "Cross Burst Attack", "236A",
             "236B","214A","214B","214C","236C","DistortionSkillDuo","222B+C"
        };

        public static string CleanMove(string move)
        {
            for (int i = 0; i < moveList.Length; i++)
            {
                if (move.Contains(moveList[i]))
                {
                    switch (moveList[i])
                    {
                        
                        case "214B+C":
                            return "214b+c";
                        case "236B+C":
                            return "236b+c";
                        case "222B+C":
                            return "222b+c";
                        case "GroundThrow":
                        case "FowardThrow":
                            return "b+c";
                        case "BackThrow":
                            return "4b+c";
                        case "AirReversalAction":
                            return "j.a+d";
                        case "ReversalAction":
                            return "a+d";
                        case "j.236A":
                            return "j.236a";
                        case "j.236B":
                            return "j.236b";
                        case "j.236C":
                            return "j.236c";
                        case "j.214A":
                            return "j.214a";
                        case "j.214B":
                            return "j.214b";
                        case "j.214C":
                            return "j.214c";
                        case "236A":
                            return "236a";
                        case "236B":
                            return "236b";
                        case "236C":
                            return "236c";
                        case "214A":
                            return "214a";
                        case "214B":
                            return "214b";
                        case "214C":
                            return "214c";
                        case "4P":
                            return "4p";
                        case "5P":
                            return "5p";
                        case "6P":
                            return "6p";
                        default:
                            continue;
                    }
                }
            }
            return move;
        }
    }
}
