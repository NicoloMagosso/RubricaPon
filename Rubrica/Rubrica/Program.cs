using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubricaPon
{
    internal class RubricaTester
    {


        static void Main(string[] args)
        {
            Console.WriteLine("Inserisci il nome e la destinazione (formato:  nome:destinazione):");
            string[] tmp;
            string file1 = Console.ReadLine();

            Rubrica rub1 = new Rubrica();
            Rubrica rub2 = new Rubrica();



            Console.Clear();
            Console.WriteLine("Inserisci il nome e la destinazione (formato:  nome:destinazione):");
            string file2 = Console.ReadLine();
            Console.Clear();

            //l'utente dovrà inserire le informazioni richieste finchè quest'ultime non rispetteranno il formato stabilito


            tmp = file1.Split(':');
            string nome = tmp[0];
            string destinazione = tmp[1];
            //aggiungo le informazioni nella raccolta
            rub1.insert(nome, destinazione);
            tmp = file2.Split(':');
            nome = tmp[0];
            destinazione = tmp[1];
            //aggiungo le informazioni nella raccolta
            rub2.insert(nome, destinazione);
            
            
                string nomeConfronto; 
                Console.WriteLine("Inserisci un nome");
                nomeConfronto = Console.ReadLine();
            string numeroConfronto;
            Console.WriteLine("Inserisci un nome");
            numeroConfronto = Console.ReadLine();

            foreach (var item in tmp[0])
                {
                    Rubrica c = (Rubrica)item.Value;
                rub1.insert(nomeConfronto, numeroConfronto);
                }
                

            
            

        }
    }  
    
     class Rubrica : IDictionary , IDimensione
    {
        //metodi di Rubrica ......da completare ......
       

        Dictionary<IComparable, object> rubrica = new Dictionary<IComparable, object>();

       

       
        public override string ToString()
        {
            //stampo a video i clienti presenti nel dizionario nel formato 'codice:nome:destinazione'
            string utenti = "";
            foreach (var item in rubrica)
            {
                Pair c = (Pair)item.Value;
                utenti += $"{item.Key}:{c.Name}:{c.Phone}\n";
            }
            return utenti;
        }

        //implemetazione dell'interfaccia IDictionary
        public void insert(IComparable key, object attribute)
        {
            bool sameCode = false;
            string tmp = (string)attribute;
            string [] dati = tmp.Split(':');

            //creo un oggetto Client a partire dalle informazioni fornite dall'utente
            Pair utente = new Pair(dati[0], int.Parse( dati[1]));
            //creo un oggetto Coppia per poter poi utilizzare il metodo CompareTo
            
            if(key == null)
            {
                throw new ArgumentException();
            }
            //controllo se esiste già un cliente con lo stesso codice
            foreach (var item in rubrica)
            {
                if (key.CompareTo(item.Key) == 0)
                    sameCode = true;
            }
            //se non esiste aggiungo in coda il nuovo cliente
            if (!sameCode)
                rubrica.Add(key, utente);
            else
                rubrica[key] = utente; //se esiste, lo sostituisco a quello individuato precedentemente nel dizionario
        }

        public object find(IComparable key)
        {
            try
            {
                //cerco il cliente in base al codice fornito dall'utente
                Pair c = (Pair)rubrica[key];
                return $"{c.Name} : {c.Phone}";
            }
            catch (KeyNotFoundException)
            {
                //nel caso in cui non venga trovato il cliente genero un'eccezione
                throw new Exception("Utente non trovato");
            }
        }
        public object remove(IComparable key)
        {
            try
            {
                //rimuovo il cliente in base al codice fornito dall'utente
                Pair c = (Pair)rubrica[key];
                rubrica.Remove(key);
                return $"{c.Name} : {c.Phone}";
            }
            catch (KeyNotFoundException)
            {
                //nel caso in cui il cliente non sia presente nel dizionario genero un'eccezione
                throw new Exception("Utente non presente nella raccolta");
            }
        }
        //fine implemetazione dell'interfaccia IDictionary

        //implemetazione dell'interfaccia IContainer
        public bool isEmpty()
        {
            //controllo se il dizionario è vuoto verificando se il numero di elementi presenti è uguale a 0
            if (rubrica.Count == 0)
                return true;
            return false;
        }

        public void makeEmpty()
        {
            //cancello il contenuto del dizionario
            rubrica.Clear();
        }

        public int size()
        {
            //ritorno il numero di elementi presenti nel dizionario
            return rubrica.Count;
        }
        //fine implemetazione dell'interfaccia IContainer
      
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

}


    
   
