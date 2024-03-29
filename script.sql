USE [master]
GO
/****** Object:  Database [ELCUTCRM]    Script Date: 04/10/2013 11:25:43 ******/
CREATE DATABASE [ELCUTCRM] ON  PRIMARY 
( NAME = N'ELCUTCRM', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\ELCUTCRM.mdf' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ELCUTCRM_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\ELCUTCRM_log.LDF' , SIZE = 1088KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ELCUTCRM] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ELCUTCRM].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ELCUTCRM] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [ELCUTCRM] SET ANSI_NULLS OFF
GO
ALTER DATABASE [ELCUTCRM] SET ANSI_PADDING OFF
GO
ALTER DATABASE [ELCUTCRM] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [ELCUTCRM] SET ARITHABORT OFF
GO
ALTER DATABASE [ELCUTCRM] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [ELCUTCRM] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [ELCUTCRM] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [ELCUTCRM] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [ELCUTCRM] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [ELCUTCRM] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [ELCUTCRM] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [ELCUTCRM] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [ELCUTCRM] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [ELCUTCRM] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [ELCUTCRM] SET  ENABLE_BROKER
GO
ALTER DATABASE [ELCUTCRM] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [ELCUTCRM] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [ELCUTCRM] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [ELCUTCRM] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [ELCUTCRM] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [ELCUTCRM] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [ELCUTCRM] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [ELCUTCRM] SET  READ_WRITE
GO
ALTER DATABASE [ELCUTCRM] SET RECOVERY FULL
GO
ALTER DATABASE [ELCUTCRM] SET  MULTI_USER
GO
ALTER DATABASE [ELCUTCRM] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [ELCUTCRM] SET DB_CHAINING OFF
GO
USE [ELCUTCRM]
GO
/****** Object:  Table [dbo].[DictionaryEntries]    Script Date: 04/10/2013 11:25:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DictionaryEntries](
	[Key] [nvarchar](128) NOT NULL,
	[DictionaryName] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[SortOrder] [smallint] NOT NULL,
 CONSTRAINT [PK_dbo.DictionaryEntries] PRIMARY KEY CLUSTERED 
(
	[Key] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Countries]    Script Date: 04/10/2013 11:25:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[ID] [smallint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[SortOrder] [smallint] NOT NULL,
 CONSTRAINT [PK_dbo.Countries] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderTypes]    Script Date: 04/10/2013 11:25:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderTypes](
	[ID] [smallint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.OrderTypes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ConfigurationOptions]    Script Date: 04/10/2013 11:25:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConfigurationOptions](
	[ID] [smallint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[FullGroupName] [nvarchar](max) NULL,
	[ParentID] [smallint] NULL,
	[SortOrder] [smallint] NOT NULL,
 CONSTRAINT [PK_dbo.ConfigurationOptions] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_ParentID] ON [dbo].[ConfigurationOptions] 
(
	[ParentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 04/10/2013 11:25:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrganizationTypes]    Script Date: 04/10/2013 11:25:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrganizationTypes](
	[ID] [smallint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.OrganizationTypes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Organizations]    Script Date: 04/10/2013 11:25:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Organizations](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TypeID] [smallint] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[CountryID] [smallint] NOT NULL,
	[City] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Index] [nvarchar](max) NULL,
	[StatusKey] [nvarchar](128) NULL,
	[RelationshipKey] [nvarchar](128) NULL,
	[Site] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Organizations] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_CountryID] ON [dbo].[Organizations] 
(
	[CountryID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_RelationshipKey] ON [dbo].[Organizations] 
(
	[RelationshipKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_StatusKey] ON [dbo].[Organizations] 
(
	[StatusKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_TypeID] ON [dbo].[Organizations] 
(
	[TypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OptionPrices]    Script Date: 04/10/2013 11:25:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OptionPrices](
	[ID] [smallint] IDENTITY(1,1) NOT NULL,
	[OrderTypeID] [smallint] NOT NULL,
	[ConfigurationOptionID] [smallint] NOT NULL,
	[Price] [smallint] NOT NULL,
 CONSTRAINT [PK_dbo.OptionPrices] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_ConfigurationOptionID] ON [dbo].[OptionPrices] 
(
	[ConfigurationOptionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_OrderTypeID] ON [dbo].[OptionPrices] 
(
	[OrderTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContactNames]    Script Date: 04/10/2013 11:25:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactNames](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Surname] [nvarchar](max) NOT NULL,
	[Position] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[Fax] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[OrganizationID] [int] NOT NULL,
	[VKID] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.ContactNames] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_OrganizationID] ON [dbo].[ContactNames] 
(
	[OrganizationID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Histories]    Script Date: 04/10/2013 11:25:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Histories](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EventDate] [datetime] NOT NULL,
	[OrganizationID] [int] NOT NULL,
	[EventKey] [nvarchar](128) NULL,
 CONSTRAINT [PK_dbo.Histories] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_EventKey] ON [dbo].[Histories] 
(
	[EventKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_OrganizationID] ON [dbo].[Histories] 
(
	[OrganizationID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Documents]    Script Date: 04/10/2013 11:25:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Documents](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[OrganizationID] [int] NOT NULL,
	[DocumentTypeKey] [nvarchar](128) NULL,
 CONSTRAINT [PK_dbo.Documents] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_DocumentTypeKey] ON [dbo].[Documents] 
(
	[DocumentTypeKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_OrganizationID] ON [dbo].[Documents] 
(
	[OrganizationID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 04/10/2013 11:25:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[OrganizationID] [int] NOT NULL,
	[VersionKey] [nvarchar](max) NULL,
	[TypeID] [smallint] NOT NULL,
	[StatusKey] [nvarchar](128) NULL,
	[ConfigurationName] [nvarchar](max) NULL,
	[Price] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Orders] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_OrganizationID] ON [dbo].[Orders] 
(
	[OrganizationID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_StatusKey] ON [dbo].[Orders] 
(
	[StatusKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_TypeID] ON [dbo].[Orders] 
(
	[TypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderConfigurations]    Script Date: 04/10/2013 11:25:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderConfigurations](
	[ID] [smallint] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NOT NULL,
	[OptionID] [smallint] NOT NULL,
 CONSTRAINT [PK_dbo.OrderConfigurations] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_OptionID] ON [dbo].[OrderConfigurations] 
(
	[OptionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_OrderID] ON [dbo].[OrderConfigurations] 
(
	[OrderID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_dbo.ConfigurationOptions_dbo.ConfigurationOptions_ParentID]    Script Date: 04/10/2013 11:25:44 ******/
