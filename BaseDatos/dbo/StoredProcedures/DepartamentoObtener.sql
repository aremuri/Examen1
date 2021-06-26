CREATE PROCEDURE [dbo].[DepartamentoObtener]
	@Id_Departamento INT = NULL
	
AS
	BEGIN --INICIE --METODO obtengo los datos del listado

	SET NOCOUNT ON -- INSTRUCCION, ES UN CONTADOR, CUENTA LAS LINEAS AFECTADAS, ON, NO HAGA EL CONTEO, EVITAMOS ESE TIEMPO DE CONTEO

	SELECT Id_Departamento, Descripcion, Ubicacion, Estado FROM Departamentos

	WHERE (@Id_Departamento IS NULL OR Id_Departamento = @Id_Departamento ) -- Tienen q coicidir para mostrar la informacion

	END--FINALICE

