﻿//---------------------------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated by T4Model template for T4 (https://github.com/linq2db/linq2db).
//    Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//---------------------------------------------------------------------------------------------------

#pragma warning disable 1591

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using LinqToDB;
using LinqToDB.Common;
using LinqToDB.Data;
using LinqToDB.Mapping;

namespace DataModels
{
	/// <summary>
	/// Database       : foreignstudy
	/// Data Source    : tcp:foreignstudygraddbserver.database.windows.net,1433
	/// Server Version : 12.00.2000
	/// </summary>
	public partial class ForeignstudyDB : LinqToDB.Data.DataConnection
	{
		public ITable<Answer>                   Answers               { get { return this.GetTable<Answer>(); } }
		public ITable<Cours>                    Courses               { get { return this.GetTable<Cours>(); } }
		public ITable<sys_DatabaseFirewallRule> DatabaseFirewallRules { get { return this.GetTable<sys_DatabaseFirewallRule>(); } }
		public ITable<Dictionary>               Dictionaries          { get { return this.GetTable<Dictionary>(); } }
		public ITable<Lecture>                  Lectures              { get { return this.GetTable<Lecture>(); } }
		public ITable<Question>                 Questions             { get { return this.GetTable<Question>(); } }
		public ITable<SchemaInfo>               SchemaInfo            { get { return this.GetTable<SchemaInfo>(); } }
		public ITable<Subscription>             Subscriptions         { get { return this.GetTable<Subscription>(); } }
		public ITable<Sysdiagram>               Sysdiagrams           { get { return this.GetTable<Sysdiagram>(); } }
		public ITable<Test>                     Tests                 { get { return this.GetTable<Test>(); } }
		public ITable<Theme>                    Themes                { get { return this.GetTable<Theme>(); } }
		public ITable<User>                     Users                 { get { return this.GetTable<User>(); } }

		public ForeignstudyDB()
		{
			InitDataContext();
			InitMappingSchema();
		}

		public ForeignstudyDB(string configuration)
			: base(configuration)
		{
			InitDataContext();
			InitMappingSchema();
		}

		partial void InitDataContext  ();
		partial void InitMappingSchema();
	}

	[Table(Schema="dbo", Name="answers")]
	public partial class Answer
	{
		[Column("question_id"),                  NotNull] public Guid   QuestionId      { get; set; } // uniqueidentifier
		[Column("answer_id"),        PrimaryKey, NotNull] public Guid   AnswerId        { get; set; } // uniqueidentifier
		[Column("answer_body"),                  NotNull] public string AnswerBody      { get; set; } // varchar(50)
		[Column("answer_ifcorrect"),             NotNull] public bool   AnswerIfcorrect { get; set; } // bit

		#region Associations

		/// <summary>
		/// FK_answers_questions1
		/// </summary>
		[Association(ThisKey="QuestionId", OtherKey="QuestionId", CanBeNull=false, Relationship=Relationship.ManyToOne, KeyName="FK_answers_questions1", BackReferenceName="Answersquestions")]
		public Question Question { get; set; }

		#endregion
	}

	[Table(Schema="dbo", Name="courses")]
	public partial class Cours
	{
		[Column("course_id"),   PrimaryKey,  NotNull] public Guid   CourseId   { get; set; } // uniqueidentifier
		[Column("course_name"),    Nullable         ] public string CourseName { get; set; } // varchar(max)

		#region Associations

		/// <summary>
		/// FK_subscriptions_courses_BackReference
		/// </summary>
		[Association(ThisKey="CourseId", OtherKey="CourseId", CanBeNull=true, Relationship=Relationship.OneToMany, IsBackReference=true)]
		public IEnumerable<Subscription> Subscriptions { get; set; }

		/// <summary>
		/// FK_themes_courses1_BackReference
		/// </summary>
		[Association(ThisKey="CourseId", OtherKey="CourseId", CanBeNull=true, Relationship=Relationship.OneToMany, IsBackReference=true)]
		public IEnumerable<Theme> Themescourses { get; set; }

