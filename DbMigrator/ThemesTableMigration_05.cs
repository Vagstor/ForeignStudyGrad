using System;
using System.Collections.Generic;
using System.Text;
using ThinkingHome.Migrator.Framework;

namespace DbMigrator
{
    [Migration(5)]
    public class ThemesTableMigration_05 : Migration
    {
        public override void Apply()
        {
            var script = $@"USE [foreignstudy]
GO

/****** Object:  Table [dbo].[themes]    Script Date: 24.04.2020 12:54:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[themes](
	[theme_id] [uniqueidentifier] NOT NULL,
	[theme_name] [varchar](50) NOT NULL,
	[course_id] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_themes] PRIMARY KEY CLUSTERED 
(
	[theme_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[themes]  WITH CHECK ADD  CONSTRAINT [FK_themes_courses] FOREIGN KEY([theme_id])
REFERENCES [dbo].[courses] ([course_id])
GO

ALTER TABLE [dbo].[themes] CHECK CONSTRAINT [FK_themes_courses]
GO



";
            Database.ExecuteNonQuery(script);
        }

        public override void Revert()
        {
            var revert_script = $@"USE [foreignstudy]
GO

/****** Object:  Table [dbo].[themes]    Script Date: 24.04.2020 12:55:07 ******/
DROP TABLE [dbo].[themes]
GO


";
            Database.ExecuteNonQuery(revert_script);
        }
    }
}
