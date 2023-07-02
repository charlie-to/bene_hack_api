using System;
namespace bene_hack_api.Models
{
	public class QuestStatus
	{ 
		public int id { get; set; }
		public int quest_id { get; set; }
		public int user_id { get; set; }
		public bool status { get; set; }
	}
}

