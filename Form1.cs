using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Syncfusion.Windows.Forms.Grid;
using Syncfusion.Drawing;

namespace GDBG_checkbox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.gridDataBoundGrid1.DataSource = GetTable();
            this.gridDataBoundGrid1[0, 2].CellType = GridCellTypeName.PushButton;
            this.gridDataBoundGrid1[0, 3].CellType = GridCellTypeName.RadioButton;
        }
        private DataTable GetTable()
        {
            DataTable dt = new DataTable("MyTable");
            dt.Columns.Add(" ", typeof(bool));            
            for (int i = 1; i < 6; i++)
                dt.Columns.Add(new DataColumn("Col" + i.ToString(), typeof(int)));

            for (int k = 1; k < 10; k++)
            {
                DataRow row = dt.NewRow();
                row[0] = true;
                row[2] = 4*k;
                dt.Rows.Add(row);
            }
            return dt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.gridDataBoundGrid1.DataSource = GetTable();
            this.gridDataBoundGrid1.ThemesEnabled = true;
            gridDataBoundGrid1.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2003;
            this.gridDataBoundGrid1.Model.Cols.DefaultSize = 100;           
            this.gridDataBoundGrid1.Binder.DirectSaveCellInfo = true;            
            this.gridDataBoundGrid1.Controls.Add(checkBox);
            checkBox.Show();
            checkBox.CheckedChanged += new EventHandler(checkBox_CheckedChanged);
            this.gridDataBoundGrid1.Layout += new LayoutEventHandler(gridDataBoundGrid1_Layout);
            this.gridDataBoundGrid1.ResizingRows += new GridResizingRowsEventHandler(gridDataBoundGrid1_ResizingRows);
            this.gridDataBoundGrid1.ResizingColumns += new GridResizingColumnsEventHandler(gridDataBoundGrid1_ResizingColumns);
        }

        void gridDataBoundGrid1_ResizingRows(object sender, GridResizingRowsEventArgs e)
        {
            this.gridDataBoundGrid1.BeginUpdate();
            SetupCheckBox();
            this.gridDataBoundGrid1.EndUpdate();
            this.gridDataBoundGrid1.Refresh();
        }

        void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            int col = 1;
            for (int row = 1; row < 10; row++)
            {
                if (count % 2 == 0)//Allows if checked stated of header cell is true 
                {
                    if (gridDataBoundGrid1[row, col].CellType == GridCellTypeName.CheckBox)
                    {
                        gridDataBoundGrid1[row, col].CellValue = 1;//checks all the check boxes to true 
                    }
                }
                else if (gridDataBoundGrid1[row, col].CellType == GridCellTypeName.CheckBox)//Allows if checked state is false
                {
                    gridDataBoundGrid1[row, col].CellValue = 0;//unchecks all the check boxes
                }
            }
            count++;//increment count for every header cell check.            
        }

        void gridDataBoundGrid1_ResizingColumns(object sender, GridResizingColumnsEventArgs e)
        {
            this.gridDataBoundGrid1.BeginUpdate();
            SetupCheckBox();
            this.gridDataBoundGrid1.EndUpdate();
            this.gridDataBoundGrid1.Model.Refresh();
        }

        private void SetupCheckBox()
        {
            Rectangle cellRect = this.gridDataBoundGrid1.ViewLayout.RangeInfoToRectangle(GridRangeInfo.Cell(0, 1), GridCellSizeKind.ActualSize);
            checkBox.Location = new Point(cellRect.X + cellRect.Width / 2 - 13 / 2, cellRect.Y + cellRect.Height / 2 - 13 / 2);// cellRect.Location;
            checkBox.Size = new Size(13, 13);
        }

        void gridDataBoundGrid1_Layout(object sender, LayoutEventArgs e)
        {
            SetupCheckBox();
        }
        CheckBox checkBox = new CheckBox();     
        int count = 2;
    }
}
