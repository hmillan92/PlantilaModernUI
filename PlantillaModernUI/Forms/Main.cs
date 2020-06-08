using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
using Forms.MenuForms;

namespace Forms
{
    public partial class Main : Form
    {
        //Fields
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;

        //Constructor
        public Main()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderBtn);
            OpenChildForm(new Login());

        }

        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
        }

        //Methods
        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                //Button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
              //  currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
               // currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
              //  currentBtn.ImageAlign = ContentAlignment.MiddleRight;

                //left border button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();

                //Icon Current Child Form
                iconCurrentChildForm.IconChar = currentBtn.IconChar;
                iconCurrentChildForm.IconColor = color;
            }
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                //Button
                currentBtn.BackColor = Color.FromArgb(31, 30, 68);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;

            //Icon Current Child Form
            iconCurrentChildForm.IconChar = IconChar.Home;
            iconCurrentChildForm.IconColor = Color.MediumPurple;
            lblTitleChildForm.Text = "Home";
        }

        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }

            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitleChildForm.Text = childForm.Text;
        }
        private void iconButton1_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new FormDashboard());
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            OpenChildForm(new FormOrders());
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
            OpenChildForm(new FormProducts());
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color4);
            OpenChildForm(new FormCustomers());
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color5);
            OpenChildForm(new FormMarketing());
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color6);
            OpenChildForm(new FormSettings());
        }

        private void pbHome_Click(object sender, EventArgs e)
        {
            currentChildForm.Close();
            Reset();
        }

        //DragForm

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }


        int LX, LY;
        private void btnMaximize_Click(object sender, EventArgs e)
        {
            //maximizar ocultando la barra de tareas
            //WindowState = FormWindowState.Maximized;

            LX = this.Location.X;
            LY = this.Location.Y;

            //maximizar sin ocultar la barra de tareas
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            btnMaximize.Visible = false;
            btnRestore.Visible = true;
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            //WindowState = FormWindowState.Normal;

            this.Size = new Size(800,592);
            this.Location = new Point(LX, LY);
            btnRestore.Visible = false;
            btnMaximize.Visible = true;
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            List<CheckBox> checkedList = new List<CheckBox>();
            checkedList.Add(chbDashboard);
            checkedList.Add(chbOrders);
            checkedList.Add(chbProducts);
            checkedList.Add(chbCustomers);
            checkedList.Add(chbMarketing);

            List<Button> button = new List<Button>();
            button.Add(iconButton1);
            button.Add(iconButton2);
            button.Add(iconButton3);
            button.Add(iconButton4);
            button.Add(iconButton5);

            int count = 0;

            foreach (var item in checkedList)
            {
                
                if (item.Checked == true)
                {

                    Button a = (Button)button.ElementAt(count);
                    a.Visible = true;
                    count++;
                }

                else
                {
                    Button a = (Button)button.ElementAt(count);
                    a.Visible = false;
                    count++;
                }
                           
            }
            
        }

        private void btnBars_Click(object sender, EventArgs e)
        {
            if (panelMenu.Width == 200)
            {
                panelMenu.Width = 53;

                iconButton1.Text = String.Empty;
                iconButton2.Text = String.Empty;
                iconButton3.Text = String.Empty;
                iconButton4.Text = String.Empty;
                iconButton5.Text = String.Empty;
                iconButton6.Text = String.Empty;
            }

            else
            {
                panelMenu.Width = 200;

                iconButton1.Text = "Dashboard";
                iconButton2.Text = "Orders";
                iconButton3.Text = "Products";
                iconButton4.Text = "Customers";
                iconButton5.Text = "Marketing";
                iconButton6.Text = "Settings";
            }
        }
    }
}