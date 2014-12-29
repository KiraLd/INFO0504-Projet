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
		public String jeu;
		public Jeu j;
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
			for(i = 0; i <je.getPlateau().getLongueur();i++)
			{
				for(j = 0; j<je.getPlateau().getLargeur(); j++)
				{
					this.Controls.Add(je.getPlateau().p[i,j]);
					je.getPlateau().p[i,j].Click += new EventHandler(MainFormClick);
				}
			}
		}
		
		
		void JeuDeDameToolStripMenuItemClick(object sender, EventArgs e)
		{
			jeu = "dames";
			j = new Jeu("Joueur1","Joueur2",10,10,3,"dames");
			this.initialiserPlateau(ref j);
			
		}
		
	}
}
