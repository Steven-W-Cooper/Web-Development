/****** Object:  StoredProcedure [dbo].[sp_Create_StoredProcedures_ave_foreignkey_drop]    Script Date: 07/12/2013 08:49:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[sp_Create_StoredProcedures_ave_foreignkey_drop](
	@SelectString	varchar(MAX), 
	@FKDescription	varchar(150),
	@FKDataType		varchar(150),
	@Table			varchar(150),
	@TableName		varchar(200),
	@Copyright		varchar(1000),
	@GetString_Drop	varchar(MAX) output
)

as

	declare @Br char(1), @Tab char(10)
	set @Br = CHAR(10)
	set @Tab = char(9)
	
		set @GetString_Drop = 'if exists (select name from sys.objects where type = ''P'' and name = ''ave_' + @Table + '_GetBy' + @FKDescription + ''')' + @Br 
		set @GetString_Drop = @GetString_Drop + 'begin'+ @Br 
		set @GetString_Drop = @GetString_Drop + 'drop procedure ave_' + @Table + '_GetBy' + @FKDescription + '' + @br
		set @GetString_Drop = @GetString_Drop + 'end'+ @Br
GO


