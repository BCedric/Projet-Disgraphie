namespace Projet_Disgraphie
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        public void AfficherDonnee(string msg)
        {
            this.TextBoxDonnees.AppendText(msg);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_check = new System.Windows.Forms.Button();
            this.TextBoxDonnees = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_check
            // 
            this.button_check.Location = new System.Drawing.Point(12, 12);
            this.button_check.Name = "button_check";
            this.button_check.Size = new System.Drawing.Size(75, 23);
            this.button_check.TabIndex = 0;
            this.button_check.Text = "Bouton check";
            this.button_check.UseVisualStyleBackColor = true;
            this.button_check.Click += new System.EventHandler(this.button1_Click);
            // 
            // TextBoxDonnees
            // 
            this.TextBoxDonnees.Location = new System.Drawing.Point(191, 14);
            this.TextBoxDonnees.Multiline = true;
            this.TextBoxDonnees.Name = "TextBoxDonnees";
            this.TextBoxDonnees.Size = new System.Drawing.Size(1032, 420);
            this.TextBoxDonnees.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1559, 499);
            this.Controls.Add(this.TextBoxDonnees);
            this.Controls.Add(this.button_check);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_check;
        private System.Windows.Forms.TextBox TextBoxDonnees;
    }
}

