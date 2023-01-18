using AudioShopFrontend.Models;
using AudioShopFrontend.Services.Contracts;

namespace AudioShopFrontend.Helpers
{
    public class UsersAuth
    {
        private readonly IDatabaseAction _db;
        public UsersAuth(IDatabaseAction databaseAction) 
        {
            _db = databaseAction;
        }
        public static string GenerateLoginCookieValue(User user,int cartcount = 0,int favcount = 0) 
        {
            return $"{user.Username},{user.NidUser.ToString()},{user.FirstName + " " + user.LastName},{cartcount},{favcount}";
        }
        public static CustomClaim GetClaim(string cookieValue) 
        {
            string[] vals = cookieValue.Split(',');
            return new CustomClaim() {  Username = vals[0], NidUser = Guid.Parse(vals[1]), FullName = vals[2], CartCount = int.Parse(vals[3]), FavCount = int.Parse(vals[4]) };
        }
        public static string GetSpecificClaim(string cookieValue,int index)
        {
            string[] vals = cookieValue.Split(',');
            if (index > 0 && index <= 5)
                return vals[index - 1];
            else
                return "";
        }
    }
    public class CustomClaim 
    {
        public string Username { get; set; } = ""!;
        public Guid NidUser { get; set; }
        public string FullName { get; set; } = ""!;
        public int CartCount { get; set; }
        public int FavCount { get; set; }
    }
}
