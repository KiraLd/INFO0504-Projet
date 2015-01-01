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
		
		
		
		
		
		
		
		//fonctions jeu de Dames, fonction principale
		public int jouer_dame(Plateau p)
		{
			//cas 1: aucune pièce selectionnée
			if(test == null)
			{
				if(etat[1])
				{
					if(etat[0] == j)
					{
						//la pièce selectionnée est retenue si elle appartient bien au joueur dont c'est le tour de jouée
						selectionnerCase();
						return 0;
					}
				}
			}
			//cas 2: on selectionne une autre pièce, si le joueur n'a pas déjà pris une pièce adverse 
			else if(test.etat[0] == this.etat[0] && etat[1] && !coup)
			{
				System.Drawing.Color c;
				if(!test.etat[2])
				{
					if(j)
					{
						c = System.Drawing.Color.Black;
					}
					else
					{
						c = System.Drawing.Color.Red;
					}
				}
				else
				{
					if(j)
					{
						c = System.Drawing.Color.Gray;
					}
					else
					{
						c = System.Drawing.Color.Pink;
					}
				}
				
				test.setCouleur(c);
				selectionnerCase();
				return 0;
			}
			//cas 3: une pièce a été selectionnée et le joueur veut la déplacer
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
						if(priseJouable(x, y, px, py, p))
						{
							prise(x, y, px, py, p);
							return 1;
						}
						else if(!coup)
						{
							if(coupJouable(x, y, px, py, 10, 10, p))
							{
								deplacementCase();
								j = !j;
								return 0;
							}
						}
						
						
					}
				}
			}
			return 0;
		}
		
		
		//détermine si la pièce selectionnée peut prendre une pièce adverse
		public bool priseJouable(int x, int y, int px, int py, Plateau p)
		{
			bool res = false;
			//si la pièce n'est pas une dame, on vérifie les 4 coups possibles
			if(!test.etat[2])
			{
				res = coordonneesValides(px + 2 , py + 2, 10, 10) && px + 2 == x && py + 2 == y && p.getCase(px + 1, py + 1).etat[1] && p.getCase(px + 1, py + 1).etat[0] == !test.etat[0] && !p.getCase(px + 2, py + 2).etat[1];
				res = res || coordonneesValides(px - 2, py + 2, 10, 10) && px - 2 == x && py + 2 == y && p.getCase(px - 1, py + 1).etat[1] && p.getCase(px - 1, py + 1).etat[0] == !test.etat[0]  && !p.getCase(px - 2, py + 2).etat[1];
				res = res || coordonneesValides(px + 2, py - 2, 10, 10) && px + 2 == x && py - 2 == y && p.getCase(px + 1, py - 1).etat[1] && p.getCase(px + 1, py - 1).etat[0] == !test.etat[0] && !p.getCase(px + 2, py - 2).etat[1];
				res = res || coordonneesValides(px - 2, py - 2, 10, 10) && px - 2 == x && py - 2 == y && p.getCase(px - 1, py - 1).etat[1] && p.getCase(px - 1, py - 1).etat[0] == !test.etat[0]  && !p.getCase(px - 2, py - 2).etat[1];
			}
			//si la pièce est une dame, on cherche un coup possible sur l'une des diagonales
			else
			{
				int dif_x = x - px;
				int dif_y = y - py;
				int i;
				res = true;
				int k = 0;
				//on vérifie que le déplacement est bien en diagonale
				if(Math.Abs(dif_x) == Math.Abs(dif_y)) 
				{
					if(dif_x > 0 && dif_y > 0)
					{
						i = 1;
						while(k < 2 && coordonneesValides(px + i, py + i, 10, 10) && px + i != x && py + i != y)
						{
							if(p.getCase(px + i, py + i).etat[1] && p.getCase(px + i, py + i).etat[0] != test.etat[0])
							{
								k++;
							}
							i++;
						}
					}
					else if(dif_x > 0 && dif_y < 0)
					{
						i = 1;
						while(k < 2 && coordonneesValides(px + i, py - i, 10, 10) && px + i != x && py - i != y)
						{
							if(p.getCase(px + i, py - i).etat[1] && p.getCase(px + i, py - i).etat[0] != test.etat[0])
							{
								k++;
							}
							i++;
						}
					}
					else if(dif_x < 0 && dif_y > 0)
					{
						i = 1;
						while(k < 2 && coordonneesValides(px - i, py + i, 10, 10) && px - i != x && py + i != y)
						{
							if(p.getCase(px - i, py + i).etat[1] && p.getCase(px - i, py + i).etat[0] != test.etat[0])
							{
								k++;
							}
							i++;
						}
						
					}
					else if(dif_x < 0 && dif_y < 0)
					{
						i = 1;
						while(k < 2 && coordonneesValides(px - i, py - i, 10, 10) && px - i != x && py - i != y)
						{
							if(p.getCase(px - i, py - i).etat[1] && p.getCase(px - i, py - i).etat[0] != test.etat[0])
							{
								k++;
							}
							i++;
						}
					}
					//si il y a plus d'une pièce adverse entre la pièce selectionné et les coordonnées de destination
					if(k != 1)
					{
						res = false;
					}
				}
			}
			return res;
		}
		
		
		//effectue la prise d'une pièce adverse
		public void prise(int x, int y, int px, int py, Plateau p)
		{
			//pièce normale, on détermine les coordonnées de la pièce prise et on met à jour le plateau
			if(!test.etat[2])
			{
				int prise_x = 0;
				int prise_y = 0;
				if(coordonneesValides(px + 2, py + 2, 10, 10) && px + 2 == x && py + 2 == y && p.getCase(px + 1, py + 1).etat[1] && p.getCase(px + 1, py + 1).etat[0] == !test.etat[0])
				{
					prise_x = px + 1;
					prise_y = py + 1;
				}
				else if(coordonneesValides(px - 2, py + 2, 10, 10) && px - 2 == x && py + 2 == y && p.getCase(px - 1, py +1).etat[1] && p.getCase(px - 1, py + 1).etat[0] == !test.etat[0])
				{
					prise_x = px - 1;
					prise_y = py + 1;
				}
				else if(coordonneesValides(px + 2 ,py - 2, 10, 10) && px + 2 == x && py - 2 == y && p.getCase(px + 1, py - 1).etat[1] && p.getCase(px + 1, py - 1).etat[0] == !test.etat[0])
				{
					prise_x = px + 1;
					prise_y = py -1 ;
				}
				else if(coordonneesValides(px - 2,py - 2, 10, 10) && px - 2 == x && py - 2 == y && p.getCase(px - 1, py - 1).etat[1] && p.getCase(px - 1, py - 1).etat[0] == !test.etat[0])
				{
					prise_x = px - 1;
					prise_y = py - 1;
				}
				p.getCase(prise_x, prise_y).etat[0] = false;
				p.getCase(prise_x, prise_y).etat[1] = false;
				p.getCase(prise_x, prise_y).etat[2] = false;
				p.getCase(prise_x, prise_y).BackColor = System.Drawing.Color.White;
				deplacementCase();
				test = this;
				
				//détermine si on peut faire plusieurs prises à la suite
				if(!etat[2])
				{
					if(priseJouable(x - 2, y - 2, x, y, p) || priseJouable(x + 2, y - 2, x, y, p) || priseJouable(x - 2, y + 2, x, y, p) || priseJouable(x + 2, y + 2,x ,y ,p))
					{
						coup = true;
						this.BackColor = System.Drawing.Color.Green;
					}
					else
					{
						coup = false;
						test = null;
						j = !j;
					}
				}
				else
				{
					if(priseJouableDame(p))
					{
						coup = true;
						this.BackColor = System.Drawing.Color.Green;
					}
					else
					{
						coup = false;
						test = null;
						j = !j;
					}
				}
				
			}
			//dame, on cherche les coordonnées de la pièce à prendre sur l'une des diagonales et on met à jour le plateau
			else
			{
				int dif_x = x - px;
				int dif_y = y - py;
				int i;
				int prise_x = 0;
				int prise_y = 0;
				bool prise = false;
				if(Math.Abs(dif_x) == Math.Abs(dif_y))
				{
					if(dif_x > 0 && dif_y > 0)
					{
						i = 1;
						while(!prise && coordonneesValides(px + i, py + i, 10, 10) && px + i != x && py + i != y)
						{
							if(p.getCase(px + i, py + i).etat[1] && p.getCase(px + i, py + i).etat[0] != test.etat[0])
							{
								prise_x = px + i;
								prise_y = py + i;
								prise = true;
							}
							i++;
						}
					}
					else if(dif_x > 0 && dif_y < 0)
					{
						i = 1;
						while(!prise && coordonneesValides(px + i, py - i, 10, 10) && px + i != x && py - i != y)
						{
							if(p.getCase(px + i, py - i).etat[1] && p.getCase(px + i, py - i).etat[0] != test.etat[0])
							{
								prise_x = px + i;
								prise_y = py - i;
								prise = true;
							}
							i++;
						}
					}
					else if(dif_x < 0 && dif_y > 0)
					{
						i = 1;
						while(!prise && coordonneesValides(px - i, py + i, 10, 10) && px - i != x && py + i != y)
						{
							if(p.getCase(px - i, py + i).etat[1] && p.getCase(px - i, py + i).etat[0] != test.etat[0])
							{
								prise_x = px - i;
								prise_y = py + i;
								prise = true;
							}
							i++;
						}
					}
					else if(dif_x < 0 && dif_y < 0)
					{
						i = 1;
						while(!prise && coordonneesValides(px - i, py - i, 10, 10) && px - i != x && py - i != y)
						{
							if(p.getCase(px - i, py - i).etat[1] && p.getCase(px - i, py - i).etat[0] != test.etat[0])
							{
								prise_x = px - i;
								prise_y = py - i;
								prise = true;
							}
							i++;
						}
					}
					p.getCase(prise_x, prise_y).etat[0] = false;
					p.getCase(prise_x, prise_y).etat[1] = false;
					p.getCase(prise_x, prise_y).etat[2] = false;
					p.getCase(prise_x, prise_y).BackColor = System.Drawing.Color.White;
					deplacementCase();
					test = this;
					//gestion des prises successives
					if(priseJouableDame(p))
					{
						coup = true;
						this.BackColor = System.Drawing.Color.Green;
					}
					else
					{
						test = null;
						j = !j;
					}
				}		
			}			
		}
		
		//détermine si une dame peut prendre une pièce adverse 
		public bool priseJouableDame(Plateau p)
		{
			int i = 0;
			bool res = false;
			bool cas1 = false;
			bool cas2 = false;
			bool cas3 = false;
			bool cas4 = false;
			int x = getCoordonnees().getX();
			int y = getCoordonnees().getY();
			while(!cas1 && !cas2 && !cas3 && !cas4 && i<10)
			{
				if(coordonneesValides(x + i, y + i, 10, 10) && p.getCase(x + i, y + i).etat[1] && p.getCase(x + i, y + i).etat[0] != etat[0])
				{
					cas1 = true;
				}
				if(coordonneesValides(x + i, y - i, 10, 10) && p.getCase(x + i, y - i).etat[1] && p.getCase(x + i, y - i).etat[0] != etat[0])
				{
					cas2 = true;
				}
				if(coordonneesValides(x - i, y + i, 10, 10) && p.getCase(x - i, y + i).etat[1] && p.getCase(x - i, y + i).etat[0] != etat[0])
				{
					cas3 = true;
				}
				if(coordonneesValides(x - i, y - i, 10, 10) && p.getCase(x - i, y - i).etat[1] && p.getCase(x - i, y - i).etat[0] != etat[0])
				{
					cas4 = true;
				}
				i++;
			}
			if(cas1)
			{
				if(coordonneesValides(x + i, y + i, 10, 10) && !p.getCase(x + i, y + i).etat[1])
				{
					res = true;
				}
			}
			else if(cas2)
			{
				if(coordonneesValides(x + i, y - i, 10, 10) && !p.getCase(x + i, y - i).etat[1])
				{
					res = true;
				}
			}
			else if(cas3)
			{
				if(coordonneesValides(x - i,y + i, 10, 10) && !p.getCase(x - i, y + i).etat[1])
				{
					res = true;
				}
			}
			else if(cas4)
			{
				if(coordonneesValides(x - i,y - i,10,10) && !p.getCase(x - i, y - i).etat[1])
				{
					res = true;
				}
			}
			return res;
		}
		
		//gestion de la pièce selectionnée par le joueur
		public void selectionnerCase()
		{
			test = this;
			test.BackColor = System.Drawing.Color.Green;
			coup = false;
		}
		
		//déplacement d'une pièce
		public void deplacementCase()
		{
			if(!test.etat[2])
			{
				System.Drawing.Color c;
			    if(j)
				{
			    	if(this.getCoordonnees().getY() == 9)
			    	{
			    		c = System.Drawing.Color.Gray;
			    		etat[2] = true;
			    	}
			    	else
			    	{
			    		c = System.Drawing.Color.Black;
			    		etat[2] = false;
			    	}
					
				}
				else
				{
					if(this.getCoordonnees().getY() == 0)
			    	{
			    		c = System.Drawing.Color.Pink;
			    		etat[2] = true;
			    	}
			    	else
			    	{
			    		c = System.Drawing.Color.Red;
			    		etat[2] = false;
			    	}
					
				}
				setCouleur(c);
				etat[1] = true;
				etat[0] = j;
				test.setCouleur(System.Drawing.Color.White);
				test.etat[1] = false;
				test.etat[0] = false;
				test = null;
			}
			else
			{
				System.Drawing.Color c;
			    if(j)
				{
					c = System.Drawing.Color.Gray;
				}
				else
				{
					c = System.Drawing.Color.Pink;
				}
				setCouleur(c);
				etat[2] = true;
				etat[1] = true;
				etat[0] = j;
				test.setCouleur(System.Drawing.Color.White);
				test = null;
			}
			
		}
		
		//vérifie si les indices (x,y) sont valables(positives et inférieurs à la du plateau)
		public bool coordonneesValides(int x, int y, int xmax, int ymax)
		{
			return (x >= 0 && x < xmax) && (y >= 0 && y < ymax);
		}
		
		//vérifie si la pièce selectionnée peut se déplacer
		public bool coupJouable(int x, int y, int px, int py, int xmax, int ymax, Plateau p)
		{		
			bool res = false;
			//pièce normale, 2 positions possibles
			if(!test.etat[2])
			{
				if(j)
				{
					res = coordonneesValides(px + 1, py + 1, 10, 10) && px + 1 == x && py + 1 == y;
					res = res || coordonneesValides(px - 1, py + 1, 10, 10) && px - 1 == x && py + 1 == y;
				}
				else
				{
					res = coordonneesValides(px + 1, py - 1, 10, 10) && px + 1 == x && py - 1 == y;
					res = res || coordonneesValides(px - 1, py - 1, 10, 10) && px - 1 == x && py - 1 == y;
				}
				
			}
			//dame, n possitions possibles
			else
			{
				int dif_x = x - px;
				int dif_y = y - py;
				int i;
				res = true;
				if(Math.Abs(dif_x) == Math.Abs(dif_y))
				{
					if(dif_x > 0 && dif_y > 0)
					{
						i = 1;
						while(res && coordonneesValides(px + i, py + i, 10, 10) && px + i != x && py + i != y)
						{
							if(p.getCase(px + i, py + i).etat[1])
							{
								res = false;
							}
							i++;
						}
					}
					else if(dif_x > 0 && dif_y < 0)
					{
						i = 1;
						while(res && coordonneesValides(px + i, py - i, 10, 10) && px + i != x && py - i != y)
						{
							if(p.getCase(px + i, py - i).etat[1])
							{
								res = false;
							}
							i++;
						}
					}
					else if(dif_x < 0 && dif_y > 0)
					{
						i = 1;
						while(res && coordonneesValides(px - i, py + i, 10, 10) && px - i != x && py + i != y)
						{
							if(p.getCase(px - i, py + i).etat[1])
							{
								res = false;
							}
							i++;
						}
					}
					else if(dif_x < 0 && dif_y < 0)
					{
						i = 1;
						while(res && coordonneesValides(px - i, py - i, 10, 10) && px - i != x && py - i != y)
						{
							if(p.getCase(px - i, py - i).etat[1])
							{
								res = false;
							}
							i++;
						}
					}	
				}
				else
				{
					res = false;
				}
			}
			return res;	
		}
	}
}
