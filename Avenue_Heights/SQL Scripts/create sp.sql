/****** Object:  StoredProcedure [dbo].[sp_Create_StoredProcedures_ave]    Script Date: 07/12/2013 08:49:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[sp_Create_StoredProcedures_ave] (
	@Table varchar(255)
)


as 

declare @Print as bit
declare @Execute as bit
set @Execute = 1 --Execute
set @Print = 1 --Print


--step 1.0 declare Variables

--	declare @Table varchar(150)
--	set @Table = 'RepairTable'

	set nocount on

	declare 
	@TableName varchar(150), 
	@CountColumns int,
	@CurrentRow int,
	@Br AS char(1),
	@Tab as char(9),
	@TableID int,
	@PKDescription varchar(150),
	@PKDataType varchar(150)

	set @Table = replace(replace(@Table, '[', ''), ']', '')
	set @TableName = '[' + replace(replace(@Table, '[', ''), ']', '') + ']'

	set @Br = CHAR(10)
	set @Tab = char(9)
	set @CurrentRow = 1

	select @TableID = object_id 
	from Sys.Objects 
	where [name] = @Table

	select @CountColumns = count(*) 
	from Sys.Columns sc
	inner join Sys.Types st	on (st.system_type_id = sc.system_type_id and st.name <> 'sysname') 
	where object_id = @TableID

	select @PKDescription = c.COLUMN_NAME
	FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS p
	inner join     INFORMATION_SCHEMA.KEY_COLUMN_USAGE c on (c.TABLE_NAME = p.TABLE_NAME AND c.CONSTRAINT_NAME = p.CONSTRAINT_NAME and CONSTRAINT_TYPE = 'PRIMARY KEY')
	and p.Table_Name = @Table
	ORDER by c.TABLE_NAME

	select @PKDataType = st.[Name]
	from Sys.Columns sc
	inner join Sys.Types st on (st.system_type_id = sc.system_type_id)  
	where object_id = @TableID
	and sc.Name = @PKDescription

		select 
			sc.*, 
			st.name as TypeName,
			st.is_user_defined,
			st.is_assembly_type
		into #tmp
		from Sys.Columns sc
		inner join Sys.Types st	on (st.system_type_id = sc.system_type_id and st.name <> 'sysname') 
		where sc.object_id =  @TableID
		order by sc.column_id
			
		alter table #tmp
			add _ID int not null identity(1,1)
			
		declare 
				@InsertString	varchar(MAX),
				@GetString		varchar(MAX),
				@GetStringByID	varchar(MAX),
				@DeleteByID		varchar(MAX),
				@UpdateByID		varchar(MAX), 

				@InsertString_Drop	nvarchar(MAX),
				@GetString_Drop		nvarchar(MAX),
				@GetStringByID_Drop	nvarchar(MAX),
				@DeleteByID_Drop	nvarchar(MAX),
				@UpdateByID_Drop	nvarchar(MAX),

				@SelectString	varchar(MAX),
				@rowString		varchar(MAX)


				set @CurrentRow = 1
				set @SelectString = @Br
				while @CurrentRow <= @CountColumns
				begin
					
					select @rowString = @Tab + '[' + sc.[Name] + ']' + 
					case
						when @CurrentRow <> (@CountColumns) then 
							','
						else 
						''
					end
					From #tmp sc
					Where _ID = @CurrentRow

				
					set @SelectString = @SelectString + (@rowString + @Br)																								
					set @CurrentRow = (@CurrentRow + 1)				
				
				end


--		ave_Table_Method
				

--START #############################################
--CREATE Get Procedure
		
		set @GetString_Drop = 'if exists (select name from sys.objects where type = ''P'' and name = ''ave_' + @Table + '_Get'')' + @Br 
		set @GetString_Drop = @GetString_Drop + 'begin'+ @Br 
		set @GetString_Drop = @GetString_Drop + 'drop procedure ave_' + @Table + '_Get' + @Br 
		set @GetString_Drop = @GetString_Drop + 'end'+ @Br

		set @GetString = 'create procedure ave_' + @Table + '_Get' + @Br
		set @GetString = @GetString + 'as' + @br + @br
		set @GetString = @GetString + 'select [*] from ' + @TableName + @br

		set @GetString = replace(@GetString, '[*]', @SelectString)




--END

--START ##############################################
--CREATE Get Procedure BYID

		set @GetStringByID_Drop = 'if exists (select name from sys.objects where type = ''P'' and name = ''ave_' + @Table + '_GetBy' + @PKDescription + ''')' + @Br 
		set @GetStringByID_Drop = @GetStringByID_Drop + 'begin'+ @Br
		set @GetStringByID_Drop = @GetStringByID_Drop + 'drop procedure ave_' + @Table + '_GetBy' + @PKDescription + @Br
		set @GetStringByID_Drop = @GetStringByID_Drop + 'end'+ @Br

		set @GetStringByID = 'create procedure ave_' + @Table + '_GetBy' + @PKDescription + ' (@' + @PKDescription + ' ' + @PKDataType  + ')' + @Br
		set @GetStringByID = @GetStringByID + 'as' + @br + @br
		set @GetStringByID = @GetStringByID + 'select [*] from ' + @TableName + @br + ' where ' + @PKDescription + ' = @' + @PKDescription + @br

		set @GetStringByID = replace(@GetStringByID, '[*]', @SelectString)



		
		
--END

--START ##############################################
--Create Delete Procedure ByID

		set @DeleteByID_Drop = 'if exists (select name from sys.objects where type = ''P'' and name = ''ave_' + @Table + '_Delete'')' + @Br
		set @DeleteByID_Drop = @DeleteByID_Drop + 'begin'+ @Br
		set @DeleteByID_Drop = @DeleteByID_Drop + 'drop procedure ave_' + @Table + '_Delete' + @Br
		set @DeleteByID_Drop = @DeleteByID_Drop + 'end'+ @Br

		set @DeleteByID = 'create procedure ave_' + @Table + '_Delete (@' + @PKDescription + ' ' + @PKDataType  + ')' + @Br
		set @DeleteByID = @DeleteByID + 'as' + @br + @br
		set @DeleteByID = @DeleteByID + 'Delete from ' + @TableName + @br + ' where ' + @PKDescription + ' = @' + @PKDescription + @br



-- =============================================
-- Declare and using a READ_ONLY cursor
-- =============================================
DECLARE CUR_FK CURSOR
READ_ONLY
FOR 
	WITH ConstraintAndTableName AS 
	(SELECT sysobjects1.name AS ChildTablename, 
			sysobjects.id, 
			sysobjects.parent_obj, 
			sysobjects.name AS ConstraintName
	  FROM  sysforeignkeys INNER  
	  JOIN  sysobjects ON sysforeignkeys.constid = sysobjects.id 
					  AND sysforeignkeys.fkeyid = sysobjects.parent_obj INNER  
	  JOIN  sysobjects AS sysobjects1 ON sysobjects.parent_obj = sysobjects1.id 
	)
	SELECT DISTINCT 
		   --syso1.name AS TableName, 
		   sysc1.name AS ColumnName,  
		   --sysc1.colid AS Pos,
		   --syso2.name AS MasterTableName, 
		   sysc2.name AS MasterColumnName, 
		   st.name as ForeignKeyType
		   --ConstraintAndTableName.ConstraintName
	 FROM  sysforeignkeys sysfk 
	INNER  JOIN  sysobjects syso1 ON sysfk.fkeyid = syso1.id 
	INNER  JOIN  sysobjects syso2 ON sysfk.rkeyid = syso2.id 
	INNER  JOIN  syscolumns sysc1 ON sysfk.fkey = sysc1.colid AND sysc1.id = syso1.id 
	INNER  JOIN  sys.columns sysc2 ON sysfk.rkey = sysc2.column_id AND sysc2.object_id = syso2.id 
	inner  join  Sys.Types st on (st.system_type_id = sysc2.system_type_id)
	INNER  JOIN  ConstraintAndTableName ON (sysfk.constid = ConstraintAndTableName.id  AND syso1.name = ConstraintAndTableName.ChildTablename)
	where sysfk.fkeyid = @TableID

DECLARE @message varchar(max)
DECLARE @SourceColumnName varchar(255), @MasterColumnName varchar(255), @ForeignKeyType varchar(255)
OPEN CUR_FK

FETCH NEXT FROM CUR_FK INTO @SourceColumnName, @MasterColumnName, @ForeignKeyType
WHILE (@@fetch_status <> -1)
BEGIN
	IF (@@fetch_status <> -2)
	BEGIN
--		PRINT 'add user defined code here'
--		eg.
		
		
		if @Execute = 1 
		begin
			select @message = ''
			exec sp_Create_StoredProcedures_ave_foreignkey @SelectString, @SourceColumnName, @MasterColumnName, @ForeignKeyType, @Table, @TableName, @message output
			declare @strsql nvarchar(max)			
			if exists (	select name from sys.objects where type = 'P' and name = 'ave_' + @Table + '_GetBy' + @SourceColumnName )
			begin
				select @strsql = 'drop procedure ave_' + @Table + '_GetBy' + @SourceColumnName + @Br
				if @Print = 1
				begin
					PRINT @strsql
				end
				exec sp_executesql @strsql
			end		
			select @strsql = convert(nvarchar(max), @message)
			exec sp_executesql @strsql
			if @Print = 1
			begin
				PRINT @strsql
			end
		end 
	END
	FETCH NEXT FROM CUR_FK INTO @SourceColumnName, @MasterColumnName, @ForeignKeyType
END

CLOSE CUR_FK
DEALLOCATE CUR_FK
		

--START ##############################################
-- CREATE Insert PROCEDURE

		set @rowString = ''
		set @CurrentRow = 1
		set @InsertString_Drop = 'if exists (select name from sysobjects where type = ''P'' and name = ''ave_' + @Table + '_Insert'')' + @Br
		set @InsertString_Drop = @InsertString_Drop + 'begin'+ @Br
		set @InsertString_Drop = @InsertString_Drop + 'drop procedure ave_' + @Table + '_Insert ' + @Br
		set @InsertString_Drop = @InsertString_Drop + 'end'+ @Br

		
		set @InsertString = 'create procedure ave_' + @Table + '_Insert (' + @Br	
		while @CurrentRow <= @CountColumns
		begin

			select @rowString = @Tab + 
				case
					when @CurrentRow = 1 then '@'
					else '@'
				end
					+ replace(replace(replace(replace(replace(sc.[Name], ' ', '_'), '(', '_'), ')', '_'), '/', '_'), '-', '_') + ' ' + [TypeName] +  
				 
				case 
					when sc.system_type_id = 167 then '(' + convert(varchar(20), case when sc.max_length = -1 then 'max' else convert(varchar(5), sc.max_length) end) + ')'
					when sc.system_type_id = 175 then '(' + convert(varchar(20), sc.max_length) + ')'
					when sc.system_type_id = 231 then '(' + convert(varchar(20), sc.max_length) + ')'
					when sc.system_type_id = 239 then '(' + convert(varchar(20), sc.max_length) + ')'
					when sc.system_type_id = 99 then '(' + convert(varchar(20), sc.max_length) + ')'
					when sc.system_type_id = 106 then '(' + convert(varchar(20), sc.precision) + ', ' + convert(varchar(20), sc.scale) + ')'
					when sc.system_type_id = 108 then '(' + convert(varchar(20), sc.precision) + ', ' + convert(varchar(20), sc.scale) + ')'
				else ''
				end
				 + 
				case 
					when sc.[is_identity] = '1' then ' Output'
					else ''
				end +
				case
					when @CurrentRow <> (@CountColumns) then ','
					else + @Br + ')'
				end 
			From #tmp sc
			Where _ID = @CurrentRow
			
			set @InsertString = @InsertString + (@rowString + @Br)																								
			set @CurrentRow = (@CurrentRow + 1)				

		end

		set @InsertString = @InsertString + 'as' + @Br + @Br + @Br
		set @InsertString = @InsertString + 'Insert into ' + @TableName + ' (' + @br
		set @CurrentRow = 1
		while @CurrentRow <= @CountColumns
		begin
			select @rowString = 
			case 
				when sc.[is_identity] = 1 then '' 
			else @tab + '[' + sc.[Name] + ']' + 
				case
				when @CurrentRow <> (@CountColumns) then ','
				else ')'
				end
			end
			From #tmp sc
			Where _ID = @CurrentRow
			set @InsertString = @InsertString + (@rowString + @Br)																								
			set @CurrentRow = (@CurrentRow + 1)				

		end

		

		set @InsertString = @InsertString + 'select '			
		set @CurrentRow = 1
		while @CurrentRow <= @CountColumns
		begin
			select  @rowString = 
			case 
				when sc.[is_identity] = 1 then '' 
				else @tab + '@' + replace(replace(replace(replace(replace(sc.[Name], ' ', '_'), '(', '_'), ')', '_'), '/', '_'), '-', '_') + 
					case
						when @CurrentRow <> (@CountColumns) then ','
						else ''
					end
			end
			From #tmp sc
			Where _ID = @CurrentRow

								
			set @InsertString = @InsertString + (@rowString + @Br)																								
			set @CurrentRow = (@CurrentRow + 1)
		end

		
		
	set @InsertString = @InsertString + @br
	set @InsertString = @InsertString + 'select @' + @PKDescription + ' = scope_identity()' + @br
	

--END



--START ##############################################
-- CREATE Update PROCEDURE

--exec (sp_Create_Net2_StoredProcedures)

		set @CurrentRow = 1
		set @UpdateByID_Drop = 'if exists (select name from sysobjects where type = ''P'' and name = ''ave_' + @Table + '_Update'')' + @Br
		set @UpdateByID_Drop = @UpdateByID_Drop + 'begin'+ @Br
		set @UpdateByID_Drop = @UpdateByID_Drop + 'drop procedure ave_' + @Table + '_Update ' + @Br
		set @UpdateByID_Drop = @UpdateByID_Drop + 'end'+ @Br


		set @UpdateByID = 'create procedure ave_' + @Table + '_Update (' + @br
		while @CurrentRow <= @CountColumns
		begin
			Declare @UpdaterowString varchar(150)
			select @UpdaterowString =  
			case
				when @CurrentRow = 1 then '@'
			else 
				@tab + '@'
			end
			+ replace(replace(replace(replace(replace(sc.[Name], ' ', '_'), '(', '_'), ')', '_'), '/', '_'), '-', '_') + ' ' + sc.[TypeName] +  
			case 
				when sc.system_type_id = 167 then '(' + convert(varchar(20), case when sc.max_length = -1 then 'max' else convert(varchar(5), sc.max_length) end) + ')'
				when sc.system_type_id = 175 then '(' + convert(varchar(20), sc.max_length) + ')'
				when sc.system_type_id = 231 then '(' + convert(varchar(20), sc.max_length) + ')'
				when sc.system_type_id = 239 then '(' + convert(varchar(20), sc.max_length) + ')'
				when sc.system_type_id = 99 then '(' + convert(varchar(20), sc.max_length) + ')'
				when sc.system_type_id = 106 then '(' + convert(varchar(20), sc.precision) + ', ' + convert(varchar(20), sc.scale) + ')'
				when sc.system_type_id = 108 then '(' + convert(varchar(20), sc.precision) + ', ' + convert(varchar(20), sc.scale) + ')'
			else 
				''
			end +
			case
				when @CurrentRow <> (@CountColumns) then ','
			else 
				')'
			end
			From #tmp sc
			Where _ID = @CurrentRow

			set @UpdateByID = @UpdateByID + (@UpdaterowString + @Br)																								
			set @CurrentRow = (@CurrentRow + 1)				

		end

		set @UpdateByID = @UpdateByID + 'as' + @Br + @Br + @Br
		set @UpdateByID = @UpdateByID + 'update ' + @TableName +  ' set '
		set @CurrentRow = 1
		while @CurrentRow <= @CountColumns
		begin
			select @UpdateRowString = 
				case 
					when sc.[is_identity] = 1 then 
						'' 
					else @tab + '['  + sc.[Name] + '] = @' + replace(replace(replace(replace(replace(sc.[Name], ' ', '_'), '(', '_'), ')', '_'), '/', '_'), '-', '_') + 
						case
							when @CurrentRow <> (@CountColumns) then 
								','
							else 
								''
							end 
					end
			From #tmp sc
			Where _ID = @CurrentRow

			set @UpdateByID = @UpdateByID + (@UpdateRowString + @Br)																								
			set @CurrentRow = (@CurrentRow + 1)				

		end
		set @UpdateByID = @UpdateByID + 'where ' + @PKDescription + ' = @' + @PKDescription  + @Br
	
		select @CurrentRow, @CountColumns
		select * from #tmp
	
		drop table #tmp

if @Print = 1
begin
	
	print @GetString
	print @GetStringByID 
	print @InsertString 
	print @DeleteByID 
	print @UpdateByID

end
if @Execute = 1 
begin	
	declare @_GetString		nvarchar(max)
	declare @_GetStringByID nvarchar(max)
	declare @_InsertString	nvarchar(max)
	declare @_DeleteByID	nvarchar(max)
	declare @_UpdateByID	nvarchar(max)
	
	
	set @_GetString = convert(nvarchar(max), @GetString)
	set @_GetStringByID = convert(nvarchar(max), @GetStringByID)
	set @_InsertString = convert(nvarchar(max), @InsertString)
	set @_DeleteByID = convert(nvarchar(max), @DeleteByID)
	set @_UpdateByID = convert(nvarchar(max), @UpdateByID)

	if len(@_GetString) <= 10000
	begin
		print '@_GetString'
		exec sp_executesql @GetString_Drop
		exec sp_executesql @_GetString
	end
	if len(@_GetStringByID) <= 10000 
	begin
		print '@_GetStringByID'
		exec sp_executesql @GetStringByID_Drop
		exec sp_executesql @_GetStringByID
	end
	if len(@_InsertString) <= 10000 
	begin
		print '@_InsertString'
		exec sp_executesql @InsertString_Drop
		exec sp_executesql @_InsertString
	end
	if len(@_DeleteByID) <= 10000 
	begin
		print '@_DeleteByID'
		exec sp_executesql @DeleteByID_Drop
		exec sp_executesql @_DeleteByID	
	end
	if len(@_UpdateByID) <= 10000 
	begin
		print '@_UpdateByID'
		exec sp_executesql @UpdateByID_Drop
		exec sp_executesql @_UpdateByID	
	end
end



exitclean:



GO


