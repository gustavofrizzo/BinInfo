using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using BinInfo.Models;

namespace BinInfo
{
    public static class BinList
    {
        /// <summary>
        /// binlist.net is a public web service for searching Issuer Identification Numbers (IIN).
        /// <para>This webservice has an internal database with IIN/BIN information.</para>
        /// </summary>
        /// <param name="bin">The first 6 digits of a credit card number.</param>
        /// <exception cref="System.Net.WebException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <returns>IssuerInformation</returns>
        public static IssuerInformation Find(string bin)
        {
            if (bin == null)
                throw new ArgumentNullException();

            if (!bin.Trim().All(c => char.IsNumber(c)))
                throw new ArgumentException("Make sure to enter a valid BIN/IIN number.");

            using (WebClient web = new WebClient())
            {
                try
                {
                    string json = web.DownloadString("https://lookup.binlist.net/" + bin);

                    DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(IssuerInformation));

                    var issuerInfo =
                        (IssuerInformation)serializer.ReadObject(new MemoryStream(Encoding.Default.GetBytes(json)));

                    return issuerInfo;
                }
                catch (WebException ex)
                {
                    string addInfo = $"No results for {bin}. Make sure you enter a valid BIN/IIN number. --- ";
                    throw new WebException(addInfo + ex.Message, ex, ex.Status, ex.Response);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

    }
}
