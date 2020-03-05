using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using BinInfo.Models;

namespace BinInfo
{
    public static class BinList
    {
        private static readonly string BaseUrl = "https://lookup.binlist.net/";

        /// <summary>
        /// binlist.net is a public web service for searching Issuer Identification Numbers (IIN).
        /// <para>This webservice has an internal database with IIN/BIN information.</para>
        /// </summary>
        /// <param name="bin">The first 6 digits of a credit card number.</param>
        /// <exception cref="WebException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns>IssuerInformation</returns>
        public static IssuerInformation Find(string bin)
        {
            if (bin == null)
                throw new ArgumentNullException("bin");

            if (!bin.Trim().All(c => char.IsNumber(c)) || string.IsNullOrWhiteSpace(bin))
                throw new ArgumentException("Make sure to enter a valid BIN/IIN number.");

            using (WebClient web = new WebClient())
            {
                try
                {
                    string json = web.DownloadString(BaseUrl + bin);

                    DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(IssuerInformation));

                    using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
                    {
                        var issuerInfo = (IssuerInformation)serializer.ReadObject(stream);
                        return issuerInfo;
                    }
                }
                catch (WebException ex)
                {
                    string addInfo = $"No results for {bin}. Make sure you enter a valid BIN/IIN number. --- ";
                    throw new WebException(addInfo + ex.Message, ex, ex.Status, ex.Response);
                }
            }
        }

#if !NET40

        /// <summary>
        /// binlist.net is a public web service for searching Issuer Identification Numbers (IIN).
        /// <para>This webservice has an internal database with IIN/BIN information.</para>
        /// </summary>
        /// <param name="bin">The first 6 digits of a credit card number.</param>
        /// <exception cref="WebException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns>IssuerInformation</returns>
        public async static Task<IssuerInformation> FindAsync(string bin)
        {
            if (bin == null)
                throw new ArgumentNullException("bin");

            if (!bin.Trim().All(c => char.IsNumber(c)) || string.IsNullOrWhiteSpace(bin))
                throw new ArgumentException("Make sure to enter a valid BIN/IIN number.");

            using (WebClient web = new WebClient())
            {
                try
                {
                    string json = await web.DownloadStringTaskAsync(BaseUrl + bin);

                    DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(IssuerInformation));

                    using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
                    {
                        var issuerInfo = (IssuerInformation)serializer.ReadObject(stream);
                        return issuerInfo;
                    }
                }
                catch (WebException ex)
                {
                    string addInfo = $"No results for {bin}. Make sure you enter a valid BIN/IIN number. --- ";
                    throw new WebException(addInfo + ex.Message, ex, ex.Status, ex.Response);
                }
            }
        }
#endif

    }
}
