/*
 * Created by SharpDevelop.
 * User: Lucas
 * Date: 21/12/2014
 * Time: 15:25
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ProjetINFO0504
{
	/// <summary>
	/// Plateau de jeu, ensemble des cases
	/// </summary>
	
	public class Plateau
	{
		//matrice de case
		public Case[,] p;
		
		//position de la 1ère case du plateau
		private int loc_x;
		private int loc_y;
		
		//tailles de la matrice
		private int size_x;
		private int size_y;
		
		//Constructeurs
		public Plateau()
		{
			loc_x = 0;
			loc_y = 0;
			size_x = 10;
			size_y = 10;
			p = new Case[size_x,size_y];
		}
		
		public Plateau(int loc_px, int loc_py, int size_px, int size_py ,int nbE,int size_x, int size_y, System.Drawing.Color c, String d)
		{
			this.loc_x = loc_px;
			this.loc_y = loc_py;
			this.size_x = size_px;
			this.size_y = size_py;
			
			//création de la matrice
			p = new Case[size_x,size_y];
			
			initialiser(nbE,size_x,size_y,c,d);
			if(d.Equals("dames"))
			{
				dame();
			}
			
		}
		
		//initialises toutes les cases
		private void initialiser(int nbE, int size_x, int size_y, System.Drawing.Color c, String d)
		{
			int i;
			int j;
			int x = loc_x;
			int y = loc_y;
			for(i = 0; i<this.size_x; i++)
			{
				x += size_x +2;
				y = loc_y;
				for(j = 0; j<this.size_y; j++)
				{
					y += size_y +2;
					p[i,j] = new Case(nbE,i,j, x, y,size_x,size_y,c,d);
				}
			}
			
		}
		
		//initialisation des états/couleurs des cases au début d'une partie
		//etat[0]: détermine le joueur, etat[1]: case vide ou occupe, etat[2]: dame ou pièce normale
		private void dame()
		{
			int i,j;
			
			//pièces noires
			for( i = 0; i<4; i++)
			{
				for( j =0; j<this.size_y; j++)
				{
					if(i%2 == 0)
					{
						if(j%2 == 1)
						{
							p[j,i].setCouleur(System.Drawing.Color.Black);
							p[j,i].setEtat(true,0);
							p[j,i].setEtat(true,1);
						}
					}
					else
					{
						if(j%2 == 0)
						{
							p[j,i].setCouleur(System.Drawing.Color.Black);
							p[j,i].setEtat(true,0);
							p[j,i].setEtat(true,1);
						}
					}
				}
			}
			
			//pièces rouge
			for( i = size_x-4; i<size_x; i++)
			{
				for( j =0; j<this.size_y; j++)
				{
					if(i%2 == 0)
					{
						if(j%2 == 1)
						{
							p[j,i].setCouleur(System.Drawing.Color.Red);
							p[j,i].setEtat(false,0);
							p[j,i].setEtat(true,1);
						}
					}
					else
					{
						if(j%2 == 0)
						{
							p[j,i].setCouleur(System.Drawing.Color.Red);
							p[j,i].setEtat(false,0);
							p[j,i].setEtat(true,1);
						}
					}
				}
			}
		}
		
		
		//Getters
		
		public Case getCase(int i, int j)
		{
			if(i >= 0 && i < size_x)
			{
				if(j >= 0 && j < size_y)
				{
					return p[i,j];
				}
				else
				{
					return null;
				}
			}
			else
			{
				return null;
			}
		}
		
		public int getLongueur()
		{
			return size_x;
		}
		
		public int getLargeur()
		{
			return size_y;
		}
		
		public void setEtat(bool b, int i)
		{
			int j,k;
			for(j = 0; j<size_x ; j++)
			{
				for(k = 0; k<size_y; k++)
				{
					p[j,k].setEtat(b,i);
				}
			}
		}
	}
}
