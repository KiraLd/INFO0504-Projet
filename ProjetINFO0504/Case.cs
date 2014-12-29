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
		
		public Case(int nbE, int x, int y, int loc_x, int loc_y, int size_x, int size_y, System.Drawing.Color c, String d)
		{
			this.c = new Coordonnees(x, y);
			etat = new bool[nbE];
			setCouleur(c);
			this.setLocation(loc_x,loc_y);
			this.setTaille(size_x,size_y);
			jeu = d;
			j = false;
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
		
		
		//fonctions jeu de Dames, fonction principale
		public void jouer_dame()
		{
			if(test == null)
			{
				if(etat[1])
				{
					if(etat[0] == j)
					{
						test = this;
					}
				}
			}
			else
			{
				if(!etat[1])
				{
					if(test.etat[0] == j)
					{
						int x = this.getCoordonnees().getX();
						int y = this.getCoordonnees().getY();
						int px = test.getCoordonnees().getX();
						int py = test.getCoordonnees().getY();
						if(coupJouable(x,y,px,py,10,10))
						{
							System.Drawing.Color c;
							if(j)
							{
								c = System.Drawing.Color.Black;
							}
							else
							{
								c = System.Drawing.Color.Red;
							}
							setCouleur(c);
							etat[1] = true;
							etat[0] = j;
							test.setCouleur(System.Drawing.Color.White);
							test = null;
							j = !j;
						}
						
					}
				}
			}
		}
		
		public bool coordonneesValides(int x, int y, int xmax, int ymax)
		{
			return (x>=0 && x<xmax)&&(y>=0 && y<ymax);
		}
		
		public bool coupJouable(int x, int y, int px, int py, int xmax, int ymax)
		{
			bool res = false;
			if(!etat[2])
			{
				if(j)
				{
					res = coordonneesValides(px+1,py,10,10) && px+1==x && py ==y;
					res = res || coordonneesValides(px,py+1,10,10) && px==x && py+1 ==y;
				}
				else
				{
					res = coordonneesValides(px-1,py,10,10) && px-1==x && py ==y;
					res = res || coordonneesValides(px,py-1,10,10) && px==x && py-1 ==y;
				}
				
			}
			
			return !res;
		}
		
		
		
		
	}
}
