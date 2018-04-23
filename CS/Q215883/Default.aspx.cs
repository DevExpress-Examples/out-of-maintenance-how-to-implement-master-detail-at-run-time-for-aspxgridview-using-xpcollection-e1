using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DevExpress.Web.ASPxGridView;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session fSession = new Session();
        ASPxGridView gv = new ASPxGridView();
        gv.DataSource = new XPCollection<Customer>(fSession);
        gv.SettingsDetail.ShowDetailRow = true;
        gv.SettingsDetail.ShowDetailButtons = true;
        gv.Templates.DetailRow = new DetailRowTemplate(fSession);
        gv.KeyFieldName = "Oid";
        ASPxRoundPanel1.Controls.Add(gv);
        gv.DataBind();
    }
}

public class DetailRowTemplate : ITemplate {
    Session fSession;

    public DetailRowTemplate(Session s) {
        fSession = s;
    }
    public void InstantiateIn(Control container) {
        ASPxGridView detailGridView = new ASPxGridView();
        detailGridView.SettingsDetail.IsDetailGrid = true;
        detailGridView.KeyFieldName = "Oid";
        detailGridView.BeforePerformDataSelect += new EventHandler(OnDetailViewBeforePerformDataSelect);
        container.Controls.Add(detailGridView);
    }

    protected void OnDetailViewBeforePerformDataSelect(object sender, EventArgs e) {
        ASPxGridView grid = (ASPxGridView)sender;
        object key = grid.GetMasterRowKeyValue();
        Customer customer = fSession.GetObjectByKey<Customer>(key);
        XPCollection<Order> dataSource = new XPCollection<Order>(customer.Orders);
        dataSource.DisplayableProperties = "Oid;OrderName;OrderDate";
        grid.DataSource = dataSource;
    }
}