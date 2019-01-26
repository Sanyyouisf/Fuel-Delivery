## FuelDeliveryProject


### Summary:
 A client needs a system designed to assist with dispatching fuel delivery trucks in the local area. All the fuel trucks have the same fixed capacity of fuel for delivery, and deliveries will usually drain between 5% and 17% of the total capacity. Unfortunately, the amount needed at each stop is unknown so a dispatcher is required to set the next stop on the fly or instruct the truck to return to base for refilling. The system will utilize three components to get job done; an embedded system on the trucks, a desktop application for the dispatcher, and a web service so the sygitstems can communicate.
### Requirements:

- Create a design consisting of any combination of code, pseudo-code, or diagrams that can help us set the roadmap for creating this new system.
- List class definitions for any objects needed in the dispatcher application.
- Provide a high level outline for how these classes will be used to maintain a
       current “state”.
- List web service method signatures that the truck will call to get or post
       information to the dispatcher.
- Describe how we will store and retrieve information from a SQL database for a
recorded fuel stop. Provide a minimal two table definition of “Stops” and
       “Fuel delivery event”
       
 ### Demonstrate delivery reporting capability by writing two SQL queries to show the following:
- Top 10 fuel consuming “Stops” over the past 12 months.
- Average fuel consumption per delivery, listed by “Stop” for the month.

### Limitations/extra info:
- Trucks are limited to certain “operating regions” and need to be displayed to the dispatcher by “operating region”
- The truck’s embedded system only “knows” three things: current fuel level, current stop, and next stop.
- The truck does not have its next stop set remotely, it must poll the service for a new stop.
- “Stops” are unique identifiers for customer locations. (though the truck can be set to a special “stop” to instruct it to return for refill)

### Technologies Used

- `ASP.NET WEB API`
 

### Contributor
[Sany Yousif](https://github.com/Sanyyouisf)