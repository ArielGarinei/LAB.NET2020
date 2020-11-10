using Lab.Demo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Demo.Logic
{
    public class ProductsController
    {
        Logic<Products> myProducts;
        public ProductsController()
        {
           this.myProducts = new Logic<Products>();
        }

        //Metodos Products
        public void UpdateOneProduct()
        {
            try
            {
                Console.WriteLine("ACTUALIZANDO DATOS DE UN PRODUCTO EXISTENTE:\n");
                var Products = SearchAndShowOneProductById();
                if (Products != null)
                {
                    Products.ProductName = GetData("Ingrese nuevo Nombre de Producto: ");
                    Products.UnitPrice = GetPrice("Ingrese nueva Precio Unitario: ");
                    myProducts.Update(Products);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void DeleteOneProductSafe()
        {
            try
            {
                Products product = myProducts.DeleteOneSafe(GetNumber("Ingrese el Id del Producto que desea eliminar: "));
                string result = Getkey("Desea revertir la accion? para confirmar ingrese [S], para cancelar ingrese cualquier tecla [?]: ");
                if (result.Contains("s"))
                {
                    int newId = 0;
                    myProducts.InsertOne(product);
                    Console.WriteLine($"Nuevo ProductsID asignado: {product.ProductID}");
                    //al parecer la base de datos auto incrementa el id de la tabla 
                    //si hay alguna manera de forzarlo verificando que ese id no exista estaria genial saber :)
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void DeleteOneProductById()
        {
            try
            {
                myProducts.DeleteOne(GetNumber("Ingrese el Id del Producto que desea eliminar: "));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void InsertOneProduct()
        {
            try
            {
                myProducts.InsertOne(new Products
                {
                    ProductName = GetData("Ingrese nuevo Nombre de Producto: "),
                    UnitPrice = GetPrice("Ingrese nueva Precio Unitario: ")
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public Products SearchAndShowOneProductById()
        {
            Products Products = null;
            try
            {
                Products = myProducts.GetOne(GetNumber("Ingrese el Id del Producto a buscar: "));
                Header(Products.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Products;
        }
        //Metodos simples

        int GetNumber(String message)
        {
            int result;
            try
            {
                Console.Write(message);
                return int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return 0;

        }
        decimal GetPrice(String message)
        {
            decimal result;
            try
            {
                Console.Write(message);
                return decimal.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return 0;

        }

        string GetData(String message)
        {
            string result;
            try
            {
                Console.Write(message);
                result = Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result = "error";
            }
            return result;
        }

        void Header(string message)
        {
            Console.WriteLine($"**************************************************\n{message}\n**************************************************");
        }

        string Getkey(string message)
        {
            string result;
            Console.Write(message);
            result = Console.ReadLine();
            return result.Trim().ToLower();
        }




    }
}
