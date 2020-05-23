using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Copa_Do_Mundo_MVC.Models
{
    public class JogadorRepository : IDisposable
    {
        private bool disposed = false;
        private CopaDoMundoContext context;

        public JogadorRepository(CopaDoMundoContext context)
        {
            this.context = context;
        }

        public Jogador Busca(int id)
        {
            return context.Jogadores.Find(id);
        }

        public void Adiciona(Jogador jogador)
        {
            context.Jogadores.Add(jogador);
        }
        public List<Jogador> Jogadores
        {
            get
            {
                return context.Jogadores.ToList();
            }
        }
        public void Salva()
        {
            context.SaveChanges();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Remove(int id)
        {
            Jogador jogador = context.Jogadores.Find(id);
            context.Jogadores.Remove(jogador);
        }

    }
}
