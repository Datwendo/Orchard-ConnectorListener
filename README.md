Orchard-ConnectorListener
=========================

Module to manage Cloud Connector Subscribers in an Orchard Web Site.

Basic summary of concept/usage:
Some server in the Cloud asks for a new connector value to Datwendo Service.
A new index is generated and sent back to the  server: the Publisher.
Then if the Connector is associated with a list of Publishers/Subscribers, each Subscriber connected to this Publisher is notified by a REST post from Datwendo with the Publisher Id, Subscriber Id, Connector Id and the new index value.
This is the responsability of each Subscriber to start the necessary actions followingb this notification.


This Orchard module is built on a Web API Orchard controller and 2 Content Parts: SubscriberPart and NotificationPart.
A System Menu, 'Connector Listener', allows creating new ConnectorListeners content items, each one will filter the posts received on the api controller.
If there are no Listener for a triplet of ids, Publisher/Subscriber/Connector, the post is simply receipted without any other action.

As already explained, a Connector Listener manages a Publisher Id, a subscriber Id and a Connector Id to filter posts
It also contains the name of a ContentItem to create when a valid post is received, the natural content item is a Notification content Item based on the Datwendo NotificationPart.
This part may also be attached to any Content Item and it could then play some index role.
Just keep in mind that the index that the Subscriber receives is related to data created by another server, so the new content item is a data 'proxy' to the real indexed data which reside on the Publisger Server.

The Connector Listener also contains a flag to trigger or no a Dedicated Workflow activity.

If the Publisher has used a Data Storage REST Call, the corresponding data could be readen using the received index from Datwendo Service using the Connector API.
If the Publisher has used a Blob Storage REST Call, the corresponding blob content could be readen using the received index from Datwendo Service using the Connector API.

Thanks.
CS
7/2013
