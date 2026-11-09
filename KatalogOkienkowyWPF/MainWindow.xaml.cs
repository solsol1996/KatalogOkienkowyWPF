using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KatalogOkienkowyWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List < Produkt > produkty = new List<Produkt>
            {
                new Produkt("Procesor Intel Core i9", 1500.01, "Procesory", 10),
                new Produkt("Karta Graficzna RTX 3080", 4000.00, "Karty Graficzne", 5),
                new Produkt("Płyta Główna ASUS ROG Strix Z590-E", 1200.00, "Płyty Główne", 8),
                new Produkt("Pamięć DDR4 32GB", 400.00, "Pamięci", 20),
                new Produkt("Dysk SSD Samsung 980 PRO", 500.00, "Dyski SSD", 15)

            };
            EtykietaLiczbaProduktow.Text = produkty.Count.ToString();
            EtykietaWartoscMagazynu.Text = $"Wartość magazynu: {Produkt.ObliczWartoscMagazynu(produkty)} zł";

            TextBlock dopisek = new TextBlock();
            dopisek.Text = "To zostało dodane bezpośrednie w kodzie C#:";
            dopisek.FontSize = 14;
            GlownyStackPanel.Children.Add(dopisek);
        }
    }
}