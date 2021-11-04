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
 
    public partial class Favoritos : System.Web.UI.Page
    {
        emailTableAdapter LeerCorreo = new emailTableAdapter();
        DataTable TabFavoritos = new DataTable();
        protected void filtrar()
        {
            TabFavoritos = LeerCorreo.LeerRecibido(Session["AuxiliarCorreo"].ToString(), "Destacado");
            foreach (DataRow fila in TabFavoritos.Rows)
            {
                GridDestacados.DataSource = TabFavoritos;
                GridDestacados.DataBind();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            filtrar();
        }

        protected void GridDestacados_RowCommand(object sender, GridViewCommandEventArgs e)
        {

          
            if (e.CommandName.CompareTo("BTeliminar") == 0)
            {
                //obtenemos el indice de la fila seleccionada por el boton
                int indice = Convert.ToInt32(e.CommandArgument);

                DataTable TC = new DataTable();
                //filtramos codigos utilizando el indice y la columna 4 del grid ya que es la de codigos, a us vez llenamos la tabla TC
                TC = LeerCorreo.BuscarCorreos(Convert.ToInt32(GridDestacados.Rows[indice].Cells[0].Text));
                //Tabla TC llena con una sola fila, se logra editar el estado 
                foreach (DataRow fila in TC.Rows)
                {
                    LeerCorreo.EditarEstado("Eliminado", Convert.ToInt32(fila[0]));
                }

                Response.Redirect("Favoritos.aspx");


            }
            //*********************************************************************************************************

            if (e.CommandName.CompareTo("BTfavoritos") == 0)
            {
                //obtenemos el indice de la fila seleccionada por el boton
                int indice = Convert.ToInt32(e.CommandArgument);

                DataTable TC = new DataTable();
                //filtramos codigos utilizando el indice y la columna 4 del grid ya que es la de codigos, a us vez llenamos la tabla TC
                TC = LeerCorreo.BuscarCorreos(Convert.ToInt32(GridDestacados.Rows[indice].Cells[0].Text));
                //Tabla TC llena con una sola fila, se logra editar el estado 
                foreach (DataRow fila in TC.Rows)
                {
                    LeerCorreo.EditarEstado("RecLeido", Convert.ToInt32(fila[0]));
                }
                Response.Redirect("Favoritos.aspx");
            }
            //*********************************************************************************************************
            if (e.CommandName.CompareTo("BTver") == 0)
            {
                int indice = Convert.ToInt32(e.CommandArgument);
                DataTable TC = new DataTable();
                //filtramos codigos utilizando el indice y la columna 4 del grid ya que es la de codigos, a us vez llenamos la tabla TC
                TC = LeerCorreo.BuscarCorreos(Convert.ToInt32(GridDestacados.Rows[indice].Cells[0].Text));
                //Tabla TC llena con una sola fila, se logra editar el estado 
                foreach (DataRow fila in TC.Rows)
                {
                    LeerCorreo.EditarEstado("RecLeido", Convert.ToInt32(fila[0]));
                    Session["codigomensaje"] = Convert.ToInt32(fila[0]);
                    Session["emisor"] = fila[1].ToString();
                    Session["mensaje"] = fila[4].ToString();
                    Session["asunto"] = fila[3].ToString();
                    Response.Redirect("ver.aspx");

                }

            }
        }

        protected void GridDestacados_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //ocultar el codigo
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Visible = false;
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Visible = false;
            }
            
        }

        protected void Selector_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            GridViewRow row = (GridViewRow)cb.NamingContainer;
        }
    }
}