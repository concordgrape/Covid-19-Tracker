USE A4Charts;
GO

DROP TABLE CovidData;
CREATE TABLE CovidData (
	pruid int,
	prname varchar(30),
	prnameFR varchar(30),
	selectedDate DATETIME,
	lastUpdate int,
	numconf int,
	numprob int,
	numdeaths int,
	numtotal int,
	numtested int,
	numtests int,
	numrecovered int,
	percentrecovered float,
	ratetested float,
	ratetests int,
	numtoday int,
	percenttoday float,
	ratetotal float,
	ratedeaths float,
	numdeathstoday int,
	percentdeath float,
	numtestedtoday int,
	numteststoday int,
	numrecoveredtoday int,
	percentactive float,
	numactive int,
	rateactive float,
	numtotal_last14 int,
	ratetotal_last14 int,
	numdeaths_last14 int,
	ratedeaths_last14 float,
	numtotal_last7 int,
	ratetotal_last7 float,
	numdeaths_last7 int,
	ratedeaths_last7 float,
	avgtotal_last7 float,
	avgincidence_last7 float,
	avgdeaths_last7 float,
	avgratedeaths_last7 float,
	raterecovered float
);
GO

select count(*) from CovidData