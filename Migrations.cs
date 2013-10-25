using System;
using System.Collections.Generic;
using System.Data;
using Orchard.ContentManagement.Drivers;
using Orchard.ContentManagement.MetaData;
using Orchard.ContentManagement.MetaData.Builders;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;


namespace Datwendo.ConnectorListener {
    public class Migrations : DataMigrationImpl {

        public int Create() 
        {
            SchemaBuilder.CreateTable("SubscriberPartRecord", table => table
                    .ContentPartRecord()
                    .Column<int>("SubscriberId", c => c.WithDefault(0))
                    .Column<int>("PublisherId", c => c.WithDefault(0))
                    .Column<int>("ConnectorId", c => c.WithDefault(0))
                    .Column<string>("ContentTypeName", c => c.WithLength(255).WithDefault("ConnectorNotification"))
                    .Column<bool>("TriggerWorkflow", c => c.WithDefault(false))
                    );

            ContentDefinitionManager.AlterPartDefinition("SubscriberPart",
                builder => builder.Attachable(false));

            // to avoid duplicate subscribers/publishers in table
            SchemaBuilder.ExecuteSql("ALTER TABLE Datwendo_ConnectorListener_SubscriberPartRecord ADD CONSTRAINT uc_sb_subscriber_publisher UNIQUE (SubscriberId,PublisherId)");    

            ContentDefinitionManager.AlterTypeDefinition("ConnectorListener", cfg => cfg
                   .WithPart("SubscriberPart")
                   .WithPart("CommonPart", p => p
                       .WithSetting("DateEditorSettings.ShowDateEditor", "false")
                       .WithSetting("OwnerEditorSettings.ShowOwnerEditor", "false"))
                   .Creatable(false)
                   .Draftable(false));

            SchemaBuilder.CreateTable("NotificationPartRecord", table => table
                    .ContentPartRecord()
                    .Column<int>("PublisherId", c => c.WithDefault(0))
                    .Column<int>("SubscriberId", c => c.WithDefault(0))
                    .Column<int>("CounterId", c => c.WithDefault(0))
                    .Column<int>("IdxVal", c => c.WithDefault(0))
                    .Column<int>("StateCode", c => c.WithDefault(0))
                    .Column<int>("DataType", c => c.WithDefault(0))
                    .Column<string>("SecretKey", c => c.WithLength(400)));

            ContentDefinitionManager.AlterPartDefinition("NotificationPart",
                builder => builder.Attachable(true));

            ContentDefinitionManager.AlterTypeDefinition("ConnectorNotification", cfg => cfg
               .WithPart("NotificationPart")
               .WithPart("CommonPart", p => p
                   .WithSetting("DateEditorSettings.ShowDateEditor", "false")
                   .WithSetting("OwnerEditorSettings.ShowOwnerEditor", "false"))
               .Creatable(false)
               .Draftable(false));

            return 3;
        }
        public int UpdateFrom1()
        {
            SchemaBuilder.AlterTable("NotificationPartRecord", table => table
                    .DropColumn("Key"));

            SchemaBuilder.AlterTable("NotificationPartRecord", table => table
                    .AddColumn<string>("SecretKey", c => c.WithLength(400)));
            return 2;
        }

        public int UpdateFrom2()
        {
            SchemaBuilder.AlterTable("NotificationPartRecord", table => table
                .DropColumn("Index"));
            SchemaBuilder.AlterTable("NotificationPartRecord", table => table
                .DropColumn("Status"));
            SchemaBuilder.AlterTable("NotificationPartRecord", table => table
                .AddColumn<int>("IdxVal", c => c.WithDefault(0)));
            SchemaBuilder.AlterTable("NotificationPartRecord", table => table
                .AddColumn<int>("StateCode", c => c.WithDefault(0)));
        return 3;
        }

        public int UpdateFrom3()
        {
            SchemaBuilder.AlterTable("NotificationPartRecord", table => table
                .AddColumn<int>("DataType", c => c.WithDefault(0)));
            return 4;
        }
    }
}