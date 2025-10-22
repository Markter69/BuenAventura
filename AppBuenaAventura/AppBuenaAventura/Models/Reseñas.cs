namespace AppBuenaAventura.Models
{
    public class Reseñas
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int? AgenciaId { get; set; }
        public int? HotelId { get; set; }
        public int? AgenteId { get; set; }
        public int Calificacion { get; set; }
        public string? Comentario { get; set; }
        public DateTime FechaReseña { get; set; }
    }
}
