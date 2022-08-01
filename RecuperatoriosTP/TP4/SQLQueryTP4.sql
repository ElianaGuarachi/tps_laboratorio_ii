GO
CREATE DATABASE SISTEMA_DE_VENTA
GO

use SISTEMA_DE_VENTA
GO

create table CLIENTES
(
ID_CLIENTES int identity primary key,
DNI int not null,
NOMBRE varchar (50) not null,
APELLIDO varchar (50) not null,
TELEFONO varchar (12) not null,
DIRECCION varchar (50) not null,
)
GO

insert into clientes (dni, nombre, apellido, telefono, direccion) values (39369071, 'Brittne', 'Rudall', '1116056420', '8634 Carey Point');
insert into clientes (dni, nombre, apellido, telefono, direccion) values (46953478, 'Alasdair', 'Le Marchand', '1104666865', '55 Sullivan Alley');
insert into clientes (dni, nombre, apellido, telefono, direccion) values (33419654, 'Manfred', 'Twelvetrees', '1178551759', '6 Fairfield Terrace');
insert into clientes (dni, nombre, apellido, telefono, direccion) values (13913342, 'Anderson', 'McClure', '1171367053', '089 Johnson Court');
insert into clientes (dni, nombre, apellido, telefono, direccion) values (49210997, 'Remy', 'Ghiroldi', '1147963302', '2 Knutson Junction');
insert into clientes (dni, nombre, apellido, telefono, direccion) values (35221830, 'Shandee', 'Cabera', '1194673768', '20 Stephen Road');
insert into clientes (dni, nombre, apellido, telefono, direccion) values (47315252, 'Gerrie', 'Witherup', '1103444871', '4 Corscot Road');
insert into clientes (dni, nombre, apellido, telefono, direccion) values (37887520, 'Paxton', 'Darragon', '1148848025', '169 Briar Crest Pass');
insert into clientes (dni, nombre, apellido, telefono, direccion) values (29582120, 'Jake', 'De Ambrosi', '1168228144', '39267 Lerdahl Road');
insert into clientes (dni, nombre, apellido, telefono, direccion) values (45401510, 'Howard', 'Ram', '3713079782', '4 Forest Dale Parkway');
insert into clientes (dni, nombre, apellido, telefono, direccion) values (37409708, 'Bearnard', 'Shiliton', '3435337319', '3 Fremont Parkway');
insert into clientes (dni, nombre, apellido, telefono, direccion) values (31572079, 'Arlyne', 'Joyson', '3439721531', '729 Northland Plaza');
insert into clientes (dni, nombre, apellido, telefono, direccion) values (48487569, 'Renate', 'Philip', '1134530644', '15901 Old Shore Crossing');
insert into clientes (dni, nombre, apellido, telefono, direccion) values (13450411, 'Hynda', 'Allston', '1106435472', '923 Jay Center');
insert into clientes (dni, nombre, apellido, telefono, direccion) values (36344183, 'Hestia', 'Testo', '1169103753', '0 Anderson Plaza');
insert into clientes (dni, nombre, apellido, telefono, direccion) values (43611780, 'Betteanne', 'Meers', '1108800423', '4 Anzinger Drive');
insert into clientes (dni, nombre, apellido, telefono, direccion) values (11856372, 'Buiron', 'Diggar', '1128795162', '67435 Hansons Court');
insert into clientes (dni, nombre, apellido, telefono, direccion) values (25213949, 'Lorry', 'Novelli', '1158812779', '28901 Crescent Oaks Avenue');
insert into clientes (dni, nombre, apellido, telefono, direccion) values (40111288, 'Ursala', 'Darrington', '1144124430', '252 Porter Street');
insert into clientes (dni, nombre, apellido, telefono, direccion) values (17164476, 'Alayne', 'Wozencroft', '1141483923', '5 Jana Lane');
insert into clientes (dni, nombre, apellido, telefono, direccion) values (18846155, 'Mercy', 'Bunclark', '1148688052', '8754 Park Meadow Pass');
insert into clientes (dni, nombre, apellido, telefono, direccion) values (49632948, 'Malinde', 'Lamplugh', '1147146710', '80 Continental Pass');
insert into clientes (dni, nombre, apellido, telefono, direccion) values (11129801, 'Dian', 'Kuhnwald', '1127868334', '5153 Iowa Junction');
insert into clientes (dni, nombre, apellido, telefono, direccion) values (24032498, 'Red', 'Amsberger', '1105612972', '951 Elmside Place');
insert into clientes (dni, nombre, apellido, telefono, direccion) values (11321855, 'Bern', 'Cleal', '1178917073', '9 Petterle Place');
insert into clientes (dni, nombre, apellido, telefono, direccion) values (35499600, 'Law', 'Brasseur', '1114292684', '79 Colorado Place');
insert into clientes (dni, nombre, apellido, telefono, direccion) values (41934388, 'Carolina', 'Firmager', '1149817008', '120 Union Court');
insert into clientes (dni, nombre, apellido, telefono, direccion) values (12365834, 'Gris', 'Zwicker', '1116747557', '08 Garrison Parkway');
insert into clientes (dni, nombre, apellido, telefono, direccion) values (36613330, 'Devy', 'Hullah', '1158326095', '2 Saint Paul Parkway');
insert into clientes (dni, nombre, apellido, telefono, direccion) values (19207167, 'Roxy', 'Eccles', '1107260554', '74174 Redwing Hill');
insert into clientes (dni, nombre, apellido, telefono, direccion) values (38352249, 'Ariadne', 'Eaglen', '1168113083', '51 Quincy Circle');
insert into clientes (dni, nombre, apellido, telefono, direccion) values (34017923, 'Judi', 'Coppock.', '1187244652', '07 Westridge Lane');
insert into clientes (dni, nombre, apellido, telefono, direccion) values (23288594, 'Ferrel', 'Coraini', '1148075068', '94 Lukken Drive');
insert into clientes (dni, nombre, apellido, telefono, direccion) values (24749531, 'Louise', 'Stirgess', '1133436646', '1171 Cottonwood Court');
insert into clientes (dni, nombre, apellido, telefono, direccion) values (44250763, 'Niles', 'Varker', '1141635140', '80 Rowland Hill');
insert into clientes (dni, nombre, apellido, telefono, direccion) values (31687226, 'Milt', 'Clell', '1193107832', '955 Hazelcrest Pass');
insert into clientes (dni, nombre, apellido, telefono, direccion) values (11570524, 'Milissent', 'Sangra', '1102270692', '14823 Superior Crossing');
insert into clientes (dni, nombre, apellido, telefono, direccion) values (26709607, 'Zita', 'Tregido', '1192040164', '53 Golf Way');
insert into clientes (dni, nombre, apellido, telefono, direccion) values (48589112, 'Malena', 'Pendrey', '1193150209', '62493 Victoria Alley');
insert into clientes (dni, nombre, apellido, telefono, direccion) values (38403277, 'Page', 'O'' Clovan', '1131054481', '21 Maple Wood Plaza');
insert into clientes (dni, nombre, apellido, telefono, direccion) values (30863447, 'Jessee', 'Glentz', '1152692413', '234 Bonner Point');
insert into clientes (dni, nombre, apellido, telefono, direccion) values (11101034, 'Pearce', 'Davidofski', '1183560801', '6523 Birchwood Pass');
insert into clientes (dni, nombre, apellido, telefono, direccion) values (20175628, 'Enoch', 'Pitkethly', '1124452082', '37 Mallory Street');
insert into clientes (dni, nombre, apellido, telefono, direccion) values (34258812, 'Stormy', 'Lemmanbie', '3434620921', '8206 Duke Crossing');
insert into clientes (dni, nombre, apellido, telefono, direccion) values (39687231, 'Freida', 'Clutten', '3718263093', '19 Brown Lane');
insert into clientes (dni, nombre, apellido, telefono, direccion) values (35758471, 'Cyrus', 'Fawdery', '3436060571', '405 Lawn Pass');
insert into clientes (dni, nombre, apellido, telefono, direccion) values (27776584, 'Oliviero', 'Rasher', '1152553883', '5 Del Sol Drive');
insert into clientes (dni, nombre, apellido, telefono, direccion) values (18799292, 'Brett', 'Challace', '1529456479', '04 Sage Park');
insert into clientes (dni, nombre, apellido, telefono, direccion) values (48334126, 'Aldin', 'Piotrowski', '1178279832', '3 Fremont Alley');
insert into clientes (dni, nombre, apellido, telefono, direccion) values (37799494, 'Avery', 'Causton', '1155846468', '63 Bunker Hill Way');
GO

