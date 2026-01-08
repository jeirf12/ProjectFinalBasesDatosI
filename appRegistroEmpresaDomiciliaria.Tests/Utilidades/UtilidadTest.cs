namespace appRegistroEmpresaDomiciliaria.Tests.Utilidades {

    using appRegistroEmpresaDomiciliaria.Utilidades;

    public class UtilidadTest {

        [Theory]
        [InlineData("123", true)]
        [InlineData("123roho", false)]
        public void EsNumerico_AmbosCasos_OK(string numero, bool resultadoEsperado) {
            var resultado = numero.EsNumerico();

            if (resultadoEsperado)
                Assert.True(resultado);
            else
                Assert.False(resultado);
        }

        [Theory]
        [InlineData("123 ", true)]
        [InlineData("abc", true)]
        [InlineData(null, false)]
        [InlineData(" ", false)]
        public void EstaLleno_CamposVacios_Ok(string campo, bool resultadoEsperado) {
            var resultado = campo.Estalleno();

            if (resultadoEsperado) 
                Assert.True(resultado);
            else
                Assert.False(resultado);
        }
    }
}