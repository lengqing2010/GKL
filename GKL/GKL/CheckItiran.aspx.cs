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

            if (Context.Items["line_id"] != null)
            {
                this.tbxLineId_key.Text = Context.Items["line_id"].ToString();
                this.tbxCheckUser.Text = Context.Items["user"].ToString();
                this.lblUserName.Text = Context.Items["user_name"].ToString();
                this.tbxDate_key.Text = Context.Items["chk_date"].ToString();

                MsInit(1);
                this.tbxMakeNo_key.Focus();
            }
            else
            {
                this.tbxCheckUser.Focus();
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
     
     return BC.SelTCheckResult(this.tbxLineId_key.Text, startTime, endTime,"","");

  

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

     string chk_no;
     string old_chk_no;
     chk_no = "";
     old_chk_no = "";
     System.Drawing.Color tmpColor = System.Drawing.Color.Blue;

     for (i = 0; i <= dt.Rows.Count -1; i++)
     {
         string[] sArray = dt.Rows[i]["chk_no"].ToString().Split('_');
         chk_no = sArray[0] + "_" + sArray[1];

         if (chk_no != old_chk_no)
         {
             if (tmpColor == System.Drawing.Color.Black)
             {
                 tmpColor = System.Drawing.Color.Blue;
             }
             else
             {
                 tmpColor = System.Drawing.Color.Black;
             }

             old_chk_no = chk_no;
         }
         gvMs.Rows[i].ForeColor = tmpColor;
         //gvMs.Rows[i].Cells[0].ForeColor  = tmpColor;
         //gvMs.Rows[i].Cells[1].ForeColor = tmpColor;
         //gvMs.Rows[i].Cells[2].ForeColor = tmpColor; 

     }





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

    /// <summary>
    /// 新规检查
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
 protected void btnInsert_Click(object sender, EventArgs e)
 {
     //string chk_no = this.hidChkNo.Text;
     //string make_no = this.hidMakeNo.Text;
     //string code = this.hidCode.Text;
     //string suu = this.hidSuu.Text;


     string chk_no ;
     string make_no = this.tbxMakeNo_key.Text;
     string code = this.tbxCode_key.Text;
     string suu = this.hidSuu.Text;
     string line_id = this.tbxLineId_key.Text;
     Context.Items["chk_date"] = this.tbxDate_key.Text.Trim();
     Context.Items["make_no"] = make_no;
     Context.Items["code"] = code;
     Context.Items["line_id"] = line_id;
     Context.Items["user"] = this.tbxCheckUser.Text.Trim();


     TCheckResultBC BC = new TCheckResultBC();
     System.Data.DataTable dt = BC.SelTCheckResult(this.tbxLineId_key.Text, "", "", make_no, code);

   

     Int32 i,mxChkTimes,chkTimes,idx;
     mxChkTimes = 0;
     idx = 0;

     string yotei_chk_date;
     DataRow[] drs;

     string tmp_chk_no;

     ///sp = chr("_");

     if (dt.Rows.Count >0){
         yotei_chk_date=dt.Rows[0]["yotei_chk_date"].ToString();
         drs = dt.Select("yotei_chk_date='" + yotei_chk_date + "'");
         for (i = 0; i <= drs.Length - 1; i++)
         {
             chkTimes = Convert.ToInt32(dt.Rows[i]["chk_times"].ToString());
             if (mxChkTimes < chkTimes)
             {
                 mxChkTimes = chkTimes;
                 idx = i;
             }
         }

         if (drs[idx]["temp_id"].ToString().Trim() == "")
         {
             Common.ShowMsg(this.Page, "检查模板不存在");
             return;
         }

         string[] sArray=drs[idx]["chk_no"].ToString().Split('_') ;

         tmp_chk_no = sArray[0] + "_" + sArray[1] + "_" + (mxChkTimes + 1).ToString();

         BC.InsTCheckResult(tmp_chk_no
                          , System.DateTime.Now.Year.ToString()
                          , (mxChkTimes+1).ToString() 
                          , drs[idx]["plan_no"].ToString()
                          , drs[idx]["line_id"].ToString()
                          , drs[idx]["make_no"].ToString()
                          , drs[idx]["code"].ToString()
                          , drs[idx]["suu"].ToString()
                          , drs[idx]["temp_id"].ToString()
                          , drs[idx]["chk_result"].ToString()
                          , this.tbxCheckUser.Text.Trim()
                          , drs[idx]["yotei_chk_date"].ToString()
                          , System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
                          , ""
                          , ""
                          , "0"
                          , this.tbxCheckUser.Text.Trim()
                          , System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")    
                          );

         Context.Items["chk_no"] = tmp_chk_no;
         Server.Transfer("t_check_ms.aspx");

     } else {
         Common.ShowMsg(this.Page, "检查计划数据不存在;");
                return;
     }
 }
 protected void btnDelete_Click(object sender, EventArgs e)
 {
     string chk_no = hidChkNo.Text.Trim();
     string line_id = this.tbxLineId_key.Text;
     string user = this.tbxCheckUser.Text.Trim();

     TCheckResultBC BC = new TCheckResultBC();
     BC.DeleteCheckResult(chk_no, line_id, user);
     MsInit(1);

     
 }

 protected void btnUpdate_Click(object sender, EventArgs e)
 {
     string chk_no;
     string make_no = this.tbxMakeNo_key.Text;
     string code = this.tbxCode_key.Text;
     string suu = this.hidSuu.Text;
     string line_id = this.tbxLineId_key.Text;
     Context.Items["chk_date"] = this.tbxDate_key.Text.Trim();

     Context.Items["chk_no"] = hidChkNo.Text.Trim();

     Context.Items["user_name"] = this.lblUserName.Text ;

     Context.Items["make_no"] = make_no;
     Context.Items["code"] = code;
     Context.Items["line_id"] = line_id;
     Context.Items["user"] = this.tbxCheckUser.Text.Trim();
     Server.Transfer("t_check_ms.aspx");
 }
 protected void btnComlete_Click(object sender, EventArgs e)
 {
     string chk_no;
     string make_no = this.tbxMakeNo_key.Text;
     string code = this.tbxCode_key.Text;
     string suu = this.hidSuu.Text;
     string line_id = this.tbxLineId_key.Text;

     TCheckMsBC BC = new TCheckMsBC();
     BC.UpdTCheckResultMS(hidChkNo.Text.Trim(), line_id);
     MsInit(1);
 }
}