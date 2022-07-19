GO
create database RecuperatorioTP4
GO

use RecuperatorioTP4
GO

create table clientes
(
id int identity primary key,
dni int not null,
nombre varchar (30) not null,
apellido varchar (30) not null,
telefono varchar (12) not null,
direccion varchar (30) not null,
email varchar (30) not null,
)
GO

insert into clientes (dni, nombre, apellido, telefono, direccion, email) values (39369071, 'Brittne', 'Rudall', '1116056420', '8634 Carey Point', 'brudall0@gmail.com');
insert into clientes (dni, nombre, apellido, telefono, direccion, email) values (46953478, 'Alasdair', 'Le Marchand', '1104666865', '55 Sullivan Alley', 'alemarchand1@gmail.com');
insert into clientes (dni, nombre, apellido, telefono, direccion, email) values (33419654, 'Manfred', 'Twelvetrees', '1178551759', '6 Fairfield Terrace', 'mtwelvetrees2@gmail.com');
insert into clientes (dni, nombre, apellido, telefono, direccion, email) values (13913342, 'Anderson', 'McClure', '1171367053', '089 Johnson Court', 'amcclure3@gmail.com');
insert into clientes (dni, nombre, apellido, telefono, direccion, email) values (49210997, 'Remy', 'Ghiroldi', '1147963302', '2 Knutson Junction', 'rghiroldi4@gmail.com');
insert into clientes (dni, nombre, apellido, telefono, direccion, email) values (35221830, 'Shandee', 'Cabera', '1194673768', '20 Stephen Road', 'scabera5@gmail.com');
insert into clientes (dni, nombre, apellido, telefono, direccion, email) values (47315252, 'Gerrie', 'Witherup', '1103444871', '4 Corscot Road', 'gwitherup6@gmail.com');
insert into clientes (dni, nombre, apellido, telefono, direccion, email) values (37887520, 'Paxton', 'Darragon', '1148848025', '169 Briar Crest Pass', 'pdarragon7@gmail.com');
insert into clientes (dni, nombre, apellido, telefono, direccion, email) values (29582120, 'Jake', 'De Ambrosi', '1168228144', '39267 Lerdahl Road', 'jdeambrosi8@gmail.com');
insert into clientes (dni, nombre, apellido, telefono, direccion, email) values (45401510, 'Howard', 'Ram', '3713079782', '4 Forest Dale Parkway', 'hram9@gmail.com');
insert into clientes (dni, nombre, apellido, telefono, direccion, email) values (37409708, 'Bearnard', 'Shiliton', '3435337319', '3 Fremont Parkway', 'bshilitona@gmail.com');
insert into clientes (dni, nombre, apellido, telefono, direccion, email) values (31572079, 'Arlyne', 'Joyson', '3439721531', '729 Northland Plaza', 'ajoysonb@gmail.com');
insert into clientes (dni, nombre, apellido, telefono, direccion, email) values (48487569, 'Renate', 'Philip', '1134530644', '15901 Old Shore Crossing', 'rphilipc@gmail.com');
insert into clientes (dni, nombre, apellido, telefono, direccion, email) values (13450411, 'Hynda', 'Allston', '1106435472', '923 Jay Center', 'hallstond@gmail.com');
insert into clientes (dni, nombre, apellido, telefono, direccion, email) values (36344183, 'Hestia', 'Testo', '1169103753', '0 Anderson Plaza', 'htestoe@gmail.com');
insert into clientes (dni, nombre, apellido, telefono, direccion, email) values (43611780, 'Betteanne', 'Meers', '1108800423', '4 Anzinger Drive', 'bmeersf@gmail.com');
insert into clientes (dni, nombre, apellido, telefono, direccion, email) values (11856372, 'Buiron', 'Diggar', '1128795162', '67435 Hansons Court', 'bdiggarg@gmail.com');
insert into clientes (dni, nombre, apellido, telefono, direccion, email) values (25213949, 'Lorry', 'Novelli', '1158812779', '28901 Crescent Oaks Avenue', 'lnovellih@gmail.com');
insert into clientes (dni, nombre, apellido, telefono, direccion, email) values (40111288, 'Ursala', 'Darrington', '1144124430', '252 Porter Street', 'udarringtoni@gmail.com');
insert into clientes (dni, nombre, apellido, telefono, direccion, email) values (17164476, 'Alayne', 'Wozencroft', '1141483923', '5 Jana Lane', 'awozencroftj@gmail.com');
insert into clientes (dni, nombre, apellido, telefono, direccion, email) values (18846155, 'Mercy', 'Bunclark', '1148688052', '8754 Park Meadow Pass', 'mbunclarkk@gmail.com');
insert into clientes (dni, nombre, apellido, telefono, direccion, email) values (49632948, 'Malinde', 'Lamplugh', '1147146710', '80 Continental Pass', 'mlamplughl@gmail.com');
insert into clientes (dni, nombre, apellido, telefono, direccion, email) values (11129801, 'Dian', 'Kuhnwald', '1127868334', '5153 Iowa Junction', 'dkuhnwaldm@gmail.com');
insert into clientes (dni, nombre, apellido, telefono, direccion, email) values (24032498, 'Red', 'Amsberger', '1105612972', '951 Elmside Place', 'ramsbergern@gmail.com');
insert into clientes (dni, nombre, apellido, telefono, direccion, email) values (11321855, 'Bern', 'Cleal', '1178917073', '9 Petterle Place', 'bclealo@gmail.com');
insert into clientes (dni, nombre, apellido, telefono, direccion, email) values (35499600, 'Law', 'Brasseur', '1114292684', '79 Colorado Place', 'lbrasseurp@gmail.com');
insert into clientes (dni, nombre, apellido, telefono, direccion, email) values (41934388, 'Carolina', 'Firmager', '1149817008', '120 Union Court', 'cfirmagerq@gmail.com');
insert into clientes (dni, nombre, apellido, telefono, direccion, email) values (12365834, 'Gris', 'Zwicker', '1116747557', '08 Garrison Parkway', 'gzwickerr@gmail.com');
insert into clientes (dni, nombre, apellido, telefono, direccion, email) values (36613330, 'Devy', 'Hullah', '1158326095', '2 Saint Paul Parkway', 'dhullahs@gmail.com');
insert into clientes (dni, nombre, apellido, telefono, direccion, email) values (19207167, 'Roxy', 'Eccles', '1107260554', '74174 Redwing Hill', 'recclest@gmail.com');
insert into clientes (dni, nombre, apellido, telefono, direccion, email) values (38352249, 'Ariadne', 'Eaglen', '1168113083', '51 Quincy Circle', 'aeaglenu@gmail.com');
insert into clientes (dni, nombre, apellido, telefono, direccion, email) values (34017923, 'Judi', 'Coppock.', '1187244652', '07 Westridge Lane', 'jcoppockv@gmail.com');
insert into clientes (dni, nombre, apellido, telefono, direccion, email) values (23288594, 'Ferrel', 'Coraini', '1148075068', '94 Lukken Drive', 'fcorainiw@gmail.com');
insert into clientes (dni, nombre, apellido, telefono, direccion, email) values (24749531, 'Louise', 'Stirgess', '1133436646', '1171 Cottonwood Court', 'lstirgessx@gmail.com');
insert into clientes (dni, nombre, apellido, telefono, direccion, email) values (44250763, 'Niles', 'Varker', '1141635140', '80 Rowland Hill', 'nvarkery@gmail.com');
insert into clientes (dni, nombre, apellido, telefono, direccion, email) values (31687226, 'Milt', 'Clell', '1193107832', '955 Hazelcrest Pass', 'mclellz@gmail.com');
insert into clientes (dni, nombre, apellido, telefono, direccion, email) values (11570524, 'Milissent', 'Sangra', '1102270692', '14823 Superior Crossing', 'msangra10@gmail.com');
insert into clientes (dni, nombre, apellido, telefono, direccion, email) values (26709607, 'Zita', 'Tregido', '1192040164', '53 Golf Way', 'ztregido11@gmail.com');
insert into clientes (dni, nombre, apellido, telefono, direccion, email) values (48589112, 'Malena', 'Pendrey', '1193150209', '62493 Victoria Alley', 'mpendrey12@gmail.com');
insert into clientes (dni, nombre, apellido, telefono, direccion, email) values (38403277, 'Page', 'O'' Clovan', '1131054481', '21 Maple Wood Plaza', 'poclovan13@gmail.com');
insert into clientes (dni, nombre, apellido, telefono, direccion, email) values (30863447, 'Jessee', 'Glentz', '1152692413', '234 Bonner Point', 'jglentz14@gmail.com');
insert into clientes (dni, nombre, apellido, telefono, direccion, email) values (11101034, 'Pearce', 'Davidofski', '1183560801', '6523 Birchwood Pass', 'pdavidofski15@gmail.com');
insert into clientes (dni, nombre, apellido, telefono, direccion, email) values (20175628, 'Enoch', 'Pitkethly', '1124452082', '37 Mallory Street', 'epitkethly16@gmail.com');
insert into clientes (dni, nombre, apellido, telefono, direccion, email) values (34258812, 'Stormy', 'Lemmanbie', '3434620921', '8206 Duke Crossing', 'slemmanbie17@gmail.com');
insert into clientes (dni, nombre, apellido, telefono, direccion, email) values (39687231, 'Freida', 'Clutten', '3718263093', '19 Brown Lane', 'fclutten18@gmail.com');
insert into clientes (dni, nombre, apellido, telefono, direccion, email) values (35758471, 'Cyrus', 'Fawdery', '3436060571', '405 Lawn Pass', 'cfawdery19@gmail.com');
insert into clientes (dni, nombre, apellido, telefono, direccion, email) values (27776584, 'Oliviero', 'Rasher', '1152553883', '5 Del Sol Drive', 'orasher1a@gmail.com');
insert into clientes (dni, nombre, apellido, telefono, direccion, email) values (18799292, 'Brett', 'Challace', '1529456479', '04 Sage Park', 'bchallace1b@gmail.com');
insert into clientes (dni, nombre, apellido, telefono, direccion, email) values (48334126, 'Aldin', 'Piotrowski', '1178279832', '3 Fremont Alley', 'apiotrowski1c@gmail.com');
insert into clientes (dni, nombre, apellido, telefono, direccion, email) values (37799494, 'Avery', 'Causton', '1155846468', '63 Bunker Hill Way', 'acauston1d@gmail.com');
GO

