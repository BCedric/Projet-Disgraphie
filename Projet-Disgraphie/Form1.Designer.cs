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
          //  this.TextBoxDonnees.AppendText(msg);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.picBoard = new System.Windows.Forms.PictureBox();
            this.TextBoxVitesseActuelle = new System.Windows.Forms.TextBox();
            this.textBoxVitesseMoyenne = new System.Windows.Forms.TextBox();
            this.textBoxNbPoint = new System.Windows.Forms.TextBox();
            this.textBoxPression = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxJerkMoyen = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textJerkInstant = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBoard)).BeginInit();
            this.SuspendLayout();
            //
            // picBoard
            //
            this.picBoard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picBoard.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.picBoard.Location = new System.Drawing.Point(259, 31);
            this.picBoard.Name = "picBoard";
            this.picBoard.Size = new System.Drawing.Size(1638, 930);
            this.picBoard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picBoard.TabIndex = 3;
            this.picBoard.TabStop = false;
            //
            // TextBoxVitesseActuelle
            //
            this.TextBoxVitesseActuelle.Location = new System.Drawing.Point(135, 94);
            this.TextBoxVitesseActuelle.Name = "TextBoxVitesseActuelle";
            this.TextBoxVitesseActuelle.Size = new System.Drawing.Size(100, 20);
            this.TextBoxVitesseActuelle.TabIndex = 4;
            //
            // textBoxVitesseMoyenne
            //
            this.textBoxVitesseMoyenne.Location = new System.Drawing.Point(135, 137);
            this.textBoxVitesseMoyenne.Name = "textBoxVitesseMoyenne";
            this.textBoxVitesseMoyenne.Size = new System.Drawing.Size(100, 20);
            this.textBoxVitesseMoyenne.TabIndex = 5;
            //
            // textBoxNbPoint
            //
            this.textBoxNbPoint.Location = new System.Drawing.Point(135, 179);
            this.textBoxNbPoint.Name = "textBoxNbPoint";
            this.textBoxNbPoint.Size = new System.Drawing.Size(100, 20);
            this.textBoxNbPoint.TabIndex = 6;
            //
            // textBoxPression
            //
            this.textBoxPression.Location = new System.Drawing.Point(135, 221);
            this.textBoxPression.Name = "textBoxPression";
            this.textBoxPression.Size = new System.Drawing.Size(100, 20);
            this.textBoxPression.TabIndex = 7;
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Vitesse instantanée :";
            //
            // label2
            //
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Vitesse moyenne :";
            //
            // label3
            //
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Nb points capturés :";
            //
            // label4
            //
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 228);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Pression :";
            //
            // label5
            //
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 269);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Jerk moyen :";
            //
            // textBoxJerkMoyen
            //
            this.textBoxJerkMoyen.Location = new System.Drawing.Point(135, 262);
            this.textBoxJerkMoyen.Name = "textBoxJerkMoyen";
            this.textBoxJerkMoyen.Size = new System.Drawing.Size(100, 20);
            this.textBoxJerkMoyen.TabIndex = 12;
            //
            // label6
            //
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 313);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Jerk instantané :";
            //
            // textJerkInstant
            //
            this.textJerkInstant.Location = new System.Drawing.Point(135, 306);
            this.textJerkInstant.Name = "textJerkInstant";
            this.textJerkInstant.Size = new System.Drawing.Size(100, 20);
            this.textJerkInstant.TabIndex = 14;
            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1916, 983);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textJerkInstant);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxJerkMoyen);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxPression);
            this.Controls.Add(this.textBoxNbPoint);
            this.Controls.Add(this.textBoxVitesseMoyenne);
            this.Controls.Add(this.TextBoxVitesseActuelle);
            this.Controls.Add(this.picBoard);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picBoard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox picBoard;
        private System.Windows.Forms.TextBox TextBoxVitesseActuelle;
        private System.Windows.Forms.TextBox textBoxVitesseMoyenne;
        private System.Windows.Forms.TextBox textBoxNbPoint;
        private System.Windows.Forms.TextBox textBoxPression;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxJerkMoyen;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textJerkInstant;
    }
}