create table PRODUCTOS
(
ID_PRODUCTOS int identity primary key,
CODIGO varchar (30) not null,
PRODUCTO varchar (100) not null,
STOCK int not null,
PRECIO float not null,
)
GO

insert into productos (codigo, producto, stock, precio) values ('B0011', 'Bidon de 20L retornable', 100, 450);
insert into productos (codigo, producto, stock, precio) values ('B0022', 'Bidon de 12L retornable', 100, 250);
insert into productos (codigo, producto, stock, precio) values ('B0033', 'Bidon de 5L no retornable', 100, 175);
insert into productos (codigo, producto, stock, precio) values ('BA062', 'Botellas de agua x6 2L', 100, 300);
insert into productos (codigo, producto, stock, precio) values ('BA615', 'Botellas de agua x6 1,5L', 100, 250);
insert into productos (codigo, producto, stock, precio) values ('BA125', 'Botellas de agua x12 500ml', 100, 200);
insert into productos (codigo, producto, stock, precio) values ('S0062', 'Soda x6 2L retornable', 297, 450);
insert into productos (codigo, producto, stock, precio) values ('S0615', 'Soda x6 1,5L retornable', 1, 350);
insert into productos (codigo, producto, stock, precio) values ('S0125', 'Soda x12 500ml no retornable', 100, 300);
insert into productos (codigo, producto, stock, precio) values ('DI000', 'Dispenser natural', 50, 700);
insert into productos (codigo, producto, stock, precio) values ('DIFCM', 'Dispenser frio/caliente mediano', 30, 2500);
insert into productos (codigo, producto, stock, precio) values ('DIFCG', 'Dispenser frio/caliente grande', 30, 4000);
GO

