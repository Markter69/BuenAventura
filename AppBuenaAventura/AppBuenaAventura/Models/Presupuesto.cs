namespace AppBuenaAventura.Models
{
    public class Presupuesto
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public string Destino { get; set; }
        public decimal Precio { get; set; }
    }
}
