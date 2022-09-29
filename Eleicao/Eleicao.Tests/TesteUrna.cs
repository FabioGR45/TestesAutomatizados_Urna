using FluentAssertions;

namespace Eleicao.Tests
{
    public class TesteUrna
    {
        #region ValidarFuncionamentoConstrutor
        //Validar se o construtor est� inserindo os dados iniciais corretamente
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
        //Validar se a elei��o est� sendo iniciada corretamente
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
        //Validar se a elei��o est� sendo encerrada corretamente
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
        //Validar se, ao cadastrar um candidato, o �ltima candidato na lista � o mesmo que foi cadastrado
        [Fact]
        public void TestarFuncaoDeAdicionarCandidatoEBuscarUltimoNome()
        {
            //Assert
            var urna1 = new Urna();
            var nome1 = "F�bio";
            var nome2 = "L�cio";

            //Act
            urna1.CadastrarCandidato(nome1);
            urna1.CadastrarCandidato(nome2);
            
            //Assert
            Assert.Equal("L�cio", urna1.Candidatos.Last().Nome);
        }
        #endregion

        #region TestarVotoEmCandidadoNaoCadastrado
        //Validar o m�todo de vota��o quando � informado um candidato n�o cadastrado
        [Fact]
        public void TestarVotoEmCandidadoNaoCadastrado()
        {
            //Assert
            var urna = new Urna();
            var nome1 = "L�cio";

            //Act
            var votoFalho = urna.Votar(nome1);

            //Assert
            Assert.False(votoFalho);
        }
        #endregion

        #region TestarVotoEmCandidatoCadastrado
        //Validar o m�todo de vota��o quando � informado um candidato cadastrado
        [Fact]
        public void TestarVotoEmCandidatoCadastrado()
        {
            //Assert
            var urna = new Urna();
            var nome1 = "F�bio";
            var nome2 = "L�cio";

            //Act
            urna.CadastrarCandidato(nome1);
            var votoCorreto = urna.Votar(nome1);
            
            //Assert
            Assert.True(votoCorreto);
        }
        #endregion

        #region ValidarResultadoDaEleicao
        //Validar o resultado da elei��o
        [Fact]
        public void ValidarResultadoDaEleicao()
        {
            //Arrange
            var urna = new Urna();
            var nome1 = "F�bio";

            //Act
            urna.CadastrarCandidato(nome1);

            for (int i = 0; i < 3; i++)
                urna.Votar(nome1);

            //Assert
            //Assert.Equal($"Candidato vencedor: F�bio! Votos: 3", urna.MostrarResultadoEleicao());
            urna.MostrarResultadoEleicao().Should().BeEquivalentTo($"Candidato vencedor: F�bio! Votos: 3");
        }
        #endregion
    }
}