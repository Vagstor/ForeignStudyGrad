using System;
using System.Collections.Generic;
using System.Text;
using ThinkingHome.Migrator.Framework;

namespace DbMigrator
{
    [Migration(1)]
    public class UsersTableMigration_01 : Migration
    {
        public override void Apply()
        {
            var script = $@"USE [foreignstudy]
GO

/****** Object:  Table [dbo].[users]    Script Date: 24.04.2020 12:47:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[users](
	[user_id] [uniqueidentifier] NOT NULL,
	[email] [varchar](max) NULL,
	[login] [varchar](max) NULL,
	[password] [varchar](max) NULL,
	[role] [varchar](max) NULL,
 CONSTRAINT [users_pkey] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO



";
            Database.ExecuteNonQuery(script);
        }

        public override void Revert()
        {
            var revert_script = $@"USE [foreignstudy]
GO

/****** Object:  Table [dbo].[users]    Script Date: 24.04.2020 12:49:02 ******/
DROP TABLE [dbo].[users]
GO


";
            Database.ExecuteNonQuery(revert_script);
        }
    }
}
