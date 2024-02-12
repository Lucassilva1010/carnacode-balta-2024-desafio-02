using IMC.Model.Enums;

namespace IMC.Model
{
    public class CalcIMC
    {
        private DateTime _dataResultado;
        private double _valorIMC;
        private ImcStatus _status;

        public double GetValorIMC() => _valorIMC;

        public ImcStatus GetStatus() => _status;

        public DateTime GetDataResultado() => _dataResultado;

        public void SetDataResultado(DateTime dataResultado)
        {
            _dataResultado = dataResultado;
        }

        public void CalculoDoIMC(Pessoa pessoa)
        {
            _valorIMC = pessoa.Peso / (pessoa.Altura * pessoa.Altura);

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
            if (_valorIMC <= 18.5)
                _status = ImcStatus.Magro;
            else if (_valorIMC < 25)
                _status = ImcStatus.Normal;
            else
                _status = ImcStatus.Sobrepeso;
        }

        private void ValidarImcIdoso()
        {
            if (_valorIMC <= 18.5)
                _status = ImcStatus.Magro;
            else if (_valorIMC <= 24.9)
                _status = ImcStatus.Normal;
            else if (_valorIMC < 29)
                _status = ImcStatus.Sobrepeso;
            else if (_valorIMC < 39.9)
                _status = ImcStatus.Obesidade;
            else
                _status = ImcStatus.Obesidade_Grave;
        }

        private void TratarIMCNegativo()
        {
            if (_valorIMC < 0)
                throw new ArgumentException("Erro ao calcular o IMC");
        }
    }
}
