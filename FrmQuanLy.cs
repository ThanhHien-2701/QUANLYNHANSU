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
    public partial class FrmQuanLy : Form
    {
        private List<Image> images;
        private int currentIndex = 0;
        // ==================== AUTO RESIZE ====================
        Dictionary<Control, Rectangle> originalControlBounds = new Dictionary<Control, Rectangle>();
        Rectangle originalFormSize;
        // =====================================================
        public FrmQuanLy()
        {
            InitializeComponent();
            images = new List<Image>
        {
            Properties.Resources.img1,
            Properties.Resources.img2,
            Properties.Resources.img3,
            Properties.Resources.img4,
            Properties.Resources.img5,
        };
            Topic.BackgroundImage = images[currentIndex];
            Topic.BackgroundImageLayout = ImageLayout.Stretch;

            timer1.Interval = 3000;
            timer1.Tick += Timer1_Tick;
            timer1.Start();
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

        private void FrmQL_Resize(object sender, EventArgs e)
        {
            if (DesignMode) return;
            ResizeAllControls(this);
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            ShowNextImage();
        }
        private void ShowNextImage()
        {

            currentIndex++;
            if (currentIndex >= images.Count)
            {
                currentIndex = 0;
            }
            Topic.BackgroundImage = images[currentIndex];
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            ShowNextImage();
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
        private void PhongBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmPhongBan_QL());
        }

        private void HDLDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmHDLD());
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TuyenDungToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmTuyenDung());
        }

        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {

            OpenChildForm(new FrmTaiKhoan());

        }

        private void nghỉPhépToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmNghiPhep());
        }

        private void tieuChiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmTieuChi());
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmNhanVien());
        }

        private void backupDữLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBackup form = new FrmBackup();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void FrmQuanLy_Load(object sender, EventArgs e)
        {
            // ==================== AUTO RESIZE ====================
            if (DesignMode) return;

            originalFormSize = this.Bounds;
            StoreOriginalSizes(this);
            this.Resize += FrmQL_Resize;
            // =====================================================
            this.AutoScroll = true;
        }
    }
}
