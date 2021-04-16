namespace Simulación_IG
{
    partial class Mundo
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
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
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.angBar = new System.Windows.Forms.TrackBar();
            this.btnDisparar = new System.Windows.Forms.Button();
            this.txtPeso = new System.Windows.Forms.TextBox();
            this.Peso = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.angBar)).BeginInit();
            this.SuspendLayout();
            // 
            // angBar
            // 
            this.angBar.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.angBar.Location = new System.Drawing.Point(314, 599);
            this.angBar.Minimum = -10;
            this.angBar.Name = "angBar";
            this.angBar.Size = new System.Drawing.Size(203, 45);
            this.angBar.TabIndex = 2;
            this.angBar.ValueChanged += new System.EventHandler(this.angBar_ValueChanged);
            // 
            // btnDisparar
            // 
            this.btnDisparar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisparar.Location = new System.Drawing.Point(801, 577);
            this.btnDisparar.Name = "btnDisparar";
            this.btnDisparar.Size = new System.Drawing.Size(120, 43);
            this.btnDisparar.TabIndex = 3;
            this.btnDisparar.Text = "Disparar";
            this.btnDisparar.UseVisualStyleBackColor = true;
            this.btnDisparar.Click += new System.EventHandler(this.btnDisparar_Click);
            // 
            // txtPeso
            // 
            this.txtPeso.Location = new System.Drawing.Point(956, 589);
            this.txtPeso.Name = "txtPeso";
            this.txtPeso.Size = new System.Drawing.Size(161, 20);
            this.txtPeso.TabIndex = 4;
            this.txtPeso.Text = "20";
            // 
            // Peso
            // 
            this.Peso.AutoSize = true;
            this.Peso.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Peso.Location = new System.Drawing.Point(971, 561);
            this.Peso.Name = "Peso";
            this.Peso.Size = new System.Drawing.Size(57, 24);
            this.Peso.TabIndex = 5;
            this.Peso.Text = "Peso";
            // 
            // Mundo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Simulación_IG.Properties.Resources._188825;
            this.ClientSize = new System.Drawing.Size(1196, 656);
            this.Controls.Add(this.Peso);
            this.Controls.Add(this.txtPeso);
            this.Controls.Add(this.btnDisparar);
            this.Controls.Add(this.angBar);
            this.DoubleBuffered = true;
            this.Name = "Mundo";
            this.Text = "Uwu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Mundo_FormClosing);
            this.Load += new System.EventHandler(this.Mundo_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Mundo_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.angBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TrackBar angBar;
        private System.Windows.Forms.Button btnDisparar;
        private System.Windows.Forms.TextBox txtPeso;
        private System.Windows.Forms.Label Peso;
    }
}

