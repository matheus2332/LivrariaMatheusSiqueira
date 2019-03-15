using System.Collections.Generic;

namespace CrossCutting.MainErrors
{
    public interface IMainError
    {
        ICollection<string> Erros { get; }
        bool IsValid { get; }

        void AddErro(string erro);
    }
}