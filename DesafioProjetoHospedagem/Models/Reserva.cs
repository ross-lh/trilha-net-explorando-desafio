namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            /* Verifica se a capacidade é maior ou igual ao número de hóspedes recebido,
               retornando uma exception caso a capacidade seja menor que o número de hóspedes recebido */
            bool capacidadeSuficiente = hospedes.Count <= Suite.Capacidade;

            if (capacidadeSuficiente)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new Exception("Capacidade insuficiente para o número de hóspedes.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            /* Retorna o valor da diária, efetuando o cálculo e, conforme a quantidade
               de dias reservados, se maior ou igual a 10, concede um desconto de 10%
            */
            decimal valor = DiasReservados * Suite.ValorDiaria;

            bool aplicarDesconto = DiasReservados >= 10;
            if (aplicarDesconto)
            {
                valor *= 0.9M;
            }
            else
            {
                valor *= 1.0M;
            }

            return valor;
        }
    }
}