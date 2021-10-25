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
	public partial class Recibidos : System.Web.UI.Page
	{
		emailTableAdapter leerCorreo = new emailTableAdapter();
		DataTable TableCorreo = new DataTable();
		

		protected void Page_Load(object sender, EventArgs e)
		{
			TableCorreo = leerCorreo.LeerRecibido(Session["AuxiliarCorreo"].ToString());

			foreach (DataRow fila in TableCorreo.Rows)
			{
				if (Session["AuxiliarCorreo"].ToString() == fila[2].ToString())
				{
					Session["auxcod"] = fila[0];
					GridView1.DataSource = TableCorreo;
					GridView1.DataBind();
				}

			}

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