create table VENDEDORES
(
ID_VENDEDOR int identity primary key,
DNI int not null,
NOMBRE varchar (30) not null,
APELLIDO varchar (30) not null,
SUELDO float not null,
ESTA_ACTIVO bit not null,
FECHA_ALTA varchar(30) not null,
FECHA_BAJA varchar(30) null
)

GO
insert into vendedores (dni, nombre, apellido, sueldo, ESTA_ACTIVO, FECHA_ALTA, FECHA_BAJA) values (39369123, 'Eliana', 'Rodriguez', 87000.25, 1, '2010-06-12', null);
insert into vendedores (dni, nombre, apellido, sueldo, ESTA_ACTIVO, FECHA_ALTA, FECHA_BAJA) values (46953271, 'Emanuel', 'Vera', 92000.25, 1, '2015-04-04', null);
insert into vendedores (dni, nombre, apellido, sueldo, ESTA_ACTIVO, FECHA_ALTA, FECHA_BAJA) values (38195632, 'Cesar', 'Alvarez', 85000.10, 1, '2019-03-06', null);
insert into vendedores (dni, nombre, apellido, sueldo, ESTA_ACTIVO, FECHA_ALTA, FECHA_BAJA) values (36913342, 'Cristina', 'Castro', 88000.50, 1, '2014-01-10', null);
insert into vendedores (dni, nombre, apellido, sueldo, ESTA_ACTIVO, FECHA_ALTA, FECHA_BAJA) values (42210997, 'Daniela', 'Pastorutti', 95000.63, 1, '2015-03-25', null);
insert into vendedores (dni, nombre, apellido, sueldo, ESTA_ACTIVO, FECHA_ALTA, FECHA_BAJA) values (37221830, 'Soledad', 'Sanchez', 83500.65, 1, '2018-06-28', null);
insert into vendedores (dni, nombre, apellido, sueldo, ESTA_ACTIVO, FECHA_ALTA, FECHA_BAJA) values (27300252, 'Cristian', 'Gonzalez', 73500.85, 1, '2017-06-09', null);
insert into vendedores (dni, nombre, apellido, sueldo, ESTA_ACTIVO, FECHA_ALTA, FECHA_BAJA) values (38887125, 'Pedro', 'Dorrego', 78900.75, 1, '2016-04-21', null);
insert into vendedores (dni, nombre, apellido, sueldo, ESTA_ACTIVO, FECHA_ALTA, FECHA_BAJA) values (39244120, 'Juan', 'De Ambrosi', 83000.15, 1, '2017-08-19', null);
insert into vendedores (dni, nombre, apellido, sueldo, ESTA_ACTIVO, FECHA_ALTA, FECHA_BAJA) values (45411010, 'Emiliana', 'Romero', 89300.45, 1, '2020-09-18', null);
GO
create table DETALLE_VENTA
(
ID_DETALLE_VENTA int identity primary key,
ID_VENTA int  not null,
PRODUCTO varchar (100) not null,
PRECIO_VENTA float not null,
CANTIDAD int not null,
SUBTOTAL float not null,
FECHA_REGISTRO varchar(30) not null
)
GO
INSERT INTO DETALLE_VENTA (ID_VENTA, PRODUCTO, PRECIO_VENTA, CANTIDAD, SUBTOTAL, FECHA_REGISTRO) VALUES (1, 'Bidon de 20L retornable', 350, 5, 1750, '21/07/2022');
INSERT INTO DETALLE_VENTA (ID_VENTA, PRODUCTO, PRECIO_VENTA, CANTIDAD, SUBTOTAL, FECHA_REGISTRO) VALUES (1,	'Bidon de 5L no retornable', 120, 5, 600, '21/07/2022');
INSERT INTO DETALLE_VENTA (ID_VENTA, PRODUCTO, PRECIO_VENTA, CANTIDAD, SUBTOTAL, FECHA_REGISTRO) VALUES (2,	'Bidon de 12L retornable', 200, 5, 1000, '29/07/2022');
INSERT INTO DETALLE_VENTA (ID_VENTA, PRODUCTO, PRECIO_VENTA, CANTIDAD, SUBTOTAL, FECHA_REGISTRO) VALUES (2,	'Bidon de 20L retornable', 350,	4, 1400, '29/07/2022');
INSERT INTO DETALLE_VENTA (ID_VENTA, PRODUCTO, PRECIO_VENTA, CANTIDAD, SUBTOTAL, FECHA_REGISTRO) VALUES (3,	'Soda x12 500ml no retornable',	200, 10, 2000, '29/07/2022');
INSERT INTO DETALLE_VENTA (ID_VENTA, PRODUCTO, PRECIO_VENTA, CANTIDAD, SUBTOTAL, FECHA_REGISTRO) VALUES (3,	'Bidon de 20L retornable',	350, 2,	700, '29/07/2022');
INSERT INTO DETALLE_VENTA (ID_VENTA, PRODUCTO, PRECIO_VENTA, CANTIDAD, SUBTOTAL, FECHA_REGISTRO) VALUES (4,	'Dispenser frio/caliente grande', 4000,	1, 4000, '29/07/2022');
INSERT INTO DETALLE_VENTA (ID_VENTA, PRODUCTO, PRECIO_VENTA, CANTIDAD, SUBTOTAL, FECHA_REGISTRO) VALUES (4,	'Bidon de 20L retornable', 350,	4, 1400, '29/07/2022');
INSERT INTO DETALLE_VENTA (ID_VENTA, PRODUCTO, PRECIO_VENTA, CANTIDAD, SUBTOTAL, FECHA_REGISTRO) VALUES (5,	'Botellas de agua x6 2L', 220,	5, 1100, '29/07/2022');
INSERT INTO DETALLE_VENTA (ID_VENTA, PRODUCTO, PRECIO_VENTA, CANTIDAD, SUBTOTAL, FECHA_REGISTRO) VALUES (6,	'Soda x6 1,5L retornable', 196,	10,	1960, '29/07/2022');
GO