ALTER TABLE [dbo].[ConfigurationOptions]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ConfigurationOptions_dbo.ConfigurationOptions_ParentID] FOREIGN KEY([ParentID])
REFERENCES [dbo].[ConfigurationOptions] ([ID])
GO
ALTER TABLE [dbo].[ConfigurationOptions] CHECK CONSTRAINT [FK_dbo.ConfigurationOptions_dbo.ConfigurationOptions_ParentID]
GO
/****** Object:  ForeignKey [FK_dbo.Organizations_dbo.Countries_CountryID]    Script Date: 04/10/2013 11:25:44 ******/
ALTER TABLE [dbo].[Organizations]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Organizations_dbo.Countries_CountryID] FOREIGN KEY([CountryID])
REFERENCES [dbo].[Countries] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Organizations] CHECK CONSTRAINT [FK_dbo.Organizations_dbo.Countries_CountryID]
GO
/****** Object:  ForeignKey [FK_dbo.Organizations_dbo.DictionaryEntries_RelationshipKey]    Script Date: 04/10/2013 11:25:44 ******/
ALTER TABLE [dbo].[Organizations]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Organizations_dbo.DictionaryEntries_RelationshipKey] FOREIGN KEY([RelationshipKey])
REFERENCES [dbo].[DictionaryEntries] ([Key])
GO
ALTER TABLE [dbo].[Organizations] CHECK CONSTRAINT [FK_dbo.Organizations_dbo.DictionaryEntries_RelationshipKey]
GO
/****** Object:  ForeignKey [FK_dbo.Organizations_dbo.DictionaryEntries_StatusKey]    Script Date: 04/10/2013 11:25:44 ******/
ALTER TABLE [dbo].[Organizations]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Organizations_dbo.DictionaryEntries_StatusKey] FOREIGN KEY([StatusKey])
REFERENCES [dbo].[DictionaryEntries] ([Key])
GO
ALTER TABLE [dbo].[Organizations] CHECK CONSTRAINT [FK_dbo.Organizations_dbo.DictionaryEntries_StatusKey]
GO
/****** Object:  ForeignKey [FK_dbo.Organizations_dbo.OrganizationTypes_TypeID]    Script Date: 04/10/2013 11:25:44 ******/
ALTER TABLE [dbo].[Organizations]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Organizations_dbo.OrganizationTypes_TypeID] FOREIGN KEY([TypeID])
REFERENCES [dbo].[OrganizationTypes] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Organizations] CHECK CONSTRAINT [FK_dbo.Organizations_dbo.OrganizationTypes_TypeID]
GO
/****** Object:  ForeignKey [FK_dbo.OptionPrices_dbo.ConfigurationOptions_ConfigurationOptionID]    Script Date: 04/10/2013 11:25:44 ******/
ALTER TABLE [dbo].[OptionPrices]  WITH CHECK ADD  CONSTRAINT [FK_dbo.OptionPrices_dbo.ConfigurationOptions_ConfigurationOptionID] FOREIGN KEY([ConfigurationOptionID])
REFERENCES [dbo].[ConfigurationOptions] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OptionPrices] CHECK CONSTRAINT [FK_dbo.OptionPrices_dbo.ConfigurationOptions_ConfigurationOptionID]
GO
/****** Object:  ForeignKey [FK_dbo.OptionPrices_dbo.OrderTypes_OrderTypeID]    Script Date: 04/10/2013 11:25:44 ******/
ALTER TABLE [dbo].[OptionPrices]  WITH CHECK ADD  CONSTRAINT [FK_dbo.OptionPrices_dbo.OrderTypes_OrderTypeID] FOREIGN KEY([OrderTypeID])
REFERENCES [dbo].[OrderTypes] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OptionPrices] CHECK CONSTRAINT [FK_dbo.OptionPrices_dbo.OrderTypes_OrderTypeID]
GO
/****** Object:  ForeignKey [FK_dbo.ContactNames_dbo.Organizations_OrganizationID]    Script Date: 04/10/2013 11:25:44 ******/
ALTER TABLE [dbo].[ContactNames]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ContactNames_dbo.Organizations_OrganizationID] FOREIGN KEY([OrganizationID])
REFERENCES [dbo].[Organizations] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ContactNames] CHECK CONSTRAINT [FK_dbo.ContactNames_dbo.Organizations_OrganizationID]
GO
/****** Object:  ForeignKey [FK_dbo.Histories_dbo.DictionaryEntries_EventKey]    Script Date: 04/10/2013 11:25:44 ******/
ALTER TABLE [dbo].[Histories]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Histories_dbo.DictionaryEntries_EventKey] FOREIGN KEY([EventKey])
REFERENCES [dbo].[DictionaryEntries] ([Key])
GO
ALTER TABLE [dbo].[Histories] CHECK CONSTRAINT [FK_dbo.Histories_dbo.DictionaryEntries_EventKey]
GO
/****** Object:  ForeignKey [FK_dbo.Histories_dbo.Organizations_OrganizationID]    Script Date: 04/10/2013 11:25:44 ******/
ALTER TABLE [dbo].[Histories]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Histories_dbo.Organizations_OrganizationID] FOREIGN KEY([OrganizationID])
REFERENCES [dbo].[Organizations] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Histories] CHECK CONSTRAINT [FK_dbo.Histories_dbo.Organizations_OrganizationID]
GO
/****** Object:  ForeignKey [FK_dbo.Documents_dbo.DictionaryEntries_DocumentTypeKey]    Script Date: 04/10/2013 11:25:44 ******/
ALTER TABLE [dbo].[Documents]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Documents_dbo.DictionaryEntries_DocumentTypeKey] FOREIGN KEY([DocumentTypeKey])
REFERENCES [dbo].[DictionaryEntries] ([Key])
GO
ALTER TABLE [dbo].[Documents] CHECK CONSTRAINT [FK_dbo.Documents_dbo.DictionaryEntries_DocumentTypeKey]
GO
/****** Object:  ForeignKey [FK_dbo.Documents_dbo.Organizations_OrganizationID]    Script Date: 04/10/2013 11:25:44 ******/
ALTER TABLE [dbo].[Documents]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Documents_dbo.Organizations_OrganizationID] FOREIGN KEY([OrganizationID])
REFERENCES [dbo].[Organizations] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Documents] CHECK CONSTRAINT [FK_dbo.Documents_dbo.Organizations_OrganizationID]
GO
/****** Object:  ForeignKey [FK_dbo.Orders_dbo.DictionaryEntries_StatusKey]    Script Date: 04/10/2013 11:25:44 ******/
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Orders_dbo.DictionaryEntries_StatusKey] FOREIGN KEY([StatusKey])
REFERENCES [dbo].[DictionaryEntries] ([Key])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_dbo.Orders_dbo.DictionaryEntries_StatusKey]
GO
/****** Object:  ForeignKey [FK_dbo.Orders_dbo.OrderTypes_TypeID]    Script Date: 04/10/2013 11:25:44 ******/
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Orders_dbo.OrderTypes_TypeID] FOREIGN KEY([TypeID])
REFERENCES [dbo].[OrderTypes] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_dbo.Orders_dbo.OrderTypes_TypeID]
GO
/****** Object:  ForeignKey [FK_dbo.Orders_dbo.Organizations_OrganizationID]    Script Date: 04/10/2013 11:25:44 ******/
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Orders_dbo.Organizations_OrganizationID] FOREIGN KEY([OrganizationID])
REFERENCES [dbo].[Organizations] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_dbo.Orders_dbo.Organizations_OrganizationID]
GO
/****** Object:  ForeignKey [FK_dbo.OrderConfigurations_dbo.ConfigurationOptions_OptionID]    Script Date: 04/10/2013 11:25:44 ******/
ALTER TABLE [dbo].[OrderConfigurations]  WITH CHECK ADD  CONSTRAINT [FK_dbo.OrderConfigurations_dbo.ConfigurationOptions_OptionID] FOREIGN KEY([OptionID])
REFERENCES [dbo].[ConfigurationOptions] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderConfigurations] CHECK CONSTRAINT [FK_dbo.OrderConfigurations_dbo.ConfigurationOptions_OptionID]
GO
/****** Object:  ForeignKey [FK_dbo.OrderConfigurations_dbo.Orders_OrderID]    Script Date: 04/10/2013 11:25:44 ******/
ALTER TABLE [dbo].[OrderConfigurations]  WITH CHECK ADD  CONSTRAINT [FK_dbo.OrderConfigurations_dbo.Orders_OrderID] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Orders] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderConfigurations] CHECK CONSTRAINT [FK_dbo.OrderConfigurations_dbo.Orders_OrderID]
GO
