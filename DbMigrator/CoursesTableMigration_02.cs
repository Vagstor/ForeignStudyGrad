using System;
using System.Collections.Generic;
using System.Text;
using ThinkingHome.Migrator.Framework;

namespace DbMigrator
{
    [Migration(2)]
    public class CoursesTableMigration_02 : Migration
    {
        public override void Apply()
        {
            var script = $@"USE [foreignstudy]
GO

/****** Object:  Table [dbo].[courses]    Script Date: 24.04.2020 12:52:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[courses](
	[course_id] [uniqueidentifier] NOT NULL,
	[course_name] [varchar](max) NULL,
 CONSTRAINT [courses_pkey] PRIMARY KEY CLUSTERED 
(
	[course_id] ASC
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

/****** Object:  Table [dbo].[courses]    Script Date: 24.04.2020 12:52:39 ******/
DROP TABLE [dbo].[courses]
GO

";
            Database.ExecuteNonQuery(revert_script);
        }
    }
}