		#endregion
	}

	[Table(Schema="sys", Name="database_firewall_rules", IsView=true)]
	public partial class sys_DatabaseFirewallRule
	{
		[Column("id"),               Identity] public int      Id             { get; set; } // int
		[Column("name"),             NotNull ] public string   Name           { get; set; } // nvarchar(128)
		[Column("start_ip_address"), NotNull ] public string   StartIpAddress { get; set; } // varchar(45)
		[Column("end_ip_address"),   NotNull ] public string   EndIpAddress   { get; set; } // varchar(45)
		[Column("create_date"),      NotNull ] public DateTime CreateDate     { get; set; } // datetime
		[Column("modify_date"),      NotNull ] public DateTime ModifyDate     { get; set; } // datetime
	}

	[Table(Schema="dbo", Name="dictionaries")]
	public partial class Dictionary
	{
		[Column("word_id"),          PrimaryKey,  NotNull] public Guid   WordId          { get; set; } // uniqueidentifier
		[Column("user_id"),                       NotNull] public Guid   UserId          { get; set; } // uniqueidentifier
		[Column("word_translation"),    Nullable         ] public string WordTranslation { get; set; } // varchar(50)
		[Column("word_original"),       Nullable         ] public string WordOriginal    { get; set; } // varchar(50)

		#region Associations

		/// <summary>
		/// FK_dictionaries_users1
		/// </summary>
		[Association(ThisKey="UserId", OtherKey="UserId", CanBeNull=false, Relationship=Relationship.ManyToOne, KeyName="FK_dictionaries_users1", BackReferenceName="Dictionariesusers")]
		public User User { get; set; }

		#endregion
	}

	[Table(Schema="dbo", Name="lectures")]
	public partial class Lecture
	{
		[Column("lecture_id"),       PrimaryKey,  NotNull] public Guid   LectureId       { get; set; } // uniqueidentifier
		[Column("lecture_filelink"),    Nullable         ] public string LectureFilelink { get; set; } // varchar(50)
		[Column("lecture_name"),                  NotNull] public string LectureName     { get; set; } // varchar(50)
		[Column("theme_id"),                      NotNull] public Guid   ThemeId         { get; set; } // uniqueidentifier

		#region Associations

		/// <summary>
		/// FK_lectures_themes1
		/// </summary>
		[Association(ThisKey="ThemeId", OtherKey="ThemeId", CanBeNull=false, Relationship=Relationship.ManyToOne, KeyName="FK_lectures_themes1", BackReferenceName="Lecturesthemes")]
		public Theme Theme { get; set; }

		#endregion
	}

	[Table(Schema="dbo", Name="questions")]
	public partial class Question
	{
		[Column("test_id"),                   NotNull] public Guid   TestId       { get; set; } // uniqueidentifier
		[Column("question_id"),   PrimaryKey, NotNull] public Guid   QuestionId   { get; set; } // uniqueidentifier
		[Column("question_body"),             NotNull] public string QuestionBody { get; set; } // varchar(50)

		#region Associations

		/// <summary>
		/// FK_answers_questions1_BackReference
		/// </summary>
		[Association(ThisKey="QuestionId", OtherKey="QuestionId", CanBeNull=true, Relationship=Relationship.OneToMany, IsBackReference=true)]
		public IEnumerable<Answer> Answersquestions { get; set; }

		/// <summary>
		/// FK_questions_tests1
		/// </summary>
		[Association(ThisKey="TestId", OtherKey="TestId", CanBeNull=false, Relationship=Relationship.ManyToOne, KeyName="FK_questions_tests1", BackReferenceName="Questionstests")]
		public Test Test { get; set; }

		#endregion
	}

	[Table(Schema="dbo", Name="SchemaInfo")]
	public partial class SchemaInfo
	{
		[PrimaryKey(1), NotNull] public long   Version     { get; set; } // bigint
		[PrimaryKey(2), NotNull] public string AssemblyKey { get; set; } // nvarchar(200)
	}

