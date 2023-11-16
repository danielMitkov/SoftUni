using ProductShop.Data;
using ProductShop.DTOs.Import;
using Newtonsoft.Json;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();

            string inputJson = File.ReadAllText(@"../../../Datasets/users.json");

            Console.WriteLine(ImportUsers(context,inputJson));
        }
        public static string ImportUsers(ProductShopContext context,string inputJson)
        {
            var userDtos = JsonConvert.DeserializeObject<ICollection<ImportUserDto>>(inputJson);

            var users = userDtos.Select(dto => new User
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Age = dto.Age
            });

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count()}";
        }
    }
}
