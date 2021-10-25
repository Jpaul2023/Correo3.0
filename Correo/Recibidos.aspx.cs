using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Correo.DataSet1TableAdapters;
using System.Data;
using System.Text;

namespace Correo
{
	public partial class Recibidos : System.Web.UI.Page
	{
		emailTableAdapter leerCorreo = new emailTableAdapter();
		DataTable TableCorreo = new DataTable();
		
		public string load_emails(string user)
        {
			StringBuilder sb = new StringBuilder();
			sb.Append("<table class=\"table table - dark table - hover\">");
			sb.Append("<thead>");
			sb.Append("<tr>");
			sb.Append("<th>");

			sb.Append("</th>");
			sb.Append("<tr>");
			sb.Append("</thead>");
			sb.Append("<tbody>");
			DataTable tblaux = leerCorreo.LeerRecibido(Session["AuxiliarCorreo"].ToString());

			foreach (DataRow fila in tblaux.Rows)
			{
				sb.Append("<tr>");
				sb.Append("<td>");
				sb.Append("<input type=\"check\" id\"chk"+ fila[0] + "\">");
				sb.Append("</td>");
				sb.Append("<td>");
				sb.Append("<button class=\"btn btn - primary\" type=\"button\" onclick=\"borrar_mensaje(" + fila[0] + ")\"><i class=\"fas fa - trash - alt\"></i></button>");
				sb.Append("</td>");
				sb.Append("<td>");
				sb.Append("<button class=\"btn btn - primary\" type=\"button\" onclick=\"agregar_favorito(" + fila[0] + ")\"><i class=\"far fa - star\"></i></button>");
				sb.Append("</td>");
				sb.Append("<td>");
				sb.Append("<button class=\"btn btn - primary\" type=\"button\" onclick=\"mostrar_mensaje(" + fila[0] + ")\"><i class=\"fas fa - eye\"></i></button>");
				sb.Append("</td>");
				sb.Append("<td>");
				TableCorreo.Rows.Add(fila[0]);
				sb.Append("</td>");
				sb.Append("</tr>");
			}
			sb.Append("</tbody>");
			sb.Append("</table>");
			return sb.ToString();
		}

		public string get_email(string id)
        {

			return "";
        }
		public static string datoc = "hola mundo";
		protected void Page_Load(object sender, EventArgs e)
		{
			
			DataTable tblaux = leerCorreo.LeerRecibido(Session["AuxiliarCorreo"].ToString());

			foreach (DataRow fila in tblaux.Rows)
			{
				if (Session["AuxiliarCorreo"].ToString() == fila[2].ToString())
				{
					TableCorreo.Rows.Add(fila[0]);
				}
			}
			Session["auxcod"] = TableCorreo;
		}

		protected void GridView1_DataBound(object sender, EventArgs e)
		{
			

		}

		protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			//ocultar el codigo
			if (e.Row.RowType ==DataControlRowType.Header)
            {
				e.Row.Cells[4].Visible = false;
            }
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				e.Row.Cells[4].Visible = false;
			}
			//ocultar el receptor
			if (e.Row.RowType == DataControlRowType.Header)
			{
				e.Row.Cells[6].Visible = false;
			}
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				e.Row.Cells[6].Visible = false;
			}
			//ocultar el estado
			if (e.Row.RowType == DataControlRowType.Header)
			{
				e.Row.Cells[10].Visible = false;
			}
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				e.Row.Cells[10].Visible = false;
			}

		}
		


        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
			if(e.CommandName=="BTeliminar")
            {
				

			}
			
			
        }

	
    }
}