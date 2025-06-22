using AT.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AT.Data.Configurations
{
    public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasData(
                new Endereco { Id = 1, Cidade = "São Paulo", Rua = "Rua das Palmeiras, 123" },
                new Endereco { Id = 2, Cidade = "Rio de Janeiro", Rua = "Avenida Brasil, 456" },
                new Endereco { Id = 3, Cidade = "Curitiba", Rua = "Rua XV de Novembro, 789" },
                new Endereco { Id = 4, Cidade = "Porto Alegre", Rua = "Rua Sete de Setembro, 101" },
                new Endereco { Id = 5, Cidade = "Belo Horizonte", Rua = "Avenida Afonso Pena, 202" }
            );
        }
    }
}
