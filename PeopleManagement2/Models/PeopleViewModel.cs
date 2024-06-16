namespace PeopleManagement2.Models
{
    public class PeopleViewModel
    {
        public List<Person> People { get; set; } = new List<Person>();
        public string SearchString { get; set; } = string.Empty;
    }
}