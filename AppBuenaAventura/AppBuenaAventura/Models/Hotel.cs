namespace AppBuenaAventura.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string? Ubicacion { get; set; }
        public string? Descripcion { get; set; }
        public string? Reseña { get; set; }
        public int AgenciaId { get; set; }
        public int? AgenteId { get; set; }
    }
}
