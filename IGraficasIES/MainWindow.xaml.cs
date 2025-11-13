using _2HerenciaSimpleIES.Clases;
using Microsoft.Win32;
using System.IO;
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
        private const string rutaFija = "..\\..\\..\\Imagenes\\";
        private List<Persona> listaPersonas;
        private int personaIndex = 0;

        public MainWindow()
        {
            InitializeComponent();
            InitializeElements();
            InitializeImageButtons();
            gridCentral.IsEnabled = false;
            gridBotones.IsEnabled = false;
        }

        private void InitializeElements()
        {
            // Llenar ComboBox de Edades válidas
            for (int i = 22; i <= 70; i++)
            {
                comboEdad.Items.Add(i.ToString());
            }
        }

        private void InitializeImageButtons()
        {
            Image[] images = { imgPrimero, imgAnterior, imgSiguiente, imgUltimo };

            foreach (Image image in images)
            {
                image.Source = (new ImageSourceConverter()).ConvertFromString(rutaFija + image.Name + ".png") as ImageSource;
            }
        }

        private ImageSource RutaImagen(Profesor p)
        {
            string miruta = rutaFija;
            return (new ImageSourceConverter()).ConvertFromString(miruta + p.RutaFoto) as ImageSource;
        }

        private void UpdateInterface()
        {
            Persona persona = listaPersonas[personaIndex];
        }

        // Archivo
        private void Abrir_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            //Nos situamos en el directorio desde el que se ejecuta la aplicación
            openFileDialog.InitialDirectory = Environment.CurrentDirectory;
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            //Por defecto, cuando se abra, nos va a mostrar los que sean de texto
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == true) //Cuando el usuario le dé a Aceptar
            {
                try
                { //Obtengo una colección de líneas (en cada una están los datos
                  //de un profesor), luego las iré recorriendo con un foreach
                    var lineas = File.ReadLines(openFileDialog.FileName);

                }
                catch (Exception)
                {
                    MessageBox.Show(
                        "Lo sentimos, algo ha ido mal al leer el fichero\n" +
                        "Quizás el fichero no existe o no tiene el formato adecuado", 
                        "ERROR", 
                        MessageBoxButton.OK, 
                        MessageBoxImage.Error
                    );
                }
            }
                

            } 

        private void Salir_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        // Fuente
        private void Negrita_Checked(object sender, RoutedEventArgs e)
        {
            this.FontWeight = FontWeights.Bold;
        }

        private void Negrita_Unchecked(object sender, RoutedEventArgs e)
        {
            this.FontWeight = FontWeights.Regular;
        }

        private void Cursiva_Checked(object sender, RoutedEventArgs e)
        {
            this.FontStyle = FontStyles.Italic;
        }

        private void Cursiva_Unchecked(object sender, RoutedEventArgs e)
        {
            this.FontStyle = FontStyles.Normal;
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
            btnPrimero.IsEnabled = ComprobarBotonActivo((Button)sender);
            personaIndex = 0;
            UpdateInterface();
        }

        private void BtnAnterior_Click(object sender, RoutedEventArgs e)
        {
            btnAnterior.IsEnabled = ComprobarBotonActivo((Button)sender);
            personaIndex--;
            UpdateInterface();
        }

        private void BtnSiguiente_Click(object sender, RoutedEventArgs e)
        {
            btnSiguiente.IsEnabled = ComprobarBotonActivo((Button)sender);
            personaIndex++;
            UpdateInterface();
        }

        private void BtnUltimo_Click(object sender, RoutedEventArgs e)
        {
            btnUltimo.IsEnabled = ComprobarBotonActivo((Button) sender);
            personaIndex = listaPersonas.Count - 1;
            UpdateInterface();
        }

        private bool ComprobarBotonActivo(Button b)
        {
            return b.Name switch
            {
                "btnAnterior" or "btnPrimero" => personaIndex != 0,
                "btnSiguiente" or "btnUltimo" => personaIndex != (listaPersonas.Count - 1),
                _ => false
            };
        }
    }
}