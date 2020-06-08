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
            leftBorderBtn.Size = new Size(7, 40);
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
            public static Color color7 = Color.FromArgb(255, 87, 51);
            public static Color color8 = Color.FromArgb(153, 137, 133);
            public static Color color9 = Color.FromArgb(192, 201, 247);
            public static Color color10 = Color.FromArgb(249, 249, 8);
            public static Color color11 = Color.FromArgb(0, 250, 246);
            public static Color color12 = Color.FromArgb(250, 0, 42);
            public static Color color13 = Color.FromArgb(45, 114, 244);
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
                //currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                //currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                //currentBtn.ImageAlign = ContentAlignment.MiddleRight;

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
            button.Add(btnContabilidad);
            button.Add(btnVenta);
            button.Add(btnProducto);
            button.Add(btnCliente);
            button.Add(btnVendedor);

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

        private void btnContabilidad_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new FormContabilidad());
        }

        private void btnVenta_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            OpenChildForm(new FormVenta());
        }

        private void btnProducto_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
            OpenChildForm(new FormProducto());
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color4);
            OpenChildForm(new FormCliente());
        }

        private void btnVendedor_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color5);
            OpenChildForm(new FormVendedor());
        }

        private void btnProveedor_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color6);
            OpenChildForm(new FormProveedor());
        }

        private void btnAlmacen_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color7);
        }

        private void btnTransporte_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color8);
        }

        private void btnBanco_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color9);
        }

        private void btnCaja_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color10);
        }

        private void btnListaPrecio_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color11);
        }

        private void btnDispositivo_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color12);
        }

        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color13);
        }

        private void btnBars_Click(object sender, EventArgs e)
        {
            if (panelMenu.Width == 200)
            {
                panelMenu.Width = 53;

                btnContabilidad.Text = String.Empty;
                btnVenta.Text = String.Empty;
                btnProducto.Text = String.Empty;
                btnCliente.Text = String.Empty;
                btnVendedor.Text = String.Empty;
                btnProveedor.Text = String.Empty;
                btnAlmacen.Text = String.Empty;
                btnTransporte.Text = String.Empty;
                btnBanco.Text = String.Empty;
                btnCaja.Text = String.Empty;
                btnListaPrecio.Text = String.Empty;
                btnDispositivo.Text = String.Empty;
                btnConfiguracion.Text = String.Empty;
            }

            else
            {
                panelMenu.Width = 200;

                btnContabilidad.Text = "Contabilidad";
                btnVenta.Text = "Venta";
                btnProducto.Text = "Productos";
                btnCliente.Text = "Clientes";
                btnVendedor.Text = "Vendedores";
                btnProveedor.Text = "Proveedores";
                btnAlmacen.Text = "Almacenes";
                btnTransporte.Text = "Transporte";
                btnBanco.Text = "Banco";
                btnCaja.Text = "Caja";
                btnListaPrecio.Text = "Lista de Precios";
                btnDispositivo.Text = "Dispositivos";
                btnConfiguracion.Text = "Configuracion";
            }
        }
    }
}