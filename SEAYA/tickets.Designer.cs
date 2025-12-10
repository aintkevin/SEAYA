namespace SEAYA
{
    partial class tickets
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTickets = new System.Windows.Forms.Label();
            this.lbltrips = new System.Windows.Forms.Label();
            this.lblProfile = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvTickets = new System.Windows.Forms.DataGridView();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTickets)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel2.Controls.Add(this.button3);
            this.panel2.Location = new System.Drawing.Point(4, 480);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(974, 70);
            this.panel2.TabIndex = 25;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(850, 16);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 38);
            this.button3.TabIndex = 10;
            this.button3.Text = "Log Out";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Showcard Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label5.Location = new System.Drawing.Point(628, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 35);
            this.label5.TabIndex = 3;
            this.label5.Text = "|";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Showcard Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label4.Location = new System.Drawing.Point(329, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 35);
            this.label4.TabIndex = 2;
            this.label4.Text = "|";
            // 
            // lblTickets
            // 
            this.lblTickets.AutoSize = true;
            this.lblTickets.Font = new System.Drawing.Font("Showcard Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTickets.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblTickets.Location = new System.Drawing.Point(723, 16);
            this.lblTickets.Name = "lblTickets";
            this.lblTickets.Size = new System.Drawing.Size(134, 35);
            this.lblTickets.TabIndex = 1;
            this.lblTickets.Text = "tickets";
            // 
            // lbltrips
            // 
            this.lbltrips.AutoSize = true;
            this.lbltrips.Font = new System.Drawing.Font("Showcard Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltrips.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbltrips.Location = new System.Drawing.Point(436, 16);
            this.lbltrips.Name = "lbltrips";
            this.lbltrips.Size = new System.Drawing.Size(100, 35);
            this.lbltrips.TabIndex = 1;
            this.lbltrips.Text = "trips";
            this.lbltrips.Click += new System.EventHandler(this.lbltrips_Click);
            // 
            // lblProfile
            // 
            this.lblProfile.AutoSize = true;
            this.lblProfile.Font = new System.Drawing.Font("Showcard Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProfile.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblProfile.Location = new System.Drawing.Point(104, 16);
            this.lblProfile.Name = "lblProfile";
            this.lblProfile.Size = new System.Drawing.Size(137, 35);
            this.lblProfile.TabIndex = 0;
            this.lblProfile.Text = "Profile";
            this.lblProfile.Click += new System.EventHandler(this.lblProfile_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lblTickets);
            this.panel1.Controls.Add(this.lbltrips);
            this.panel1.Controls.Add(this.lblProfile);
            this.panel1.Location = new System.Drawing.Point(4, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(974, 70);
            this.panel1.TabIndex = 24;
            // 
            // dgvTickets
            // 
            this.dgvTickets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTickets.Location = new System.Drawing.Point(12, 148);
            this.dgvTickets.Name = "dgvTickets";
            this.dgvTickets.RowHeadersWidth = 51;
            this.dgvTickets.RowTemplate.Height = 24;
            this.dgvTickets.Size = new System.Drawing.Size(958, 247);
            this.dgvTickets.TabIndex = 26;
            // 
            // tickets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 553);
            this.Controls.Add(this.dgvTickets);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "tickets";
            this.Text = "tickets";
            this.Load += new System.EventHandler(this.tickets_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTickets)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTickets;
        private System.Windows.Forms.Label lbltrips;
        private System.Windows.Forms.Label lblProfile;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvTickets;
    }
}