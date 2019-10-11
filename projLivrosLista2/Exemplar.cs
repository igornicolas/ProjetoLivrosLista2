using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projLivrosLista2
{
    public class Exemplar
    {
        private int tombo;
        private List<Emprestimo> emprestimos;
        public int Tombo { get => tombo; set => tombo = value; }
        public List<Emprestimo> Emprestimos { get => emprestimos; set => emprestimos = value; }

        public Exemplar(int t)
        {
            Tombo = t;
            emprestimos = new List<Emprestimo>();
        }

        public Exemplar()
        {
            emprestimos = new List<Emprestimo>();
        }

        public bool disponivel()
        {
            if (this.Emprestimos.Count()==0){
                return true;
            }
            else
            {
                if (this.Emprestimos.Last().DtDevolucao != DateTime.MinValue)
                {


                    return true;
                }
                else
                {

                    return false;
                }
            }

        }

        public bool emprestar()
        {
            if (disponivel() == true)
            {
                this.Emprestimos.Add(new Emprestimo(DateTime.Now));
                return true;
            }
            else
            {
                
                return false;
            }
        }

        public bool devolver()
        {
            if (this.Emprestimos.Last().DtDevolucao == DateTime.MinValue)
            {
                this.Emprestimos.Last().DtDevolucao = DateTime.Now;
                return true;
            }
            else
            {
                return false;
            }
            
        }


        public int qtdeEmprestimos()
        {
            return this.Emprestimos.Count();
        }
    }
}
