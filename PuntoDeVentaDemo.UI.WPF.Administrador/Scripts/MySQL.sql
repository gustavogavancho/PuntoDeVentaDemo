CREATE TABLE `Producto` (
	`IdProducto` INT NOT NULL AUTO_INCREMENT,
	`Nombre` varchar(50) NOT NULL UNIQUE,
	`Costo` DECIMAL(8.2) NOT NULL,
	PRIMARY KEY (`IdProducto`)
);

CREATE TABLE `Usuario` (
	`NombreDeUsuario` varchar(50) NOT NULL,
	`Nombres` varchar(50) NOT NULL,
	`Apellidos` varchar(50) NOT NULL,
	`Password` varchar(50) NOT NULL,
	PRIMARY KEY (`NombreDeUsuario`)
);

CREATE TABLE `Venta` (
	`IdVenta` INT NOT NULL AUTO_INCREMENT,
	`FechaHora` DATETIME NOT NULL,
	`Cliente` varchar(50) NOT NULL,
	`NombreDeUsuario` varchar(50) NOT NULL,
	PRIMARY KEY (`IdVenta`)
);

CREATE TABLE `ProductoVendido` (
	`IdProductoVendido` INT NOT NULL AUTO_INCREMENT,
	`IdVenta` INT NOT NULL,
	`Costo` DECIMAL(8.2) NOT NULL,
	`Cantidad` INT NOT NULL,
	`IdProducto` INT NOT NULL,
	PRIMARY KEY (`IdProductoVendido`)
);

ALTER TABLE `Venta` ADD CONSTRAINT `Venta_fk0` FOREIGN KEY (`NombreDeUsuario`) REFERENCES `Usuario`(`NombreDeUsuario`);

ALTER TABLE `ProductoVendido` ADD CONSTRAINT `ProductoVendido_fk0` FOREIGN KEY (`IdVenta`) REFERENCES `Venta`(`IdVenta`);

ALTER TABLE `ProductoVendido` ADD CONSTRAINT `ProductoVendido_fk1` FOREIGN KEY (`IdProducto`) REFERENCES `Producto`(`IdProducto`);