create table productos
(
id int identity primary key,
codigo varchar (30) not null,
producto varchar (100) not null,
stock int not null,
precio float not null,
)
GO

insert into productos (codigo, producto, stock, precio) values ('B0011', 'Bidon de 20L retornable', 100, 350);
insert into productos (codigo, producto, stock, precio) values ('B0022', 'Bidon de 12L retornable', 100, 200);
insert into productos (codigo, producto, stock, precio) values ('B0033', 'Bidon de 5L no retornable', 100, 120);
insert into productos (codigo, producto, stock, precio) values ('BA062', 'Botellas de agua x6 2L', 100, 220);
insert into productos (codigo, producto, stock, precio) values ('BA615', 'Botellas de agua x6 1,5L', 100, 157);
insert into productos (codigo, producto, stock, precio) values ('BA125', 'Botellas de agua x12 500ml', 100, 134);
insert into productos (codigo, producto, stock, precio) values ('S0062', 'Soda x6 2L retornable', 297, 451);
insert into productos (codigo, producto, stock, precio) values ('S0615', 'Soda x6 1,5L retornable', 1, 196);
insert into productos (codigo, producto, stock, precio) values ('S0125', 'Soda x12 500ml no retornable', 100, 3);
insert into productos (codigo, producto, stock, precio) values ('DI000', 'Dispenser natural', 50, 700);
insert into productos (codigo, producto, stock, precio) values ('DIFCM', 'Dispenser frio/caliente mediano', 30, 2500);
insert into productos (codigo, producto, stock, precio) values ('DIFCG', 'Dispenser frio/caliente grande', 30, 4000);



