ENTREGA FINAL PRÁCTICA BACKEND (CURSO DIGITAL STACK GETD)

La aplicación desarrollada es capaz de gestionar un inventario de productos, realizando operaciones CRUD.

1. Descripción de la clase Product.cs

Cada elemento del inventario será de la clase Product. Los atributos de cada producto son los siguientes: un identificador "ID" para la base de datos (por defecto, lo vamos a dejar en 0 normalmente para que el sistema añada automáticamente el identificador de modo que no haya identificadores repetidos), el nombre "Name" del producto, una descripción "Description", el precio por unidad de producto "UnitPrice", el número de ventas "ProductSales" que se registran a través del usuario, el número de unidades de reabastecimiento "ReorderQuantity" y los stocks pre-actualización y post-actualización ("PreviousStock" y "Stock" respectivamente). Se considera un validador ProductValidator.cs para asegurarnos que los datos introducidos son coherentes.

2. Descripción de las clases ProductService.cs y ProductController.cs

La aplicación puede procesar varios tipos de solicitudes: 

GET: Obtener el listado de productos en el inventario

PUT: Añadir un artículo nuevo al inventario

DELETE: Eliminar un artículo del inventario

POST: Actualizar un artículo del inventario

La implementación de las funciones que se encargan de realizar cada una de las cuatro acciones se encuentra en ProductService.cs. En caso de que se procese un nombre para actualizar/eliminar un elemento de la base de datos se comprueba si el elemento existe o no

Adicionalmente se implementa un sistema de login por medio de JWT token en Swagger y pruebas unitarias para validar el correcto funcionamiento del programa.