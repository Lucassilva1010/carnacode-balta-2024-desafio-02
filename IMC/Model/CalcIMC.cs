using Microsoft.JSInterop;
using System.Net.NetworkInformation;
using System.Security.Cryptography;

namespace IMC.Model
{
    public class CalcIMC
    {

        public DateTime DataResultado { get; set; }
        public double? ValorIMC { get; set; }
        public ImcStatus Status { get; set; }

        //Metodos
        public void CalculoDoIMC(pessoa pessoa)
        {
            ValorIMC = pessoa.Peso / (pessoa.Altura * pessoa.Altura);
            if (pessoa.Maior65)
            {
                if (ValorIMC >= 0)

                    if (ValorIMC >= 0 && ValorIMC <= 18.5)
                    {
                        Status = ImcStatus.Magro;
                    }
                    else if (ValorIMC <= 24.9)
                    {
                        Status = ImcStatus.Normal;
                    }
                    else if (ValorIMC < 29)
                    {
                        Status = ImcStatus.Sobrepeso;
                    }
                    else if (ValorIMC < 39.9)
                    {
                        Status = ImcStatus.Obesidade;
                    }
                    else
                    {
                        Status = ImcStatus.Obesidade_Grave;
                    }

            }
            else
            {
                if (ValorIMC >= 0)
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
        Obesidade_Grave
    }


}
