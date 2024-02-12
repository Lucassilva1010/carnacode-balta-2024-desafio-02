using IMC.Model.Enums;

namespace IMC.Model
{
    public class CalcIMC
    {
        private DateTime dataResultado;
        private double ValorIMC;
        private ImcStatus status;


        public ImcStatus GetStatus() => status;

        public DateTime GetDataResultado() => dataResultado;


        public void CalculoDoIMC(Pessoa pessoa)
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
                status = ImcStatus.Magro;
            else if (ValorIMC < 25)
                status = ImcStatus.Normal;
            else
                status = ImcStatus.Sobrepeso;
        }

        private void ValidarImcIdoso()
        {
            if (ValorIMC <= 18.5)
                status = ImcStatus.Magro;
            else if (ValorIMC <= 24.9)
                status = ImcStatus.Normal;
            else if (ValorIMC < 29)
                status = ImcStatus.Sobrepeso;
            else if (ValorIMC < 39.9)
                status = ImcStatus.Obesidade;
            else
                status = ImcStatus.Obesidade_Grave;
        }

        private void TratarIMCNegativo()
        {
            if (ValorIMC < 0)
                throw new ArgumentException("Erro ao calcular o IMC");
        }

    }
}
