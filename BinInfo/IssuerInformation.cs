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
        public string Bin { get; set; }

        /// <summary>
        /// Card brand.
        /// </summary>
        [DataMember(Name = "brand")]
        public string Brand { get; set; }

        [DataMember(Name = "sub_brand")]
        public string SubBrand { get; set; }

        /// <summary>
        /// Country Code (ISO3166-1)
        /// </summary>
        [DataMember(Name = "country_code")]
        public string CountryCode { get; set; }

        [DataMember(Name = "country_name")]
        public string CountryName { get; set; }

        [DataMember(Name = "bank")]
        public string Bank { get; set; }

        /// <summary>
        /// Card types like Debit, Crecit, Prepaid an so on.
        /// </summary>
        [DataMember(Name = "card_type")]
        public string CardType { get; set; }

        /// <summary>
        /// Categories like Standard, Classic, Platinum, Premier and so on.
        /// </summary>
        [DataMember(Name = "card_category")]
        public string CardCategory { get; set; }

        [DataMember(Name = "latitude")]
        public string Latitude { get; set; }

        [DataMember(Name = "longitude")]
        public string Longitude { get; set; }

        [DataMember(Name = "query_time")]
        public string QueryTime { get; set; }
    }
}
