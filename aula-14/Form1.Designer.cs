namespace Aula14
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtPeso = new TextBox();
            txtAltura = new TextBox();
            btnCalcular = new Button();
            lblResultado = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DarkViolet;
            label1.Location = new Point(229, 46);
            label1.Name = "label1";
            label1.Size = new Size(185, 32);
            label1.TabIndex = 0;
            label1.Text = "Sistema IMC";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Rounded MT Bold", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.DarkMagenta;
            label2.Location = new Point(75, 118);
            label2.Name = "label2";
            label2.Size = new Size(91, 32);
            label2.TabIndex = 1;
            label2.Text = "Peso:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial Rounded MT Bold", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.DarkMagenta;
            label3.Location = new Point(75, 215);
            label3.Name = "label3";
            label3.Size = new Size(107, 32);
            label3.TabIndex = 2;
            label3.Text = "Altura:";
            // 
            // txtPeso
            // 
            txtPeso.Font = new Font("Segoe UI", 16.2F);
            txtPeso.Location = new Point(190, 118);
            txtPeso.Name = "txtPeso";
            txtPeso.Size = new Size(160, 43);
            txtPeso.TabIndex = 3;
            // 
            // txtAltura
            // 
            txtAltura.Font = new Font("Segoe UI", 16.2F);
            txtAltura.Location = new Point(190, 215);
            txtAltura.Name = "txtAltura";
            txtAltura.Size = new Size(160, 43);
            txtAltura.TabIndex = 4;
            // 
            // btnCalcular
            // 
            btnCalcular.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCalcular.ForeColor = Color.Purple;
            btnCalcular.Location = new Point(477, 157);
            btnCalcular.Name = "btnCalcular";
            btnCalcular.Size = new Size(151, 47);
            btnCalcular.TabIndex = 5;
            btnCalcular.Text = "Calcular";
            btnCalcular.UseVisualStyleBackColor = true;
            btnCalcular.Click += btnCalcular_Click;
            // 
            // lblResultado
            // 
            lblResultado.AutoSize = true;
            lblResultado.Font = new Font("Arial Rounded MT Bold", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblResultado.ForeColor = Color.DarkViolet;
            lblResultado.Location = new Point(190, 310);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(162, 32);
            lblResultado.TabIndex = 6;
            lblResultado.Text = "Resultado:";
            lblResultado.Click += label4_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Lavender;
            ClientSize = new Size(800, 450);
            Controls.Add(lblResultado);
            Controls.Add(btnCalcular);
            Controls.Add(txtAltura);
            Controls.Add(txtPeso);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            TransparencyKey = Color.FromArgb(255, 192, 255);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtPeso;
        private TextBox txtAltura;
        private Button btnCalcular;
        private Label lblResultado;
    }
}
