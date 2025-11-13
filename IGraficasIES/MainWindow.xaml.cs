using _2HerenciaSimpleIES.Clases;
using _2HerenciaSimpleIES.Recursos;
using IGraficasIES.Recursos;
using IGraficasIES.Clases;
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
using _2HerenciaSimpleIES.Interfaces;

namespace IGraficasIES
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Persona> listaPersonas = new List<Persona>();
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
                comboEdad.Items.Add(i);
            }
        }

        private void InitializeImageButtons()
        {
            Image[] images = [imgPrimero, imgAnterior, imgSiguiente, imgUltimo];

            foreach (Image image in images)
            {
                image.Source = (new ImageSourceConverter())
                    .ConvertFromString(ClaseWPFAuxiliar.RUTA_IMG + image.Name + ".png") 
                    as ImageSource;
            }
        }

        private void UpdateInterface()
        {
            Persona persona = listaPersonas[personaIndex];

            if (persona is ProfesorFuncionario profesor)
            {
                // Campos comunes de Persona
                txtNombre.Text = profesor.Nombre;
                txtApellidos.Text = profesor.Apellidos;
                comboEdad.SelectedValue = Convert.ToInt32(profesor.Edad);
                txtEmail.Text = profesor.Email;

                // Checkboxes de tipo de profesor
                rdbCarrera.IsChecked = profesor.TipoProfesor == Profesor.TipoFuncionario.DeCarrera;
                rdbPracticas.IsChecked = profesor.TipoProfesor == Profesor.TipoFuncionario.EnPracticas;

                // Campos específicos de ProfesorFuncionario
                checkDestinoDefinitivo.IsChecked = profesor.DestinoDefinitivo;
                txtAnioIngreso.Text = profesor.YearIngreso.ToString();
                listMedico.SelectedItem = profesor.Medico == IEmpleadoPublico.TipoMedico.SeguridadSocial ?
                    ss : muface;

                // Imagen
                imgFoto.Source = ClaseWPFAuxiliar.RutaImagen(profesor);
            }

            // Actualizar estado de los botones de navegación
            btnPrimero.IsEnabled = ComprobarBotonActivo(btnPrimero);
            btnAnterior.IsEnabled = ComprobarBotonActivo(btnAnterior);
            btnSiguiente.IsEnabled = ComprobarBotonActivo(btnSiguiente);
            btnUltimo.IsEnabled = ComprobarBotonActivo(btnUltimo);
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
                    int registrosInvalidos = 0;
                    foreach (var line in lineas) 
                    {
                        //Aquí parto la línea por los ';' y obtengo un array de strings
                        string[] datos = line.Split(';');

                        // Compruebo que el número de datos es correcto
                        if (datos.Length != 10)
                        {
                            registrosInvalidos++;
                        } else
                        {
                            //Creo un nuevo profesor con los datos obtenidos
                            ProfesorFuncionario p = new
                            (
                                datos[0], // Nombre
                                datos[1], // Apellidos
                                uint.Parse(datos[2]), // Edad
                                datos[3], // Email
                                datos[4], // Materia
                                ClaseWPFAuxiliar.StringToFuncionario(datos[5]), // TipoProfesor
                                uint.Parse(datos[6]), // YearIngreso
                                datos[7] == "true", // Definitivo
                                ClaseWPFAuxiliar.StringToTipoMedico(datos[8]), // TipoMedico
                                datos[9] == "" ? "empty.jpg" : datos[9] // RutaFoto
                            );
                            //Añado el profesor a la lista
                            listaPersonas.Add(p);
                            gridBotones.IsEnabled = true;
                            UpdateInterface();
                        }
                    }

                    if (registrosInvalidos > 0)
                    {
                        throw new FormatException($"Se han encontrado {registrosInvalidos} registros con formato no válido");
                    }
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(
                        "Algunos campos del fichero tienen un tipo de dato no válido\n" +
                        ex.Message, 
                        "INFO", 
                        MessageBoxButton.OK, 
                        MessageBoxImage.Information
                    );
                }
                catch (IOException ex)
                {
                    MessageBox.Show(
                        "Lo sentimos, algo ha ido mal al leer el fichero\n" +
                        "Compruebe que el fichero existe y que su formato es correcto\n" +
                        ex.Message, 
                        "ERROR", 
                        MessageBoxButton.OK, 
                        MessageBoxImage.Error
                    );
                }
                catch (FormatException ex)
                {
                    MessageBox.Show(
                        "No se han podido leer todos los registros del fichero\n" +
                        ex.Message, 
                        "ERROR", 
                        MessageBoxButton.OK, 
                        MessageBoxImage.Warning
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
            personaIndex = 0;
            UpdateInterface();
        }

        private void BtnAnterior_Click(object sender, RoutedEventArgs e)
        {
            personaIndex--;
            UpdateInterface();
        }

        private void BtnSiguiente_Click(object sender, RoutedEventArgs e)
        {
            personaIndex++;
            UpdateInterface();
        }

        private void BtnUltimo_Click(object sender, RoutedEventArgs e)
        {
            personaIndex = listaPersonas.Count - 1;
            UpdateInterface();
        }

        private bool ComprobarBotonActivo(Button b)
        {
            return b.Name switch
            {
                // Habilitar o deshabilitar botones según la posición actual en la lista
                "btnAnterior" or "btnPrimero" => personaIndex != 0,
                "btnSiguiente" or "btnUltimo" => personaIndex != (listaPersonas.Count - 1),
                _ => false
            };
        }
    }
}