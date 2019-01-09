Imports System.Configuration
Imports System.Text

Imports EMAB = Itis.ApplicationBlocks.ExceptionManagement.UnTrappedExceptionManager
Imports MyMethod = System.Reflection.MethodBase
Imports Itis.ApplicationBlocks.Data.SQLHelper
Imports Itis.ApplicationBlocks.Data
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration.ConfigurationSettings
Imports System.Collections.Generic
Imports System.IO


Public Class PicImport

    Private conn As String = ConfigurationManager.AppSettings("connectionString").ToString()
    ' Private picturePath As String = ConfigurationManager.AppSettings("picturePath").ToString()

    Private CMsSql As New CMsSql

    Private Sub PicImport_Load(sender As Object, e As EventArgs) Handles MyBase.Load




    End Sub


    ''' <summary>
    ''' 
    ''' Infoを登録する
    ''' </summary>
    '''<param name="picId">pic_id</param>
    '''<param name="lineId">line_id</param>
    '''<param name="picName">pic_name</param>
    ''' <returns>Info</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  作成者：李さん 新規作成 </para>
    ''' </history>

    Public Function InsMPicture(ByVal picId As String, _
               ByVal lineId As String, _
               ByVal picName As String, ByRef picCon As Byte()) As Boolean
        'EMAB　ＥＲＲ
        'SQLコメント
        '--**テーブル： : m_picture
        Dim sb As New StringBuilder
        'SQL文

        sb.AppendLine("DELETE FROM m_picture WHERE 1=1")
        sb.AppendLine("AND pic_id='" & picId & "'")   'pic_id
        sb.AppendLine("AND line_id='" & lineId & "'")   'line_id

        sb.AppendLine("INSERT INTO  m_picture")
        sb.AppendLine("(")
        sb.AppendLine("pic_id")                                                    'pic_id
        sb.AppendLine(", line_id")                                                 'line_id
        sb.AppendLine(", pic_name ,pic_conn")                                        'pic_name
        sb.AppendLine(")")
        sb.AppendLine("VALUES(")
        sb.AppendLine("@pic_id")                                                       'pic_id
        sb.AppendLine(", @line_id")                                                    'line_id
        sb.AppendLine(", @pic_name")                                                   'pic_name
        sb.AppendLine(", @picCon")
        sb.AppendLine(")")
        '僶儔儊僞奿擺
        Dim paramList As New List(Of SqlParameter)
        paramList.Add(MakeParam("@pic_id", SqlDbType.VarChar, 10, picId))
        paramList.Add(MakeParam("@line_id", SqlDbType.VarChar, 10, lineId))
        paramList.Add(MakeParam("@pic_name", SqlDbType.NVarChar, 200, picName))
        paramList.Add(MakeParam("@picCon", SqlDbType.VarBinary, -1, picCon))

        SQLHelper.ExecuteNonQuery(conn, CommandType.Text, sb.ToString(), paramList.ToArray)

        Return True

    End Function




    Private Function GetLineList(ByVal picId_key As String, ByVal lineId_key As String)

        '--**テーブル： : m_picture
        Dim sb As New StringBuilder
        'SQL文
        sb.AppendLine("SELECT")
        sb.AppendLine("pic_id as 图片ID")                                                    'pic_id
        sb.AppendLine(", line_id as 生产线")                                                 'line_id
        sb.AppendLine(", pic_name as 图片名称")                                                'pic_name
        sb.AppendLine("FROM m_picture")
        sb.AppendLine("WHERE 1=1")
        If picId_key <> "" Then
            sb.AppendLine("AND pic_id='" & picId_key & "'")   'pic_id
        End If
        If lineId_key <> "" Then
            sb.AppendLine("AND line_id='" & lineId_key & "'")   'line_id
        End If
        sb.AppendLine("ORDER BY line_id,pic_id")
        Dim dt As DataTable = CMsSql.ExecSelect(sb.ToString)
        CMsSql.CloseConn(CMsSql.conn)
        Return dt

    End Function


    Private Function GetLineListPic(ByVal picId_key As String, ByVal lineId_key As String)

        '--**テーブル： : m_picture
        Dim sb As New StringBuilder
        'SQL文
        sb.AppendLine("SELECT")
        sb.AppendLine("pic_id ")                                                    'pic_id
        sb.AppendLine(", line_id ")                                                 'line_id
        sb.AppendLine(", pic_name ")                                                'pic_name
        sb.AppendLine(", pic_conn ")
        sb.AppendLine("FROM m_picture")
        sb.AppendLine("WHERE 1=1")
        If picId_key <> "" Then
            sb.AppendLine("AND pic_id='" & picId_key & "'")   'pic_id
        End If
        If lineId_key <> "" Then
            sb.AppendLine("AND line_id='" & lineId_key & "'")   'line_id
        End If
        sb.AppendLine("ORDER BY line_id,pic_id")

        Dim dt As DataTable = CMsSql.ExecSelect(sb.ToString)
        CMsSql.CloseConn(CMsSql.conn)
        Return dt.Rows(0).Item("pic_conn")

    End Function

    Public Function DelMPicture(ByVal picId_key As String, _
           ByVal lineId_key As String) As Boolean
        'EMAB　ＥＲＲ
        EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name, _
               picId_key, _
               lineId_key)
        'SQLコメント
        '--**テーブル： : m_picture
        Dim sb As New StringBuilder
        'SQL文
        sb.AppendLine("DELETE FROM m_picture")
        sb.AppendLine("WHERE 1=1")
        If picId_key <> "" Then
            sb.AppendLine("AND pic_id=@pic_id_key")   'pic_id
        End If
        If lineId_key <> "" Then
            sb.AppendLine("AND line_id=@line_id_key")   'line_id
        End If

        '僶儔儊僞奿擺
        Dim paramList As New List(Of SqlParameter)
        paramList.Add(MakeParam("@pic_id_key", SqlDbType.VarChar, 10, picId_key))
        paramList.Add(MakeParam("@line_id_key", SqlDbType.VarChar, 10, lineId_key))


        SQLHelper.ExecuteNonQuery(conn, CommandType.Text, sb.ToString(), paramList.ToArray)

        Return True

    End Function


    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click, lblFolder.Click

    End Sub

    Private Sub btnFolder_Click(sender As Object, e As EventArgs) Handles btnFolder.Click
        Me.FolderBD.ShowDialog()
        Dim strDirect As String = FolderBD.SelectedPath

        If strDirect <> "" Then
            Dim mFileInfo As System.IO.FileInfo
            Dim mDir As System.IO.DirectoryInfo
            Dim mDirInfo As New System.IO.DirectoryInfo(strDirect)
            Try
                Dim dic As New Dictionary(Of String, String)

                For Each mFileInfo In mDirInfo.GetFiles("*.*")
                    Dim picId As String = mFileInfo.Name.Split("_")(0)
                    If picId.Length > 10 Then
                        MsgBox(mFileInfo.FullName & vbNewLine & "  图片文件名：请更改成  图片ID（10位）+‘_'+图片名称.jpg的格式")
                        Exit Sub
                    End If

                    If dic.ContainsKey(picId) Then
                        MsgBox(mFileInfo.Name & vbNewLine & dic.Item(picId) & vbNewLine & "   图片名称前10位 重复 ")
                        Exit Sub
                    Else
                        dic.Add(picId, mFileInfo.Name)
                    End If
                Next
            Catch ex As System.IO.DirectoryNotFoundException
                Debug.Print("目录没找到：" + ex.Message)
            End Try
            Me.tbxFolder.Text = strDirect
        End If



    End Sub

    Private Sub btnTouroku_Click(sender As Object, e As EventArgs) Handles btnTouroku.Click

        Dim strDirect As String = Me.tbxFolder.Text
        If Me.tbxLineCd.Text = "" Then
            MsgBox("请输入生产线")
            tbxLineCd.Focus()
            Exit Sub
        End If
        If strDirect.Trim = "" Then
            MsgBox("请选择文件夹")
            Exit Sub
        End If

        Try
            Dim mFileInfo As System.IO.FileInfo
            Dim mDirInfo As New System.IO.DirectoryInfo(strDirect)
            Try

                For Each mFileInfo In mDirInfo.GetFiles("*.*")
                    '图片登录
                    Dim picId As String = mFileInfo.Name.Split("_")(0)
                    Dim lineId As String = Me.tbxLineCd.Text
                    Dim picName As String = mFileInfo.Name
                    InsMPicture(picId, lineId, picName, imageToByte(mFileInfo.FullName))
                Next
                InitMs()
                MsgBox("图片登录完了")
            Catch ex As System.IO.DirectoryNotFoundException
                Debug.Print("目录没找到：" + ex.Message)
            End Try
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



    End Sub



    Private Function imageToByte(ByVal Imagepath As String) As Byte()
        If System.IO.File.Exists(Imagepath) Then '检查图片路径是否正确
            Dim fs As FileStream = New FileStream(Imagepath, FileMode.Open)
            Dim br As BinaryReader = New BinaryReader(fs)
            Dim imageByte() As Byte = br.ReadBytes(CInt(fs.Length))
            br.Close()
            fs.Close()
            Return imageByte
        Else
            Return Nothing
        End If
    End Function
    ''' <summary>
    ''' 将二进制图片转为图片
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Convert_byte_To_Image(ByVal imageByte() As Byte)
        Dim sm As MemoryStream = New MemoryStream(imageByte, True) '图片数组转为内存文件流
        Me.PictureBox1.Image = Image.FromStream(DirectCast(sm, System.IO.Stream))
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        sm.Close()
    End Sub

    Private Sub GetAllFiles(ByVal strDirect As String)  '搜索所有目录下的文件
        If Not (strDirect Is Nothing) Then
            Dim mFileInfo As System.IO.FileInfo
            Dim mDir As System.IO.DirectoryInfo
            Dim mDirInfo As New System.IO.DirectoryInfo(strDirect)
            Try
                For Each mFileInfo In mDirInfo.GetFiles("*.*")
                    'Debug.Print(mFileInfo.FullName)
                    'GetIncludeInfo(mFileInfo.FullName)
                Next

                'For Each mDir In mDirInfo.GetDirectories
                '    'Debug.Print("******目录回调*******")
                '    GetAllFiles(mDir.FullName)
                'Next
            Catch ex As System.IO.DirectoryNotFoundException
                Debug.Print("目录没找到：" + ex.Message)
            End Try
        End If
    End Sub


    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub gv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gv.CellContentClick



    End Sub


    Public oldPicId As String = ""

    Private Sub gv_SelectionChanged(sender As Object, e As EventArgs) Handles gv.SelectionChanged

        Try
            Dim picId As String = Me.gv.CurrentRow.Cells(0).Value
            Dim lineId As String = Me.gv.CurrentRow.Cells(1).Value

            If oldPicId <> picId Then

                Dim bt() As Byte = DirectCast(GetLineListPic(picId, lineId), Byte())
                Convert_byte_To_Image(bt)

                oldPicId = picId
            End If

        Catch ex As Exception

        End Try


    End Sub


    Private Sub btnSel_Click(sender As Object, e As EventArgs) Handles btnSel.Click
        InitMs()
    End Sub

    Private Sub InitMs()
        Dim dt As DataTable = GetLineList("", Me.tbxLineCd.Text.Trim)
        gv.DataSource = dt
        gv.Columns(2).Width = 200
    End Sub
    Private Sub tbxLineCd_TextChanged(sender As Object, e As EventArgs) Handles tbxLineCd.TextChanged

    End Sub

    Private Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click

        If Me.gv.CurrentRow Is Nothing Then
            MsgBox("请输选择要删除的行")
            Exit Sub
        End If

        Dim picId As String = Me.gv.CurrentRow.Cells(0).Value
        Dim lineId As String = Me.gv.CurrentRow.Cells(1).Value

        If picId = "" Then
            MsgBox("请输选择要删除的行")

            Exit Sub
        End If

        If lineId = "" Then
            MsgBox("请输选择要删除的行")

            Exit Sub
        End If


        DelMPicture(picId, lineId)
    End Sub
End Class
