using System;
using System.Collections.Generic;
using System.Text;
using ThinkingHome.Migrator.Framework;

namespace DbMigrator
{
    [Migration(3)]
    public class SubscriptionsTableMigration_03 : Migration
    {
        public override void Apply()
        {
            var script = $@"USE [foreignstudy]
GO

/****** Object:  Table [dbo].[subscriptions]    Script Date: 24.04.2020 12:53:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[subscriptions](
	[user_id] [uniqueidentifier] NOT NULL,
	[course_id] [uniqueidentifier] NOT NULL,
	[sub_id] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_subscriptions] PRIMARY KEY CLUSTERED 
(
	[sub_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[subscriptions]  WITH CHECK ADD  CONSTRAINT [FK_subscriptions_courses1] FOREIGN KEY([user_id])
REFERENCES [dbo].[courses] ([course_id])
GO

ALTER TABLE [dbo].[subscriptions] CHECK CONSTRAINT [FK_subscriptions_courses1]
GO

ALTER TABLE [dbo].[subscriptions]  WITH CHECK ADD  CONSTRAINT [FK_subscriptions_users1] FOREIGN KEY([user_id])
REFERENCES [dbo].[users] ([user_id])
GO

ALTER TABLE [dbo].[subscriptions] CHECK CONSTRAINT [FK_subscriptions_users1]
GO



";
            Database.ExecuteNonQuery(script);
        }

        public override void Revert()
        {
            var revert_script = $@"USE [foreignstudy]
GO

/****** Object:  Table [dbo].[subscriptions]    Script Date: 24.04.2020 12:53:33 ******/
DROP TABLE [dbo].[subscriptions]
GO


";
            Database.ExecuteNonQuery(revert_script);
        }
    }
}
