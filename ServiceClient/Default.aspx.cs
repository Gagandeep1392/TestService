using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServiceReference1;

public partial class _Default : System.Web.UI.Page
{
    ServiceClient proxyHost = null;
    List<Country> m_lst;

    public _Default()
    {
       
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            m_lst = new List<Country>();
            proxyHost = new ServiceClient("TcpEndPoint");
            proxyHost.OpenConnection();


            string f = proxyHost.GetData();
            Response.Write(f);

            List<Country> lstCoun = proxyHost.GetCountries();

            DropDownList1.DataSource = lstCoun;
            DropDownList1.DataTextField = "CountryName";
            DropDownList1.DataValueField = "Id";
            DropDownList1.DataBind();

        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            

            foreach(Country cus in m_lst)
            {
                proxyHost.AddCountry(cus);
            }


            System.Text.StringBuilder strb = new StringBuilder();
            List<Country> list =  proxyHost.GetCountriesAdded();
            foreach (Country cus in list)
            {
                strb.Append(cus.Id + " " + cus.CountryName);
                strb.AppendLine();
            }
            this.TextBox3.Text = strb.ToString();

        }
        catch (FaultException ex)
        {
           
        }
        finally
        {
            proxyHost.CloseConnection();
            m_lst.Clear();
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        string sId   = this.TextBox1.Text;
        string sName = this.TextBox2.Text;

        m_lst.Add(new Country() { Id = int.Parse(sId), CountryName = sName });

        this.TextBox1.Text = "";
        this.TextBox2.Text = "";
    }

    
}