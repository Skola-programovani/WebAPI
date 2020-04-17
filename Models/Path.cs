namespace TodoApi.Models
{
    public class Path  
    {
        public int id {get; set;}
        public int idTemplate { get; set; }
        public string FTP {get; set;}
        public string source {get; set;}
        public string fullPath {get; set;}
    }
}