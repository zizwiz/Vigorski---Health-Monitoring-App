# Vigorski - Health Monitor App
Written during Covid-19 Lockdown to keep check of my own health this app will allow the user to check their Blood Pressure, Pulse rate and weight and get information on whether it is optimal or not and a lot more. There is a section on how much energy you require per day as well. Most figure are based on research by more than one set of professionals, so you see the results are in batches.

This app was not made by a qualified health professional. The figures the app produces should only be taken as a guide. If you need accurate information, then you need to consult a qualified health professional.

# Blood Pressure and Heart Rate

Heart pressures are based on information from https://www.bhf.org.uk/ and https://www.heart.org/
Blood pressure is based on information found on http://www.bloodpressureuk.org/. 

If you need more accurate information you will need to consult a qualified health professional. 

The heart will pumps in the following colours for the following conditions:
•	Low = Purple
•	Normal = Green
•	Pre-high = Yellow
•	High = Red

# Oxygen Saturation
During the Covid-19 pandemic it was noticed that if you measure the SPO2 it was found that if you have certain levels of O2 in the blood it can mean you are ill, the % limits are shown below:

•	100% - 95% = OK
•	94% and 93% = Warning Contact Doctor
•	Below 93% = Alert Go to Hospital immediately

# Weight, Body Fat and Body Mass index

These figures come from the works of many health professionals but should be only used as a guide. For more accurate figures you should consider asking a qualified health professional for advice.
 
# Energy Required

These figures are only a guide. If you require more accurate ones, then you will need to consult a health professional.

The Harris-Benedict Equation was one of the earliest equations used to calculate basal metabolic rate (BMR), which is the amount of energy expended per day at rest. In 1984 it was revised to be more accurate

In 1990 the Mifflin-St Jeor Equation was introduced as it was and still is considered the most accurate. 

The Katch-McArdle Formula calculates resting daily energy expenditure and as such can be more accurate for people who are leaner and know their body fat percentage.

All the figures assume you do moderate exercise at least 5 times a week.

# Graphs and Data
In this section you can show all you recorded data. All data is stored and show in Metric.
 
# Save Data
The data is saved as a Comma Separated File (.csv). It is done this way so it is easy for the user to edit, copy or transfer the file. The layout of the file is
                                   Date,Time,Systolic,Diastolic,Pulse,SPO2,Weight,Temperature

The weight and temperature can be decimal numbers and as such are enclosed in quotes as is common in csv files. Depending on where in the world you are, the decimal may be a point or a comma.
                                   Date,Time,Systolic,Diastolic,Pulse,SPO2,Weight,Temperature
                                   22/01/2021,18:03:52,120,80,75,100,"72.5","34.25",

