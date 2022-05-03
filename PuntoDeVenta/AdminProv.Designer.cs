namespace PuntoDeVenta
{
    partial class AdminProv
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtNOM = new System.Windows.Forms.TextBox();
            this.btnAddProv = new System.Windows.Forms.Button();
            this.btnEditProv = new System.Windows.Forms.Button();
            this.btnDelProv = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 319);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Id del proveedor:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 352);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre proveedor: ";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(527, 285);
            this.dataGridView1.TabIndex = 3;
            // 
            // txtID
            // 
            this.txtID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.Location = new System.Drawing.Point(142, 316);
            this.txtID.Margin = new System.Windows.Forms.Padding(2);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(194, 26);
            this.txtID.TabIndex = 4;
            this.txtID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtID.TextChanged += new System.EventHandler(this.txtID_TextChanged);
            // 
            // txtNOM
            // 
            this.txtNOM.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNOM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNOM.Location = new System.Drawing.Point(163, 349);
            this.txtNOM.Margin = new System.Windows.Forms.Padding(2);
            this.txtNOM.Name = "txtNOM";
            this.txtNOM.Size = new System.Drawing.Size(194, 26);
            this.txtNOM.TabIndex = 5;
            this.txtNOM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnAddProv
            // 
            this.btnAddProv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddProv.BackColor = System.Drawing.Color.AliceBlue;
            this.btnAddProv.Enabled = false;
            this.btnAddProv.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnAddProv.Location = new System.Drawing.Point(15, 391);
            this.btnAddProv.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddProv.Name = "btnAddProv";
            this.btnAddProv.Size = new System.Drawing.Size(178, 32);
            this.btnAddProv.TabIndex = 23;
            this.btnAddProv.Text = "Agregar producto nuevo";
            this.btnAddProv.UseVisualStyleBackColor = false;
            this.btnAddProv.Click += new System.EventHandler(this.btnAddProv_Click);
            // 
            // btnEditProv
            // 
            this.btnEditProv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditProv.BackColor = System.Drawing.Color.AliceBlue;
            this.btnEditProv.Enabled = false;
            this.btnEditProv.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnEditProv.Location = new System.Drawing.Point(197, 391);
            this.btnEditProv.Margin = new System.Windows.Forms.Padding(2);
            this.btnEditProv.Name = "btnEditProv";
            this.btnEditProv.Size = new System.Drawing.Size(139, 32);
            this.btnEditProv.TabIndex = 24;
            this.btnEditProv.Text = "Editar proveedor";
            this.btnEditProv.UseVisualStyleBackColor = false;
            this.btnEditProv.Click += new System.EventHandler(this.btnEditProv_Click);
            // 
            // btnDelProv
            // 
            this.btnDelProv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelProv.BackColor = System.Drawing.Color.AliceBlue;
            this.btnDelProv.Enabled = false;
            this.btnDelProv.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnDelProv.Location = new System.Drawing.Point(340, 391);
            this.btnDelProv.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelProv.Name = "btnDelProv";
            this.btnDelProv.Size = new System.Drawing.Size(178, 32);
            this.btnDelProv.TabIndex = 25;
            this.btnDelProv.Text = "Borrar proveedor";
            this.btnDelProv.UseVisualStyleBackColor = false;
            this.btnDelProv.Click += new System.EventHandler(this.btnDelProv_Click);
            // 
            // AdminProv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 434);
            this.Controls.Add(this.btnDelProv);
            this.Controls.Add(this.btnEditProv);
            this.Controls.Add(this.btnAddProv);
            this.Controls.Add(this.txtNOM);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AdminProv";
            this.Text = "AdminProv";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtNOM;
        private System.Windows.Forms.Button btnAddProv;
        private System.Windows.Forms.Button btnEditProv;
        private System.Windows.Forms.Button btnDelProv;
    }
}