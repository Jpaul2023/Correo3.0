using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Correo.DataSet1TableAdapters;
using System.Data;
using System.Windows;

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
				
				DataTable auxUser = new DataTable();
				auxUser = misusuarios.GetData();


				//recorrer tabla y buscar un usuario similar al Textbox de correo y contraseña
				foreach (DataRow fila in auxUser.Rows)
				{
					
					if (Convert.ToString(fila[2]) == TextBoxemail.Text && Convert.ToString(fila[3]) == TextBoxpass.Text)
					{
                        Session["AuxiliarCorreo"] = fila[2].ToString();
                        Session["NombreUsuario"] = fila[0].ToString();
                        Response.Redirect("Recibidos.aspx");
					}
					else
                    {
						if (Convert.ToString(fila[2]) != TextBoxemail.Text)
						{
							Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message Box", "<script language = 'javascript'>alert('El correo no existe en nuestro lago')</script>");
						}

						if(Convert.ToString(fila[3]) != TextBoxpass.Text)
						{
							Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message Box", "<script language = 'javascript'>alert('La contraseña no existe ne nuestro lago')</script>");
						} 
					}
				

				}
				//***********************************
			}
			catch
			{

				Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message Box", "<script language = 'javascript'>alert('ERROR 404')</script>");
			}


		}

		protected void BTSubmit_Click(object sender, EventArgs e)
		{
			try
			{
				if (TBpassword.Text == TBpasswordconfirm.Text)
				{
					//tomando los datos del tab registrarse para generar un usuario en la base de datos 
					DataTable auxIngresoDeUsuarios = new DataTable();
					misusuarios.InsertUsuario(TBuser.Text, TBapellido.Text, TBcorreo.Text+"@lake.com", TBpassword.Text, Convert.ToDateTime(TBfecha.Text), true);
					TBuser.Text = "";
					TBapellido.Text = "";
					TBcorreo.Text = "";
					TBpassword.Text = "";
					TBpasswordconfirm.Text = "";
					TBfecha.Text = "";
				}
				else
				{
					Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message Box", "<script language = 'javascript'>alert('Por una gota puede ser diferente tu contraseña')</script>");
				}
			}
			catch
			{
				Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message Box", "<script language = 'javascript'>alert('El correo ya es parte de nuestras aguas,')</script>");
			}
		}
	}
}