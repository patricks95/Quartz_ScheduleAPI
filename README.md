Package
----------------------------------
Install-Package Quartz.AspNetCore
----------------------------------


The CRON expression 0 45 7 * * ? schedules the job as follows:
--------------------------------------------------------------
0: Executes at the start of the 45th minute.
45: Minute of the hour.
7: Hour (7 AM).
* *: Any day of the month and any month.
?: No specific day of the week.
--------------------------------------------------------------
