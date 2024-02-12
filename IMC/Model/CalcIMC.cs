using IMC.Model.Enums;

namespace IMC.Model
{
    public class CalcIMC
    {
        public DateTime DataResultado { get; set; }
        public double ValorIMC { get; set; }
        public ImcStatus Status { get; set; }

        public void CalculoDoIMC(pessoa pessoa)
        {
            ValorIMC = pessoa.Peso / (pessoa.Altura * pessoa.Altura);

            TratarIMCNegativo();

            ClassificarImc(pessoa.Maior65);
        }

        private void ClassificarImc(bool maior65)
        {
            if (maior65)
                ValidarImcIdoso();
            else
                ValidarImc();
        }

        private void ValidarImc()
        {
            if (ValorIMC <= 18.5)
                Status = ImcStatus.Magro;
            else if (ValorIMC < 25)
                Status = ImcStatus.Normal;
            else
                Status = ImcStatus.Sobrepeso;
        }

        private void ValidarImcIdoso()
        {
            if (ValorIMC <= 18.5)
                Status = ImcStatus.Magro;
            else if (ValorIMC <= 24.9)
                Status = ImcStatus.Normal;
            else if (ValorIMC < 29)
                Status = ImcStatus.Sobrepeso;
            else if (ValorIMC < 39.9)
                Status = ImcStatus.Obesidade;
            else
                Status = ImcStatus.Obesidade_Grave;
        }

        private void TratarIMCNegativo()
        {
            if (ValorIMC < 0)
                throw new ArgumentException("Erro ao calcular o IMC");
        }

    }
}
