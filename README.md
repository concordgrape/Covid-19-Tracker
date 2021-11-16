# Covid-19 Tracker
Covid-19 tracking dashboard

## General info
This Covid-19 tracking application displays specific data from the Canada government while using MSCharts within a WPF application. Data can be found using the link below.

## Technologies
Project is created with:
* WinForms
* WinCharts
* TSQL
	
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
