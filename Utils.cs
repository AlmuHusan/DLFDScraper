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
            "Ground Throw","Back Throw","Foward Throw", "Air Reversal Action","Reversal Action", "j.236C","j.236A","j.236B","j.214B","j.214A","j.214C","6P","4P","5P", "Reversal Action", "Cross Burst Attack", "236A",
             "236B","214A","214B","214C","236C","236B+C",
            "214B+C","Distortion Skill Duo","222B+C"
        };

        public static string CleanMove(string move)
        {
            for (int i = 0; i < moveList.Length; i++)
            {
                if (move.Contains(moveList[i]))
                {
                    switch (moveList[i])
                    {
                        case "Ground Throw":
                        case "Foward Throw":
                            return "B+C";
                        case "Back Throw":
                            return "4B+C";
                        case "Air Reversal Action":
                            return "j.A+D";
                        case "Reversal Action":
                            return "A+D";
                        case "j.236A":
                            return "j.236A";
                        case "j.236B":
                            return "j.236B";
                        case "j.236C":
                            return "j.236C";
                        case "j.214A":
                            return "j.214A";
                        case "j.214B":
                            return "j.214B";
                        case "j.214C":
                            return "j.214C";
                        case "236A":
                            return "236A";
                        case "236B":
                            return "236B";
                        case "236C":
                            return "236C";
                        case "214A":
                            return "214A";
                        case "214B":
                            return "214B";
                        case "214C":
                            return "214C";
                        case "214B+C":
                            return "214B+C";
                        case "236B+C":
                            return "236B+C";
                        case "222B+C":
                            return "222B+C";
                        default:
                            continue;
                    }
                }
            }
            return move;
        }
    }
}
