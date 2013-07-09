Orchard-ConnectorListener
=========================

Module to manage Cloud Connector Subscribers in an Orchard Web Site.
(Runs with ASP.NET 4.5)

Basic summary of concept/usage:
Some server in the Cloud asks for a new Connector value to Datwendo Service.
A new index is generated and sent back to the  server: the Publisher.
Then if the Connector/Publisher is associated with a list of Subscribers, each Subscriber connected to the Publisher is notified by a REST Post from Datwendo with the Publisher Id, Subscriber Id, Connector Id and the new index value.
This is the responsability of each Subscriber to start any actions related to this notification.
More on Datwendo http://www.datwendo.com


This Orchard module is built on a Web API Orchard controller and 2 Content Parts: SubscriberPart and NotificationPart.
A System Menu, 'Connector Listener', allows creating new ConnectorListeners content items, each one will filter the Posts received on the api controller.
If there are no Listener for a triplet of ids, Publisher/Subscriber/Connector, the post is simply received without any other action.

As already explained, a Connector Listener manages, within its SubscriberPart a Publisher Id, a subscriber Id and a Connector Id to filter Posts
It also contains the name of a ContentItem to be created when a valid Post is received and filtered, the natural Content Item to create is a Notification content item based on the Datwendo NotificationPart.
This part may also be attached to any Content Item and it could then play some indexing role (the received value is certified unique).
Just keep in mind that the index that the Subscriber receives is related to data created by another server, so the new content item is a data 'proxy' to the real indexed data which resides on the Publisher Server.

The Connector Listener also contains a flag to trigger or not a dedicated Workflow activity (SubscribersActivity).

If the Publisher has used a Data Storage REST Call, the corresponding data could be readen using the received index, the Connector Id and the Connector API (REST Get call).
If the Publisher has used a Blob Storage REST Call, the corresponding blob content could be readen using the received index, the Connector Id and the Connector API (REST Get call).

Thanks.
CS
7/2013
