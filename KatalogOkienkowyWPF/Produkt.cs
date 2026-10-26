using System;
using System.Collections.Generic;
using System.Text;

namespace KatalogOkienkowyWPF
{
    internal class Produkt
    {
        private string _nazwa;
        public string Nazwa
        {
            get { return _nazwa; }
            set
            {
                if (value == String.Empty)
                {
                    _nazwa = "Brak nazwy";
                    throw new ArgumentException("Nazwa nie może być pusta.");
                }
                else
                {
                    _nazwa = value;
                }
            }
        }

        public int MinimalnyStan = 1;
        // to jest prywatne pole które przechowuje wartość ceny produktu
        private double _cena;
        //to jest publiczna właściwość (pole) która pozwala na KONTROLOWANY dostęp do prywatnego pola _cena
        public double Cena
        {
            get { return _cena; } //jeśli ktoś chce przeczytać cenę produktu, to zwracamy wartość prywatnego pola _cena - nie ma problemu
            set //jeśli ktoś chce ustawić cenę produktu, to sprawdzamy czy wartość jest poprawna
            {
                if (value < 0) //jeśli ktoś próbuje ustawić cenę na wartość ujemną, to wyrzucamy wyjątek
                {
                    _cena = 0;
                    throw new ArgumentException("Cena nie może być ujemna.");
                }
                else //w innym przypadku ustawiamy wartość prywatnego pola _cena na wartość podaną przez użytkownika
                {
                    _cena = value;
                }
            }
        }

        public string Kategoria;
        public int Ilosc;

        // właściwość wyliczana - nie przechowujemy tego tylko liczymy na żywo
        public double WartoscMagazynu
        {
            get { return _cena * Ilosc; }
        }

        public Produkt(string nazwa, double cena, string kategoria, int ilosc)
        {
            Nazwa = nazwa;
            Cena = cena;
            Kategoria = kategoria;
            Ilosc = ilosc;
        }

        public Produkt(string nazwa)
        {
            Nazwa = nazwa;
            Cena = 0;
            Kategoria = "Brak kategorii";
            Ilosc = 0;
        }

        public void WypiszProdukt()
        {
            Console.WriteLine($"Nazwa: {Nazwa,-25}| Cena: {Cena,10:f2} zł | $Kategoria: {Kategoria} | Ilość: {Ilosc,5}");
        }

        public string InformacjeOProdukcie()
        {
            return $"Nazwa: {Nazwa,-25}| Cena: {Cena,10:f2} zł | $Kategoria: {Kategoria} | Ilość: {Ilosc,5}";
        }

        public static double ObliczWartoscMagazynu(Produkt[] produkty)
        {
            double suma = 0;
            foreach (Produkt produkt in produkty)
            {
                suma += produkt.WartoscMagazynu;
            }
            return suma;
        }
        public static double ObliczWartoscMagazynu(List<Produkt> produkty)
        {
            return produkty.Sum(p => p.WartoscMagazynu); //na koniec zwracamy sumę wartości magazynu
        }

        public bool CzyMoznaZamowic()
        {
            return Ilosc > MinimalnyStan;
        }

        public void Sprzedaj()
        {
            if (CzyMoznaZamowic())
            {
                Ilosc--;
                Console.WriteLine($"Sprzedano produkt: {Nazwa}. Pozostało na stanie: {Ilosc}");
            }
            else
            {
                Console.WriteLine($"Nie można sprzedać produktu: {Nazwa}. Brak wystarczającej ilości na stanie.");
            }
        }

        public static Produkt ZnajdzPoNazwie(Produkt[] produkty, string nazwa)
        {
            foreach (var produkt in produkty)
            {
                if (produkt.Nazwa == nazwa)
                {
                    return produkt;
                }
            }
            return null;
        }

        public static Produkt ZnajdzPoNazwie(List<Produkt> produkty, string nazwa)
        {
            return produkty.FirstOrDefault(p => p.Nazwa.Contains(nazwa, StringComparison.OrdinalIgnoreCase)); //zwraca pierwszy produkt, którego nazwa zawiera podany ciąg znaków (ignorując wielkość liter)
        }
    }
}