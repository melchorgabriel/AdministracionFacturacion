use master
drop database  EmpresasFacturacion
create database EmpresasFacturacion
use EmpresasFacturacion

create table Empresa
(
IdEmpresa int not null identity(1,1) constraint pkEmpresa primary key,
RFC nchar(13) not null constraint ukEmpresa_RFC unique,
Nombre varchar(90) not null,
Correo varchar(max) not null,
Contraseña varchar(max) not null,
Estatus bit not null constraint dfEmpresa_estatus default (1),
);
go
create procedure Sp_Guardar_Empresa
(
@id int
,@rfc nchar(13)
,@nombre varchar(90)
,@correo varchar(max)
,@contraseña varchar(max)
,@Estatus bit
)
as
MERGE Empresa As Tabla
USING (SELECT @id AS ID) AS SRC ON SRC.ID = Tabla.IdEmpresa
WHEN MATCHED THEN
UPDATE SET 

Nombre=@Nombre,
Correo=@correo
,Estatus=@Estatus
WHEN NOT MATCHED THEN
INSERT 
(
RFC,
Nombre,
Correo,
Contraseña
) 
values 
(
@rfc
,@Nombre
,@correo
,@contraseña
);
