# Don8: Blockchain Donation Website
(get it? "donate")

## General info
Don8 is a simple blockchain based off of Naivechain [(Github)](https://github.com/lhartikk/naivechain)
This website allows users to add fundraisers through a blockchain, or donate to a specific cryptocurrency address.
These fundraisers will include a cryptocurrency wallet address so that everything stays anonymous.

# Covid-19 Tracker

## Technologies
Project is created with:
* WinForms
* WinCharts
* C#
	
## Setup
To correctly run SQL please input a SQL connection string in the App.config file as well as a path to the CSV data file that the Canadian government provides.
https://health-infobase.canada.ca/covid-19/epidemiological-summary-covid-19-cases.html

When you first run the application, it may take a little time as it's filling SQL queries.

```
$ open /sroth1644_A4/sroth1644_A4/App.config         -> Edit config file with appropriate strings
$ open ../sroth1644_A4.sln                           -> Open the main solution
```

## Charts
Charts can be easily edited through the solution, the default charts will remain as a pie and line chart.
