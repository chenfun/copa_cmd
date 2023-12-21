using CopaContext;

namespace CopaCmd
{
    internal class Program
    {
        //Scaffold-DbContext "server=192.168.100.253;Port=3306;Database=copapms;User=sa;Password=htit;Charset=utf8" Pomelo.EntityFrameworkCore.MySql -o ./Models -ContextNamespace CopaContext -f
        //dotnet ef dbcontext scaffold "server=192.168.100.253;Port=3306;Database=copapms;User=sa;Password=htit;Charset=utf8;" "Pomelo.EntityFrameworkCore.MySql" -o ./Models -c CopaContext -f
        private static void Main(string[] args)
        {
            Console.WriteLine("===========國鵬常註排程啟動===========!");

            var db = new copapmsContext();

            foreach (var item in db.MachineTables)
            {
                Console.WriteLine("{0}==>{1}", item.Id, item.MachineName);
            }

            Console.ReadLine();
        }
    }
}