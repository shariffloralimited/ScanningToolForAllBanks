using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace RTGS.Modules
{
    public partial class DHBLCBS : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //RTGS.Forms.Outward08ShortMaker parentpage = (RTGS.Forms.Outward08ShortMaker)Parent.Page;
            //string AccountNo = parentpage.txtAccountNo.Text;

            //GetData(AccountNo);
        }
        private void GetData(string AccountNo)
        {
            //DHBLWS.CBS_Master cbs = new DHBLWS.CBS_Master();
            //DataSet ds = cbs.get_cbs_acctinfo(AccountNo, StateList.SelectedValue);

            //if (StateList.SelectedValue == "3")
            //{
            //    DataTable dt = ds.Tables[0];

            //    ImgList.Visible = true;
            //    MyGrid.Visible = false;
            //    DataTable table = new DataTable();

            //    table.Columns.Add("ImgSrc", typeof(string));

            //    int n = dt.Rows.Count;
            //    for (int i = 0; i < n; i++)
            //    {
            //        byte[] ImageData = (byte[])dt.Rows[i]["IMAGEDATA"];
            //        table.Rows.Add("data:image/jpg;base64," + Convert.ToBase64String((byte[])ImageData));
            //    }
            //    ImgList.DataSource = table;
            //    ImgList.DataBind();

            //    table.Dispose();
            //    dt.Dispose();
            //}
            //else
            //{
            //    DataTable dt = Flip(ds.Tables[0]);

            //    MyGrid.Visible = true;
            //    ImgList.Visible = false;
            //    MyGrid.DataSource = dt;
            //    MyGrid.DataBind();

            //    dt.Dispose();
            //}

            //ds.Dispose();

        }
        protected DataTable Flip(DataTable dt)
        {
            DataTable dt2 = new DataTable();
            for (int i = 0; i <= dt.Rows.Count; i++)
            {
                dt2.Columns.Add();
            }
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                dt2.Rows.Add();
                dt2.Rows[i][0] = dt.Columns[i].ColumnName;
            }
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    dt2.Rows[i][j + 1] = dt.Rows[j][i];
                }
            }

            return dt2;

        }
    }
}