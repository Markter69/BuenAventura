namespace AppBuenaAventura.Models
{
    public class AgenteViaje
    {
        public int Id { get; set; }
        public string NombreCompletoAgen { get; set; }
        public string Correo { get; set; }
        public string? Telefono { get; set; }
        public int AgenciaId { get; set; }
    }
}
