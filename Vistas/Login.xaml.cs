namespace AAmaguaExamen.Vistas;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}
    private void btnIniciar_Clicked(object sender, EventArgs e)
    {
        string usuario = txtUsuario.Text;
        string contrase�a = txtContrase�a.Text;

        bool credencialesCorrectas = VerificarCredenciales(usuario, contrase�a);

        if (credencialesCorrectas)
        {
            Vistas.Registro paginaRegistros = new Vistas.Registro(usuario);
            App.Current.MainPage = paginaRegistros;
        }
        else
        {
            DisplayAlert("Error", "Usuario y/o contrase�a incorrectos", "Aceptar");
        }
    }

    private bool VerificarCredenciales(string usuario, string contrase�a)
    {
        string[,] usuariosContrase�as =
        {
                { "estudiante2024", "uisrael2024" },
                { "examen1", "parcial1" },
                { "NombreEstudiante", "2024" },
                { "1", "1" }

            };

        for (int i = 0; i < usuariosContrase�as.GetLength(0); i++)
        {
            if (usuario == usuariosContrase�as[i, 0] && contrase�a == usuariosContrase�as[i, 1])
            {
                return true;
            }
        }

        return false;
    }
    private void btnAcercaDe_Clicked(object sender, EventArgs e)
    {
        string mensaje = "Este proyecto fue ejecutado por Argenis Amagua de 8vo semestre de Sistemas";
        DisplayAlert("Acerca de", mensaje, "Aceptar");
    }
}