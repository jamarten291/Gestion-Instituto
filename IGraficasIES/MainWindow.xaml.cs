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

namespace IGraficasIES
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeElements();
        }

        private void InitializeElements()
        {
            // Llenar ComboBox de Edades válidas
            for (int i = 22; i <= 70; i++)
            {
                comboEdad.Items.Add(i.ToString());
            }
        }

        private void UpdateInterface()
        {

        }

        // Archivo
        private void Abrir_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Salir_Click(object sender, RoutedEventArgs e)
        {
        }

        // Fuente
        private void Negrita_Checked(object sender, RoutedEventArgs e)
        {
        }

        private void Negrita_Unchecked(object sender, RoutedEventArgs e)
        {
        }

        private void Cursiva_Checked(object sender, RoutedEventArgs e)
        {
        }

        private void Cursiva_Unchecked(object sender, RoutedEventArgs e)
        {
        }

        // Filtros
        private void Filtro1_Checked(object sender, RoutedEventArgs e)
        {
        }

        private void Filtro1_Unchecked(object sender, RoutedEventArgs e)
        {
        }

        private void Filtro2_Checked(object sender, RoutedEventArgs e)
        {
        }

        private void Filtro2_Unchecked(object sender, RoutedEventArgs e)
        {
        }

        private void Filtro3_Checked(object sender, RoutedEventArgs e)
        {
        }

        private void Filtro3_Unchecked(object sender, RoutedEventArgs e)
        {
        }

        private void Filtro4_Checked(object sender, RoutedEventArgs e)
        {
        }

        private void Filtro4_Unchecked(object sender, RoutedEventArgs e)
        {
        }

        // Agrupación
        private void Agrup1_Checked(object sender, RoutedEventArgs e)
        {
        }

        private void Agrup1_Unchecked(object sender, RoutedEventArgs e)
        {
        }

        private void Agrup2_Checked(object sender, RoutedEventArgs e)
        {
        }

        private void Agrup2_Unchecked(object sender, RoutedEventArgs e)
        {
        }

        private void Agrup3_Checked(object sender, RoutedEventArgs e)
        {
        }

        private void Agrup3_Unchecked(object sender, RoutedEventArgs e)
        {
        }

        private void Agrup4_Checked(object sender, RoutedEventArgs e)
        {
        }

        private void Agrup4_Unchecked(object sender, RoutedEventArgs e)
        {
        }

        private void Definitivo_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Definitivo_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void BtnPrimero_Click(object sender, RoutedEventArgs e)
        {
            UpdateInterface();
        }

        private void BtnAnterior_Click(object sender, RoutedEventArgs e)
        {
            UpdateInterface();
        }

        private void BtnSiguiente_Click(object sender, RoutedEventArgs e)
        {
            UpdateInterface();
        }

        private void BtnUltimo_Click(object sender, RoutedEventArgs e)
        {
            UpdateInterface();
        }
    }
}