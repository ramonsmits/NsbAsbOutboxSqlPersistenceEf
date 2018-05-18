# NsbAsbOutboxSqlPersistenceEf

I have tried to create a reproducible solution so that Particular might be able to give me some guidance. 

Endpoint1 is the endpoint that works, it has the SaveChanges inside the handler. This is not the way I want it.

Endpoint2 is an endpoint where I have tried to inject an NServiceBus Behavior, so that I don't need to do SaveChanges in all handlers. 
This is not working, I get some exceptions when executing about 10 PlaceOrderCommands in one go. 
I think I got this to work as well, but with SaveChanges in the handler and NOT in the PersistAndPublishBehavior 

UnitTests 
Since we cannot inject the DbContext like we did in V5, we cannot Fake the DbContext 
