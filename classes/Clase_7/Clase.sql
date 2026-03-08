CREATE TABLE clientes ( 
id_cliente SERIAL PRIMARY KEY, 
nombre VARCHAR(100) NOT NULL, 
correo VARCHAR(100), 
telefono VARCHAR(20) 
); 

CREATE TABLE productos ( 
id_producto SERIAL PRIMARY KEY, 
nombre_producto VARCHAR(100) NOT NULL, 
precio DECIMAL(10,2) NOT NULL, 
stock INTEGER 
); 

CREATE TABLE pedidos ( 
id_pedido SERIAL PRIMARY KEY, 
id_cliente INTEGER, 
id_producto INTEGER, 
cantidad INTEGER, 
fecha TIMESTAMP DEFAULT CURRENT_TIMESTAMP, 
FOREIGN KEY (id_cliente) REFERENCES clientes(id_cliente), 
FOREIGN KEY (id_producto) REFERENCES productos(id_producto) 
); 

select * from clientes 
select * from productos 

INSERT INTO clientes (nombre, correo, telefono) 
VALUES ('Juan Perez', 'juan@gmail.com', '55512345'), ('Maria Lopez', 'maria@gmail.com', '55567890'); 

INSERT INTO productos (nombre_producto, precio, stock) 
VALUES ('Laptop', 7500.00, 10), ('Mouse', 150.00, 50), ('Teclado', 300.00, 20); 

INSERT INTO pedidos (id_cliente, id_producto, cantidad) 
VALUES (1, 1, 1), (2, 2, 2); 

SELECT clientes.nombre, productos.nombre_producto, pedidos.cantidad, pedidos.fecha FROM pedidos 
JOIN clientes ON pedidos.id_cliente = clientes.id_cliente 
JOIN productos ON pedidos.id_producto = productos.id_producto;