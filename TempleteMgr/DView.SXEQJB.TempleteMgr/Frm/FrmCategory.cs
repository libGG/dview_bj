// created by lib
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DView.SXEQJB.TempleteMgr.Dal;

namespace DView.SXEQJB.TempleteMgr
{
    /// <summary>
    /// 类别管理
    /// </summary>
    public partial class FrmCategory : DevExpress.XtraEditors.XtraForm
    {
        private SXEQ_JBLB_DAL _JBLB_DAL = new SXEQ_JBLB_DAL();

        public FrmCategory()
        {
            InitializeComponent();
            // 设置数据列表控件隔行变色
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.FromArgb(237, 243, 254);
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(199, 237, 204);
        }

        private void FrmCategory_Load(object sender, EventArgs e)
        {
            this.loadData();
        }

        private void loadData()
        {
            dataGridView1.DataSource = this._JBLB_DAL.GetAllList().Tables[0];
            if (dataGridView1.Columns.Count > 0)
            {
                dataGridView1.Columns["fguid"].Visible = false;
                dataGridView1.Columns["name"].HeaderText = "名称";
                dataGridView1.Columns["memo"].HeaderText = "说明";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                add();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("添加失败：\r\n{0}",ex));
                return;
            }
            loadData();
            MessageBox.Show("添加成功");
            txtMemo.Text = "";
            txtName.Text = "";
        }

        private void add()
        {
            try
            {
                SXEQ_JBLB model = new SXEQ_JBLB();
                model.fguid = Guid.NewGuid().ToString("D");
                model.memo = txtMemo.Text.Trim();
                model.name = txtName.Text.Trim();
                this._JBLB_DAL.Add(model);
            }
            catch (Exception ex)
            {                
                throw ex;
            }           
        }

        private void del()
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataGridViewRow var in dataGridView1.SelectedRows)
            {
                sb.Append(",'"+var.Cells["fguid"].Value.ToString()+"'");
            }
            string sql = string.Format("fguid in({0})", sb.ToString().Trim(','));
            this._JBLB_DAL.DeleteList(sql);
        }

        private void update(string guid)
        {
            SXEQ_JBLB model = new SXEQ_JBLB();
            model.fguid = guid;
            model.memo = txtMemo.Text.Trim();
            model.name = txtName.Text.Trim();
            this._JBLB_DAL.Update(model);
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0)
            {
                MessageBox.Show("没选中记录"); return;
            }
            try
            {
                del();
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除失败：\r\n{0}",ex.ToString());
            }
            MessageBox.Show("删除成功");
            this.loadData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0)
            {
                MessageBox.Show("没选中记录"); return;
            }
            if (dataGridView1.SelectedRows.Count != 1 )
            {
                MessageBox.Show("只能选中一行，才能做更新操作"); return;
            }
            string guid = dataGridView1.SelectedRows[0].Cells["fguid"].Value.ToString();
            try
            {
                this.update(guid);
            }
            catch (Exception ex)
            {
                MessageBox.Show("更新失败：\r\n{0}", ex.ToString()); return;
            }
            MessageBox.Show("更新成功");
            loadData();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0) return;
            txtMemo.Text = dataGridView1.SelectedRows[0].Cells["memo"].Value.ToString();
            txtName.Text = dataGridView1.SelectedRows[0].Cells["name"].Value.ToString();
        }

    }
}