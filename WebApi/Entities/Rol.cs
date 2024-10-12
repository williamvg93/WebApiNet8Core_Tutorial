using System.Security.Cryptography.X509Certificates;

namespace WebApi.Entities
{
    public class Rol
    {
        public int IdRol { get; set; }
        public string Name { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
