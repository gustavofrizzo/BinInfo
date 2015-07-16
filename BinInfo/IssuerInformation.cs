using System;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace BinInfo
{
    /// <summary>
    /// Represents all the information returned by binlist.net.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("Bin: {Bin}, Brand: {Brand}")]
    public class IssuerInformation
    {
        //private IssuerInformation() { }

        /// <summary>
        /// BIN/IIN number.
        /// </summary>
        [DataMember(Name = "bin")]
        public String Bin { get; set; }

        /// <summary>
        /// Card brand.
        /// </summary>
        [DataMember(Name = "brand")]
        public String Brand { get; set; }

        [DataMember(Name = "sub_brand")]
        public String SubBrand { get; set; }

        /// <summary>
        /// Country Code (ISO3166-1)
        /// </summary>
        [DataMember(Name = "country_code")]
        public String CountryCode { get; set; }

        [DataMember(Name = "country_name")]
        public String CountryName { get; set; }

        [DataMember(Name = "bank")]
        public String Bank { get; set; }

        /// <summary>
        /// Card types like Debit, Crecit, Prepaid an so on.
        /// </summary>
        [DataMember(Name = "card_type")]
        public String CardType { get; set; }

        /// <summary>
        /// Categories like Standard, Classic, Platinum, Premier and so on.
        /// </summary>
        [DataMember(Name = "card_category")]
        public String CardCategory { get; set; }

        [DataMember(Name = "latitude")]
        public String Latitude { get; set; }

        [DataMember(Name = "longitude")]
        public String Longitude { get; set; }

        [DataMember(Name = "query_time")]
        public String QueryTime { get; set; }
    }
}
