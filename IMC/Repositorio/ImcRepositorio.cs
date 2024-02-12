using IMC.Model;
using Microsoft.JSInterop;
using System.Security.Cryptography;

namespace IMC.Repositorio
{
    public class ImcRepositorio
    {
        private readonly ILocalStorageService _localStorage;
       
        public ImcRepositorio(ILocalStorageService localStorage) => _localStorage = localStorage;

        public List<CalcIMC> Get()
        {
            var result = new List<CalcIMC>();
            for (var i = 0; i < _localStorage.Length; i++)
            {
                var key = (i + 1).ToString();
                var item = _localStorage.GetItem<CalcIMC>(key);

                if (item is not null)
                    result.Add(item);
            }
            return result;
        }

        public void Create(Pessoa pessoa)
        {
            var key = (_localStorage.Length + 1).ToString();

            var imcCal  = new CalcIMC();

            imcCal.DataResultado = DateTime.Now;
            imcCal.CalculoDoIMC(pessoa);
           
            _localStorage.SetItem(key, imcCal);
        }
    }
}
    
