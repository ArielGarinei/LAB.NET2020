using Lab.Demo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Demo.Logic
{
    public class CategoriesController
    {
        Logic<Categories> myCategories;

        public CategoriesController()
        {
            this.myCategories = new Logic<Categories>();
        }

        public void UpdateOneCategory()
        {
            try
            {
                Console.WriteLine("ACTUALIZANDO DATOS DE UN PRODUCTO EXISTENTE:\n");
                var category = SearchAndShowOneCategoryById();
                if (category != null)
                {
                    category.CategoryName = GetData("Ingrese nuevo Nombre de Categoria: ");
                    category.Description = GetData("Ingrese nueva Descripcion de Categoria: ");
                    myCategories.Update(category);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void DeleteOneCategorySafe()
        {
            try
            {
                Categories categories = myCategories.DeleteOneSafe(GetNumber("Ingrese el Id de la categoria que desea eliminar: "));
                string result = Getkey("Desea revertir la accion? para confirmar ingrese [S], para cancelar ingrese cualquier tecla [?]: ");
                if (result.Contains("s"))
                {
                    int newId = 0;
                    myCategories.InsertOne(categories);
                    Console.WriteLine($"Nuevo CategoryID asignado: {newId}");
                    //al parecer la base de datos auto incrementa el id de la tabla 
                    //si hay alguna manera de forzarlo verificando que ese id no exista estaria genial saber :)
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void DeleteOneCategoryById()
        {
            try
            {
                myCategories.DeleteOne(GetNumber("Ingrese el Id de la categoria que desea eliminar: "));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void InsertOneCategory()
        {
            try
            {
                myCategories.InsertOne(new Categories
                {
                    CategoryName = GetData("Ingrese nuevo CategoryName: "),
                    Description = GetData("Ingrese nueva Description: ")
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void SearchAndShowAllCategories()
        {
            try
            {
                foreach (var objEntity in myCategories.GetAll())
                {

                    Header(objEntity.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

       public  Categories SearchAndShowOneCategoryById()
        {
            Categories categories = null;
            try
            {
                categories = myCategories.GetOne(GetNumber("Ingrese el Id de la categoria a buscar: "));
                Header(categories.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return categories;
        }

        public void DeleteAllCategories()
        {
            try
            {
                myCategories.DeleteAll();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

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

        public void Header(string message)
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

