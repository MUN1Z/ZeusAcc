namespace ZeusWeb.Code.Models
{
    public class Account
    {
        public int ID { get; set; }
        public string NAME { get; set; }
        public string PASSWORD { get; set; }
        public int PREMDAYS { get; set; }
        public long LASTDAY { get; set; }
        public string EMAIL { get; set; }
        public string KEY { get; set; }
        public bool BLOKED { get; set; }
        public int WARNINGS { get; set; }
        public int GROUPID { get; set; }
    }
}