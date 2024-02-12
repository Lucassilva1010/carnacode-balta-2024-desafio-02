using Microsoft.JSInterop;
using System.Net.NetworkInformation;
using System.Security.Cryptography;

namespace IMC.Model
{
    public class CalcIMC
    {
      
        public DateTime DataResultado { get; set; }
        public double ValorIMC { get; set; }
        public ImcStatus Status { get; set; }

        //Metodos
        public void CalculoDoIMC(pessoa pessoa)
        {
           ValorIMC = pessoa.Peso / (pessoa.Altura * pessoa.Altura);
            if (pessoa.Idade)
            {
                if (ValorIMC <= 22)
                    Status = ImcStatus.Magro;
                else if (ValorIMC < 27)
                    Status = ImcStatus.Normal;
                else
                    Status = ImcStatus.Sobrepeso;
            }
            else
            {
                if (ValorIMC <= 18.5)
                    Status = ImcStatus.Magro;
                else if (ValorIMC < 25)
                    Status = ImcStatus.Normal;
                else
                    Status = ImcStatus.Sobrepeso;

            }
        }

    }
    public enum ImcStatus
    {
        Magro,
        Normal, 
        Sobrepeso,
        Obesidade,
        Obesidade_grave
    }

   
}
