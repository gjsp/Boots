﻿
Partial Class manage_data_month
    Inherits basePage

    Protected Sub ImgDel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim i As Integer = CType(CType(sender, ImageButton).Parent.Parent, GridViewRow).RowIndex
        Dim id As String = GridView1.DataKeys(i).Value
        ClsDB.DelMonthData(id)
        GridView1.DataBind()
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            CType(e.Row.FindControl("ImgDel"), ImageButton).Attributes.Add("onclick", "return confirm('Do you want to delete.');")
        End If
    End Sub
End Class
