using System.Collections.Generic;
using System.Linq;

namespace LivrariaWeb.Models.Base
{
    public class BaseViewModel
    {
        public BaseViewModel()
        {
            Erros = new List<string>();
        }

        public ICollection<string> Erros { get; set; }
        public bool IsValid => !Erros.Any();

        public void AddErro(string erro)
        {
            Erros.Add(erro);
        }
    }
}