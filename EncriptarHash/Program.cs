using EncriptarHash;


internal class Program
{
    private static void Main(string[] args)
    {
        //Ejemplo de uso de BCrypt 

        var usuario = new Usuario
        {
            Id = 1,
            UserName = "admin",
            Salt = BCrypt.Net.BCrypt.GenerateSalt(),
            PasswordHash = BCrypt.Net.BCrypt.HashPassword("1234")
        };

        Console.Write("Ingrese el nombre de usuario: ");
        string inputUsername = Console.ReadLine();
        Console.Write("Ingrese la contraseña: ");
        string inputPassword = Console.ReadLine();

        var usuarioExistente = usuario.UserName == inputUsername;

        if (usuarioExistente != null && BCrypt.Net.BCrypt.Verify(inputPassword, usuario.PasswordHash))
        {
            Console.WriteLine("Inicio de sesión exitoso.");
        }
        else
        {
            Console.WriteLine("Credenciales incorrectas. Inicio de sesión fallido.");
        }
    }
}