	[Table(Schema="dbo", Name="subscriptions")]
	public partial class Subscription
	{
		[Column("user_id"),               NotNull] public Guid UserId   { get; set; } // uniqueidentifier
		[Column("course_id"),             NotNull] public Guid CourseId { get; set; } // uniqueidentifier
		[Column("sub_id"),    PrimaryKey, NotNull] public Guid SubId    { get; set; } // uniqueidentifier

		#region Associations

		/// <summary>
		/// FK_subscriptions_courses
		/// </summary>
		[Association(ThisKey="CourseId", OtherKey="CourseId", CanBeNull=false, Relationship=Relationship.ManyToOne, KeyName="FK_subscriptions_courses", BackReferenceName="Subscriptions")]
		public Cours Course { get; set; }

		/// <summary>
		/// FK_subscriptions_users1
		/// </summary>
		[Association(ThisKey="UserId", OtherKey="UserId", CanBeNull=false, Relationship=Relationship.ManyToOne, KeyName="FK_subscriptions_users1", BackReferenceName="Subscriptionsusers")]
		public User User { get; set; }

		#endregion
	}

	[Table(Schema="dbo", Name="sysdiagrams")]
	public partial class Sysdiagram
	{
		[Column("name"),         NotNull              ] public string Name        { get; set; } // nvarchar(128)
		[Column("principal_id"), NotNull              ] public int    PrincipalId { get; set; } // int
		[Column("diagram_id"),   PrimaryKey,  Identity] public int    DiagramId   { get; set; } // int
		[Column("version"),         Nullable          ] public int?   Version     { get; set; } // int
		[Column("definition"),      Nullable          ] public byte[] Definition  { get; set; } // varbinary(max)
	}

	[Table(Schema="dbo", Name="tests")]
	public partial class Test
	{
		[Column("theme_id"),              NotNull] public Guid   ThemeId  { get; set; } // uniqueidentifier
		[Column("test_name"),             NotNull] public string TestName { get; set; } // varchar(50)
		[Column("test_id"),   PrimaryKey, NotNull] public Guid   TestId   { get; set; } // uniqueidentifier

		#region Associations

		/// <summary>
		/// FK_questions_tests1_BackReference
		/// </summary>
		[Association(ThisKey="TestId", OtherKey="TestId", CanBeNull=true, Relationship=Relationship.OneToMany, IsBackReference=true)]
		public IEnumerable<Question> Questionstests { get; set; }

		/// <summary>
		/// FK_tests_themes1
		/// </summary>
		[Association(ThisKey="ThemeId", OtherKey="ThemeId", CanBeNull=false, Relationship=Relationship.ManyToOne, KeyName="FK_tests_themes1", BackReferenceName="Teststhemes")]
		public Theme Theme { get; set; }

		#endregion
	}

	[Table(Schema="dbo", Name="themes")]
	public partial class Theme
	{
		[Column("theme_id"),     PrimaryKey,  NotNull] public Guid   ThemeId     { get; set; } // uniqueidentifier
		[Column("theme_name"),                NotNull] public string ThemeName   { get; set; } // varchar(50)
		[Column("course_id"),                 NotNull] public Guid   CourseId    { get; set; } // uniqueidentifier
		[Column("viewname"),        Nullable         ] public string Viewname    { get; set; } // varchar(max)
		[Column("theme_number"),    Nullable         ] public byte?  ThemeNumber { get; set; } // tinyint
		[Column("theme_goal"),      Nullable         ] public string ThemeGoal   { get; set; } // varchar(max)

		#region Associations

		/// <summary>
		/// FK_themes_courses1
		/// </summary>
		[Association(ThisKey="CourseId", OtherKey="CourseId", CanBeNull=false, Relationship=Relationship.ManyToOne, KeyName="FK_themes_courses1", BackReferenceName="Themescourses")]
		public Cours Course { get; set; }

