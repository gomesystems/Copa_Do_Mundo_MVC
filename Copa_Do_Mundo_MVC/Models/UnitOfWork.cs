using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/*
 O único propósito de criar uma classe UnitOfWork é ter certeza que quando temos múltiplos repositórios 
eles compartilham o mesmo DbContext. Para isto, devemos apenas criar um método Salvaeumapropriedadeparacadarepositório.

 */
namespace Copa_Do_Mundo_MVC.Models
{
    public class UnitOfWork : IDisposable
    {   //injeção
        private bool disposed = false;
        private CopaDoMundoContext context = new CopaDoMundoContext();
        private SelecaoRepository selecaoRepository;
        private JogadorRepository jogadorRepository;

        public JogadorRepository JogadorRepository
        {
            get
            {
                if (jogadorRepository == null)
                {
                    jogadorRepository = new JogadorRepository(context);
                }
                return jogadorRepository;
            }
        }
        public SelecaoRepository SelecaoRepository
        {
            get
            {
                if (selecaoRepository == null)
                {
                    selecaoRepository = new SelecaoRepository(context);
                }
                return selecaoRepository;
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
    }
}