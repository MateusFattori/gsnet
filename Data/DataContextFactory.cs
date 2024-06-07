using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace gsnet.Data
{
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            // Verifica se está no modo design-time
            if (args != null && args.Length > 0 && args[0].Equals("designTimeDbContext", StringComparison.OrdinalIgnoreCase))
            {
                return null;
            }

            // Configuração do provedor do banco de dados
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();

            try
            {
                // Carrega as configurações do arquivo appsettings.json
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                // Obtém a string de conexão do arquivo de configuração
                var connectionString = configuration.GetConnectionString("OracleConnection");

                // Configura o provedor Oracle
                optionsBuilder.UseOracle(connectionString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao carregar configurações: {ex.Message}");
                throw;
            }

            // Retorna uma nova instância do contexto de banco de dados com as opções configuradas
            return new DataContext(optionsBuilder.Options);
        }
    }
}
