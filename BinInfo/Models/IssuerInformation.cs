using System.Diagnostics;
using System.Runtime.Serialization;

namespace BinInfo.Models
{
    /// <summary>
    /// Represents all the information returned by binlist.net.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("Scheme: {Scheme}, Brand: {Brand}")]
    public class IssuerInformation
    {
        [DataMember(Name = "number")]
        public CardNumberInformation Number { get; set; }

        /// <summary>
        /// Card scheme. (i.e. Categories like
        /// Standard, Classic, Platinum, Premier
        /// and so on.)
        /// </summary>
        [DataMember(Name = "scheme")]
        public string Scheme { get; set; }

        /// <summary>
        /// Card type. (i.e. Credit / Debit)
        /// </summary>
        [DataMember(Name = "type")]
        public string CardType { get; set; }

        /// <summary>
        /// Card brand.
        /// </summary>
        [DataMember(Name = "brand")]
        public string Brand { get; set; }

        /// <summary>
        /// Is a prepaid card type
        /// </summary>
        [DataMember(Name = "prepaid")]
        public bool Prepaid { get; set; }

        /// <summary>
        /// Details about the cards registered origin,
        /// including location, country, currency ...
        /// </summary>
        [DataMember(Name = "country")]
        public CardOriginInformation Country { get; set; }

        /// <summary>
        /// Details about the bank who issued the card
        /// </summary>
        [DataMember(Name = "bank")]
        public BankInformation Bank { get; set; }
    }
}
