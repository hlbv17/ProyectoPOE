
namespace Visual
{
    partial class Frm_Odontologo_Horario
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmbDia = new System.Windows.Forms.ComboBox();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvHorario = new System.Windows.Forms.DataGridView();
            this.colTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColhorSalida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHoraEntrsa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnSeleccionarHorario = new System.Windows.Forms.Button();
            this.dgvHorarioOdontologo = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHoraEntr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colhorSal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHorario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHorarioOdontologo)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbDia
            // 
            this.cmbDia.FormattingEnabled = true;
            this.cmbDia.Items.AddRange(new object[] {
            "",
            "Lunes",
            "Martes",
            "Miercoles",
            "Jueves",
            "Viernes",
            "Sábado"});
            this.cmbDia.Location = new System.Drawing.Point(158, 32);
            this.cmbDia.Name = "cmbDia";
            this.cmbDia.Size = new System.Drawing.Size(210, 24);
            this.cmbDia.TabIndex = 0;
            this.cmbDia.SelectedIndexChanged += new System.EventHandler(this.cmbDia_SelectedIndexChanged);
            // 
            // cmbTipo
            // 
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Items.AddRange(new object[] {
            "",
            "Matutino ",
            "Vespertino ",
            "Fines de semana"});
            this.cmbTipo.Location = new System.Drawing.Point(676, 32);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(210, 24);
            this.cmbTipo.TabIndex = 1;
            this.cmbTipo.SelectedIndexChanged += new System.EventHandler(this.cmbTipo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Dia:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(590, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Jornada:";
            // 
            // dgvHorario
            // 
            this.dgvHorario.AllowUserToAddRows = false;
            this.dgvHorario.AllowUserToDeleteRows = false;
            this.dgvHorario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHorario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTipo,
            this.colDia,
            this.ColhorSalida,
            this.colHoraEntrsa});
            this.dgvHorario.Location = new System.Drawing.Point(27, 92);
            this.dgvHorario.MultiSelect = false;
            this.dgvHorario.Name = "dgvHorario";
            this.dgvHorario.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHorario.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHorario.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvHorario.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHorario.RowTemplate.Height = 24;
            this.dgvHorario.Size = new System.Drawing.Size(498, 250);
            this.dgvHorario.TabIndex = 4;
            // 
            // colTipo
            // 
            this.colTipo.HeaderText = "Tipo de jornada";
            this.colTipo.MinimumWidth = 6;
            this.colTipo.Name = "colTipo";
            this.colTipo.ReadOnly = true;
            this.colTipo.Width = 125;
            // 
            // colDia
            // 
            this.colDia.HeaderText = "Dia";
            this.colDia.MinimumWidth = 6;
            this.colDia.Name = "colDia";
            this.colDia.ReadOnly = true;
            this.colDia.Width = 125;
            // 
            // ColhorSalida
            // 
            this.ColhorSalida.HeaderText = "Hora de salida";
            this.ColhorSalida.MinimumWidth = 6;
            this.ColhorSalida.Name = "ColhorSalida";
            this.ColhorSalida.ReadOnly = true;
            this.ColhorSalida.Width = 125;
            // 
            // colHoraEntrsa
            // 
            this.colHoraEntrsa.HeaderText = "Hora de entrada";
            this.colHoraEntrsa.MinimumWidth = 6;
            this.colHoraEntrsa.Name = "colHoraEntrsa";
            this.colHoraEntrsa.ReadOnly = true;
            this.colHoraEntrsa.Width = 125;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(531, 204);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(123, 53);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "Seleccionar Horario";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnSeleccionarHorario
            // 
            this.btnSeleccionarHorario.Location = new System.Drawing.Point(531, 376);
            this.btnSeleccionarHorario.Name = "btnSeleccionarHorario";
            this.btnSeleccionarHorario.Size = new System.Drawing.Size(123, 43);
            this.btnSeleccionarHorario.TabIndex = 6;
            this.btnSeleccionarHorario.Text = "Guardar";
            this.btnSeleccionarHorario.UseVisualStyleBackColor = true;
            this.btnSeleccionarHorario.Click += new System.EventHandler(this.btnSeleccionarHorario_Click);
            // 
            // dgvHorarioOdontologo
            // 
            this.dgvHorarioOdontologo.AllowUserToAddRows = false;
            this.dgvHorarioOdontologo.AllowUserToDeleteRows = false;
            this.dgvHorarioOdontologo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHorarioOdontologo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.colHoraEntr,
            this.colhorSal});
            this.dgvHorarioOdontologo.Location = new System.Drawing.Point(660, 92);
            this.dgvHorarioOdontologo.MultiSelect = false;
            this.dgvHorarioOdontologo.Name = "dgvHorarioOdontologo";
            this.dgvHorarioOdontologo.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHorarioOdontologo.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvHorarioOdontologo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvHorarioOdontologo.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvHorarioOdontologo.RowTemplate.Height = 24;
            this.dgvHorarioOdontologo.Size = new System.Drawing.Size(469, 250);
            this.dgvHorarioOdontologo.TabIndex = 7;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "Tipo de jornada";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.Frozen = true;
            this.dataGridViewTextBoxColumn2.HeaderText = "Dia";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 125;
            // 
            // colHoraEntr
            // 
            this.colHoraEntr.HeaderText = "Hora de Entrada";
            this.colHoraEntr.MinimumWidth = 6;
            this.colHoraEntr.Name = "colHoraEntr";
            this.colHoraEntr.ReadOnly = true;
            this.colHoraEntr.Width = 125;
            // 
            // colhorSal
            // 
            this.colhorSal.HeaderText = "Hora de salida";
            this.colhorSal.MinimumWidth = 6;
            this.colhorSal.Name = "colhorSal";
            this.colhorSal.ReadOnly = true;
            this.colhorSal.Width = 125;
            // 
            // Frm_Odontologo_Horario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 431);
            this.Controls.Add(this.dgvHorarioOdontologo);
            this.Controls.Add(this.btnSeleccionarHorario);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.dgvHorario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbTipo);
            this.Controls.Add(this.cmbDia);
            this.Name = "Frm_Odontologo_Horario";
            this.Text = "HorarioEGGM";
            ((System.ComponentModel.ISupportInitialize)(this.dgvHorario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHorarioOdontologo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbDia;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvHorario;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnSeleccionarHorario;
        private System.Windows.Forms.DataGridView dgvHorarioOdontologo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDia;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColhorSalida;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHoraEntrsa;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHoraEntr;
        private System.Windows.Forms.DataGridViewTextBoxColumn colhorSal;
    }
}