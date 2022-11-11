# How to put a CheckBox in a header cell in the WinForms GridControl or GridDataBoundGrid 

## Adding checkbox in a header cell

### GridControl:

In [WinForms GridControl](https://www.syncfusion.com/winforms-ui-controls/grid-control), to put a <b>CheckBox</b> in the <b>GridControl</b>, set the <b>CellType</b> to <b>CheckBox</b> and assign string values for the <b>CheckedValue</b> and <b>UncheckedValue</b> in the <b>CheckBoxOptions</b> property. The value of the <b>CheckBox</b> can be stored to a particular cell in the <b>GridControl</b> and the <b>CheckBoxClick</b> event gets triggered when the <b>CheckBox</b> is clicked. The following is the code example for <b>GridControl</b>.

## C#

```C#
this.gridControl1[0,2].CellType = "CheckBox";
this.gridControl1[0,2].Description = "B";
this.gridControl1[0,2].CellAppearance = GridCellAppearance.Raised;
```

## VB

```VB
Me.gridControl1(0,2).CellType = "CheckBox"
Me.gridControl1(0,2).Description = "B"
Me.gridControl1(0,2).CellAppearance = GridCellAppearance.Raised
```

## GridDataBoundGrid:

To put a <b>CheckBox</b> in the <b>GridDataBoundGrid</b>, two events have to be used. The <b>QueryCellInfo</b> event is used to set the <b>style</b> properties and the <b>SaveCellInfo</b> event is used to save the cell's value. The value of the <b>CheckBox</b> cannot be stored in the <b>GridDataBoundGrid</b>, so any datatype/collection can be used to store the value. The <b>CheckBoxClick</b> event gets triggered when the <b>CheckBox</b> is clicked. In the following code example, the <b>CheckBox</b> is added to the Column header on the <b>GridDataBoundGrid</b>.

## C#

```C#
private bool CheckBoxValue = false;   
private void Model_QueryCellInfo(object sender, GridQueryCellInfoEventArgs e)
{
   if(e.ColIndex > 0 && e.RowIndex == 0)
   {
      int colIndex1 = this.gridDataBoundGrid1.Binder.NameToColIndex("Column2");
      if(colIndex1 == e.ColIndex)
      {
         e.Style.Description = "Check";
         e.Style.CellValue = CheckBoxValue;
         e.Style.CellValueType = typeof(bool);
         e.Style.CheckBoxOptions = new GridCheckBoxCellInfo(true.ToString(), false.ToString(), "", true);
         e.Style.CellType = "CheckBox";
         e.Style.CellAppearance = GridCellAppearance.Raised;
         e.Style.Enabled = true;
      }
   }
}
private void Model_SaveCellInfo(object sender, GridSaveCellInfoEventArgs e)
{
   if(e.ColIndex > 0 && e.RowIndex == 0)
   {
      int colIndex1 = this.gridDataBoundGrid1.Binder.NameToColIndex("Column2");
      if(colIndex1 == e.ColIndex)
      {
         if(e.Style.CellValue != null)
  CheckBoxValue = (bool)e.Style.CellValue;
      }
   }
}
```

## VB

```VB
Private CheckBoxValue As Boolean = False
Private Sub Model_QueryCellInfo(ByVal sender As Object, ByVal e As GridQueryCellInfoEventArgs)
  If e.ColIndex > 0 AndAlso e.RowIndex = 0 Then
    Dim colIndex1 As Integer = Me.gridDataBoundGrid1.Binder.NameToColIndex("Column2")
    If colIndex1 = e.ColIndex Then
      e.Style.Description = "Check"
      e.Style.CellValue = CheckBoxValue
      e.Style.CellValueType = GetType(Boolean)
      e.Style.CheckBoxOptions = New GridCheckBoxCellInfo(True.ToString(), False.ToString(), "", True)
      e.Style.CellType = "CheckBox"
      e.Style.CellAppearance = GridCellAppearance.Raised
      e.Style.Enabled = True
    End If
  End If
End Sub
Private Sub Model_SaveCellInfo(ByVal sender As Object, ByVal e As GridSaveCellInfoEventArgs)
  If e.ColIndex > 0 AndAlso e.RowIndex = 0 Then
    Dim colIndex1 As Integer = Me.gridDataBoundGrid1.Binder.NameToColIndex("Column2")
    If colIndex1 = e.ColIndex Then
      If e.Style.CellValue IsNot Nothing Then
        CheckBoxValue = CBool(e.Style.CellValue)
      End If
    End If
  End If
End Sub
```
