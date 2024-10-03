
namespace ReservaVuelo
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lstVuelos = new System.Windows.Forms.ListView();
            label1 = new System.Windows.Forms.Label();
            txtorigen = new System.Windows.Forms.TextBox();
            txtDestino = new System.Windows.Forms.TextBox();
            txtDistancia = new System.Windows.Forms.TextBox();
            txtValor = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            btnGuardar = new System.Windows.Forms.Button();
            button1 = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            LblIndice = new System.Windows.Forms.Label();
            cbOrigen = new System.Windows.Forms.ComboBox();
            cbDestino = new System.Windows.Forms.ComboBox();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            button3 = new System.Windows.Forms.Button();
            lstRutas = new System.Windows.Forms.ListView();
            SuspendLayout();
            // 
            // lstVuelos
            // 
            lstVuelos.HideSelection = false;
            lstVuelos.Location = new System.Drawing.Point(64, 34);
            lstVuelos.Name = "lstVuelos";
            lstVuelos.Size = new System.Drawing.Size(249, 216);
            lstVuelos.TabIndex = 0;
            lstVuelos.UseCompatibleStateImageBehavior = false;
            lstVuelos.View = System.Windows.Forms.View.List;
            lstVuelos.SelectedIndexChanged += lstVuelos_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(387, 43);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(46, 15);
            label1.TabIndex = 1;
            label1.Text = "Origen:";
            // 
            // txtorigen
            // 
            txtorigen.Location = new System.Drawing.Point(441, 36);
            txtorigen.Name = "txtorigen";
            txtorigen.Size = new System.Drawing.Size(198, 23);
            txtorigen.TabIndex = 2;
            // 
            // txtDestino
            // 
            txtDestino.Location = new System.Drawing.Point(441, 80);
            txtDestino.Name = "txtDestino";
            txtDestino.Size = new System.Drawing.Size(198, 23);
            txtDestino.TabIndex = 3;
            // 
            // txtDistancia
            // 
            txtDistancia.Location = new System.Drawing.Point(441, 124);
            txtDistancia.Name = "txtDistancia";
            txtDistancia.Size = new System.Drawing.Size(82, 23);
            txtDistancia.TabIndex = 4;
            // 
            // txtValor
            // 
            txtValor.Location = new System.Drawing.Point(441, 168);
            txtValor.Name = "txtValor";
            txtValor.Size = new System.Drawing.Size(82, 23);
            txtValor.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(383, 85);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(50, 15);
            label2.TabIndex = 6;
            label2.Text = "Destino:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(347, 127);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(86, 15);
            label3.TabIndex = 7;
            label3.Text = "Distancia (km):";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(380, 169);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(53, 15);
            label4.TabIndex = 8;
            label4.Text = "Valor ($):";
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new System.Drawing.Point(392, 227);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new System.Drawing.Size(75, 23);
            btnGuardar.TabIndex = 9;
            btnGuardar.Text = "GUARDAR";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(495, 227);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(75, 23);
            button1.TabIndex = 10;
            button1.Text = "EDITAR";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new System.Drawing.Point(602, 227);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(75, 23);
            button2.TabIndex = 11;
            button2.Text = "ELIMINAR";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // LblIndice
            // 
            LblIndice.AutoSize = true;
            LblIndice.Location = new System.Drawing.Point(387, 7);
            LblIndice.Name = "LblIndice";
            LblIndice.Size = new System.Drawing.Size(12, 15);
            LblIndice.TabIndex = 12;
            LblIndice.Text = "-";
            // 
            // cbOrigen
            // 
            cbOrigen.FormattingEnabled = true;
            cbOrigen.Location = new System.Drawing.Point(78, 310);
            cbOrigen.Name = "cbOrigen";
            cbOrigen.Size = new System.Drawing.Size(121, 23);
            cbOrigen.TabIndex = 13;
            // 
            // cbDestino
            // 
            cbDestino.FormattingEnabled = true;
            cbDestino.Location = new System.Drawing.Point(296, 310);
            cbDestino.Name = "cbDestino";
            cbDestino.Size = new System.Drawing.Size(121, 23);
            cbDestino.TabIndex = 14;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(26, 318);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(46, 15);
            label5.TabIndex = 15;
            label5.Text = "Origen:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(219, 318);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(50, 15);
            label6.TabIndex = 16;
            label6.Text = "Destino:";
            // 
            // button3
            // 
            button3.Location = new System.Drawing.Point(448, 309);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(75, 23);
            button3.TabIndex = 17;
            button3.Text = "BUSCAR";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // lstRutas
            // 
            lstRutas.HideSelection = false;
            lstRutas.Location = new System.Drawing.Point(26, 361);
            lstRutas.Name = "lstRutas";
            lstRutas.Size = new System.Drawing.Size(497, 106);
            lstRutas.TabIndex = 19;
            lstRutas.UseCompatibleStateImageBehavior = false;
            lstRutas.View = System.Windows.Forms.View.List;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 500);
            Controls.Add(lstRutas);
            Controls.Add(button3);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(cbDestino);
            Controls.Add(cbOrigen);
            Controls.Add(LblIndice);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(btnGuardar);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtValor);
            Controls.Add(txtDistancia);
            Controls.Add(txtDestino);
            Controls.Add(txtorigen);
            Controls.Add(label1);
            Controls.Add(lstVuelos);
            Name = "Form1";
            Text = "Reserva de Vuelos";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ListView lstVuelos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtorigen;
        private System.Windows.Forms.TextBox txtDestino;
        private System.Windows.Forms.TextBox txtDistancia;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label LblIndice;
        private System.Windows.Forms.ComboBox cbOrigen;
        private System.Windows.Forms.ComboBox cbDestino;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListView lstRutas;
    }
}

