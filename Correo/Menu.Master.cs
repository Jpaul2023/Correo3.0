using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
	}
}