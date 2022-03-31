USE MarvicDB
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAlls_Proc]            
        AS
        BEGIN
            select * from Project
        END
GO

exec GetAlls_Proc