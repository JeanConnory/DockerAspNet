using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace mvc1.Models
{
    public static class PopulaDb
    {
        public static void IncluiDadosDB(IApplicationBuilder app)
        {
            IncluiDadosDB(app.ApplicationServices.GetRequiredService<AppDbContext>());
        }

        public static void IncluiDadosDB(AppDbContext context)
        {
            System.Console.WriteLine("Aplicando Migrations...");
            context.Database.Migrate();
            if(!context.Produtos.Any())
            {
                System.Console.WriteLine("Criando dados...");
                context.Produtos.AddRange(
                    new Produto("Luvas de goleiro", "Futebol", 25),
                    new Produto("Bola de basquete", "Basquete", 48.95m),
                    new Produto("Bola de futebol", "Futebol", 19.50m),
                    new Produto("Meias grandes", "Futebol", 50),
                    new Produto("Cesta para quadra", "Basquete", 29.95m)
                );
                context.SaveChanges();
            }
            else
            {
                System.Console.WriteLine("Dados já existe!");
            }
        }
    }
}