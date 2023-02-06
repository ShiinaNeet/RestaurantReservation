declare @timetime datetime; 
set @timetime =  cast('12/01/2023 7:51:00 PM' as datetime);

select * from Reservations where ResvDate = @timetime
SELECT CASE WHEN EXISTS(SELECT ResvDate from Reservations where ResvDate  BETWEEN @timetime AND DATEADD(HOUR,1,@timetime) 
AND tablenum = 4) THEN 'TRUE' ELSE 'FALSE' end
                