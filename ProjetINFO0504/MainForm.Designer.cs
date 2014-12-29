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
			this.menuStrip1.Size = new System.Drawing.Size(653, 24);
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
			this.jeuToolStripMenuItem.Size = new System.Drawing.Size(91, 22);
			this.jeuToolStripMenuItem.Text = "Jeu";
			// 
			// jeuDeDameToolStripMenuItem
			// 
			this.jeuDeDameToolStripMenuItem.Name = "jeuDeDameToolStripMenuItem";
			this.jeuDeDameToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
			this.jeuDeDameToolStripMenuItem.Text = "Jeu de dame";
			this.jeuDeDameToolStripMenuItem.Click += new System.EventHandler(this.JeuDeDameToolStripMenuItemClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(653, 577);
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
				Case c = (Case)sender;
				c.jouer_dame();
			}
			catch(System.InvalidCastException ice)
			{
				System.Console.Error.WriteLine("Une autre exception a eu lieu : "+ice.Message);
			}
			
			
		}
	}
}
