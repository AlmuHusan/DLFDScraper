using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DustloopFDScraper
{
    class CharacterMove
    {
        [JsonPropertyName("character")]
        public string character { get; set; }

        [JsonPropertyName("move")]
        public string move { get; set; }

        [JsonPropertyName("damage")]
        public string damage { get; set; }

        [JsonPropertyName("cancel")]
        public string cancel { get; set; }

        [JsonPropertyName("p1")]
        public string p1 { get; set; }

        [JsonPropertyName("p2")]
        public string p2 { get; set; }

        [JsonPropertyName("attribute")]
        public string attribute { get; set; }

        [JsonPropertyName("guard")]
        public string guard { get; set; }

        [JsonPropertyName("startup")]
        public string startup { get; set; }

        [JsonPropertyName("active")]
        public string active { get; set; }

        [JsonPropertyName("recovery")]
        public string recovery { get; set; }

        [JsonPropertyName("franeAdv")]
        public string frameAdv { get; set; }

        [JsonPropertyName("level")]
        public string level { get; set; }

        [JsonPropertyName("blockstun")]
        public string blockstun { get; set; }

        [JsonPropertyName("hitstun")]
        public string hitstun { get; set; }

        [JsonPropertyName("untech")]
        public string untech { get; set; }

        [JsonPropertyName("hitstop")]
        public string hitstop { get; set; }

        [JsonPropertyName("invul")]
        public string invul { get; set; }

        [JsonPropertyName("hitbox")]
        public string hitbox { get; set; }
    }
}
