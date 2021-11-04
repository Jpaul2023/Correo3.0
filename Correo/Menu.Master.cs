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
		
		//#####################################################


        protected void ButtonEnviar_Click(object sender, EventArgs e)
        {

			
		
				EnviarCorreo.EnviarCorreo(Session["AuxiliarCorreo"].ToString(), TextBoxdestinatario.Text, TextBoxasunto.Text, TextBoxmensaje.Text, DateTime.Today, "RecLeido"); ;
				TextBoxdestinatario.Text = "";
				TextBoxasunto.Text = "";
				TextBoxmensaje.Text = "";
			
			
		
		}



        
    }
}