		/// <summary>
		/// FK_lectures_themes1_BackReference
		/// </summary>
		[Association(ThisKey="ThemeId", OtherKey="ThemeId", CanBeNull=true, Relationship=Relationship.OneToMany, IsBackReference=true)]
		public IEnumerable<Lecture> Lecturesthemes { get; set; }

		/// <summary>
		/// FK_tests_themes1_BackReference
		/// </summary>
		[Association(ThisKey="ThemeId", OtherKey="ThemeId", CanBeNull=true, Relationship=Relationship.OneToMany, IsBackReference=true)]
		public IEnumerable<Test> Teststhemes { get; set; }

		#endregion
	}

	[Table(Schema="dbo", Name="users")]
	public partial class User
	{
		[Column("user_id"),  PrimaryKey,  NotNull] public Guid   UserId   { get; set; } // uniqueidentifier
		[Column("email"),       Nullable         ] public string Email    { get; set; } // varchar(max)
		[Column("login"),       Nullable         ] public string Login    { get; set; } // varchar(max)
		[Column("password"),    Nullable         ] public string Password { get; set; } // varchar(max)
		[Column("role"),        Nullable         ] public string Role     { get; set; } // varchar(max)

		#region Associations

		/// <summary>
		/// FK_dictionaries_users1_BackReference
		/// </summary>
		[Association(ThisKey="UserId", OtherKey="UserId", CanBeNull=true, Relationship=Relationship.OneToMany, IsBackReference=true)]
		public IEnumerable<Dictionary> Dictionariesusers { get; set; }

		/// <summary>
		/// FK_subscriptions_users1_BackReference
		/// </summary>
		[Association(ThisKey="UserId", OtherKey="UserId", CanBeNull=true, Relationship=Relationship.OneToMany, IsBackReference=true)]
		public IEnumerable<Subscription> Subscriptionsusers { get; set; }

		#endregion
	}

	public static partial class ForeignstudyDBStoredProcedures
	{
		#region SpAlterdiagram

		public static int SpAlterdiagram(this ForeignstudyDB dataConnection, string @diagramname, int? @owner_id, int? @version, byte[] @definition)
		{
			return dataConnection.ExecuteProc("[dbo].[sp_alterdiagram]",
				new DataParameter("@diagramname", @diagramname, DataType.NVarChar),
				new DataParameter("@owner_id",    @owner_id,    DataType.Int32),
				new DataParameter("@version",     @version,     DataType.Int32),
				new DataParameter("@definition",  @definition,  DataType.VarBinary));
		}

		#endregion

		#region SpCreatediagram

		public static int SpCreatediagram(this ForeignstudyDB dataConnection, string @diagramname, int? @owner_id, int? @version, byte[] @definition)
		{
			return dataConnection.ExecuteProc("[dbo].[sp_creatediagram]",
				new DataParameter("@diagramname", @diagramname, DataType.NVarChar),
				new DataParameter("@owner_id",    @owner_id,    DataType.Int32),
				new DataParameter("@version",     @version,     DataType.Int32),
				new DataParameter("@definition",  @definition,  DataType.VarBinary));
		}

		#endregion

		#region SpDropdiagram

		public static int SpDropdiagram(this ForeignstudyDB dataConnection, string @diagramname, int? @owner_id)
		{
			return dataConnection.ExecuteProc("[dbo].[sp_dropdiagram]",
				new DataParameter("@diagramname", @diagramname, DataType.NVarChar),
				new DataParameter("@owner_id",    @owner_id,    DataType.Int32));
		}

		#endregion

		#region SpHelpdiagramdefinition

		public static IEnumerable<SpHelpdiagramdefinitionResult> SpHelpdiagramdefinition(this ForeignstudyDB dataConnection, string @diagramname, int? @owner_id)
		{
			return dataConnection.QueryProc<SpHelpdiagramdefinitionResult>("[dbo].[sp_helpdiagramdefinition]",
				new DataParameter("@diagramname", @diagramname, DataType.NVarChar),
				new DataParameter("@owner_id",    @owner_id,    DataType.Int32));
		}

