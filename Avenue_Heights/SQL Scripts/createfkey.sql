USE [Avenue-Workflow]
GO

/****** Object:  StoredProcedure [dbo].[sp_Create_StoredProcedures_ave_foreignkey]    Script Date: 07/12/2013 08:49:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[sp_Create_StoredProcedures_ave_foreignkey](
	@SelectString	varchar(MAX), 
	@SourceDescription	varchar(150),
	@FKDescription	varchar(150),
	@FKDataType		varchar(150),
	@Table			varchar(150),
	@TableName		varchar(200),
	@GetStringByID	varchar(MAX) output
)

as

	declare @Br char(1), @Tab char(10)
	set @Br = CHAR(10)
	set @Tab = char(9)
	
--	set @GetStringByID = 'if exists (select name from sys.objects where type = ''P'' and name = ''xpdms_' + @Table + '_GetBy' + @FKDescription + ''')' + @Br 
--	set @GetStringByID = @GetStringByID + 'begin'+ @Br
--	set @GetStringByID = @GetStringByID + 
--	set @GetStringByID = @GetStringByID + 'end'+ @Br
--	set @GetStringByID = @GetStringByID + @br + 'go' + @Br
	set @GetStringByID = 'create procedure ave_' + @Table + '_GetBy' + @SourceDescription + ' (@' + @SourceDescription + ' ' + @FKDataType  + ')' + @Br
	set @GetStringByID = @GetStringByID + 'as' + @br + @br
	set @GetStringByID = @GetStringByID + 'select [*] from ' + @TableName + @br + ' where ' + @SourceDescription + ' = @' + @SourceDescription + @br


	set @GetStringByID = replace(@GetStringByID, '[*]', @SelectString)

	--set @GetStringByID = + char(10) + 'go' + char(10)

GO


