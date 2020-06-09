namespace Forms.MenuForms
{
    partial class FormConfiguracion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblConfiguration = new System.Windows.Forms.Label();
            this.btnPlay = new FontAwesome.Sharp.IconButton();
            this.txtCod1 = new System.Windows.Forms.TextBox();
            this.txtCod2 = new System.Windows.Forms.TextBox();
            this.txtCod3 = new System.Windows.Forms.TextBox();
            this.txtCod4 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblConfiguration
            // 
            this.lblConfiguration.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblConfiguration.AutoSize = true;
            this.lblConfiguration.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfiguration.Location = new System.Drawing.Point(289, 153);
            this.lblConfiguration.Name = "lblConfiguration";
            this.lblConfiguration.Size = new System.Drawing.Size(181, 26);
            this.lblConfiguration.TabIndex = 1;
            this.lblConfiguration.Text = "Codigo de Licencia";
            this.lblConfiguration.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnPlay
            // 
            this.btnPlay.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnPlay.BackColor = System.Drawing.Color.Gainsboro;
            this.btnPlay.FlatAppearance.BorderSize = 0;
            this.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlay.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnPlay.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlay.ForeColor = System.Drawing.Color.Gray;
            this.btnPlay.IconChar = FontAwesome.Sharp.IconChar.Play;
            this.btnPlay.IconColor = System.Drawing.Color.White;
            this.btnPlay.IconSize = 25;
            this.btnPlay.Location = new System.Drawing.Point(350, 236);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Rotation = 0D;
            this.btnPlay.Size = new System.Drawing.Size(54, 29);
            this.btnPlay.TabIndex = 7;
            this.btnPlay.UseVisualStyleBackColor = false;
            // 
            // txtCod1
            // 
            this.txtCod1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtCod1.Location = new System.Drawing.Point(219, 192);
            this.txtCod1.Name = "txtCod1";
            this.txtCod1.Size = new System.Drawing.Size(74, 20);
            this.txtCod1.TabIndex = 8;
            // 
            // txtCod2
            // 
            this.txtCod2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtCod2.Location = new System.Drawing.Point(299, 192);
            this.txtCod2.Name = "txtCod2";
            this.txtCod2.Size = new System.Drawing.Size(74, 20);
            this.txtCod2.TabIndex = 9;
            // 
            // txtCod3
            // 
            this.txtCod3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtCod3.Location = new System.Drawing.Point(379, 192);
            this.txtCod3.Name = "txtCod3";
            this.txtCod3.Size = new System.Drawing.Size(74, 20);
            this.txtCod3.TabIndex = 10;
            // 
            // txtCod4
            // 
            this.txtCod4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtCod4.Location = new System.Drawing.Point(459, 192);
            this.txtCod4.Name = "txtCod4";
            this.txtCod4.Size = new System.Drawing.Size(74, 20);
            this.txtCod4.TabIndex = 11;
            // 
            // FormConfiguracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 342);
            this.Controls.Add(this.txtCod4);
            this.Controls.Add(this.txtCod3);
            this.Controls.Add(this.txtCod2);
            this.Controls.Add(this.txtCod1);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.lblConfiguration);
            this.Name = "FormConfiguracion";
            this.Text = "Configuracion";
            this.Controls.SetChildIndex(this.lblConfiguration, 0);
            this.Controls.SetChildIndex(this.btnPlay, 0);
            this.Controls.SetChildIndex(this.txtCod1, 0);
            this.Controls.SetChildIndex(this.txtCod2, 0);
            this.Controls.SetChildIndex(this.txtCod3, 0);
            this.Controls.SetChildIndex(this.txtCod4, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblConfiguration;
        private FontAwesome.Sharp.IconButton btnPlay;
        private System.Windows.Forms.TextBox txtCod1;
        private System.Windows.Forms.TextBox txtCod2;
        private System.Windows.Forms.TextBox txtCod3;
        private System.Windows.Forms.TextBox txtCod4;
    }
}