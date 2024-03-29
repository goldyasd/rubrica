using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    enum Type
    {
        Email,
        Telefono,
        Nome,
        Cognome,
        Web,
        Instagram,
        Telegram,
        Facebook
    }
    internal class Persona
    {
        private int idPersona;
        private Type tipo;
        private string valore;

        public Persona(int idPersona, Type tipo, string valore)
        {
            this.idPersona = idPersona;
            this.tipo = tipo;
            this.valore = valore;
        }

        public int IdPersona
        {
            get { return idPersona; }
            set { idPersona = value; }
        }

        public Type Tipo
        {
            get { return tipo; }
        }

        public string Valore
        {
            get { return valore; }
        }
    }

    internal class Persone : List<Persona> {
        public Persone() { }
        public Persone(string nomefile)
        {
            StreamReader sr = new StreamReader(nomefile);
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string s = sr.ReadLine();
                Add(new Persona(Convert.ToInt32(s.Split(';')[0]), Enum.Parse<Type>(s.Split(';')[1]), s.Split(';')[2]));
            }
            sr.Close();
        }
    }
}
