CREATE TABLE [Producto] (
	IdProducto integer identity(1,1) NOT NULL,
	Nombre varchar(50) NOT NULL UNIQUE,
	Costo decimal(8,2) NOT NULL,
  CONSTRAINT [PK_PRODUCTO] PRIMARY KEY CLUSTERED
  (
  [IdProducto] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Usuario] (
	NombreDeUsuario varchar(50) NOT NULL,
	Nombres varchar(50) NOT NULL,
	Apellidos varchar(50) NOT NULL,
	Password varchar(50) NOT NULL,
  CONSTRAINT [PK_USUARIO] PRIMARY KEY CLUSTERED
  (
  [NombreDeUsuario] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Venta] (
	IdVenta integer identity(1,1) NOT NULL,
	FechaHora datetime NOT NULL,
	Cliente varchar(50) NOT NULL,
	NombreDeUsuario varchar(50) NOT NULL,
  CONSTRAINT [PK_VENTA] PRIMARY KEY CLUSTERED
  (
  [IdVenta] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [ProductoVendido] (
	IdProductoVendido integer identity(1,1) NOT NULL,
	IdVenta integer NOT NULL,
	Costo decimal(8,2) NOT NULL,
	Cantidad integer NOT NULL,
	IdProducto integer NOT NULL,
  CONSTRAINT [PK_PRODUCTOVENDIDO] PRIMARY KEY CLUSTERED
  (
  [IdProductoVendido] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO


ALTER TABLE [Venta] WITH CHECK ADD CONSTRAINT [Venta_fk0] FOREIGN KEY ([NombreDeUsuario]) REFERENCES [Usuario]([NombreDeUsuario])
ON UPDATE CASCADE
GO
ALTER TABLE [Venta] CHECK CONSTRAINT [Venta_fk0]
GO

ALTER TABLE [ProductoVendido] WITH CHECK ADD CONSTRAINT [ProductoVendido_fk0] FOREIGN KEY ([IdVenta]) REFERENCES [Venta]([IdVenta])
ON UPDATE CASCADE
GO
ALTER TABLE [ProductoVendido] CHECK CONSTRAINT [ProductoVendido_fk0]
GO
ALTER TABLE [ProductoVendido] WITH CHECK ADD CONSTRAINT [ProductoVendido_fk1] FOREIGN KEY ([IdProducto]) REFERENCES [Producto]([IdProducto])
ON UPDATE CASCADE
GO
ALTER TABLE [ProductoVendido] CHECK CONSTRAINT [ProductoVendido_fk1]
GO
