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
    public partial class enviados : System.Web.UI.Page
    {
		emailTableAdapter leerCorreo = new emailTableAdapter();
		DataTable TableCorreo = new DataTable();
		DataTable filtrXestado = new DataTable();

		protected void Page_Load(object sender, EventArgs e)
		{
			TableCorreo = leerCorreo.filtrarporemisor(Session["AuxiliarCorreo"].ToString());


			foreach (DataRow fila in TableCorreo.Rows)
			{

				GridView1.DataSource = TableCorreo;
				GridView1.DataBind();
				
			}
		}

		protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
			if (e.Row.RowType == DataControlRowType.Header)
			{
				e.Row.Cells[0].Visible = false;
			}
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				e.Row.Cells[0].Visible = false;
			}
		}

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
			if (e.CommandName.CompareTo("BTeliminar") == 0)
			{
				//obtenemos el indice de la fila seleccionada por el boton
				int indice = Convert.ToInt32(e.CommandArgument);

				DataTable TC = new DataTable();
				//filtramos codigos utilizando el indice y la columna 4 del grid ya que es la de codigos, a us vez llenamos la tabla TC
				TC = leerCorreo.BuscarCorreos(Convert.ToInt32(GridView1.Rows[indice].Cells[0].Text));
				//Tabla TC llena con una sola fila, se logra editar el estado 
				foreach (DataRow fila in TC.Rows)
				{
					leerCorreo.EditarEstado("Eliminado", Convert.ToInt32(fila[0]));
				}
				Response.Redirect("Recibidos.aspx");
			}
			if (e.CommandName.CompareTo("BTver") == 0)
			{
				int indice = Convert.ToInt32(e.CommandArgument);
				DataTable TC = new DataTable();
				//filtramos codigos utilizando el indice y la columna 4 del grid ya que es la de codigos, a us vez llenamos la tabla TC
				TC = leerCorreo.BuscarCorreos(Convert.ToInt32(GridView1.Rows[indice].Cells[0].Text));
				//Tabla TC llena con una sola fila, se logra editar el estado 
				foreach (DataRow fila in TC.Rows)
				{
					leerCorreo.EditarEstado("RecLeido", Convert.ToInt32(fila[0]));
					Session["codigomensaje"] = Convert.ToInt32(fila[0]);
					Session["emisor"] = fila[1].ToString();
					Session["mensaje"] = fila[4].ToString();
					Session["asunto"] = fila[3].ToString();
					Response.Redirect("ver.aspx");


				}
			}
		}
    }
}