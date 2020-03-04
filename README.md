# BinInfo 

BinInfo gets information about Credit Card Issuers through [binlist.net](http://binlist.net) public REST API.

NuGet Package -> https://www.nuget.org/packages/BinInfo

## About [binlist.net](http://binlist.net)

[binlist.net](http://binlist.net) is a public web service for searching Issuer Identification Numbers (IIN).

The first 6 digits of a credit card number are known as the Issuer Identification Number (IIN), previously known as Bank Identification Number (BIN). These identify the institution that issued the card to the card holder.

This webservice has an internal database with IIN/BIN information, which is queried via the Rest API. There's no magic or tricky calculations, it's just a database. And although the database is very accurate, don't expect it to be perfect.

## Usage

```C#
IssuerInformation info = BinList.Find("431940"); // First 6 digits of a credit card number.

info.Brand; // => "VISA"
info.Country.Alpha2; // => "IE"
info.Country.Name; // => "Ireland"
info.Bank.Name; // => "BANK OF IRELAND"
info.CardType; // => "DEBIT"
info.Country.Latitude; // => "53"
info.Country.Longitude; // => "-8"
info.Brand; // => "Traditional"
info.Prepaid; // => false

```

## Limits

Requests are throttled at 10 per minute with a burst allowance of 10. If you hit the speed limit the service will return a 429 http status code. (More info: https://binlist.net/)
