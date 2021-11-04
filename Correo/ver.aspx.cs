using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Correo.DataSet1TableAdapters;


namespace Correo
{
	public partial class ver : System.Web.UI.Page
	{
		emailTableAdapter Temail = new emailTableAdapter();
		DataTable Tresponder = new DataTable();
		emailTableAdapter EnviarCorreo = new emailTableAdapter();
		protected void Page_Load(object sender, EventArgs e)
		{
			TextBoxasunto.Text = Session["asunto"].ToString();
			TextBoxcontenido.Text = Session["mensaje"].ToString();
			TextBoxcorreo.Text = Session["emisor"].ToString();
		}

        protected void TextBoxcorreo_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Buttonsubmit_Click(object sender, EventArgs e)
        {
			EnviarCorreo.EnviarCorreo(Session["AuxiliarCorreo"].ToString(), Session["emisor"].ToString(), Session["asunto"].ToString(), TextBoxredactar.Text, DateTime.Today, "RecLeido");
			Response.Redirect("Recibidos.aspx");
		}
    }
}