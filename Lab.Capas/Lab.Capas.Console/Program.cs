using Lab.Demo.Entities;
using Lab.Demo.Logic;
using System;


namespace Lab.Capas.Presentacion
{
    class Program
    {
        static void Main(string[] args)
        {
            var myProducts = new Logic<Products>();
            var myCategories = new Logic<Categories>();
            ProductsController productsController = new ProductsController();
            CategoriesController categoriesController = new CategoriesController();



            string exit = " ";
            do
            {
                Console.Clear();
                Header("--------------------PRODUCTOS--------------------");
                SearchAndShowAllEntity<Products>(myProducts);
                Console.ReadKey();
                productsController.SearchAndShowOneProductById();
                Console.ReadKey();
                Console.Clear();
                productsController.InsertOneProduct();
                Console.ReadKey();
                SearchAndShowAllEntity<Products>(myProducts);
                Console.ReadKey();
                Console.Clear();
                Header("--------------------UPDATE--------------------");
                productsController.UpdateOneProduct();
                Console.ReadKey();
                Console.Clear();
                Header("--------------------DELETE--------------------");
                productsController.DeleteOneProductById();
                Console.ReadKey();
                Console.Clear(); 
                SearchAndShowAllEntity<Products>(myProducts);
                Console.ReadKey();
                Console.Clear(); 
                Header("--------------------CATEGORIAS--------------------");
                SearchAndShowAllEntity<Categories>(myCategories);
                Console.ReadKey();
                categoriesController.SearchAndShowOneCategoryById();
                Console.ReadKey();
                Console.Clear();
                categoriesController.InsertOneCategory();
                Console.ReadKey();
                SearchAndShowAllEntity<Categories>(myCategories);
                Console.ReadKey();
                Console.Clear();
                Header("--------------------UPDATE--------------------");
                categoriesController.UpdateOneCategory();
                Console.ReadKey();
                Console.Clear();
                Header("--------------------DELETE--------------------");
                categoriesController.DeleteOneCategoryById();
                Console.ReadKey();
                Console.Clear();
                SearchAndShowAllEntity<Categories>(myCategories);
                Console.ReadKey();
                Console.Clear();
                Console.Write("\nIngrese [S] para terminar el bucle o cualquier tecla para continuar[?]: ");
                exit = Console.ReadLine();
            } while (!exit.Trim().ToLower().Contains("s"));



            //Metodos Generic 
            //llegue a esto intentando hacer el codigo lo mas reutilizable posible pero me encontre con algunas piedras tratando de implementarlo en lo que podria ser un "EntityController"
            void SearchAndShowAllEntity<T>(Logic<T> entity) where T : class
            {
                try
                {
                    foreach (var objEntity in entity.GetAll())
                    {

                        Header(objEntity.ToString());
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            
            void DeleteAllEntit< T > (Logic < T > entity) where T : class
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

            string Header(string message) 
            {
                string result = $"**************************************************\n{message}\n**************************************************";
                Console.WriteLine(result);
                return result;


            }
        }
    }
}