create table VENTAS
(
ID_VENTAS int identity primary key,
VENDEDOR varchar (100) not null,
COMPRADOR varchar (100) not null,
PRECIO_TOTAL float not null,
PAGO_REALIZADO bit not null,
FECHA_REGISTRO varchar(30) not null
)
GO
INSERT INTO VENTAS (VENDEDOR, COMPRADOR, PRECIO_TOTAL, PAGO_REALIZADO, FECHA_REGISTRO) VALUES ('Dni: 42210997 - Pastorutti, Daniela',	'DNI: 49210997 - Ghiroldi, Remy', 2350, 1, '21/07/2022');
INSERT INTO VENTAS (VENDEDOR, COMPRADOR, PRECIO_TOTAL, PAGO_REALIZADO, FECHA_REGISTRO) VALUES ('Dni: 39369123 - Rodriguez, Eliana',	'DNI: 38177868 - Guarachi, Eliana', 2400, 1, '29/07/2022');
INSERT INTO VENTAS (VENDEDOR, COMPRADOR, PRECIO_TOTAL, PAGO_REALIZADO, FECHA_REGISTRO) VALUES ('Dni: 39369123 - Rodriguez, Eliana',	'DNI: 13913342 - McClure, Anderson', 2700, 1, '29/07/2022');
INSERT INTO VENTAS (VENDEDOR, COMPRADOR, PRECIO_TOTAL, PAGO_REALIZADO, FECHA_REGISTRO) VALUES ('Dni: 42210997 - Pastorutti, Daniela',	'DNI: 49210997 - Ghiroldi, Remy', 2350, 1, '21/07/2022');
INSERT INTO VENTAS (VENDEDOR, COMPRADOR, PRECIO_TOTAL, PAGO_REALIZADO, FECHA_REGISTRO) VALUES ('Dni: 36913342 - Castro, Cristina',	'DNI: 38177868 - Guarachi, Eliana', 1100, 1, '29/07/2022');
INSERT INTO VENTAS (VENDEDOR, COMPRADOR, PRECIO_TOTAL, PAGO_REALIZADO, FECHA_REGISTRO) VALUES ('Dni: 27300252 - Gonzalez, Cristian',	'DNI: 45401510 - Ram, Howard', 1960, 1,	'29/07/2022');

