--Top 10 fuel consuming “Stops” over the past 12 months.
Select Top 10
	C.customerName as 'Customer Name',
	SUM(DS.noOfGallons) as 'Total fuel consuming'	
from
	FuelDelivery.dbo.DeliveryStop DS
left Join
	FuelDelivery.dbo.customer C
ON
	DS.CustomerID = C.customerId
left join 
	FuelDelivery.dbo.DeliveryEvent DE
ON
	DS.deliveryEventId = DE.deliveryEventId
WHERE
	DATEDIFF(MONTH,DE.eventDate, GETDATE()) <= 12
GROUP BY 
	C.CustomerName
ORDER BY
	'Total fuel consuming' DESc
	 

--Average fuel consumption per delivery, listed by “Stop” for the month. 
Select 
	C.customerName as 'Customer Name',
	AVG(DS.noOfGallons) as 'Average Fuel Consumption'	
from
	FuelDelivery.dbo.DeliveryStop DS
left Join
	FuelDelivery.dbo.customer C
ON
	DS.CustomerID = C.customerId
left join 
	FuelDelivery.dbo.DeliveryEvent DE
ON
	DS.deliveryEventId = DE.deliveryEventId
WHERE
	MONTH(DE.eventDate) = Month(GETDATE()) AND YEAR(DE.eventDate) = YEAR(GETDATE())
GROUP BY 
	C.CustomerName
ORDER BY
	'Customer Name' 


--check the current fuel level for today 
Declare @var1 int
SELECT @var1 = (Select 
	Sum(DS.noOfGallons) 
	--DE.truckId as 'Truck Id',
	--DE.eventDate
from 
	dbo.DeliveryStop DS
Left Join 
	dbo.DeliveryEvent DE
on
	DS.DeliveryEventId = DE.DeliveryEventId 
WHERE
	DAY(DE.eventDate) = DAY(GETDATE())AND 
	MONTH(DE.eventDate) = Month(GETDATE()) AND 
	YEAR(DE.eventDate) = YEAR(GETDATE()) AND
	DE.truckId =1
group By
	DE.eventDate, DE.truckId)
	SELECT @var1 as'Total'

--Calculate how many gallons does this truck delivered today 

SELECT 
	Sum(DS.noOfGallons) As 'Total Number of Gallons'
from 
	dbo.DeliveryStop DS 
Left Join 
	dbo.DeliveryEvent DE 
on 
	DS.DeliveryEventId = DE.DeliveryEventId 
WHERE 
	DAY(DE.eventDate) = DAY(GETDATE())AND 
    MONTH(DE.eventDate) = Month(GETDATE()) AND 
    YEAR(DE.eventDate) = YEAR(GETDATE()) AND 
    DE.truckId = 2