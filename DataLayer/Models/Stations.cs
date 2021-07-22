namespace DataLayer.Models
{
    using System.ComponentModel.DataAnnotations;

    public partial class Stations
    {
        public long RecId { get; set; }
        public string MachineName { get; set; }
        public string HostAddress { get; set; }
        public int StationType { get; set; }
        public string Description { get; set; }
        public int? Sshport { get; set; }
        public string SshuserName { get; set; }
        [Encrypted]
        public string Sshpassword { get; set; }
        public int? Svdrpport { get; set; }
        public string SambaUserName { get; set; }
        [Encrypted]
        public string SambaPassword { get; set; }
        public string PathToRecordings { get; set; }
        public int? VdrControlServicePort { get; set; }
        public string MacAddress { get; set; }
        public bool? EnableWol { get; set; }
        public int? VdradminPort { get; set; }
        public string VdradminUserName { get; set; }
        [Encrypted]
        public string VdradminPassword { get; set; }
    }
}
