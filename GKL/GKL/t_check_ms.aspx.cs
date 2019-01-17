using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Linq;


public partial class t_check_ms : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
                this.lblMsg.Text = "";
        if (!IsPostBack ){

            ViewState["make_no"] = Context.Items["make_no"];
            ViewState["code"] = Context.Items["code"] ;
            ViewState["line_id"] = Context.Items["line_id"];
            ViewState["user"] = Context.Items["user"] ;
            ViewState["chk_no"] = Context.Items["chk_no"];
            ViewState["user_name"] = Context.Items["user_name"];
            ViewState["chk_date"] = Context.Items["chk_date"];
            this.lblMake_no.Text = ViewState["make_no"].ToString();
            this.lblCode.Text = ViewState["code"].ToString();
            this.lblUser.Text = ViewState["user"].ToString();
            this.lblLine_id.Text = ViewState["line_id"].ToString() + "  " + ViewState["user_name"].ToString();

            //ViewState["chk_no"] = "190112_049010465_1";
            //ViewState["line_id"] = "SRM1312A";
            //ViewState["CheckUser"] = "3003000";
            this.hidChkNo.Text = ViewState["chk_no"].ToString();
            this.hidLineId.Text = ViewState["line_id"].ToString();
            this.hidInsUser.Text = ViewState["user"].ToString();


            //'固定項目設定
            KoteiInit();

            //'明細項目設定
            MsInit();
        }


    }


    public void KoteiInit(){

    }

    public void MsInit(){

        DataTable dt = GetMsData();
        this.gvMs.DataSource = dt;
        this.gvMs.DataBind();

        Int32 i;
        for (i = 0; i <= dt.Rows.Count - 1; i++)
        {
            this.gvMs.Rows[i].Attributes.Add("chk_id", dt.Rows[i]["chk_id"].ToString());
            this.gvMs.Rows[i].Attributes.Add("kj_0", dt.Rows[i]["kj_0_Expr"].ToString());
            this.gvMs.Rows[i].Attributes.Add("kj_1", dt.Rows[i]["kj_1_Expr"].ToString());
            this.gvMs.Rows[i].Attributes.Add("kj_2", dt.Rows[i]["kj_2_Expr"].ToString());
            this.gvMs.Rows[i].Attributes.Add("chk_method_id", dt.Rows[i]["chk_method_id"].ToString());
            this.gvMs.Rows[i].Attributes.Add("chk_method", dt.Rows[i]["chk_method"].ToString());
            this.gvMs.Rows[i].Attributes.Add("chk_formula", dt.Rows[i]["chk_formula"].ToString());
            this.gvMs.Rows[i].Attributes.Add("pic_id", dt.Rows[i]["pic_id"].ToString());
        }

        MergeGridViewCell.MergeRow(this.gvMs, 0, 1);

    }

    DataTable GetMsData(){
        TCheckMsBC BC = new TCheckMsBC();
        return BC.SelTCheckMs(ViewState["chk_no"].ToString(), ViewState["line_id"].ToString());
    }
    protected void btnComplete_Click(object sender, EventArgs e)
    {
        TCheckMsBC BC = new TCheckMsBC();
        BC.UpdTCheckResultMS(ViewState["chk_no"].ToString(), ViewState["line_id"].ToString());

        Context.Items["make_no"] = ViewState["make_no"];
        Context.Items["code"] = ViewState["code"];
        Context.Items["line_id"] = ViewState["line_id"];
        Context.Items["user"] = ViewState["user"];
        Context.Items["chk_no"] = ViewState["chk_no"];
        Context.Items["user_name"] = ViewState["user_name"];
        Context.Items["chk_date"] = ViewState["chk_date"];
        Server.Transfer("CheckItiran.aspx");
    }
    protected void btnModoru_Click(object sender, EventArgs e)
    {
        Context.Items["make_no"] = ViewState["make_no"];
        Context.Items["code"] = ViewState["code"];
        Context.Items["line_id"] = ViewState["line_id"];
        Context.Items["user"] = ViewState["user"];
        Context.Items["chk_no"] = ViewState["chk_no"];
        Context.Items["user_name"] = ViewState["user_name"];
        Context.Items["chk_date"] = ViewState["chk_date"];
        Server.Transfer("CheckItiran.aspx");
    }
}




/// <summary>
/// 合并GridView单元格
/// </summary>
public class MergeGridViewCell
{

    #region Public

    /// <summary>
    /// GridView合并行
    /// </summary>
    /// <param name="gv">GridView</param>
    /// <param name="startCol">开始列（索引从0开始）</param>
    /// <param name="endCol">结束列</param>
    public static void MergeRow(GridView gv, int startCol, int endCol)
    {
        if (startCol < 0)
            throw new ArgumentOutOfRangeException("startCol", "开始列不能小于0");
        if (endCol < 0)
            throw new ArgumentOutOfRangeException("endCol", "结束列不能小于0");
        if (startCol > endCol)
            throw new ArgumentException("开始列不能小于结束列");

        var init = new RowArg()
        {
            StartRowIndex = 0,
            EndRowIndex = gv.Rows.Count - 2
        };
        for (int i = startCol; i < endCol + 1; i++)
        {
            if (i > 0)
            {
                var list = new List<RowArg>();
                //从第二列开始就要遍历前一列
                IteratePrevCol(gv, i - 1, list);
                foreach (var item in list)
                {
                    MergeRow(gv, i, item.StartRowIndex, item.EndRowIndex);
                }
            }
            //合并开始列的行
            else
            {
                MergeRow(gv, i, init.StartRowIndex, init.EndRowIndex);
            }
        }
    }

