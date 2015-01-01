/*
 * Created by SharpDevelop.
 * User: Lucas
 * Date: 21/12/2014
 * Time: 14:13
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace ProjetINFO0504
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.jeuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.jeuDeDameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.fichierToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(791, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fichierToolStripMenuItem
			// 
			this.fichierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.jeuToolStripMenuItem});
			this.fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
			this.fichierToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
			this.fichierToolStripMenuItem.Text = "Fichier";
			// 
			// jeuToolStripMenuItem
			// 
			this.jeuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.jeuDeDameToolStripMenuItem});
			this.jeuToolStripMenuItem.Name = "jeuToolStripMenuItem";
			this.jeuToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.jeuToolStripMenuItem.Text = "Jeux";
			// 
			// jeuDeDameToolStripMenuItem
			// 
			this.jeuDeDameToolStripMenuItem.Name = "jeuDeDameToolStripMenuItem";
			this.jeuDeDameToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.jeuDeDameToolStripMenuItem.Text = "Jeu de dames";
			this.jeuDeDameToolStripMenuItem.Click += new System.EventHandler(this.JeuDeDameToolStripMenuItemClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(791, 577);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.Text = "ProjetINFO0504";
			this.Click += new System.EventHandler(this.MainFormClick);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ToolStripMenuItem jeuDeDameToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem jeuToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fichierToolStripMenuItem;
		private System.Windows.Forms.MenuStrip menuStrip1;
		
		
		//Callback principale, appel les fonctions nécéssaires au jeu en cours
		void MainFormClick(object sender, System.EventArgs e)
		{
			try
			{
				if(j != null)
				{
					Case c = (Case)sender;
					int s = c.jouer_dame(j.getPlateau());
					if(s != 0)
					{
						if(Case.coup)
						{
							Case.j = !Case.j;
						}
						j.ajouterScore(Case.j,-s);
						if(Case.j)
						{
							s1.Text = j.getScore(true).ToString();
						}
						else
						{
							s2.Text = j.getScore(false).ToString();
						}
						if(Case.coup)
						{
							Case.j = !Case.j;
						}
					}
					
					if(j.getScore(true) == 0)
					{
						System.Windows.Forms.MessageBox.Show(j.getNom(false)+" gagne la partie");
						finPartie();
						
					}
					else if(j.getScore(false) == 0)
					{
						System.Windows.Forms.MessageBox.Show(j.getNom(true)+" gagne la partie");
						finPartie();
					}
				}
				
				
			}
			catch(System.InvalidCastException ice)
			{
				System.Console.Error.WriteLine("Une autre exception a eu lieu : "+ice.Message);
			}
		}
		
		void b1_Click(object sender, System.EventArgs e)
		{
			if(Case.j)
			{
				System.Windows.Forms.MessageBox.Show(j.getNom(false)+" gagne la partie");
			}
			else
			{
				System.Windows.Forms.MessageBox.Show(j.getNom(true)+" gagne la partie");
			}
			finPartie();
		}
	}
}
