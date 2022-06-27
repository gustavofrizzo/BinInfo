using System.Diagnostics;
using System.Runtime.Serialization;

namespace BinInfo.Models
{
    /// <summary>
    /// Brief details about the card number
    /// </summary>
    [DataContract]
    [DebuggerDisplay("Length: {Length}, Luhn: {Luhn}")]
    public class CardNumberInformation
    {
        /// <summary>
        /// Length of the card number
        /// </summary>
        [DataMember(Name = "length")]
        public int? Length { get; set; }

        /// <summary>
        /// Whether card was tested successfully
        /// against the Luhn algorithm 
        /// </summary>
        [DataMember(Name = "luhn")]
        public bool? Luhn { get; set; }
    }
}