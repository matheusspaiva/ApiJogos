using CatalogoJogos.Enity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoJogos.Repository
{
    public class SqlServer: IJogoRepository
    {
        private SqlConnection sqlconn;
        public SqlServer(IConfiguration configuration)
        {
            sqlconn = new SqlConnection(configuration.GetConnectionString("Default"));
        }

        public Task Atualizar(Jogo jogo)
        {
            var comando = $"update jogos set Nome='{jogo.Nome}', produtora='{jogo.Produtora}', preco={jogo.Preco} where id={jogo.Id}";
            SqlCommand com = new SqlCommand(comando, sqlconn);
            com.ExecuteNonQuery();
            return Task.FromResult(jogo);
        }

        public Task Atualizar(Guid id, double preco)
        {
            var comando = $"update jogos set  preco={preco} where id={id}";
            SqlCommand com = new SqlCommand(comando, sqlconn);
            com.ExecuteNonQuery();
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            sqlconn?.Close();
            sqlconn.Dispose();
        }

        public Task<Jogo> Inserir(Jogo jogo)
        {
            var comando = $"insert into jogos values({jogo.Id},'{jogo.Nome}','{jogo.Produtora}',{jogo.Preco});";
            SqlCommand com = new SqlCommand(comando, sqlconn);
            com.ExecuteNonQuery();
            return Task.FromResult(jogo);
        }

        public async Task<List<Jogo>> obter(int pagina, int quantidade)
        {
            var jogos = new List<Jogo>();
            var comando = $"select * from jogos order by ofset {((pagina - 1) * quantidade)} rows fetch {quantidade} rows;";
            await sqlconn.OpenAsync();
            SqlCommand com = new SqlCommand(comando, sqlconn);
            SqlDataReader read = await com.ExecuteReaderAsync();
            while (read.Read())
            {
                jogos.Add(new Jogo
                {
                    Id = (Guid)read["id"],
                    Nome = (string)read["nome"],
                    Produtora = (string)read["produroa"],
                    Preco = (double)read["Preco"]
                });
            }
            return Task.FromResult(jogos).Result;
        }

        public async Task<Jogo> obter(Guid id)
        {
            var jogos = new Jogo();
            var comando = $"select * from jogos where Id={id};";
            await sqlconn.OpenAsync();
            SqlCommand com = new SqlCommand(comando, sqlconn);
            SqlDataReader read = await com.ExecuteReaderAsync();
            
                var jogo = (new Jogo
                {
                    Id = (Guid)read["id"],
                    Nome = (string)read["nome"],
                    Produtora = (string)read["produroa"],
                    Preco = (double)read["Preco"]
                });
            return Task.FromResult(jogo).Result;
        }

        public async Task<List<Jogo>> obter(string nome, string produtora)
        {
            var jogos = new List<Jogo>();
            var comando = $"select * from jogos where Nome={nome} and produtora={produtora}";
            await sqlconn.OpenAsync();
            SqlCommand com = new SqlCommand(comando, sqlconn);
            SqlDataReader read = await com.ExecuteReaderAsync();
            while (read.Read())
            {
                jogos.Add(new Jogo { 
                Id = (Guid)read["id"],
                Nome =(string)read["nome"],
                Produtora=(string)read["produroa"],
                Preco=(double)read["Preco"]
                });
            }
            return Task.FromResult(jogos).Result;
        }

        public Task<List<Jogo>> ObterSemLambda(string nome, string produtora)
        {
            throw new NotImplementedException();
        }

        public  Task Remover(Guid id)
        {
            var comando = $"delete * from jogos where Id={id};";
            SqlCommand com = new SqlCommand(comando, sqlconn);
            com.ExecuteNonQuery();
            return Task.CompletedTask;
        }
    }
}
