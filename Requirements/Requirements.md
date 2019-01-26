### Requirements

#### Provide a high-level outline for how these classes will be used to maintain a current “state”. 

- The ‘DeliveryStop’ class will have all the details that we need to know in each stop, like the customer name, how many Gallons delivered to this customer. Also, it will take the truck information from the ‘DeliveryEvent’ class, like the truck plate number and service date.

- We will use the ‘DeliveryStop’ table join with the other tables to get the information about the consumption for the customers in certain months


#### Describe how we will store and retrieve information from a SQL database for a recorded fuel stop. Provide a minimal two table definition of “Stops” and “Fuel delivery event” 

- We have five tables:

* `Truck` : has data about the truck, like plate number, and driver name.

* `OperatingRegion` : has data about the different regions like the region name.

* `Customer` : has data about the customer like the name, belong to which region and the max capacity.

* `DeliveryEvent` : has data about which truck will go to deliver the gas and the date.

*  `DeliveryStop` : has data about each stop, like the customer name, how many gallons it delivered to this customer and the DeliveryEventId used. 

- After the truck finishes fueling at the first stop, the dispatcher will calculate how many gallons delivered to this stop- we will insert a new row in the ‘DeliverStop’ table. So, here we will have a record that has data about the name of the customer, how many gallons, and the date of delivery. 

- When we need to retrieve information about which customer(stop) delivered and how many gallons at which date we will select from the ‘DeliverStop’ table.

