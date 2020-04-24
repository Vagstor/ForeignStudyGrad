using System;
using System.Collections.Generic;
using System.Text;
using ThinkingHome.Migrator.Framework;

namespace DbMigrator
{
    [Migration(6)]
    public class LecturesTableMigration_06 : Migration
    {
        public override void Apply()
        {
            var script = $@"USE [foreignstudy]
GO

/****** Object:  Table [dbo].[lectures]    Script Date: 24.04.2020 12:55:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[lectures](
	[lecture_id] [uniqueidentifier] NOT NULL,
	[lecture_filelink] [varchar](50) NOT NULL,
	[lecture_name] [varchar](50) NOT NULL,
	[theme_id] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_lectures] PRIMARY KEY CLUSTERED 
(
	[lecture_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[lectures]  WITH CHECK ADD  CONSTRAINT [FK_lectures_themes] FOREIGN KEY([lecture_id])
REFERENCES [dbo].[themes] ([theme_id])
GO

ALTER TABLE [dbo].[lectures] CHECK CONSTRAINT [FK_lectures_themes]
GO



";
            Database.ExecuteNonQuery(script);
        }

        public override void Revert()
        {
            var revert_script = $@"USE [foreignstudy]
GO

/****** Object:  Table [dbo].[lectures]    Script Date: 24.04.2020 12:55:55 ******/
DROP TABLE [dbo].[lectures]
GO


";
            Database.ExecuteNonQuery(revert_script);
        }
    }
}
