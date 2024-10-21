namespace WebApi.DTOs
{
    public class RolDTO
    {
        public int Id { get; set; }
        // El Simbolo(?) despues del tipo de dato permite que hayan valores nulos
        public string ? Name { get; set; }
    }
}
