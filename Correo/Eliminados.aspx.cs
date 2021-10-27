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
    public partial class Eliminados : System.Web.UI.Page
    {
        emailTableAdapter leerCorreo = new emailTableAdapter();
        DataTable TableCorreo = new DataTable();
        DataTable filtrXestado = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            TableCorreo = leerCorreo.LeerRecibido(Session["AuxiliarCorreo"].ToString(), "Eliminado");

            foreach (DataRow fila in TableCorreo.Rows)
            {

                GridView1.DataSource = TableCorreo;
                GridView1.DataBind();
               
            }
        }
		protected void GridView1_DataBound(object sender, EventArgs e)
		{


		}

		protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			//ocultar el codigo
			if (e.Row.RowType == DataControlRowType.Header)
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
			//se genera la consulta para el click del boton eliminar
			if (e.CommandName.CompareTo("BTeliminar") == 0)
			{
				//obtenemos el indice de la fila seleccionada por el boton
				int indice = Convert.ToInt32(e.CommandArgument);

				DataTable TC = new DataTable();
				//filtramos codigos utilizando el indice y la columna 4 del grid ya que es la de codigos, a us vez llenamos la tabla TC
				TC = leerCorreo.BuscarCorreos(Convert.ToInt32(GridView1.Rows[indice].Cells[4].Text));
				//Tabla TC llena con una sola fila, se logra editar el estado 
				foreach (DataRow fila in TC.Rows)
				{
					leerCorreo.EditarEstado("Eliminado", Convert.ToInt32(fila[0]));
				}
				Response.Redirect("Eliminados.aspx");
			}
			//*********************************************************************************************************

			if (e.CommandName.CompareTo("BTfavoritos") == 0)
			{
				//obtenemos el indice de la fila seleccionada por el boton
				int indice = Convert.ToInt32(e.CommandArgument);

				DataTable TC = new DataTable();
				//filtramos codigos utilizando el indice y la columna 4 del grid ya que es la de codigos, a us vez llenamos la tabla TC
				TC = leerCorreo.BuscarCorreos(Convert.ToInt32(GridView1.Rows[indice].Cells[4].Text));
				//Tabla TC llena con una sola fila, se logra editar el estado 
				foreach (DataRow fila in TC.Rows)
				{
					leerCorreo.EditarEstado("Destacado", Convert.ToInt32(fila[0]));
				}
				Response.Redirect("Eliminados.aspx");
			}
			//*********************************************************************************************************
			if (e.CommandName.CompareTo("BTver") == 0)
			{
				//obtenemos el indice de la fila seleccionada por el boton
				int indice = Convert.ToInt32(e.CommandArgument);

				DataTable TC = new DataTable();
				//filtramos codigos utilizando el indice y la columna 4 del grid ya que es la de codigos, a us vez llenamos la tabla TC
				TC = leerCorreo.BuscarCorreos(Convert.ToInt32(GridView1.Rows[indice].Cells[4].Text));
				//Tabla TC llena con una sola fila, se logra editar el estado 
				foreach (DataRow fila in TC.Rows)
				{
					leerCorreo.EditarEstado("RecLeido", Convert.ToInt32(fila[0]));
				}

				Response.Redirect("Eliminados.aspx");
			}
		}

		protected void deleteSelected_Click(object sender, ImageClickEventArgs e)
		{
			for (int i = 0; i < GridView1.Rows.Count; i++)
			{
				CheckBox cbselect = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("selector");
				if (cbselect.Checked == true)
				{
					int id = Convert.ToInt32(GridView1.Rows[i].Cells[4].Text);
					DataTable TC = new DataTable();
					TC = leerCorreo.BuscarCorreos(Convert.ToInt32(GridView1.Rows[id].Cells[4].Text));
					foreach (DataRow fila in TC.Rows)
					{
						leerCorreo.EditarEstado("Eliminado", Convert.ToInt32(fila[0]));
					}
				}
			}
			GridView1.DataBind();

		}

		protected void selector_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox chkstat = (CheckBox)sender;
			GridViewRow row = (GridViewRow)chkstat.NamingContainer;
		}

		protected void HeaderChk_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox chkheader = (CheckBox)GridView1.HeaderRow.FindControl("HeaderChk");
			foreach (GridViewRow row in GridView1.Rows)
			{
				CheckBox chkrows = (CheckBox)row.FindControl("selector");
				if (chkheader.Checked == true)
				{ chkrows.Checked = true; }
				else
				{ chkrows.Checked = false; }

			}
		}
	}
}