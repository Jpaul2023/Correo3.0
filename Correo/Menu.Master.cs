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
	public partial class Menu : System.Web.UI.MasterPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if  (Session["NombreUsuario"] != null)


			 {
				Label1.Text = Session["NombreUsuario"].ToString();

			}
		}
		//Generadno table adapters para la consulta y manejo de datos del envio del correo.
		emailTableAdapter EnviarCorreo = new emailTableAdapter();
		DataTable MisEnviados = new DataTable();
		PersonaTableAdapter Mispersonas = new PersonaTableAdapter();
		DataTable PersonasAux = new DataTable();
		//#####################################################


        protected void ButtonEnviar_Click(object sender, EventArgs e)
        {

			if (Session["NombreUsuario"] != null)
			{
				EnviarCorreo.Enviar(Session["AuxiliarCorreo"].ToString(), TextBoxdestinatario.Text, TextBoxasunto.Text, TextBoxmensaje.Text, DateTime.Today, false); ;
				TextBoxdestinatario.Text = "";
				TextBoxasunto.Text = "";
				TextBoxmensaje.Text = "";
			
			
			}
		}



        
    }
}