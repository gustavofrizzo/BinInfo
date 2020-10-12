using System.Diagnostics;
using System.Runtime.Serialization;

namespace BinInfo.Models
{
    /// <summary>
    /// Brief information about the bank who issued the card
    /// </summary>
    [DataContract]
    [DebuggerDisplay("Name: {Name}, City: {City}")]
    public class BankInformation
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name="url")]
        public string Url { get; set; }

        [DataMember(Name = "phone")]
        public string Phone { get; set; }

        [DataMember(Name = "city")]
        public string City { get; set; }
    }
}