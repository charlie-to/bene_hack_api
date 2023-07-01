using System;
namespace bene_hack_api.Models
{
    public class Quest
    {
        public int id { get; set; }
        public string? name { get; set; }
        public DateTime deadline { get; set; }
        public bool isFinished { get; set; }
    }
}

