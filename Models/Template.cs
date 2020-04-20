namespace TodoApi.Models
{
    public class Template 
    {
        public int id {get; set;}
        public int idKlient{ get; set; }
        public string name {get; set;}
        public int backup {get; set;} //Incremental atd
        public int maxFull {get; set;}
        public int maxSegments {get; set;}
        public string repetition {get; set;}
        public string format {get; set;}
    }
}