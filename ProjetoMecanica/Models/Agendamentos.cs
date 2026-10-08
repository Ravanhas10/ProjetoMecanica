namespace ProjetoMecanica.Models
{
    public class Agendamentos
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Servico { get; set; }
        public int VeiculoId { get; set; }

        public Veiculos Veiculo { get; set; }
    }
}
