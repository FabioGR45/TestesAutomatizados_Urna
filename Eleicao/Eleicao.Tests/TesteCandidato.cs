using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eleicao.Tests
{
    public class TesteCandidato
    {

        #region ValidarQuantidadeDeVotos
        //Validar se a quantidade de votos está correta após o cadastro do candidato e após a inserção de um novo voto
        [Theory]
        [InlineData(3)]
        [InlineData(2)]
        public void ValidarQuantidadeDeVotos(int votos)
        {

            //Arrange
            Candidato cand1 = new Candidato("Fábio");

            for (int i = 0; i < 3; i++)
                cand1.AdicionarVoto();

            //Act
            var retorno = cand1.RetornarVotos();

            //Assert
            Assert.Equal(3, retorno);
            
        }
        #endregion

        #region ValidarNomeDosCandidatos
        //Validar se o nome do candidato está correto após o cadastro do candidato
        [Fact]
        public void ValidarNomeDosCandidatos()
        {
            //Arrange
            var nome1 = "Fábio";
            var cand1 = new Candidato(nome1);

            //Act /Assert
            Assert.Equal(nome1, cand1.Nome);
        }
        #endregion
    }
}