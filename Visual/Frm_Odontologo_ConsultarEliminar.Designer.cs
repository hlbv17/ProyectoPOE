
namespace Visual
{
    partial class Frm_Odontologo_ConsultarEliminar
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
            this.dvgOdontologo = new System.Windows.Forms.DataGridView();
            this.colNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colcedula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSexo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEspe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaNacimieto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCorreo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTelefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rtCedula = new System.Windows.Forms.RadioButton();
            this.rtCampos = new System.Windows.Forms.RadioButton();
            this.PanelCampos = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Consultorio = new System.Windows.Forms.Label();
            this.cmbEspecialidad = new System.Windows.Forms.ComboBox();
            this.cmbjornada = new System.Windows.Forms.ComboBox();
            this.cmbConsultorio = new System.Windows.Forms.ComboBox();
            this.PanelCedula = new System.Windows.Forms.Panel();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtCedula = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnRefres = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dvgOdontologo)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.PanelCampos.SuspendLayout();
            this.PanelCedula.SuspendLayout();
            this.SuspendLayout();
            // 
            // dvgOdontologo
            // 
            this.dvgOdontologo.AllowUserToAddRows = false;
            this.dvgOdontologo.AllowUserToDeleteRows = false;
            this.dvgOdontologo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgOdontologo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNumero,
            this.colcedula,
            this.colNombre,
            this.colSexo,
            this.colEspe,
            this.colEstado,
            this.colFechaNacimieto,
            this.colCorreo,
            this.colTelefono,
            this.colTipo});
            this.dvgOdontologo.Location = new System.Drawing.Point(21, 105);
            this.dvgOdontologo.Name = "dvgOdontologo";
            this.dvgOdontologo.ReadOnly = true;
            this.dvgOdontologo.RowHeadersWidth = 51;
            this.dvgOdontologo.RowTemplate.Height = 24;
            this.dvgOdontologo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvgOdontologo.Size = new System.Drawing.Size(944, 257);
            this.dvgOdontologo.TabIndex = 0;
            // 
            // colNumero
            // 
            this.colNumero.HeaderText = "Nro";
            this.colNumero.MinimumWidth = 6;
            this.colNumero.Name = "colNumero";
            this.colNumero.ReadOnly = true;
            this.colNumero.Width = 125;
            // 
            // colcedula
            // 
            this.colcedula.HeaderText = "Cedula";
            this.colcedula.MinimumWidth = 6;
            this.colcedula.Name = "colcedula";
            this.colcedula.ReadOnly = true;
            this.colcedula.Width = 125;
            // 
            // colNombre
            // 
            this.colNombre.HeaderText = "Nombre";
            this.colNombre.MinimumWidth = 6;
            this.colNombre.Name = "colNombre";
            this.colNombre.ReadOnly = true;
            this.colNombre.Width = 125;
            // 
            // colSexo
            // 
            this.colSexo.HeaderText = "Sexo";
            this.colSexo.MinimumWidth = 6;
            this.colSexo.Name = "colSexo";
            this.colSexo.ReadOnly = true;
            this.colSexo.Width = 125;
            // 
            // colEspe
            // 
            this.colEspe.HeaderText = "Especialidad";
            this.colEspe.MinimumWidth = 6;
            this.colEspe.Name = "colEspe";
            this.colEspe.ReadOnly = true;
            this.colEspe.Width = 125;
            // 
            // colEstado
            // 
            this.colEstado.HeaderText = "Estado";
            this.colEstado.MinimumWidth = 6;
            this.colEstado.Name = "colEstado";
            this.colEstado.ReadOnly = true;
            this.colEstado.Width = 125;
            // 
            // colFechaNacimieto
            // 
            this.colFechaNacimieto.HeaderText = "Fecha de Nacimieento";
            this.colFechaNacimieto.MinimumWidth = 6;
            this.colFechaNacimieto.Name = "colFechaNacimieto";
            this.colFechaNacimieto.ReadOnly = true;
            this.colFechaNacimieto.Width = 125;
            // 
            // colCorreo
            // 
            this.colCorreo.HeaderText = "Correo";
            this.colCorreo.MinimumWidth = 6;
            this.colCorreo.Name = "colCorreo";
            this.colCorreo.ReadOnly = true;
            this.colCorreo.Width = 125;
            // 
            // colTelefono
            // 
            this.colTelefono.HeaderText = "Telefono";
            this.colTelefono.MinimumWidth = 6;
            this.colTelefono.Name = "colTelefono";
            this.colTelefono.ReadOnly = true;
            this.colTelefono.Width = 125;
            // 
            // colTipo
            // 
            this.colTipo.HeaderText = "Horario(tipo)";
            this.colTipo.MinimumWidth = 6;
            this.colTipo.Name = "colTipo";
            this.colTipo.ReadOnly = true;
            this.colTipo.Width = 125;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Red;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEliminar.Location = new System.Drawing.Point(200, 377);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(126, 38);
            this.btnEliminar.TabIndex = 1;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.Chartreuse;
            this.btnActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.Location = new System.Drawing.Point(444, 377);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(126, 38);
            this.btnActualizar.TabIndex = 2;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.Color.Teal;
            this.btnImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnImprimir.Location = new System.Drawing.Point(666, 377);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(126, 38);
            this.btnImprimir.TabIndex = 3;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rtCedula);
            this.groupBox1.Controls.Add(this.rtCampos);
            this.groupBox1.Location = new System.Drawing.Point(21, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 78);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Busqueda por:";
            // 
            // rtCedula
            // 
            this.rtCedula.AutoSize = true;
            this.rtCedula.Location = new System.Drawing.Point(25, 47);
            this.rtCedula.Name = "rtCedula";
            this.rtCedula.Size = new System.Drawing.Size(73, 21);
            this.rtCedula.TabIndex = 1;
            this.rtCedula.Text = "Cédula";
            this.rtCedula.UseVisualStyleBackColor = true;
            this.rtCedula.CheckedChanged += new System.EventHandler(this.rtCedula_CheckedChanged);
            // 
            // rtCampos
            // 
            this.rtCampos.AutoSize = true;
            this.rtCampos.Checked = true;
            this.rtCampos.Location = new System.Drawing.Point(25, 20);
            this.rtCampos.Name = "rtCampos";
            this.rtCampos.Size = new System.Drawing.Size(80, 21);
            this.rtCampos.TabIndex = 0;
            this.rtCampos.TabStop = true;
            this.rtCampos.Text = "Campos";
            this.rtCampos.UseVisualStyleBackColor = true;
            this.rtCampos.CheckedChanged += new System.EventHandler(this.rtCampos_CheckedChanged);
            // 
            // PanelCampos
            // 
            this.PanelCampos.Controls.Add(this.label2);
            this.PanelCampos.Controls.Add(this.label1);
            this.PanelCampos.Controls.Add(this.Consultorio);
            this.PanelCampos.Controls.Add(this.cmbEspecialidad);
            this.PanelCampos.Controls.Add(this.cmbjornada);
            this.PanelCampos.Controls.Add(this.cmbConsultorio);
            this.PanelCampos.Location = new System.Drawing.Point(227, 44);
            this.PanelCampos.Name = "PanelCampos";
            this.PanelCampos.Size = new System.Drawing.Size(738, 45);
            this.PanelCampos.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(256, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Especialidad";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Jornada:";
            // 
            // Consultorio
            // 
            this.Consultorio.AutoSize = true;
            this.Consultorio.Location = new System.Drawing.Point(512, 16);
            this.Consultorio.Name = "Consultorio";
            this.Consultorio.Size = new System.Drawing.Size(83, 17);
            this.Consultorio.TabIndex = 9;
            this.Consultorio.Text = "Consultorio:";
            // 
            // cmbEspecialidad
            // 
            this.cmbEspecialidad.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.cmbEspecialidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEspecialidad.FormattingEnabled = true;
            this.cmbEspecialidad.Items.AddRange(new object[] {
            "",
            "Ortodoncia",
            "Peridoncia",
            "Endodoncia",
            "Odontopediatría"});
            this.cmbEspecialidad.Location = new System.Drawing.Point(354, 11);
            this.cmbEspecialidad.Name = "cmbEspecialidad";
            this.cmbEspecialidad.Size = new System.Drawing.Size(121, 24);
            this.cmbEspecialidad.TabIndex = 8;
            this.cmbEspecialidad.SelectedValueChanged += new System.EventHandler(this.cmbjornada_SelectedValueChanged);
            // 
            // cmbjornada
            // 
            this.cmbjornada.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.cmbjornada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbjornada.FormattingEnabled = true;
            this.cmbjornada.Items.AddRange(new object[] {
            "",
            "Matutino",
            "Vespertino",
            "Fines de semana"});
            this.cmbjornada.Location = new System.Drawing.Point(89, 13);
            this.cmbjornada.Name = "cmbjornada";
            this.cmbjornada.Size = new System.Drawing.Size(121, 24);
            this.cmbjornada.TabIndex = 7;
            this.cmbjornada.SelectedValueChanged += new System.EventHandler(this.cmbjornada_SelectedValueChanged);
            // 
            // cmbConsultorio
            // 
            this.cmbConsultorio.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.cmbConsultorio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbConsultorio.FormattingEnabled = true;
            this.cmbConsultorio.Items.AddRange(new object[] {
            "",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.cmbConsultorio.Location = new System.Drawing.Point(602, 9);
            this.cmbConsultorio.Name = "cmbConsultorio";
            this.cmbConsultorio.Size = new System.Drawing.Size(121, 24);
            this.cmbConsultorio.TabIndex = 6;
            this.cmbConsultorio.SelectedValueChanged += new System.EventHandler(this.cmbjornada_SelectedValueChanged);
            // 
            // PanelCedula
            // 
            this.PanelCedula.Controls.Add(this.btnBuscar);
            this.PanelCedula.Controls.Add(this.txtCedula);
            this.PanelCedula.Controls.Add(this.label4);
            this.PanelCedula.Location = new System.Drawing.Point(227, 44);
            this.PanelCedula.Name = "PanelCedula";
            this.PanelCedula.Size = new System.Drawing.Size(738, 45);
            this.PanelCedula.TabIndex = 12;
            this.PanelCedula.Visible = false;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.SystemColors.ControlText;
            this.btnBuscar.ForeColor = System.Drawing.Color.GhostWhite;
            this.btnBuscar.Location = new System.Drawing.Point(286, 15);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(155, 24);
            this.btnBuscar.TabIndex = 12;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtCedula
            // 
            this.txtCedula.Location = new System.Drawing.Point(84, 15);
            this.txtCedula.MaxLength = 10;
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(196, 22);
            this.txtCedula.TabIndex = 11;
            this.txtCedula.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCedula_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Cédula:";
            // 
            // btnRefres
            // 
            this.btnRefres.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnRefres.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnRefres.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnRefres.FlatAppearance.BorderSize = 0;
            this.btnRefres.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefres.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRefres.Location = new System.Drawing.Point(893, 3);
            this.btnRefres.Name = "btnRefres";
            this.btnRefres.Size = new System.Drawing.Size(57, 44);
            this.btnRefres.TabIndex = 13;
            this.btnRefres.Text = "↺";
            this.btnRefres.UseVisualStyleBackColor = false;
            this.btnRefres.Click += new System.EventHandler(this.btnRefres_Click);
            // 
            // FrmConsultarANDEliminarodontologo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 444);
            this.Controls.Add(this.btnRefres);
            this.Controls.Add(this.PanelCedula);
            this.Controls.Add(this.PanelCampos);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.dvgOdontologo);
            this.Name = "FrmConsultarANDEliminarodontologo";
            this.Text = "FrmConsultarANDEliminarodontologo";
            ((System.ComponentModel.ISupportInitialize)(this.dvgOdontologo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.PanelCampos.ResumeLayout(false);
            this.PanelCampos.PerformLayout();
            this.PanelCedula.ResumeLayout(false);
            this.PanelCedula.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dvgOdontologo;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn colcedula;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSexo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEspe;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaNacimieto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCorreo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTelefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipo;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rtCedula;
        private System.Windows.Forms.RadioButton rtCampos;
        private System.Windows.Forms.Panel PanelCampos;
        private System.Windows.Forms.ComboBox cmbEspecialidad;
        private System.Windows.Forms.ComboBox cmbjornada;
        private System.Windows.Forms.ComboBox cmbConsultorio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Consultorio;
        private System.Windows.Forms.Panel PanelCedula;
        private System.Windows.Forms.TextBox txtCedula;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnRefres;
    }
}