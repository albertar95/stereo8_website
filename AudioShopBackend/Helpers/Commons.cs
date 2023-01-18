using ImageMagick;
using System.Security.Cryptography;
using System.Text;
namespace AudioShopBackend.Helpers
{
    public class Commons
    {
        //scaffold-dbcontext "Server=.\MSSQL2017;Database=AudioShopDb;User Id=sa;Password=safa@123;TrustServerCertificate=true;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Force
        public static string[] bgColor { get; set; } = new string[] { "aquamarine", "burlywood", "lemonchiffon", "azure", "cadetblue", "chartreuse", "lightcoral", "lightsteelblue", "plum", "lightseagreen", "peru", "cornflowerblue", "darkgray", "darkkhaki", "lightblue", "bisque", "violet", "mediumseagreen", "palegreen", "paleturquoise", "tan", "hotpink", "cyan", "thistle", "goldenrod", "darksalmon" };
        public static string EncryptString(string text)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            {
                using (var tdes = new TripleDESCryptoServiceProvider())
                {
                    tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes("B@8CCto%YgfBF8OP1!Con007W"));
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    using (var transform = tdes.CreateEncryptor())
                    {
                        byte[] textBytes = UTF8Encoding.UTF8.GetBytes(text);
                        byte[] bytes = transform.TransformFinalBlock(textBytes, 0, textBytes.Length);
                        return Convert.ToBase64String(bytes, 0, bytes.Length);
                    }
                }
            }
        }
        public static string GenerateColor() 
        {
            Random r = new Random();
            return bgColor[r.Next(26)];
        }
        public static bool SaveReducedImage(int width, int height, string filepath,IFormFile file)
        {
            try
            {
                using (MagickImage tmpimage = new MagickImage(file.OpenReadStream()))
                {
                    tmpimage.Format = MagickFormat.WebP;
                    tmpimage.Resize(width, height);
                    tmpimage.Quality = 75;
                    tmpimage.Write(filepath);
                    if (File.Exists(filepath))
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