    /// <summary>
    /// 合并GridView单元格
    /// </summary>
    /// <param name="gv">要合并的GridView</param>
    /// <param name="cols">制定的列</param>
    public static void MergeRow(GridView gv, params int[] cols)
    {
        if (cols.Any(t => t < 0))
        {
            throw new ArgumentOutOfRangeException("参数中不能包含小于0列");
        }
        var init = new RowArg()
        {
            StartRowIndex = 0,
            EndRowIndex = gv.Rows.Count - 2
        };

        for (int i = 0; i < cols.Length; i++)
        {
            if (i > 0)
            {
                var list = new List<RowArg>();
                //从第二列开始就要遍历前一列
                IteratePrevCol(gv, cols[i - 1], list);
                foreach (var item in list)
                {
                    MergeRow(gv, cols[i], item.StartRowIndex, item.EndRowIndex);
                }
            }
            //合并开始列的行
            else
            {
                MergeRow(gv, i, init.StartRowIndex, init.EndRowIndex);
            }
        }
    }

    /// <summary>
    /// 和并列
    /// </summary>
    /// <param name="gv">要合并的GridView</param>
    /// <param name="startCol">开始列的索引</param>
    /// <param name="endCol">结束列的索引</param>
    /// <param name="containHeader">是否合并表头，默认不合并</param>
    public static void MergeColumn(GridView gv, int startCol, int endCol, bool containHeader)
    {
        if (containHeader)
        {
            IterateRowCells(gv.HeaderRow, startCol, endCol);
        }
        foreach (GridViewRow row in gv.Rows)
        {
            IterateRowCells(row, startCol, endCol);
        }
    }

    #endregion


    #region Private

    /// <summary>
    /// 合并单列的行
    /// </summary>
    /// <param name="gv">GridView</param>
    /// <param name="currentCol">当前列</param>
    /// <param name="startRow">开始合并的行索引</param>
    /// <param name="endRow">结束合并的行索引</param>
    private static void MergeRow(GridView gv, int currentCol, int startRow, int endRow)
    {
        for (int rowIndex = endRow; rowIndex >= startRow; rowIndex--)
        {
            GridViewRow currentRow = gv.Rows[rowIndex];
            GridViewRow prevRow = gv.Rows[rowIndex + 1];
            if (currentRow.Cells[currentCol].Text != "" && currentRow.Cells[currentCol].Text != " ")
            {
                if (currentRow.Cells[currentCol].Text == prevRow.Cells[currentCol].Text)
                {
                    currentRow.Cells[currentCol].RowSpan = prevRow.Cells[currentCol].RowSpan < 1 ? 2 : prevRow.Cells[currentCol].RowSpan + 1;
                    prevRow.Cells[currentCol].Visible = false;
                }
            }
        }
    }

    /// <summary>
    /// 遍历GridViewRow中的单元格
    /// </summary>
    /// <param name="row">要遍历的行</param>
    /// <param name="start">开始索引</param>
    /// <param name="end">结束索引</param>
    private static void IterateRowCells(GridViewRow row, int start, int end)
    {
        //从开始索引的下一列开始
        for (int i = start + 1; i <= end; i++)
        {
            //当前单元格
            TableCell currCell = row.Cells[i];
            //前一个单元格
            TableCell prevCell = row.Cells[i - 1];
            if (!string.IsNullOrEmpty(currCell.Text) && !string.IsNullOrEmpty(prevCell.Text))
            {
                if (currCell.Text == prevCell.Text)
                {
                    currCell.ColumnSpan = prevCell.ColumnSpan < 1 ? 2 : prevCell.ColumnSpan + 1;
                    prevCell.Visible = false;
                }
            }
        }
    }

    /// <summary>
    /// 遍历前一列
    /// </summary>
    /// <param name="gv">GridView</param>
    /// <param name="prevCol">当前列的前一列</param>
    /// <param name="list"></param>
    private static void IteratePrevCol(GridView gv, int prevCol, List<RowArg> list)
    {
        if (list == null)
        {
            list = new List<RowArg>();
        }
        foreach (GridViewRow row in gv.Rows)
        {
            if (!row.Cells[prevCol].Visible)
                continue;
            list.Add(new RowArg
            {
                StartRowIndex = row.RowIndex,
                EndRowIndex = row.RowIndex + row.Cells[prevCol].RowSpan - 2
            });
        }
    }

    class RowArg
    {
        public int StartRowIndex { get; set; }
        public int EndRowIndex { get; set; }
    }

    #endregion
}
