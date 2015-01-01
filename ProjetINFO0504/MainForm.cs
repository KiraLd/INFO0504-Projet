/*
 * Created by SharpDevelop.
 * User: Lucas
 * Date: 21/12/2014
 * Time: 14:13
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ProjetINFO0504
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		private String jeu;
		private Jeu j;
		private Label j1,j2,s1,s2;
		private Button b1;
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void initialiserPlateau(ref Jeu je)
		{
			int i;
			int j;
			j1 = new Label();
			j2 = new Label();
			s1 = new Label();
			s2 = new Label();
			j1.Location = new Point(600,200);
			j2.Location = new Point(600,250);
			s1.Location = new Point(600,225);
			s2.Location = new Point(600,275);
			j1.Text = je.getNom(true);
			j2.Text = je.getNom(false);
			s1.Text = "20";
			s2.Text = "20";
			Controls.Add(j1);
			Controls.Add(j2);
			Controls.Add(s1);
			Controls.Add(s2);	
			b1 = new Button();
			b1.Text = "Abandonner";
			b1.Location = new Point(600,150);
			Controls.Add(b1);
			b1.Click += new EventHandler(b1_Click);
			for(i = 0; i < je.getPlateau().getLongueur() ; i++)
			{
				for(j = 0; j <je.getPlateau().getLargeur() ; j++)
				{
					this.Controls.Add(je.getPlateau().p[i,j]);
					je.getPlateau().p[i,j].Click += new EventHandler(MainFormClick);
				}
			}
		}
		
		
		void JeuDeDameToolStripMenuItemClick(object sender, EventArgs e)
		{
			jeu = "dames";
			String j1 = Microsoft.VisualBasic.Interaction.InputBox("Entrez le nom du 1er joueur:","Joueur 1","Noir",0,0);
			String j2 = Microsoft.VisualBasic.Interaction.InputBox("Entrez le nom du 2ème joueur:","Joueur 2","Rouge",0,0);
			j = new Jeu(j1,j2,10,10,3,"dames",true);
			j.ajouterScore(true,20);
			j.ajouterScore(false,20);
			this.initialiserPlateau(ref j);
		}
		
		void finPartie()
		{
			j = null;
			j1 = null;
			j2 = null;
			s1 = null;
			s2 = null;
			jeu = null;
		}
		
		

	}
}
