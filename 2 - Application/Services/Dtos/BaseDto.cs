using System.Collections.Generic;
using System.Linq;

namespace Services.Dtos
{
    public class BaseDto
    {
        public BaseDto()
        {
            Erros = new List<ValidacaoErro>();
        }

        public ICollection<ValidacaoErro> Erros { get; set; }

        public bool IsValid => !Erros.Any();

        public void AddErro(string propertyName, string erro)
        {
            Erros.Add(new ValidacaoErro(propertyName, erro));
        }
    }
}