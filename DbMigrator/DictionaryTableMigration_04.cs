using System;
using System.Collections.Generic;
using System.Text;
using ThinkingHome.Migrator.Framework;

namespace DbMigrator
{
    [Migration(4)]
    public class DictionaryTableMigration_04 : Migration
    {
        public override void Apply()
        {
            var script = $@"USE [foreignstudy]
GO

/****** Object:  Table [dbo].[dictionaries]    Script Date: 24.04.2020 12:54:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[dictionaries](
	[word_id] [uniqueidentifier] NOT NULL,
	[word_body] [varchar](50) NOT NULL,
	[user_id] [uniqueidentifier] NOT NULL,
    [WordTranslation] [varchar](50) NOT NULL,
    [WordOriginal] [varchar](50) NOT NULL,
 CONSTRAINT [PK_dictionaries] PRIMARY KEY CLUSTERED 
(
	[word_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[dictionaries]  WITH CHECK ADD  CONSTRAINT [FK_dictionaries_users] FOREIGN KEY([word_id])
REFERENCES [dbo].[users] ([user_id])
GO

ALTER TABLE [dbo].[dictionaries] CHECK CONSTRAINT [FK_dictionaries_users]
GO



";
            Database.ExecuteNonQuery(script);
        }

        public override void Revert()
        {
            var revert_script = $@"USE [foreignstudy]
GO

/****** Object:  Table [dbo].[dictionaries]    Script Date: 24.04.2020 12:54:24 ******/
DROP TABLE [dbo].[dictionaries]
GO



";
            Database.ExecuteNonQuery(revert_script);
        }
    }
}
