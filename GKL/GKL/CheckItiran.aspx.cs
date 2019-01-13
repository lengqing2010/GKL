using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class CheckItiran : System.Web.UI.Page
{
     


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.tbxDate_key.Text = System.DateTime.Now.ToString("yyyy/MM/dd");

            this.tbxDate_key.Attributes["itType"] = "date";
            this.tbxDate_key.Attributes["itLength"] = "20";
            this.tbxDate_key.Attributes["itName"] = "登録日";

            if (Request.QueryString["line_id"] != null)
            {
                this.tbxLineId_key.Text = Request.QueryString["line_id"];


            }
        }

        ;
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Server.Transfer("Default.aspx");
    }

    public void MsInit()
    {

        DataTable dt = GetMsData();
        gvMs.DataSource = dt;
        gvMs.DataBind();

    }


 private System.Data.DataTable GetMsData(){

     TCheckResultBC BC = new TCheckResultBC();
     string startTime;
     string endTime;
     System.DateTime currentTime=new System.DateTime();
     if (this.tbxDate_key.Text == "")
     {
          currentTime = System.DateTime.Now;
          startTime = currentTime.AddDays(-7).ToString("yyyy/MM/dd");
          endTime = currentTime.ToString("yyyy/MM/dd");
     } else
     {
         startTime = Convert.ToDateTime(this.tbxDate_key.Text).ToString("yyyy/MM/dd");
         endTime = startTime;
     }
     
     return BC.SelTCheckResult(this.tbxLineId_key.Text, startTime, endTime);

  

 }

 public void MsInit(int pageIdx )
 {
     System.Data.DataTable dt = new DataTable();
     System.Data.DataTable dtMs = new DataTable();
     System.Data.DataTable dtPageIdx = new DataTable();

     dt = GetMsData();
         
     GetPageData(dt , pageIdx);


 }


 protected void btnSelect_Click(object sender, EventArgs e)
 {
     MsInit(1);
 }


 public void  GetPageData(System.Data.DataTable inDt, int pageIdx)
 {
     int onePageRowCnt = 100;
     int mxPageIdx;
          mxPageIdx = (int)Math.Ceiling((double)inDt.Rows.Count / (double)onePageRowCnt);
          int i;

     System.Data.DataTable dt = inDt.Clone();
     for (i = (pageIdx - 1) * onePageRowCnt; i <= (pageIdx) * onePageRowCnt - 1; i++)
     {
         if (i < inDt.Rows.Count)
             dt.Rows.Add(inDt.Rows[i].ItemArray);
     }


     System.Data.DataTable dt2 = new System.Data.DataTable();
     dt2.Columns.Add("idx");
     for ( i = 1; i <= mxPageIdx; i++)
     {
         System.Data.DataRow dr = dt2.NewRow();
         dr[0] = i.ToString();
         //dr.Item[0] = i.ToString();
         dt2.Rows.Add(dr);
     }
     

     gvMs.DataSource = dt;
     gvMs.DataBind();

     ddlPageIdx.DataValueField = "idx";
     ddlPageIdx.DataTextField = "idx";
     ddlPageIdx.DataSource = dt2;
     ddlPageIdx.DataBind();

     lblAllPageText.Text = ddlPageIdx.Items.Count.ToString();

     if (ddlPageIdx.Items.Count > pageIdx)
         ddlPageIdx.SelectedIndex = pageIdx - 1;

 }


 protected void ddlPageIdx_SelectedIndexChanged(object sender, EventArgs e)
 {
     MsInit(Convert.ToInt32(ddlPageIdx.SelectedValue));
 }
}