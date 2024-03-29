USE [CRUDDemo07122019]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 08/12/2019 13:41:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](150) NULL,
	[Gender] [varchar](50) NULL,
	[Company] [varchar](150) NULL,
	[Department] [varchar](150) NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[Sp_DeleteEmployee]    Script Date: 08/12/2019 13:41:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--For delete

Create Procedure [dbo].[Sp_DeleteEmployee]
(
 @Id int
)
as
Begin
  Delete From Employee Where Id = @Id
End

GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllEmployee]    Script Date: 08/12/2019 13:41:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SP_GetAllEmployee]
as
Begin
select * from Employee
end
GO
/****** Object:  StoredProcedure [dbo].[Sp_GetEmployeebyId]    Script Date: 08/12/2019 13:41:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Get Employee By Id

Create Procedure [dbo].[Sp_GetEmployeebyId]
(
 @Id int
)
as
Begin
  Select * from Employee Where Id = @Id
End

GO
/****** Object:  StoredProcedure [dbo].[SP_InsertEmployee]    Script Date: 08/12/2019 13:41:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--For Insert:

Create Procedure [dbo].[SP_InsertEmployee]
(
  @Name  varchar(150)='',
  @Gender  varchar(50)='',
  @Company  varchar(150)='',
  @Department  varchar(150)=''
  )
  as
  Begin
	Insert Into Employee (Name, Gender, Company, Department) Values(@Name, @Gender, @Company, @Department)
  End
GO
/****** Object:  StoredProcedure [dbo].[SP_UpdateEmployee]    Script Date: 08/12/2019 13:41:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--For Update

CREATE Procedure [dbo].[SP_UpdateEmployee]
(
  @Id int=0,
  @Name  varchar(150)='',
  @Gender  varchar(50)='',
  @Company  varchar(150)='',
  @Department  varchar(150)=''
  )
  as
  Begin
	Update Employee Set Name = @Name, Gender = @Gender, Company = @Company, Department = @Department Where Id = @Id 
  End
GO
