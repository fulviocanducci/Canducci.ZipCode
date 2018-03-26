namespace Canducci.Zip
{
#if NET40 || NET45 || NET451 || NET452 || NET46 || NET461 || NET462 || NET47 || NET471 || NETSTANDARD2_0
    [System.Serializable()]
#endif
    public sealed class ZipCodeException: System.Exception
    {
        public ZipCodeException() { }

        public ZipCodeException(string message)
            : base(message) { }

        public ZipCodeException(string message, System.Exception innerException)
            : base(message, innerException) { }

#if NET40 || NET45 || NET451 || NET452 || NET46 || NET461 || NET462 || NET47 || NET471 || NETSTANDARD2_0
        public ZipCodeException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
#endif
    }
}

//https://docs.microsoft.com/en-us/nuget/reference/target-frameworks
//https://msdn.microsoft.com/pt-br/library/cc564864.aspx?f=255&MSPPError=-2147217396
//https://docs.microsoft.com/pt-br/dotnet/visual-basic/language-reference/directives/const-directive
//https://docs.microsoft.com/pt-br/dotnet/csharp/language-reference/preprocessor-directives/preprocessor-if !!!
/*
Frameworks de destino Símbolos
.NET Framework NET20, NET35, NET40, NET45, NET451, NET452, NET46, NET461, NET462, NET47, NET471
.NET Standard   NETSTANDARD1_0, NETSTANDARD1_1, NETSTANDARD1_2, NETSTANDARD1_3, NETSTANDARD1_4, NETSTANDARD1_5, NETSTANDARD1_6, NETSTANDARD2_0
.NET Core   NETCOREAPP1_0, NETCOREAPP1_1, NETCOREAPP2_0
*/