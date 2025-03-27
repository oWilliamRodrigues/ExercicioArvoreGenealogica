using System;
using System.Collections.Generic;

namespace ArvoreGenealogica.Models
{
    public class Pessoa
    {
        public string Nome { get; set; }
        public Pessoa Conjuge { get; set; }
        public List<Pessoa> Filhos { get; set; } = new List<Pessoa>();

        public Pessoa(string nome)
        {
            Nome = nome;
        }

        public Pessoa(string nome, Pessoa paiOuMae)
        {
            Nome = nome;
            paiOuMae.AdicionarFilho(this);
        }

        public void AdicionarFilho(Pessoa filho)
        {
            Filhos.Add(filho);
        }

        public void Conjugue(Pessoa conjuge)
        {
            if (this.Conjuge == null)
            {
                this.Conjuge = conjuge;
                conjuge.Conjuge = this;
            }
        }

        public void ImprimeArvore(int nivel = 0)
        {
            string indentacao = new string(' ', nivel * 4);
            string status = Conjuge != null ? $"é casado(a) com {Conjuge.Nome}" : "está solteiro(a)";
            string filhosText = Filhos.Count > 0 ? " filhos:" : "";

            Console.WriteLine($"{indentacao}-->{Nome} {status}{filhosText}");

            foreach (var filho in Filhos)
            {
                filho.ImprimeArvore(nivel + 1);
            }
        }
    }
}
