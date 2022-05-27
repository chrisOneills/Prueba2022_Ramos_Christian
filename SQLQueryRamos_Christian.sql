create database DB_PRUEBA
GO

USE DB_PRUEBA
GO

CREATE TABLE ma_Proveedores(
cod_proveedor varchar(8),
dsc_ruc varchar(11),
dsc_razon_social varchar (200),
dsc_nombre_comercial varchar(50),
num_celular int,
dsc_direccion varchar (200),
fecha_creacion varchar (5),
flg_activo varchar(2)
)
go

--insert into ma_Proveedores (cod_proveedor,dsc_ruc,dsc_razon_social,dsc_nombre_comercial

create proc usp_Listar_Proveedores
as
select * from ma_Proveedores order by cod_proveedor
go

--exec usp_Listar_Proveedores

exec usp_Mantenimeintos_Proveedores @cod_proveedor='',@dsc_ruc='20111',@dsc_razon_social='prueba',@dsc_nombre_comercial='prueba',@num_celular=91823,@dsc_direccion='lima',@fecha_creacion='26/05',@flg_activo='si',@accion='1';
go

alter proc usp_Mantenimeintos_Proveedores
@cod_proveedor varchar(8),
@dsc_ruc varchar(11),
@dsc_razon_social varchar (200),
@dsc_nombre_comercial varchar(50),
@num_celular int,
@dsc_direccion varchar (200),
@fecha_creacion varchar (5),
@flg_activo varchar(2),
@accion varchar(50) output
as
if (@accion = '1')
begin
	declare @codnuevo varchar(8), @codmax varchar(8)
	set @codmax = (select max(cod_proveedor) from ma_Proveedores)
	set @codmax = isnull(@codmax,'PR000000')
	set @codnuevo = 'PR'+RIGHT(RIGHT(@codmax,6)+1000001,6)
	insert into ma_Proveedores(cod_proveedor,dsc_ruc,dsc_razon_social,dsc_nombre_comercial,num_celular,dsc_direccion,fecha_creacion,flg_activo)
	values(@codnuevo,@dsc_ruc,@dsc_razon_social,@dsc_nombre_comercial,@num_celular,@dsc_direccion,@fecha_creacion,@flg_activo)
	set @accion='Se genero el código: ' +@codnuevo
end
else if (@accion = '2')
begin
	update ma_Proveedores set dsc_ruc=@dsc_ruc, dsc_razon_social=@dsc_razon_social, dsc_nombre_comercial=@dsc_nombre_comercial, num_celular=@num_celular, dsc_direccion=@dsc_direccion, fecha_creacion=@fecha_creacion, flg_activo = @flg_activo where cod_proveedor=@cod_proveedor
	set @accion='Se modifico el código: ' +@cod_proveedor
end
else if (@accion = '3')
begin
	update ma_Proveedores set flg_activo = 'no' where cod_proveedor=@cod_proveedor
	set @accion='Se inactivo el código: ' +@cod_proveedor
end
go
