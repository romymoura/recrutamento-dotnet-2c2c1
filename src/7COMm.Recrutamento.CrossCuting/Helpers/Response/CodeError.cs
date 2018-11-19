using _7COMm.Recrutamento.CrossCuting.Enuns;

namespace _7COMm.Recrutamento.CrossCuting.Response
{
    public static class CodeError
    {
        public static string GetCodeError(CodeErrorType codeErrorType)
        {
            switch (codeErrorType)
            {
                case CodeErrorType.UnexpectedError:
                    return "001";
                case CodeErrorType.RequiredField:
                    return "002";
                case CodeErrorType.ParameterWithInvalidType:
                    return "003";
                case CodeErrorType.InvalidValue:
                    return "004";
                case CodeErrorType.ETC:
                    return "005";
                default:
                    return "Opção Inválida";
            }
        }
    }
}
