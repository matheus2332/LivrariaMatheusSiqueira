namespace Services.Dtos
{
    public class ValidacaoErro
    {
        public ValidacaoErro(string propertyName, string erro)
        {
            PropertyName = propertyName;
            Erro = erro;
        }

        public string PropertyName { get; set; }
        public string Erro { get; set; }
    }
}