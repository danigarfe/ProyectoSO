﻿namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.nombre = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.checkpartidas = new System.Windows.Forms.RadioButton();
            this.IDpartida = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkgoles = new System.Windows.Forms.RadioButton();
            this.checkganador = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nombre
            // 
            this.nombre.Location = new System.Drawing.Point(130, 18);
            this.nombre.Name = "nombre";
            this.nombre.Size = new System.Drawing.Size(258, 20);
            this.nombre.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(18, 153);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(368, 31);
            this.button2.TabIndex = 5;
            this.button2.Text = "Enviar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre:";
            // 
            // checkpartidas
            // 
            this.checkpartidas.AutoSize = true;
            this.checkpartidas.Location = new System.Drawing.Point(130, 44);
            this.checkpartidas.Name = "checkpartidas";
            this.checkpartidas.Size = new System.Drawing.Size(186, 17);
            this.checkpartidas.TabIndex = 8;
            this.checkpartidas.TabStop = true;
            this.checkpartidas.Text = "Dime numero de partidas ganadas";
            this.checkpartidas.UseVisualStyleBackColor = true;
            // 
            // IDpartida
            // 
            this.IDpartida.Location = new System.Drawing.Point(130, 104);
            this.IDpartida.Name = "IDpartida";
            this.IDpartida.Size = new System.Drawing.Size(256, 20);
            this.IDpartida.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "ID partida:";
            // 
            // checkgoles
            // 
            this.checkgoles.AutoSize = true;
            this.checkgoles.Location = new System.Drawing.Point(130, 63);
            this.checkgoles.Name = "checkgoles";
            this.checkgoles.Size = new System.Drawing.Size(258, 17);
            this.checkgoles.TabIndex = 7;
            this.checkgoles.TabStop = true;
            this.checkgoles.Text = "Dime numero de goles marcados por este jugador";
            this.checkgoles.UseVisualStyleBackColor = true;
            // 
            // checkganador
            // 
            this.checkganador.AutoSize = true;
            this.checkganador.Location = new System.Drawing.Point(130, 130);
            this.checkganador.Name = "checkganador";
            this.checkganador.Size = new System.Drawing.Size(207, 17);
            this.checkganador.TabIndex = 7;
            this.checkganador.TabStop = true;
            this.checkganador.Text = "Dime nombre del ganador de la partida";
            this.checkganador.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(309, 190);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 25);
            this.button1.TabIndex = 10;
            this.button1.Text = "Desconectar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 188);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkganador);
            this.Controls.Add(this.checkgoles);
            this.Controls.Add(this.checkpartidas);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nombre);
            this.Controls.Add(this.IDpartida);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nombre;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton checkpartidas;
        private System.Windows.Forms.TextBox IDpartida;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton checkgoles;
        private System.Windows.Forms.RadioButton checkganador;
        private System.Windows.Forms.Button button1;
    }
}
