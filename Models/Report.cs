namespace TodoApi.Models
{
    public class Report 
    {
        public int id {get; set;}
        public string message { get; set; }
        public int idKlient {get; set;}
        public int idTemplate {get; set;}
        public string status {get; set;}
        public string sentTime {get; set;}
    }
}