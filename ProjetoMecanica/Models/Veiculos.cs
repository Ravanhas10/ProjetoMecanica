namespace ProjetoMecanica.Models
{
    public class Veiculos
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }

        public Clientes Cliente { get; set; }
    }
}
