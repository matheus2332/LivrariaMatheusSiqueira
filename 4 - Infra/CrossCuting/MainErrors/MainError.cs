using System.Collections.Generic;
using System.Linq;

namespace CrossCutting.MainErrors
{
    public class MainError : IMainError
    {
        public MainError()
        {
            Erros = new List<string>();
        }

        public ICollection<string> Erros { get; private set; }
        public bool IsValid => !Erros.Any();

        public void AddErro(string erro)
        {
            Erros.Add(erro);
        }
    }
}