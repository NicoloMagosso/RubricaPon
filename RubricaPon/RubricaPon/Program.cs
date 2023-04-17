using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubricaPon
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }
    }
    internal class Rubrica
    {
        //metodi di Rubrica ......da completare ......

        public override string ToString()
        {
            return "0";
        }

    }


    //classe privata Pair: non modificare!!
     internal class Pair
    {
        string _name;
        int _phone;
        public Pair(string aName, int aPhone)
        {
            _name = aName;
            _phone = aPhone;
        }
        public string Name
        { get { return _name; } }
        public int Phone
        { get { return _phone; } }
        /*
            Restituisce una stringa contenente
            - la nome, "name"
            - un carattere di separazione ( : )
            - il numero telefonico, "phone"
        */
        public override string ToString()
        {
            return string.Format(_name + " : " + _phone);

        }
       
       
    }
}


internal interface Dictionary
{
    /*
        verifica se il dizionario contiene almeno una coppia chiave/valore
    */
    bool isEmpty();

    /*
        svuota il dizionario
    */
    void makeEmpty();

    /*
     Inserisce un elemento nel dizionario. L'inserimento va sempre a buon fine.
     Se la chiave non esiste la coppia key/value viene aggiunta al dizionario; 
     se la chiave esiste gia' il valore ad essa associato viene sovrascritto 
     con il nuovo valore; se key e` null viene lanciata IllegalArgumentException
    */
    void insert(Comparable key, Object value);

    /*
     Rimuove dal dizionario l'elemento specificato dalla chiave key
     Se la chiave non esiste viene lanciata DictionaryItemNotFoundException 
    */
    void remove( key);

    /*
     Cerca nel dizionario l'elemento specificato dalla chiave key
     La ricerca per chiave restituisce soltanto il valore ad essa associato
     Se la chiave non esiste viene lanciata DictionaryItemNotFoundException
    */
    Object find(Comparable key);
}

class DictionaryItemNotFoundException extends RuntimeException { }

}
