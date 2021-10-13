using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Correo.DataSet1TableAdapters;
using System.Data;

namespace Correo
{
	public partial class Default : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			
		}
		PersonaTableAdapter misusuarios = new PersonaTableAdapter();

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void ButtonSignIn_Click(object sender, EventArgs e)
        {
			try
            {
				//crear variables y datatable
				string User, pass;
				string auxtbemail = TextBoxemail.Text, auxtbpass = TextBoxpass.Text;
				DataTable auxUser = new DataTable();
				auxUser = misusuarios.BuscarUsuario(auxtbemail);

				//recorrer tabla y buscar un usuario similar al Textbox de correo y contraseña
				foreach (DataRow fila in auxUser.Rows)
				{
					User = fila[3].ToString();
					pass = fila[4].ToString();
					if (User == auxtbemail && pass == auxtbpass)
					{
						Session["AuxiliarCorreo"] = fila[3].ToString();
						Session["NombreUsuario"] = fila[1].ToString();
						Response.Redirect("Recibidos.aspx");
					}
				}
				//***********************************
			}
            catch 
			{
				TextBoxemail.Text = "Usuario no encontrado";
			}
			

		}
	}
}