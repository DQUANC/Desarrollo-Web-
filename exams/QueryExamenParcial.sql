create table reserva (
id_reserva int identity primary key not null,
nombre_cliente varchar(50) not null,
numero_habitacion int not null,
fecha_ingreso datetime not null,
fecha_salida datetime not null,
cantidad_personas int not null,
fecha_creacion datetime,
fecha_modificacion datetime
)

insert into reserva (nombre_cliente, numero_habitacion, fecha_ingreso, fecha_salida, cantidad_personas,fecha_creacion) 
values ('Daniel Quan', 7, '03-20-2026', '03-25-2026', 3, GETDATE())

UPDATE reserva 
SET 
    nombre_cliente = 'Daniel Latorre', 
    numero_habitacion = 7, 
    fecha_ingreso = '2026-09-20', 
    fecha_salida = '2026-09-25', 
    cantidad_personas = 2,
    fecha_modificacion = GETDATE()
WHERE id_reserva = 1;

select * from reserva