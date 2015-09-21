using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeKata.Exercicios.Exercicio18
{
    public class Dependencies
    {
        private Dictionary<string, string[]> Itens { get; set; }

        private List<string> dependenciesItem { get; set; }

        public Dependencies()
        {
            Itens = new Dictionary<string, string[]>();
            dependenciesItem = new List<string>();
        }

        public void add_direct(string name, string[] dependencies)
        {
            Itens.Add(name, dependencies);
        }

        public string[] dependencies_for(string name)
        {
            dependeciesByName(name);
            var ret = dependenciesItem.OrderBy(x => x).ToArray();
            dependenciesItem = new List<string>();
            return ret;
        }

        private void dependeciesByName(string name)
        {
            if (Itens.ContainsKey(name))
            {
                string[] values = Itens[name];

                foreach (var value in values)
                {
                    dependenciesToAdd(value);
                    dependeciesByName(value);
                }
            }
            else
            {
                dependenciesToAdd(name);
            }
        }

        private void dependenciesToAdd (string name)
        {
            if (!dependenciesItem.Contains(name))
            {
                dependenciesItem.Add(name);
            }
        }
    }
}
