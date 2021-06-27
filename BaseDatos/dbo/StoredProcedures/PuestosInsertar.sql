CREATE PROCEDURE [dbo].[PuestosInsertar]
@Nombre VARCHAR(250),  @Salario INT, @Estado BIT
AS
	BEGIN
		SET NOCOUNT ON
		BEGIN TRANSACTION TRASA 
		
		BEGIN TRY

		--METODO
		INSERT INTO Puestos(Nombre, Salario, Estado) VALUES (@Nombre, @Salario, @Estado)

		COMMIT TRANSACTION TRASA

		SELECT 0 AS CodeError, '' AS MsgError --MSGerror en texto por eso las comillas

		END TRY

		BEGIN CATCH
		
		SELECT ERROR_NUMBER() AS CodeError, ERROR_MESSAGE() AS MsgError

		ROLLBACK TRANSACTION TRASA --CTLZ, DESHACE TODO

		END CATCH

	
	END