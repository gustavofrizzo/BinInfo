using System.Diagnostics;
using System.Runtime.Serialization;

namespace BinInfo.Models
{
    [DataContract]
    [DebuggerDisplay("Name: {Name}, Alpha2: {Alpha2}, Currency: {Currency}")]
    public class CardOriginInformation
    {
        [DataMember(Name = "numeric")]
        public int Numeric { get; set; }

        [DataMember(Name = "alpha2")]
        public string Alpha2 { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "emoji")]
        public string Emoji { get; set; }

        [DataMember(Name = "currency")]
        public string Currency { get; set; }

        [DataMember(Name = "latitude")]
        public string Latitude { get; set; }

        [DataMember(Name = "longitude")]
        public string Longitude { get; set; }
    }
}