using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projLivrosLista2
{
    public class Livros
    {
        private List<Livro> acervo;

        public List<Livro> Acervo { get { return acervo; }  }


        public Livros()
        {
            acervo = new List<Livro>();
        }


        public void adicionar(Livro l)
        {
            this.Acervo.Add(l);
        }

        public Livro pesquisar(Livro l)
        {
            Livro livroAchado;
            livroAchado= new Livro();
            foreach (Livro li in this.acervo)
                if (li.Isbnt.Equals(l.Isbnt))
                    livroAchado = li;
            return livroAchado;
            
        }
    }
}
