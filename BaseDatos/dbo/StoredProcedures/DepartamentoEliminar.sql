CREATE PROCEDURE [dbo].[DepartamentoEliminar]
@Id_Departamento INT

AS
	BEGIN
		SET NOCOUNT ON
		BEGIN TRANSACTION TRASA 
		
		BEGIN TRY

		--METODO
		DELETE  FROM Departamentos  WHERE  Id_Departamento = @Id_Departamento
		

	COMMIT TRANSACTION TRASA

	SELECT 0 AS CodeError, '' AS MsgError --MSGerror en texto por eso las comillas

	END TRY

	BEGIN CATCH
		
		SELECT ERROR_NUMBER() AS CodeError, ERROR_MESSAGE() AS MsgError

		ROLLBACK TRANSACTION TRASA --CTLZ, DESHACE TODO

		END CATCH

	
	END
