CREATE PROCEDURE [dbo].[DepartamentoInsertar]
@Descripcion VARCHAR(250),  @Ubicacion VARCHAR(250), @Estado BIT
AS
	BEGIN
		SET NOCOUNT ON
		BEGIN TRANSACTION TRASA 
		
		BEGIN TRY

		--METODO
		INSERT INTO Departamentos(Descripcion, Ubicacion, Estado) VALUES (@Descripcion, @Ubicacion, @Estado)

		COMMIT TRANSACTION TRASA

		SELECT 0 AS CodeError, '' AS MsgError --MSGerror en texto por eso las comillas

		END TRY

		BEGIN CATCH
		
		SELECT ERROR_NUMBER() AS CodeError, ERROR_MESSAGE() AS MsgError

		ROLLBACK TRANSACTION TRASA --CTLZ, DESHACE TODO

		END CATCH

	
	END
