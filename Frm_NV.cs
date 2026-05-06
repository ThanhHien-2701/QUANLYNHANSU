using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUANLYNHANSU
{
    public partial class Frm_NV : Form
    {
        // ==================== AUTO RESIZE ====================
        Dictionary<Control, Rectangle> originalControlBounds = new Dictionary<Control, Rectangle>();
        Rectangle originalFormSize;
        // =====================================================
        public Frm_NV()
        {
            InitializeComponent();

        }
        // ==================== AUTO RESIZE ====================
        private void StoreOriginalSizes(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                originalControlBounds[c] = c.Bounds;
                if (c.Controls.Count > 0)
                    StoreOriginalSizes(c);
            }
        }

        private void ResizeAllControls(Control parent)
        {
            float xRatio = (float)this.Width / originalFormSize.Width;
            float yRatio = (float)this.Height / originalFormSize.Height;

            foreach (Control c in parent.Controls)
            {
                if (!originalControlBounds.ContainsKey(c))
                    continue;
                Rectangle original = originalControlBounds[c];
                c.SetBounds(
                    (int)(original.X * xRatio),
                    (int)(original.Y * yRatio),
                    (int)(original.Width * xRatio),
                    (int)(original.Height * yRatio)
                );

                if (c.Controls.Count > 0)
                    ResizeAllControls(c);
            }
        }

        private void Frm_Resize(object sender, EventArgs e)
        {
            if (DesignMode) return;
            ResizeAllControls(this);
        }
        private void LoadFormToPanel(Form form, bool center = false)
        {
            panelFather.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.StartPosition = FormStartPosition.Manual;
            panelFather.Controls.Add(form);

            form.Show(); // BẮT BUỘC phải Show trước!

            if (center)
            {
                // Delay lại một vòng UI để form vẽ xong
                form.BeginInvoke(new Action(() =>
                {
                    int x = (panelFather.Width - form.Width) / 2;
                    int y = panelFather.Location.Y - 120;

                    // Tránh giá trị âm
                    form.Location = new Point(Math.Max(x, 0), Math.Max(y, 0));
                }));
            }
        }

        // -----------------------------
        // MENU CLICK → LOAD FORM
        // -----------------------------
        /*private void PhòngBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadFormToPanel(new Frm_PhongBan_NV());
        }

        private void chấmCôngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadFormToPanel(new FrmChamCong());
        }

        private void lươngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadFormToPanel(new FrmLuong());
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void đợtPhỏngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadFormToPanel(new FrmPhongVan());
        }

        private void ứngViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadFormToPanel(new FrmUngVien());
        }

        private void nhânviênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNhanVien frm = new FrmNhanVien();
            frm.ShowPathLabel = false;  // Ẩn label trước khi load vào panel
            LoadFormToPanel(frm);
        }*/

        private void Frm_NV_Load(object sender, EventArgs e)
        {
            // ==================== AUTO RESIZE ====================
            if (DesignMode) return;

            originalFormSize = this.Bounds;
            StoreOriginalSizes(this);
            this.Resize += Frm_Resize;
            // =====================================================
            // Maximized form
            this.WindowState = FormWindowState.Maximized;

            // Auto scroll
            this.AutoScroll = true;
        }
        public interface IResizableForm
        {
            void InitializeResize(Rectangle parentBounds);
        }

        private Form currentFormChild;
        private void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close(); // Đóng form con hiện tại nếu có
            }

            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            panelFather.Controls.Add(childForm);
            panelFather.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

            if (childForm is IResizableForm resizable)
                resizable.InitializeResize(panelFather.Bounds);

        }

      
        
        private void PhòngBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_PhongBan_NV());
        }

        private void chấmCôngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmChamCong());
        }

        private void lươngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmLuong());
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void đợtPhỏngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmPhongVan());
        }

        private void ứngViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmUngVien());
        }

        private void nhânviênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNhanVien frm = new FrmNhanVien();
            frm.ShowPathLabel = false;  // Ẩn label trước khi load vào panel
            LoadFormToPanel(frm);
        }

        private void khenThưởngKỷLuậtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmKhenThuongKyLuat());
        }
    }
}
