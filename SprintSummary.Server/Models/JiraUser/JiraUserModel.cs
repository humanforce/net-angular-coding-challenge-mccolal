namespace SprintSummary.server.Models.JiraUser
{
    public class JiraUserRawResponseModel
    {
        public List<JiraUserModel> ListOfJiraUsers { get; set; }
    }
    public class JiraUserModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Location Location { get; set; }

    }

    public class Location
    {
        public Guid Id { get; set; }
        public string Country { get; set; }
        public string region { get; set; }
    }
}
