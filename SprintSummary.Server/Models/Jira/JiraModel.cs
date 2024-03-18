using Newtonsoft.Json;

namespace SprintSummary.server.Models.JiraData
{
    public class Sprint
    {
        public int id { get; set; }
        public string name { get; set; }
        public string state { get; set; }
        public int boardId { get; set; }
        public string goal { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
    }

    public class Properties
    {

        public List<Sprint> Sprints { get; set; }
        public Priority Priority { get; set; }
        public string Summary { get; set; }
        public double StoryPoints { get; set; }
        public Status Status { get; set; }
    }

    public class JiraModel
    {
        public string expand { get; set; }
        public string id { get; set; }
        public string self { get; set; }
        public string key { get; set; }
        public Properties fields { get; set; }
        
    }

   

    public class Priority
    {
        public string self { get; set; }
        public string iconUrl { get; set; }
        public string name { get; set; }
        public string id { get; set; }
    }

    public class Status
    {
        public string self { get; set; }
        public string description { get; set; }
        public string iconUrl { get; set; }
        public string name { get; set; }
        public string id { get; set; }
    }





}


