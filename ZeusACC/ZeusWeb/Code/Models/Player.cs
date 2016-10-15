namespace ZeusWeb.Code.Models
{
    public class Player
    { 
        public int ID { get; set; }
        public string NAME { get; set; }
        public byte WORDL_ID { get; set; }
        public int GROUP_ID { get; set; }
        public int ACCOUNT_ID { get; set; }
        public int LEVEL { get; set; }
        public int VOCATION { get; set; }
        public int HEALTH { get; set; }
        public int HEALTHMAX { get; set; }
        public long EXPERIENCE { get; set; }
        public int LOOKBODY { get; set; }
        public int LOOKFEET { get; set; }
        public int LOOKHEAD { get; set; }
        public int LOOKLEGS { get; set; }
        public int LOOKTYPE { get; set; }
        public int LOOKADDONS { get; set; }
        public int MAGLEVEL { get; set; }
        public int MANA { get; set; }
        public int MANAMAX { get; set; }
        public int MANASPENT { get; set; }
        public long SOUL { get; set; }
        public int TOWN_ID { get; set; }
        public int POSX { get; set; }
        public int POSY { get; set; }
        public int POZ { get; set; }
        public byte[] CONDITIONS { get; set; }
        public int CAP { get; set; }
        public int SEX { get; set; }
        public decimal LASTLOGIN { get; set; }
        public long LASTIP { get; set; }
        public bool SAVE { get; set; }
        public bool SKULL { get; set; }
        public int SKULLTIME { get; set; }
        public int RANK_ID { get; set; }
        public string GUILDNICK { get; set; }
        public decimal LASTLOGOUT { get; set; }
        public sbyte BLESSINGS { get; set; }
        public long BALANCE { get; set; }
        public long STAMINA { get; set; }
        public int DIRECTION { get; set; }
        public int LOSS_EXPERIENCE { get; set; }
        public int LOSS_MANA { get; set; }
        public int LOSS_SKILLS { get; set; }
        public int LOSS_CONTAINERS { get; set; }
        public int LOSS_ITEMS { get; set; }
        public int PREMEND { get; set; }
        public bool ONLINE { get; set; }
        public long MARRIAGE { get; set; }
        public int PROMOTION { get; set; }
        public bool DELETED { get; set; }
        public string DESCRIPTION { get; set; }
    }
}