namespace AAmaguaExamen.Vistas;

public partial class Registro : ContentPage
{
        private const double costoCurso = 1500;
        private const int numCuotas = 4;
        private const double porcentajeAdicional = 0.04;
    public Registro(string usuario)
	{
		InitializeComponent();
        lbUsuario.Text =   usuario+ "Conectado ";

        List<string> paises = new List<string> { "Ecuador", "Colombia", "Perú" };
        pickerPais.ItemsSource = paises;

        // Agregar elementos al Picker de ciudades
        List<string> ciudades = new List<string> { "Quito", "Bogota", "Lima" };
        pickerCiudad.ItemsSource = ciudades;
    }
    private void btnCalcularPagoMensual_Clicked(object sender, EventArgs e)
    {
        if (double.TryParse(entryMontoInicial.Text, out double montoInicial))
        {
            double montoRestante = costoCurso - montoInicial;
            double montoCuota = (montoRestante / numCuotas) * (1 + porcentajeAdicional);
            entryPagoMensual.Text = montoCuota.ToString("0.00");
        }
        else
        {
            DisplayAlert("Error", "Por favor ingrese o seleccione datos válidos", "Aceptar");
        }
    }

    private void btnVerResumen_Clicked(object sender, EventArgs e)
    {
        string fecha = datePickerFecha.Date.ToString("dd/MM/yyyy");
        string pais = pickerPais.SelectedItem?.ToString();
        string ciudad = pickerCiudad.SelectedItem?.ToString();
        string nombre = entryNombre.Text;
        string apellido = entryApellido.Text;
        int edad;

        if (string.IsNullOrEmpty(fecha) || string.IsNullOrEmpty(pais) || string.IsNullOrEmpty(ciudad) ||
            string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) || !int.TryParse(entryEdad.Text, out edad))
        {
            DisplayAlert("Error", "Por favor ingrese o seleccione datos válidos", "Aceptar");
        }
        else
        {
            if (double.TryParse(entryMontoInicial.Text, out double montoInicial))
            {
                double montoRestante = costoCurso - montoInicial;
                double montoMensual = (montoRestante / numCuotas) * (1 + porcentajeAdicional);
                double total = montoInicial + (montoMensual * numCuotas);

                string resumen = $"Nombre: {nombre}\n" +
                                 $"Apellido: {apellido}\n" +
                                 $"Edad: {edad}\n" +
                                 $"Fecha: {fecha}\n" +
                                 $"Ciudad: {ciudad}\n" +
                                 $"País: {pais}\n" +
                                 $"Monto Inicial: {montoInicial.ToString("0.00")}\n" +
                                 $"Monto Mensual: {montoMensual.ToString("0.00")}\n" +
                                 $"Total: {total.ToString("0.00")}\n";

                DisplayAlert("Resumen", resumen, "OK");
            }
            else
            {
                DisplayAlert("Error", "Por favor ingrese o seleccione datos válidos", "Aceptar");
            }
        }
    }
    private void btnCerrarSesion_Clicked(object sender, EventArgs e)
    {
        
        Vistas.Login paginaLogin = new Vistas.Login();        
        Application.Current.MainPage = new NavigationPage(paginaLogin);
    }
}


