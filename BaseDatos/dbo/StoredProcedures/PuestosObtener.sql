CREATE PROCEDURE [dbo].[PuestosObtener]
	@Id_Puesto INT = NULL
	
AS
	BEGIN --INICIE --METODO obtengo los datos del listado

	SET NOCOUNT ON -- INSTRUCCION, ES UN CONTADOR, CUENTA LAS LINEAS AFECTADAS, ON, NO HAGA EL CONTEO, EVITAMOS ESE TIEMPO DE CONTEO

	SELECT Id_Puesto, Nombre, Salario, Estado FROM Puestos

	WHERE (@Id_Puesto IS NULL OR Id_Puesto = @Id_Puesto ) -- Tienen q coicidir para mostrar la informacion

	END--FINALICE
