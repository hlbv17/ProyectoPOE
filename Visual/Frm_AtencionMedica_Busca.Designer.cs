
namespace Visual {
    partial class Frm_AtencionMedica_Busca {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose ();
            }
            base.Dispose (disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent () {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grb_Fecha = new System.Windows.Forms.GroupBox();
            this.rdb_No = new System.Windows.Forms.RadioButton();
            this.rdb_Si = new System.Windows.Forms.RadioButton();
            this.btn_Reporte = new System.Windows.Forms.Button();
            this.btn_Eliminar = new System.Windows.Forms.Button();
            this.btn_Editar = new System.Windows.Forms.Button();
            this.btn_Limpiar = new System.Windows.Forms.Button();
            this.btn_Buscar = new System.Windows.Forms.Button();
            this.dtp_Fecha = new System.Windows.Forms.DateTimePicker();
            this.cmb_Paciente = new System.Windows.Forms.ComboBox();
            this.cmb_Hora = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_Total = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_AntencionMedica = new System.Windows.Forms.DataGridView();
            this.col_N = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_NHClinica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Paciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Odontologo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Consultorio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Hora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_NPiezaDental = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_CuadrantePieza = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_NombrePieza = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_MotivoConsulta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Diagnostico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grb_Fecha.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_AntencionMedica)).BeginInit();
            this.SuspendLayout();
            // 
            // grb_Fecha
            // 
            this.grb_Fecha.Controls.Add(this.rdb_No);
            this.grb_Fecha.Controls.Add(this.rdb_Si);
            this.grb_Fecha.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grb_Fecha.Location = new System.Drawing.Point(520, 11);
            this.grb_Fecha.Name = "grb_Fecha";
            this.grb_Fecha.Size = new System.Drawing.Size(160, 41);
            this.grb_Fecha.TabIndex = 30;
            this.grb_Fecha.TabStop = false;
            this.grb_Fecha.Text = "Incluir fecha en busqueda";
            // 
            // rdb_No
            // 
            this.rdb_No.AutoSize = true;
            this.rdb_No.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdb_No.Location = new System.Drawing.Point(99, 18);
            this.rdb_No.Name = "rdb_No";
            this.rdb_No.Size = new System.Drawing.Size(44, 17);
            this.rdb_No.TabIndex = 1;
            this.rdb_No.Text = "No.";
            this.rdb_No.UseVisualStyleBackColor = true;
            this.rdb_No.CheckedChanged += new System.EventHandler(this.rdb_Si_CheckedChanged);
            // 
            // rdb_Si
            // 
            this.rdb_Si.AutoSize = true;
            this.rdb_Si.Checked = true;
            this.rdb_Si.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdb_Si.Location = new System.Drawing.Point(6, 19);
            this.rdb_Si.Name = "rdb_Si";
            this.rdb_Si.Size = new System.Drawing.Size(37, 17);
            this.rdb_Si.TabIndex = 0;
            this.rdb_Si.TabStop = true;
            this.rdb_Si.Text = "Sí.";
            this.rdb_Si.UseVisualStyleBackColor = true;
            this.rdb_Si.CheckedChanged += new System.EventHandler(this.rdb_Si_CheckedChanged);
            // 
            // btn_Reporte
            // 
            this.btn_Reporte.BackColor = System.Drawing.Color.SlateGray;
            this.btn_Reporte.Enabled = false;
            this.btn_Reporte.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Reporte.ForeColor = System.Drawing.Color.White;
            this.btn_Reporte.Location = new System.Drawing.Point(520, 417);
            this.btn_Reporte.Name = "btn_Reporte";
            this.btn_Reporte.Size = new System.Drawing.Size(103, 23);
            this.btn_Reporte.TabIndex = 29;
            this.btn_Reporte.Text = "Generar Reporte";
            this.btn_Reporte.UseVisualStyleBackColor = false;
            this.btn_Reporte.Click += new System.EventHandler(this.btn_Reporte_Click);
            // 
            // btn_Eliminar
            // 
            this.btn_Eliminar.BackColor = System.Drawing.Color.Brown;
            this.btn_Eliminar.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Eliminar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Eliminar.Location = new System.Drawing.Point(187, 417);
            this.btn_Eliminar.Name = "btn_Eliminar";
            this.btn_Eliminar.Size = new System.Drawing.Size(87, 23);
            this.btn_Eliminar.TabIndex = 28;
            this.btn_Eliminar.Text = "Eliminar";
            this.btn_Eliminar.UseVisualStyleBackColor = false;
            this.btn_Eliminar.Click += new System.EventHandler(this.btn_Eliminar_Click);
            // 
            // btn_Editar
            // 
            this.btn_Editar.BackColor = System.Drawing.Color.SandyBrown;
            this.btn_Editar.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Editar.Location = new System.Drawing.Point(26, 417);
            this.btn_Editar.Name = "btn_Editar";
            this.btn_Editar.Size = new System.Drawing.Size(87, 23);
            this.btn_Editar.TabIndex = 27;
            this.btn_Editar.Text = "Editar";
            this.btn_Editar.UseVisualStyleBackColor = false;
            this.btn_Editar.Click += new System.EventHandler(this.btn_Editar_Click);
            // 
            // btn_Limpiar
            // 
            this.btn_Limpiar.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Limpiar.Location = new System.Drawing.Point(701, 60);
            this.btn_Limpiar.Name = "btn_Limpiar";
            this.btn_Limpiar.Size = new System.Drawing.Size(87, 23);
            this.btn_Limpiar.TabIndex = 26;
            this.btn_Limpiar.Text = "Limpiar Datos";
            this.btn_Limpiar.UseVisualStyleBackColor = true;
            this.btn_Limpiar.Click += new System.EventHandler(this.btn_Limpiar_Click);
            // 
            // btn_Buscar
            // 
            this.btn_Buscar.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Buscar.Location = new System.Drawing.Point(537, 58);
            this.btn_Buscar.Name = "btn_Buscar";
            this.btn_Buscar.Size = new System.Drawing.Size(86, 23);
            this.btn_Buscar.TabIndex = 25;
            this.btn_Buscar.Text = "Buscar";
            this.btn_Buscar.UseVisualStyleBackColor = true;
            this.btn_Buscar.Click += new System.EventHandler(this.btn_Buscar_Click);
            // 
            // dtp_Fecha
            // 
            this.dtp_Fecha.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_Fecha.Location = new System.Drawing.Point(80, 54);
            this.dtp_Fecha.Name = "dtp_Fecha";
            this.dtp_Fecha.Size = new System.Drawing.Size(135, 22);
            this.dtp_Fecha.TabIndex = 24;
            // 
            // cmb_Paciente
            // 
            this.cmb_Paciente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Paciente.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_Paciente.FormattingEnabled = true;
            this.cmb_Paciente.Location = new System.Drawing.Point(80, 15);
            this.cmb_Paciente.Name = "cmb_Paciente";
            this.cmb_Paciente.Size = new System.Drawing.Size(135, 21);
            this.cmb_Paciente.TabIndex = 23;
            // 
            // cmb_Hora
            // 
            this.cmb_Hora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Hora.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_Hora.FormattingEnabled = true;
            this.cmb_Hora.Location = new System.Drawing.Point(323, 15);
            this.cmb_Hora.Name = "cmb_Hora";
            this.cmb_Hora.Size = new System.Drawing.Size(135, 21);
            this.cmb_Hora.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(284, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Hora:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Fecha:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Paciente:";
            // 
            // lbl_Total
            // 
            this.lbl_Total.AutoSize = true;
            this.lbl_Total.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Total.Location = new System.Drawing.Point(729, 427);
            this.lbl_Total.Name = "lbl_Total";
            this.lbl_Total.Size = new System.Drawing.Size(22, 13);
            this.lbl_Total.TabIndex = 18;
            this.lbl_Total.Text = "___";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(689, 427);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Total:";
            // 
            // dgv_AntencionMedica
            // 
            this.dgv_AntencionMedica.AllowUserToAddRows = false;
            this.dgv_AntencionMedica.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_AntencionMedica.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_AntencionMedica.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_AntencionMedica.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_N,
            this.col_NHClinica,
            this.col_Paciente,
            this.col_Odontologo,
            this.col_Consultorio,
            this.col_Fecha,
            this.col_Hora,
            this.col_NPiezaDental,
            this.col_CuadrantePieza,
            this.col_NombrePieza,
            this.col_MotivoConsulta,
            this.col_Diagnostico});
            this.dgv_AntencionMedica.EnableHeadersVisualStyles = false;
            this.dgv_AntencionMedica.Location = new System.Drawing.Point(12, 87);
            this.dgv_AntencionMedica.Name = "dgv_AntencionMedica";
            this.dgv_AntencionMedica.ReadOnly = true;
            this.dgv_AntencionMedica.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_AntencionMedica.Size = new System.Drawing.Size(776, 324);
            this.dgv_AntencionMedica.TabIndex = 16;
            this.dgv_AntencionMedica.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_AntencionMedica_CellClick);
            // 
            // col_N
            // 
            this.col_N.HeaderText = "N°";
            this.col_N.Name = "col_N";
            this.col_N.ReadOnly = true;
            this.col_N.Width = 30;
            // 
            // col_NHClinica
            // 
            this.col_NHClinica.HeaderText = "N° Historia Clínica";
            this.col_NHClinica.Name = "col_NHClinica";
            this.col_NHClinica.ReadOnly = true;
            this.col_NHClinica.Width = 75;
            // 
            // col_Paciente
            // 
            this.col_Paciente.HeaderText = "Paciente";
            this.col_Paciente.Name = "col_Paciente";
            this.col_Paciente.ReadOnly = true;
            // 
            // col_Odontologo
            // 
            this.col_Odontologo.HeaderText = "Odontologo";
            this.col_Odontologo.Name = "col_Odontologo";
            this.col_Odontologo.ReadOnly = true;
            // 
            // col_Consultorio
            // 
            this.col_Consultorio.HeaderText = "Consultorio";
            this.col_Consultorio.Name = "col_Consultorio";
            this.col_Consultorio.ReadOnly = true;
            this.col_Consultorio.Width = 70;
            // 
            // col_Fecha
            // 
            this.col_Fecha.HeaderText = "Fecha";
            this.col_Fecha.Name = "col_Fecha";
            this.col_Fecha.ReadOnly = true;
            this.col_Fecha.Width = 75;
            // 
            // col_Hora
            // 
            this.col_Hora.HeaderText = "Hora";
            this.col_Hora.Name = "col_Hora";
            this.col_Hora.ReadOnly = true;
            this.col_Hora.Width = 50;
            // 
            // col_NPiezaDental
            // 
            this.col_NPiezaDental.HeaderText = "N° Pieza Dental";
            this.col_NPiezaDental.Name = "col_NPiezaDental";
            this.col_NPiezaDental.ReadOnly = true;
            this.col_NPiezaDental.Width = 60;
            // 
            // col_CuadrantePieza
            // 
            this.col_CuadrantePieza.HeaderText = "Cuadrante Pieza";
            this.col_CuadrantePieza.Name = "col_CuadrantePieza";
            this.col_CuadrantePieza.ReadOnly = true;
            // 
            // col_NombrePieza
            // 
            this.col_NombrePieza.HeaderText = "Nombre Pieza";
            this.col_NombrePieza.Name = "col_NombrePieza";
            this.col_NombrePieza.ReadOnly = true;
            // 
            // col_MotivoConsulta
            // 
            this.col_MotivoConsulta.HeaderText = "Motivo Consulta";
            this.col_MotivoConsulta.Name = "col_MotivoConsulta";
            this.col_MotivoConsulta.ReadOnly = true;
            // 
            // col_Diagnostico
            // 
            this.col_Diagnostico.HeaderText = "Diagnostico";
            this.col_Diagnostico.Name = "col_Diagnostico";
            this.col_Diagnostico.ReadOnly = true;
            // 
            // Frm_AtencionMedica_Buscar_ROPB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grb_Fecha);
            this.Controls.Add(this.btn_Reporte);
            this.Controls.Add(this.btn_Eliminar);
            this.Controls.Add(this.btn_Editar);
            this.Controls.Add(this.btn_Limpiar);
            this.Controls.Add(this.btn_Buscar);
            this.Controls.Add(this.dtp_Fecha);
            this.Controls.Add(this.cmb_Paciente);
            this.Controls.Add(this.cmb_Hora);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_Total);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv_AntencionMedica);
            this.Name = "Frm_AtencionMedica_Buscar_ROPB";
            this.Text = "Frm_AtencionMedica_Buscar_ROPB";
            this.grb_Fecha.ResumeLayout(false);
            this.grb_Fecha.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_AntencionMedica)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grb_Fecha;
        private System.Windows.Forms.RadioButton rdb_No;
        private System.Windows.Forms.RadioButton rdb_Si;
        private System.Windows.Forms.Button btn_Reporte;
        private System.Windows.Forms.Button btn_Eliminar;
        private System.Windows.Forms.Button btn_Editar;
        private System.Windows.Forms.Button btn_Limpiar;
        private System.Windows.Forms.Button btn_Buscar;
        private System.Windows.Forms.DateTimePicker dtp_Fecha;
        private System.Windows.Forms.ComboBox cmb_Paciente;
        private System.Windows.Forms.ComboBox cmb_Hora;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_Total;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_AntencionMedica;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_N;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_NHClinica;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Paciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Odontologo;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Consultorio;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Hora;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_NPiezaDental;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_CuadrantePieza;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_NombrePieza;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_MotivoConsulta;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Diagnostico;
    }
}