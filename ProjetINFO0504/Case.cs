/*
 * Created by SharpDevelop.
 * User: Lucas
 * Date: 21/12/2014
 * Time: 14:20
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ProjetINFO0504
{
	/// <summary>
	/// Description of Case.
	/// </summary>
	
	public class Case: System.Windows.Forms.PictureBox
	{
		
		private Coordonnees c;
		public static bool j;
		private bool[] etat;
		public static Case test;
		public static String jeu;
		public static bool coup = false;
		
		
		//Constructeurs
		
		public Case()
		{
			c = new Coordonnees();
			etat = new bool[3];
			this.BackColor = System.Drawing.Color.White;
			j = false;
		}
		
		public Case(int taille, int x, int y)
		{
			c = new Coordonnees(x, y);
			etat = new bool[taille];
			this.BackColor = System.Drawing.Color.White;
			this.Size = new System.Drawing.Size(10, 10);
			j = false;
		}
		
		public Case(int nbE, int x, int y, int loc_x, int loc_y, int size_x, int size_y, System.Drawing.Color c, String d, bool je)
		{
			this.c = new Coordonnees(x, y);
			etat = new bool[nbE];
			setCouleur(c);
			this.setLocation(loc_x,loc_y);
			this.setTaille(size_x,size_y);
			jeu = d;
			j = je;
		}
		
		//Setters
		
		public void setLocation(int a, int b)
		{
			this.Location = new System.Drawing.Point(a,b);
		}
		
		public void setTaille(int a, int b)
		{
			this.Size = new System.Drawing.Size(a, b);
		}
		
		public void setCouleur(System.Drawing.Color c)
		{
			this.BackColor = c;
		}
		
		public void setEtat(bool b, int i)
		{
			if(i >= 0 && i <etat.Length)
			{
				etat[i] = b;
			}
		}
		
		
		//Getters
		
		public Coordonnees getCoordonnees()
		{
			return c;
		}
		
		public bool getEtat(int i)
		{
			if(i>=0 && i < etat.Length)
			{
				return etat[i];
			}
			return false;
		}
		
	}
		
		
		
		
		
		
}
