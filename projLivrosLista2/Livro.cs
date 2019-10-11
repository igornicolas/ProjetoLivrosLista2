using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projLivrosLista2
{
    public class Livro
    {
        private int isbnt;
        private string titulo, autor, editora;
        private List<Exemplar> exemplares;

        public Livro(int i, string t, string a, string e)
        {
            Isbnt = i;
            Titulo = t;
            Autor = a;
            editora = e;
            exemplares = new List<Exemplar>();
        }

        public Livro(int i) : this(i, "", "", "")
        { }
        public Livro() : this(0,"", "", "")
        { }



        public int Isbnt
        {
            get
            {
                return isbnt;
            }
            set
            {
                isbnt = value;
            }
        }

        public string Titulo { get => titulo; set => titulo = value; }
        public string Autor { get => autor; set => autor = value; }
        public string Editora { get => editora; set => editora = value; }
        public List<Exemplar> Exemplares { get => exemplares; set => exemplares = value; }



        public void adicionarExemplar(Exemplar e)
        {
            this.Exemplares.Add(e);
        }

        public int qtdeExemplares()
        {

            return this.Exemplares.Count();
        }

        public int qtdeDisponiveis()
        {
            int qtdeReal = 0;
            foreach (Exemplar e in Exemplares)
            {
                
                if (e.disponivel())
                {
                    qtdeReal++;
                }
            }
            
            return qtdeReal;
        }

        public double percDisponibilidade()
        {
             
            double percReal = qtdeDisponiveis() /(double) qtdeExemplares();
            return percReal;
        }

        public int qtdeEmprestimos()
        {
            int qtdeReal = 0;
            foreach (Exemplar e in Exemplares)
            {
                qtdeReal+= e.Emprestimos.Count();        
            }

                return qtdeReal;
        }
    }
}
