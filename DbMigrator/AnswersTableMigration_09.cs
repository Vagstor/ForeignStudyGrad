using System;
using System.Collections.Generic;
using System.Text;
using ThinkingHome.Migrator.Framework;

namespace DbMigrator
{
    [Migration(9)]
    public class AnswersTableMigration_09 : Migration
    {
        public override void Apply()
        {
            var script = $@"USE [foreignstudy]
GO

/****** Object:  Table [dbo].[answers]    Script Date: 24.04.2020 12:57:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[answers](
	[question_id] [uniqueidentifier] NOT NULL,
	[answer_id] [uniqueidentifier] NOT NULL,
	[answer_body] [varchar](50) NOT NULL,
	[answer_ifcorrect] [bit] NOT NULL,
 CONSTRAINT [PK_answers] PRIMARY KEY CLUSTERED 
(
	[answer_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[answers]  WITH CHECK ADD  CONSTRAINT [FK_answers_questions] FOREIGN KEY([question_id])
REFERENCES [dbo].[questions] ([question_id])
GO

ALTER TABLE [dbo].[answers] CHECK CONSTRAINT [FK_answers_questions]
GO



";
            Database.ExecuteNonQuery(script);
        }

        public override void Revert()
        {
            var revert_script = $@"USE [foreignstudy]
GO

/****** Object:  Table [dbo].[answers]    Script Date: 24.04.2020 12:57:59 ******/
DROP TABLE [dbo].[answers]
GO


";
            Database.ExecuteNonQuery(revert_script);
        }
    }
}
