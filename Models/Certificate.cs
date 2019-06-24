namespace Models
{
    public class Certificate:Entity
    { 
        public string Certi_Img { get; set; }
        public string Certi_Title { get; set; }
        public string ESSN { get; set; }
        public Doctor Doctor { get; set; }
    }
}
