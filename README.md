# BinInfo 

BinInfo gets information about Credit Card Issuers through [binlist.net](http://binlist.net) public REST API.

## About [binlist.net](http://binlist.net)

[binlist.net](http://binlist.net) is a public web service for searching Issuer Identification Numbers (IIN).

The first 6 digits of a credit card number are known as the Issuer Identification Number (IIN), previously known as Bank Identification Number (BIN). These identify the institution that issued the card to the card holder.

This webservice has an internal database with IIN/BIN information, which is queried via the Rest API. There's no magic or tricky calculations, it's just a database. And although the database is very accurate, don't expect it to be perfect.

## Usage

```C#
IssuerInformation info = BinList.Find("431940"); // First 6 digits of a credit card number.

info.Bin; // => "431940"
info.Brand; // => "VISA"
info.CountryCode; // => "IE"
info.CountryName; // => "Ireland"
info.Bank; // => "BANK OF IRELAND"
info.CardType; // => "DEBIT"
info.Latitude; // => "53"
info.Longitude; // => "-8"
info.SubBrand; // => ""
info.CardCategory; // => ""
info.QueryTime; // => "226.125µs"
```

## Limits

Due to the high volume of queries binlist.net implemented a throttling mechanism, which allows at most 10,000 queries per hour. After reaching this hourly quota, all your requests result in HTTP 403 (Forbidden) until it clears up on the next roll over.
