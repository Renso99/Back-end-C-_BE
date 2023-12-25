CREATE DATABASE bodega;

USE bodega;

CREATE TABLE tipo_documentos (
    id smallint primary key auto_increment,
    descripcion varchar(30)
);

CREATE TABLE personas (
    id int primary key auto_increment,
    id_tipo_documento smallint,
    nro_documento varchar(15) UNIQUE,
    ap_paterno varchar(50),
    ap_materno varchar(50),
    nombres varchar(50),
    fecha_nacimiento date,
    telefono varchar(13),
    correo varchar(70),
    constraint FK_tipo_documento FOREIGN KEY (id_tipo_documento) references tipo_documentos(id)
);

create table ubigeos (
    id int primary key auto_increment,
    ubigeo varchar(6),
    departamento varchar(30),
    provincia varchar(30),
    distrito varchar(30),
    descripcion varchar(100)
);

create table persona_direccions (
    id int primary key auto_increment,
    id_persona int,
    id_ubigeo int,
    calle varchar(40),
    nro varchar(5),
    referencia varchar(100),
    latitud varchar(30),
    longitud varchar(30),
    constraint FK_persona FOREIGN KEY (id_persona) references personas(id),
    constraint FK_ubigeo FOREIGN KEY (id_ubigeo) references ubigeos(id)
);

create table categorias (
    id int primary key auto_increment,
    descripcion varchar(50)
);

create table sub_categorias (
    id int primary key auto_increment,
    id_categoria int,
    descripcion varchar(50),
    constraint FK_Categoria FOREIGN KEY (id_categoria) references categorias(id)
);

create table unidad_medidas (
    id int primary key auto_increment,
    descripcion varchar(50)
);

create table productos (
    id int primary key auto_increment,
    id_categoria int,
    id_sub_categoria int,
    id_unidad_medida int,
    codigo varchar(50),
    nombre varchar(150),
    stock decimal(8, 2),
    stock_minimo decimal(8, 2),
    precio_compra decimal(8, 2),
    precio_venta decimal(8, 2),
    descripcion varchar(300),
    estado bit,
    constraint FK_CategoriaProducto FOREIGN KEY (id_categoria) references categorias(id),
    constraint FK_Sub_Categoria FOREIGN KEY (id_sub_categoria) references sub_categorias(id),
    constraint FK_Unidad_Medida FOREIGN KEY (id_unidad_medida) references unidad_medidas(id)
);

create table producto_componentes (
    id int primary key auto_increment,
    id_producto int,
    nombre varchar(50),
    cantidad varchar(50),
    constraint FK_producto_componente_producto FOREIGN KEY (id_producto) references productos(id)
);

create table comprobantes_pagos (
    id int primary key auto_increment,
    codigo_sunat varchar(3),
    descripcion varchar(30)
);


create table proveedores (
    id int primary key auto_increment,
    ruc varchar(11),
    razon_social varchar(100),
    telefono varchar(13),
    contacto varchar(50),
    email varchar(100)
);


create table ingreso_salida_productos (
    id int primary key auto_increment,
    id_producto int,
    id_unidad_medida int,
    id_comprobante_pago int,
    id_proveedor int,
    tipo varchar(10),
    nro_lote varchar(30),
    fecha_vencimiento date,
    cantidad_ingreso decimal(8, 2),
    cantidad_salida decimal(8, 2),
    fecha_registro date,
    fecha_boleta date,
    nro_serie varchar(5),
    correlativo varchar(20),
    precio_unitario decimal(8, 2),
    precio_total decimal(8, 2),
    motivo varchar(100),
    constraint FK_ingreso_salida_producto_producto FOREIGN KEY (id_producto) references productos(id),
    constraint FK_ingreso_salida_producto_comprobante_pago FOREIGN KEY (id_comprobante_pago) references comprobantes_pagos(id),
    constraint FK_ingreso_salida_producto_unidad_medida FOREIGN KEY (id_unidad_medida) references unidad_medidas(id),
    constraint FK_ingreso_salida_producto_proveedor FOREIGN KEY (id_proveedor) references proveedores(id)
);


create table producto_proveedores (
    id int primary key auto_increment,
    id_proveedor int,
    id_producto int,
    constraint FK_producto_proveedor_producto FOREIGN KEY (id_producto) references productos(id),
    constraint FK_producto_proveedor_proveedor FOREIGN KEY (id_proveedor) references unidad_medidas(id)
);

create table roles (
    id int primary key auto_increment,
    descripcion varchar(50),
    funcion varchar(100)
);

create table usuarios (
    id int primary key auto_increment,
    username varchar(30),
    password varchar(300),
    id_persona int,
    estado bit,
    constraint FK_usuario_persona FOREIGN KEY (id_persona) references personas(id)
);

create table medios_pagos (
    id int primary key auto_increment,
    descripcion varchar(100),
    titular varchar(50)
);

create table estado_pedidos (
    id int primary key auto_increment,
    descripcion varchar(30)
);

create table pedidos (
    id int primary key auto_increment,
    id_persona int,
    id_estado_pedido int,
    fecha date,
    estado_pagago bit,
    fiado bit,
    delivery bit,
    id_persona_direccion int,
    monto_total decimal(8, 2),
    monto_pagado decimal(8, 2),
    monto_por_pagar decimal(8, 2),
    igv decimal(8, 2),
    nro_serie varchar(5),
    correlativo varchar(30),
    id_usuario int,
    constraint FK_pedido_estado_pedido FOREIGN KEY (id_estado_pedido) references estado_pedidos(id),
    constraint FK_pedido_usuario FOREIGN KEY (id_usuario) references usuarios(id)
);

create table pedido_detalle_pagos (
    id int primary key auto_increment,
    id_medio_pago int,
    id_pedido int,
    monto_pago decimal(8, 2),
    constraint FK_pedido_detalle_pago_medio_pago FOREIGN KEY (id_medio_pago) references medios_pagos(id),
    constraint FK_pedido_detalle_pago_pedido FOREIGN KEY (id_pedido) references pedidos(id)
);

create table pedido_detalles (
    id int primary key auto_increment,
    id_pedido int,
    id_producto int,
    cantidad decimal(8, 2),
    precio_unitario decimal(8, 2),
    sub_total decimal(8, 2),
    estado bit,
    constraint FK_pedido_detalle_producto FOREIGN KEY (id_producto) references productos(id),
    constraint FK_pedido_detalle_pedido FOREIGN KEY (id_pedido) references pedidos(id)
);

CREATE TABLE cajas (
    id int primary key auto_increment,
    fecha date,
    id_usuario_apertura int,
    id_usuario_cierre int,
    estado bit,
    monto_apertura decimal(8, 2),
    monto_cierre decimal(8, 2),
    constraint FK_caja_usuario_apertura FOREIGN KEY (id_usuario_apertura) references usuarios(id),
    constraint FK_caja_usuario_cierre FOREIGN KEY (id_usuario_cierre) references usuarios(id)
);

CREATE TABLE caja_movimientos (
    id int primary key auto_increment,
    id_caja int,
    tipo varchar(20),
    monto decimal(8, 2),
    id_detalle_pago int,
    constraint FK_caja_movimiento_caja FOREIGN KEY (id_caja) references cajas(id),
    constraint FK_caja_movimiento_pedido_detalle_pago FOREIGN KEY (id_detalle_pago) references pedido_detalle_pagos(id)
);