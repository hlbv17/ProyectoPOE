
namespace Visual
{
    partial class Frm_Odontologo_Registrar
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.dgvHorarioOdontologo = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colentrsa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colsalida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCedula = new System.Windows.Forms.TextBox();
            this.textNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbSexo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbConsultorio = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.cmbEspecialidad = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHorarioOdontologo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSeleccionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccionar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSeleccionar.Location = new System.Drawing.Point(511, 70);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(126, 33);
            this.btnSeleccionar.TabIndex = 0;
            this.btnSeleccionar.Text = "Seleccionar";
            this.btnSeleccionar.UseVisualStyleBackColor = false;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // dgvHorarioOdontologo
            // 
            this.dgvHorarioOdontologo.AllowUserToAddRows = false;
            this.dgvHorarioOdontologo.AllowUserToDeleteRows = false;
            this.dgvHorarioOdontologo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHorarioOdontologo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.colentrsa,
            this.colsalida});
            this.dgvHorarioOdontologo.Location = new System.Drawing.Point(424, 113);
            this.dgvHorarioOdontologo.MultiSelect = false;
            this.dgvHorarioOdontologo.Name = "dgvHorarioOdontologo";
            this.dgvHorarioOdontologo.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHorarioOdontologo.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHorarioOdontologo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvHorarioOdontologo.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHorarioOdontologo.RowTemplate.Height = 24;
            this.dgvHorarioOdontologo.Size = new System.Drawing.Size(525, 215);
            this.dgvHorarioOdontologo.TabIndex = 8;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Tipo de jornada";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Dia";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 125;
            // 
            // colentrsa
            // 
            this.colentrsa.HeaderText = "Hora de Entrada";
            this.colentrsa.MinimumWidth = 6;
            this.colentrsa.Name = "colentrsa";
            this.colentrsa.ReadOnly = true;
            this.colentrsa.Width = 125;
            // 
            // colsalida
            // 
            this.colsalida.HeaderText = "Hora de Salida";
            this.colsalida.MinimumWidth = 6;
            this.colsalida.Name = "colsalida";
            this.colsalida.ReadOnly = true;
            this.colsalida.Width = 125;
            // 
            // txtCedula
            // 
            this.txtCedula.Location = new System.Drawing.Point(121, 70);
            this.txtCedula.MaxLength = 10;
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(243, 22);
            this.txtCedula.TabIndex = 10;
            this.txtCedula.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCedula_KeyPress);
            // 
            // textNombre
            // 
            this.textNombre.Location = new System.Drawing.Point(121, 110);
            this.textNombre.MaxLength = 50;
            this.textNombre.Name = "textNombre";
            this.textNombre.Size = new System.Drawing.Size(243, 22);
            this.textNombre.TabIndex = 10;
            this.textNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textNombre_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "Cedula";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "Nombre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 276);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "Sexo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 233);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 17);
            this.label4.TabIndex = 14;
            this.label4.Text = "Fecha de nacimiento";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(47, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 17);
            this.label5.TabIndex = 15;
            this.label5.Text = "Correo";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(48, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 17);
            this.label6.TabIndex = 16;
            this.label6.Text = "Telefono";
            // 
            // cmbSexo
            // 
            this.cmbSexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSexo.FormattingEnabled = true;
            this.cmbSexo.Items.AddRange(new object[] {
            "F",
            "M"});
            this.cmbSexo.Location = new System.Drawing.Point(143, 273);
            this.cmbSexo.Name = "cmbSexo";
            this.cmbSexo.Size = new System.Drawing.Size(221, 24);
            this.cmbSexo.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(440, 351);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 17);
            this.label7.TabIndex = 18;
            this.label7.Text = "Presentar Datos";
            // 
            // txtCorreo
            // 
            this.txtCorreo.Location = new System.Drawing.Point(121, 147);
            this.txtCorreo.MaxLength = 60;
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(243, 22);
            this.txtCorreo.TabIndex = 19;
            this.txtCorreo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCorreo_KeyPress);
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(121, 189);
            this.txtTelefono.MaxLength = 10;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(243, 22);
            this.txtTelefono.TabIndex = 20;
            this.txtTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelefono_KeyPress);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(198, 233);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(166, 22);
            this.dateTimePicker1.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(53, 316);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 17);
            this.label8.TabIndex = 22;
            this.label8.Text = "Consultorio";
            // 
            // cmbConsultorio
            // 
            this.cmbConsultorio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbConsultorio.FormattingEnabled = true;
            this.cmbConsultorio.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.cmbConsultorio.Location = new System.Drawing.Point(143, 316);
            this.cmbConsultorio.Name = "cmbConsultorio";
            this.cmbConsultorio.Size = new System.Drawing.Size(221, 24);
            this.cmbConsultorio.TabIndex = 23;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(421, 78);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 17);
            this.label9.TabIndex = 24;
            this.label9.Text = "Horario";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(339, 417);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(222, 44);
            this.btnGuardar.TabIndex = 25;
            this.btnGuardar.Text = "Guardar Datos";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // cmbEspecialidad
            // 
            this.cmbEspecialidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEspecialidad.FormattingEnabled = true;
            this.cmbEspecialidad.Items.AddRange(new object[] {
            "Ortodoncia",
            "Peridoncia",
            "Endodoncia",
            "Odontopediatría"});
            this.cmbEspecialidad.Location = new System.Drawing.Point(143, 353);
            this.cmbEspecialidad.Name = "cmbEspecialidad";
            this.cmbEspecialidad.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbEspecialidad.Size = new System.Drawing.Size(221, 24);
            this.cmbEspecialidad.TabIndex = 27;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(53, 353);
            this.label10.Name = "label10";
            this.label10.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label10.Size = new System.Drawing.Size(88, 17);
            this.label10.TabIndex = 26;
            this.label10.Text = "Especialidad";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Lucida Fax", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(274, 25);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(394, 22);
            this.label11.TabIndex = 28;
            this.label11.Text = "INGRESO DE DATOS DEL ODONTOLOGO";
            // 
            // Frm_Odontologo_Registrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 484);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cmbEspecialidad);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbConsultorio);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.txtCorreo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbSexo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textNombre);
            this.Controls.Add(this.txtCedula);
            this.Controls.Add(this.dgvHorarioOdontologo);
            this.Controls.Add(this.btnSeleccionar);
            this.Name = "Frm_Odontologo_Registrar";
            this.Text = "FrmOdontologo";
            ((System.ComponentModel.ISupportInitialize)(this.dgvHorarioOdontologo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSeleccionar;
        private System.Windows.Forms.DataGridView dgvHorarioOdontologo;
        private System.Windows.Forms.TextBox txtCedula;
        private System.Windows.Forms.TextBox textNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbSexo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbConsultorio;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.ComboBox cmbEspecialidad;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colentrsa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colsalida;
        private System.Windows.Forms.Label label11;
    }
}