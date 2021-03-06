﻿using System.ComponentModel;
namespace _7COMm.Recrutamento.HelperUtilities.Enuns
{
    public enum ApiVersion
    {
        V3,
        V4,
        V3_Oauth,
        V4_Oauth
    }
    public enum KeyIdentifierType
    {
        //Faltando implementação
    }
    public enum ReturnExecution
    {
        [Description("Execution with successful")]
        SUCCESS = 0,

        [Description("Execution with errors")]
        WITH_ERROR = 1,

        [Description("Execution with Warnings")]
        WITH_WARNING = 2
    }


    public enum CodeErrorType
    {
        [Description("Ocorreu um erro na comunicação com o servidor. Tente novamente mais tarde.")]
        UnexpectedError = 1,
        [Description("Required Field")]
        RequiredField = 2,
        [Description("Parameter With Invalid Type")]
        ParameterWithInvalidType = 3,
        [Description("Invalid Value")]
        InvalidValue = 4,
        [Description("ETC")]
        ETC = 5
    }
}
