
namespace WebApi.Entities
{
    public class Employee
    {
        public int IdEmployee { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public int FkIdRol {  get; set; }
        public virtual Rol Rol { get; set; }
    }
}
