Orchard-ConnectorListener
=========================

Module to manage Cloud Connector Subscribers in an Orchard Web Site.

Basically some server in the Cloud ask for a new connector value to Datendo Service.
A new index is generated and sent back to the  server.
Then if the Connector is associated with a list of subscribers, each subscriber is notified by a post from Datwendo with the subscriber Id and the new index value.
This is the responsability of each subscriber to start the necessary actions.


This Orchard module is built on a Web API Orchard controller and 2  ContentParts: SubscriberPart and NotificationPart.
A System Menu, Connector Listener', allows creating new ConnectorListeners content items, each one will filter the posts received on the api controller.
If there are no Listener for a triplet of ids, Publisher/Subscriber/Connector, the post is simply rejected.

A Connector Listener manages a Publisher Id, a subscriber Id and a Connector Id to filter posts
It also contains the name of a contentItem to create when a post is received, the natural content item is a Notification base on theDatwendo NotificationPart.
This part may also be attached to any Content Item and it could then play some index role.
Just keep in mind that the index that the Subscriber receives is related to data created by another server, so the new content item is a data 'proxy' to the real indexed data which reside on the Publisger Server.

The Connector Listener also contains a flag to trigger or no a Dedicated Workflow activity.

Thanks.
CS
7/2013
