using System;
using System.Collections.Generic;
using System.Text;

namespace ЛР2Console.Model
{
    class classprodukte : interfaceprodukte
    {
        string _kategorie, _name;
        int _preis, _nutzbarkeit;
        public string Kategorie;
        public string Name;
        public int Preis;
        public int Nutzbarkeit;

        public classprodukte()
        {
            _kategorie = Kategorie;
            _name = Name;
            _preis = Preis;
            _nutzbarkeit = Nutzbarkeit;
        }
        public string kategorie { get => _kategorie; set => _kategorie = value; }
        public string name { get => _name; set => _name = value; }
        public int preis { get => _preis; set => _preis = value; }
        public int nutzbarkeit { get => _nutzbarkeit; set => _nutzbarkeit = value; }
    }
}
