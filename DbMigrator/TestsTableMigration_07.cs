﻿using System;
using System.Collections.Generic;
using System.Text;
using ThinkingHome.Migrator.Framework;

namespace DbMigrator
{
    [Migration(7)]
    public class TestsTableMigration_07 : Migration
    {
        public override void Apply()
        {
            var script = $@"USE [foreignstudy]
GO

/****** Object:  Table [dbo].[tests]    Script Date: 24.04.2020 12:56:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[tests](
	[theme_id] [uniqueidentifier] NOT NULL,
	[test_name] [varchar](50) NOT NULL,
	[test_id] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_tests] PRIMARY KEY CLUSTERED 
(
	[test_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[tests]  WITH CHECK ADD  CONSTRAINT [FK_tests_themes] FOREIGN KEY([theme_id])
REFERENCES [dbo].[themes] ([theme_id])
GO

ALTER TABLE [dbo].[tests] CHECK CONSTRAINT [FK_tests_themes]
GO



";
            Database.ExecuteNonQuery(script);
        }

        public override void Revert()
        {
            var revert_script = $@"USE [foreignstudy]
GO

/****** Object:  Table [dbo].[tests]    Script Date: 24.04.2020 12:56:40 ******/
DROP TABLE [dbo].[tests]
GO


";
            Database.ExecuteNonQuery(revert_script);
        }
    }
}