		public partial class SpHelpdiagramdefinitionResult
		{
			public int?   version    { get; set; }
			public byte[] definition { get; set; }
		}

		#endregion

		#region SpHelpdiagrams

		public static IEnumerable<SpHelpdiagramsResult> SpHelpdiagrams(this ForeignstudyDB dataConnection, string @diagramname, int? @owner_id)
		{
			return dataConnection.QueryProc<SpHelpdiagramsResult>("[dbo].[sp_helpdiagrams]",
				new DataParameter("@diagramname", @diagramname, DataType.NVarChar),
				new DataParameter("@owner_id",    @owner_id,    DataType.Int32));
		}

		public partial class SpHelpdiagramsResult
		{
			public string Database { get; set; }
			public string Name     { get; set; }
			public int    ID       { get; set; }
			public string Owner    { get; set; }
			public int    OwnerID  { get; set; }
		}

		#endregion

		#region SpRenamediagram

		public static int SpRenamediagram(this ForeignstudyDB dataConnection, string @diagramname, int? @owner_id, string @new_diagramname)
		{
			return dataConnection.ExecuteProc("[dbo].[sp_renamediagram]",
				new DataParameter("@diagramname",     @diagramname,     DataType.NVarChar),
				new DataParameter("@owner_id",        @owner_id,        DataType.Int32),
				new DataParameter("@new_diagramname", @new_diagramname, DataType.NVarChar));
		}

		#endregion
	}

	public static partial class SqlFunctions
	{
		#region FnDiagramobjects

		[Sql.Function(Name="dbo.fn_diagramobjects", ServerSideOnly=true)]
		public static int? FnDiagramobjects()
		{
			throw new InvalidOperationException();
		}

		#endregion
	}

	public static partial class TableExtensions
	{
		public static Answer Find(this ITable<Answer> table, Guid AnswerId)
		{
			return table.FirstOrDefault(t =>
				t.AnswerId == AnswerId);
		}

		public static Cours Find(this ITable<Cours> table, Guid CourseId)
		{
			return table.FirstOrDefault(t =>
				t.CourseId == CourseId);
		}

		public static Dictionary Find(this ITable<Dictionary> table, Guid WordId)
		{
			return table.FirstOrDefault(t =>
				t.WordId == WordId);
		}

		public static Lecture Find(this ITable<Lecture> table, Guid LectureId)
		{
			return table.FirstOrDefault(t =>
				t.LectureId == LectureId);
		}

		public static Question Find(this ITable<Question> table, Guid QuestionId)
		{
			return table.FirstOrDefault(t =>
				t.QuestionId == QuestionId);
		}

		public static SchemaInfo Find(this ITable<SchemaInfo> table, long Version, string AssemblyKey)
		{
			return table.FirstOrDefault(t =>
				t.Version     == Version &&
				t.AssemblyKey == AssemblyKey);
		}

		public static Subscription Find(this ITable<Subscription> table, Guid SubId)
		{
			return table.FirstOrDefault(t =>
				t.SubId == SubId);
		}

		public static Sysdiagram Find(this ITable<Sysdiagram> table, int DiagramId)
		{
			return table.FirstOrDefault(t =>
				t.DiagramId == DiagramId);
		}

		public static Test Find(this ITable<Test> table, Guid TestId)
		{
			return table.FirstOrDefault(t =>
				t.TestId == TestId);
		}

		public static Theme Find(this ITable<Theme> table, Guid ThemeId)
		{
			return table.FirstOrDefault(t =>
				t.ThemeId == ThemeId);
		}

		public static User Find(this ITable<User> table, Guid UserId)
		{
			return table.FirstOrDefault(t =>
				t.UserId == UserId);
		}
	}
}

#pragma warning restore 1591
