using FluentAssertions;

namespace Eleicao.Tests
{
    public class TesteUrna
    {
        #region ValidarFuncionamentoConstrutor
        //Validar se o construtor está inserindo os dados iniciais corretamente
        [Fact]
        public void ValidarFuncionamentoConstrutor()
        {
            //Arrange
            var urna = new Urna();
            var comparacao = new Urna{ VencedorEleicao = "", VotosVencedor = 0, Candidatos = new List<Candidato>(), EleicaoAtiva = false };
            
            //Act /Assert
            urna.Should().BeEquivalentTo(comparacao);
        }
        #endregion

        #region ValidarInicioEleicao
        //Validar se a eleição está sendo iniciada corretamente
        [Fact]
        public void ValidarInicioEleicao()
        {
            //Arrange
            var urna1 = new Urna();

            //Act
            urna1.IniciarEncerrarEleicao();

            //Assert
            Assert.True(urna1.EleicaoAtiva);
        }
        #endregion

        #region ValidarEncerramentoEleicao
        //Validar se a eleição está sendo encerrada corretamente
        [Fact]
        public void ValidarEncerramentoEleicao()
        {
            //Arrange
            var urna1 = new Urna();

            //Act
            urna1.IniciarEncerrarEleicao();
            urna1.IniciarEncerrarEleicao();

            //Assert
            Assert.False(urna1.EleicaoAtiva);
        }
        #endregion

        #region TestarFuncaoDeAdicionarCandidatoEBuscarUltimoNome
        //Validar se, ao cadastrar um candidato, o última candidato na lista é o mesmo que foi cadastrado
        [Fact]
        public void TestarFuncaoDeAdicionarCandidatoEBuscarUltimoNome()
        {
            //Assert
            var urna1 = new Urna();
            var nome1 = "Fábio";
            var nome2 = "Lúcio";

            //Act
            urna1.CadastrarCandidato(nome1);
            urna1.CadastrarCandidato(nome2);
            
            //Assert
            Assert.Equal("Lúcio", urna1.Candidatos.Last().Nome);
        }
        #endregion

        #region TestarVotoEmCandidadoNaoCadastrado
        //Validar o método de votação quando é informado um candidato não cadastrado
        [Fact]
        public void TestarVotoEmCandidadoNaoCadastrado()
        {
            //Assert
            var urna = new Urna();
            var nome1 = "Lúcio";

            //Act
            var votoFalho = urna.Votar(nome1);

            //Assert
            Assert.False(votoFalho);
        }
        #endregion

        #region TestarVotoEmCandidatoCadastrado
        //Validar o método de votação quando é informado um candidato cadastrado
        [Fact]
        public void TestarVotoEmCandidatoCadastrado()
        {
            //Assert
            var urna = new Urna();
            var nome1 = "Fábio";
            var nome2 = "Lúcio";

            //Act
            urna.CadastrarCandidato(nome1);
            var votoCorreto = urna.Votar(nome1);
            
            //Assert
            Assert.True(votoCorreto);
        }
        #endregion

        #region ValidarResultadoDaEleicao
        //Validar o resultado da eleição
        [Fact]
        public void ValidarResultadoDaEleicao()
        {
            //Arrange
            var urna = new Urna();
            var nome1 = "Fábio";

            //Act
            urna.CadastrarCandidato(nome1);

            for (int i = 0; i < 3; i++)
                urna.Votar(nome1);

            //Assert
            //Assert.Equal($"Candidato vencedor: Fábio! Votos: 3", urna.MostrarResultadoEleicao());
            urna.MostrarResultadoEleicao().Should().BeEquivalentTo($"Candidato vencedor: Fábio! Votos: 3");
        }
        #endregion
    }
}