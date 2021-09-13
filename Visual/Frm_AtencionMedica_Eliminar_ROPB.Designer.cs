
namespace Visual {
    partial class Frm_AtencionMedica_Eliminar_ROPB {
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
            this.label12 = new System.Windows.Forms.Label();
            this.lbl_NumeroPieza = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cmb_NombrePieza = new System.Windows.Forms.ComboBox();
            this.cmb_CuadrantePieza = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Diagnostico = new System.Windows.Forms.TextBox();
            this.txt_MotivoConsulta = new System.Windows.Forms.TextBox();
            this.btn_Eliminar = new System.Windows.Forms.Button();
            this.lbl_Odontologo = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmb_Paciente = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmb_Hora = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp_Fecha = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label12.Location = new System.Drawing.Point(563, 78);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(122, 16);
            this.label12.TabIndex = 84;
            this.label12.Text = "Datos a Eliminar";
            // 
            // lbl_NumeroPieza
            // 
            this.lbl_NumeroPieza.AutoSize = true;
            this.lbl_NumeroPieza.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_NumeroPieza.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_NumeroPieza.Location = new System.Drawing.Point(594, 181);
            this.lbl_NumeroPieza.Name = "lbl_NumeroPieza";
            this.lbl_NumeroPieza.Size = new System.Drawing.Size(0, 16);
            this.lbl_NumeroPieza.TabIndex = 83;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label11.Location = new System.Drawing.Point(518, 180);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 16);
            this.label11.TabIndex = 82;
            this.label11.Text = "Número:";
            // 
            // cmb_NombrePieza
            // 
            this.cmb_NombrePieza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_NombrePieza.Enabled = false;
            this.cmb_NombrePieza.FormattingEnabled = true;
            this.cmb_NombrePieza.Location = new System.Drawing.Point(597, 147);
            this.cmb_NombrePieza.Name = "cmb_NombrePieza";
            this.cmb_NombrePieza.Size = new System.Drawing.Size(144, 21);
            this.cmb_NombrePieza.TabIndex = 81;
            this.cmb_NombrePieza.SelectedValueChanged += new System.EventHandler(this.cmb_CuadrantePieza_SelectedValueChanged);
            // 
            // cmb_CuadrantePieza
            // 
            this.cmb_CuadrantePieza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_CuadrantePieza.Enabled = false;
            this.cmb_CuadrantePieza.FormattingEnabled = true;
            this.cmb_CuadrantePieza.Location = new System.Drawing.Point(597, 113);
            this.cmb_CuadrantePieza.Name = "cmb_CuadrantePieza";
            this.cmb_CuadrantePieza.Size = new System.Drawing.Size(144, 21);
            this.cmb_CuadrantePieza.TabIndex = 80;
            this.cmb_CuadrantePieza.SelectedValueChanged += new System.EventHandler(this.cmb_CuadrantePieza_SelectedValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(518, 149);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 16);
            this.label7.TabIndex = 79;
            this.label7.Text = "Nombre:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(518, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 16);
            this.label6.TabIndex = 78;
            this.label6.Text = "Cuadrante:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(511, 287);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 16);
            this.label5.TabIndex = 77;
            this.label5.Text = "Diagnostico:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(511, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 16);
            this.label4.TabIndex = 76;
            this.label4.Text = "Motivo de Consulta:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(512, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 16);
            this.label3.TabIndex = 75;
            this.label3.Text = "Pieza Dental:";
            // 
            // txt_Diagnostico
            // 
            this.txt_Diagnostico.Enabled = false;
            this.txt_Diagnostico.Location = new System.Drawing.Point(514, 306);
            this.txt_Diagnostico.Multiline = true;
            this.txt_Diagnostico.Name = "txt_Diagnostico";
            this.txt_Diagnostico.Size = new System.Drawing.Size(227, 42);
            this.txt_Diagnostico.TabIndex = 74;
            // 
            // txt_MotivoConsulta
            // 
            this.txt_MotivoConsulta.Enabled = false;
            this.txt_MotivoConsulta.Location = new System.Drawing.Point(514, 231);
            this.txt_MotivoConsulta.Multiline = true;
            this.txt_MotivoConsulta.Name = "txt_MotivoConsulta";
            this.txt_MotivoConsulta.Size = new System.Drawing.Size(227, 42);
            this.txt_MotivoConsulta.TabIndex = 73;
            // 
            // btn_Eliminar
            // 
            this.btn_Eliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Eliminar.Location = new System.Drawing.Point(353, 385);
            this.btn_Eliminar.Name = "btn_Eliminar";
            this.btn_Eliminar.Size = new System.Drawing.Size(101, 39);
            this.btn_Eliminar.TabIndex = 72;
            this.btn_Eliminar.Text = "Eliminar";
            this.btn_Eliminar.UseVisualStyleBackColor = true;
            this.btn_Eliminar.Click += new System.EventHandler(this.btn_Eliminar_Click);
            // 
            // lbl_Odontologo
            // 
            this.lbl_Odontologo.AutoSize = true;
            this.lbl_Odontologo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Odontologo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_Odontologo.Location = new System.Drawing.Point(147, 191);
            this.lbl_Odontologo.Name = "lbl_Odontologo";
            this.lbl_Odontologo.Size = new System.Drawing.Size(0, 16);
            this.lbl_Odontologo.TabIndex = 71;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Location = new System.Drawing.Point(59, 191);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 16);
            this.label9.TabIndex = 70;
            this.label9.Text = "Odontólogo:";
            // 
            // cmb_Paciente
            // 
            this.cmb_Paciente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Paciente.FormattingEnabled = true;
            this.cmb_Paciente.Location = new System.Drawing.Point(129, 155);
            this.cmb_Paciente.Name = "cmb_Paciente";
            this.cmb_Paciente.Size = new System.Drawing.Size(163, 21);
            this.cmb_Paciente.TabIndex = 69;
            this.cmb_Paciente.SelectedValueChanged += new System.EventHandler(this.cmb_Paciente_SelectedValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(315, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(155, 16);
            this.label8.TabIndex = 68;
            this.label8.Text = "Eliminación de Datos";
            // 
            // cmb_Hora
            // 
            this.cmb_Hora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Hora.FormattingEnabled = true;
            this.cmb_Hora.Location = new System.Drawing.Point(129, 122);
            this.cmb_Hora.Name = "cmb_Hora";
            this.cmb_Hora.Size = new System.Drawing.Size(163, 21);
            this.cmb_Hora.TabIndex = 67;
            this.cmb_Hora.SelectedValueChanged += new System.EventHandler(this.dtp_Fecha_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label10.Location = new System.Drawing.Point(59, 125);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 16);
            this.label10.TabIndex = 66;
            this.label10.Text = "Hora:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(59, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 65;
            this.label2.Text = "Paciente:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(59, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 16);
            this.label1.TabIndex = 64;
            this.label1.Text = "Fecha:";
            // 
            // dtp_Fecha
            // 
            this.dtp_Fecha.Location = new System.Drawing.Point(129, 90);
            this.dtp_Fecha.Name = "dtp_Fecha";
            this.dtp_Fecha.Size = new System.Drawing.Size(163, 20);
            this.dtp_Fecha.TabIndex = 63;
            this.dtp_Fecha.ValueChanged += new System.EventHandler(this.dtp_Fecha_ValueChanged);
            // 
            // Frm_AtencionMedica_Eliminar_ROPB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lbl_NumeroPieza);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cmb_NombrePieza);
            this.Controls.Add(this.cmb_CuadrantePieza);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_Diagnostico);
            this.Controls.Add(this.txt_MotivoConsulta);
            this.Controls.Add(this.btn_Eliminar);
            this.Controls.Add(this.lbl_Odontologo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmb_Paciente);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmb_Hora);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtp_Fecha);
            this.Name = "Frm_AtencionMedica_Eliminar_ROPB";
            this.Text = "Frm_AtencionMedica_Eliminar_ROPB";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lbl_NumeroPieza;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmb_NombrePieza;
        private System.Windows.Forms.ComboBox cmb_CuadrantePieza;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Diagnostico;
        private System.Windows.Forms.TextBox txt_MotivoConsulta;
        private System.Windows.Forms.Button btn_Eliminar;
        private System.Windows.Forms.Label lbl_Odontologo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmb_Paciente;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmb_Hora;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp_Fecha;
    }
}