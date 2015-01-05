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
using ProjetINFO0504;

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
			Case.jeu = "dames";
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
		
		//fonctions Case.jeu de Dames, fonction principale
		public int jouer_dame(Case c, Plateau p)
		{
			//cas 1: aucune pièce selectionnée
			if(Case.test == null)
			{
				if(c.getEtat(1))
				{
					if(c.getEtat(0) == Case.j)
					{
						//la pièce selectionnée est retenue si elle appartient bien au Case.joueur dont c'est le tour de Case.jouée
						selectionnerCase(c);
						return 0;
					}
				}
			}
			//cas 2: on selectionne une autre pièce, si le Case.joueur n'a pas déCase.jà pris une pièce adverse 
			else if(Case.test.getEtat(0) == c.getEtat(0) && c.getEtat(1) && !Case.coup)
			{
				System.Drawing.Color co;
				if(!Case.test.getEtat(2))
				{
					if(Case.j)
					{
						co = System.Drawing.Color.Black;
					}
					else
					{
						co = System.Drawing.Color.Red;
					}
				}
				else
				{
					if(Case.j)
					{
						co = System.Drawing.Color.Gray;
					}
					else
					{
						co = System.Drawing.Color.Pink;
					}
				}
				
				Case.test.setCouleur(co);
				selectionnerCase(c);
				return 0;
			}
			//cas 3: une pièce a été selectionnée et le Case.joueur veut la déplacer
			else
			{
				if(!c.getEtat(1))
				{
					if(Case.test.getEtat(0) == Case.j)
					{
						int x = c.getCoordonnees().getX();
						int y = c.getCoordonnees().getY();
						int px = Case.test.getCoordonnees().getX();
						int py = Case.test.getCoordonnees().getY();
						if(priseJouable(x, y, px, py, p))
						{
							prise(c,x, y, px, py, p);
							return 1;
						}
						else if(!Case.coup)
						{
							if(coupJouable(x, y, px, py, 10, 10, p))
							{
								deplacementCase(c);
								Case.j = !Case.j; //ligne à enlever pour le multi
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
			//si la pièce n'est pas une dame, on vérifie les 4 Case.coups possibles
			if(!Case.test.getEtat(2))
			{
				res = coordonneesValides(px + 2 , py + 2, 10, 10) && px + 2 == x && py + 2 == y && p.getCase(px + 1, py + 1).getEtat(1) && p.getCase(px + 1, py + 1).getEtat(0) == !Case.test.getEtat(0) && !p.getCase(px + 2, py + 2).getEtat(1);
				res = res || coordonneesValides(px - 2, py + 2, 10, 10) && px - 2 == x && py + 2 == y && p.getCase(px - 1, py + 1).getEtat(1) && p.getCase(px - 1, py + 1).getEtat(0) == !Case.test.getEtat(0)  && !p.getCase(px - 2, py + 2).getEtat(1);
				res = res || coordonneesValides(px + 2, py - 2, 10, 10) && px + 2 == x && py - 2 == y && p.getCase(px + 1, py - 1).getEtat(1) && p.getCase(px + 1, py - 1).getEtat(0) == !Case.test.getEtat(0) && !p.getCase(px + 2, py - 2).getEtat(1);
				res = res || coordonneesValides(px - 2, py - 2, 10, 10) && px - 2 == x && py - 2 == y && p.getCase(px - 1, py - 1).getEtat(1) && p.getCase(px - 1, py - 1).getEtat(0) == !Case.test.getEtat(0)  && !p.getCase(px - 2, py - 2).getEtat(1);
			}
			//si la pièce est une dame, on cherche un Case.coup possible sur l'une des diagonales
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
							if(p.getCase(px + i, py + i).getEtat(1) && p.getCase(px + i, py + i).getEtat(0) != Case.test.getEtat(0))
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
							if(p.getCase(px + i, py - i).getEtat(1) && p.getCase(px + i, py - i).getEtat(0) != Case.test.getEtat(0))
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
							if(p.getCase(px - i, py + i).getEtat(1) && p.getCase(px - i, py + i).getEtat(0) != Case.test.getEtat(0))
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
							if(p.getCase(px - i, py - i).getEtat(1) && p.getCase(px - i, py - i).getEtat(0) != Case.test.getEtat(0))
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
		public void prise(Case c, int x, int y, int px, int py, Plateau p)
		{
			//pièce normale, on détermine les coordonnées de la pièce prise et on met à Case.jour le plateau
			if(!Case.test.getEtat(2))
			{
				int prise_x = 0;
				int prise_y = 0;
				if(coordonneesValides(px + 2, py + 2, 10, 10) && px + 2 == x && py + 2 == y && p.getCase(px + 1, py + 1).getEtat(1) && p.getCase(px + 1, py + 1).getEtat(0) == !Case.test.getEtat(0))
				{
					prise_x = px + 1;
					prise_y = py + 1;
				}
				else if(coordonneesValides(px - 2, py + 2, 10, 10) && px - 2 == x && py + 2 == y && p.getCase(px - 1, py +1).getEtat(1) && p.getCase(px - 1, py + 1).getEtat(0) == !Case.test.getEtat(0))
				{
					prise_x = px - 1;
					prise_y = py + 1;
				}
				else if(coordonneesValides(px + 2 ,py - 2, 10, 10) && px + 2 == x && py - 2 == y && p.getCase(px + 1, py - 1).getEtat(1) && p.getCase(px + 1, py - 1).getEtat(0) == !Case.test.getEtat(0))
				{
					prise_x = px + 1;
					prise_y = py -1 ;
				}
				else if(coordonneesValides(px - 2,py - 2, 10, 10) && px - 2 == x && py - 2 == y && p.getCase(px - 1, py - 1).getEtat(1) && p.getCase(px - 1, py - 1).getEtat(0) == !Case.test.getEtat(0))
				{
					prise_x = px - 1;
					prise_y = py - 1;
				}
				p.getCase(prise_x, prise_y).setEtat(false,0);
				p.getCase(prise_x, prise_y).setEtat(false,1);
				p.getCase(prise_x, prise_y).setEtat(false,2);
				p.getCase(prise_x, prise_y).BackColor = System.Drawing.Color.White;
				deplacementCase(c);
				//à rajouter: maj damier adverse prise
				Case.test = c;
				
				//détermine si on peut faire plusieurs prises à la suite
				if(!c.getEtat(2))
				{
					if(priseJouable(x - 2, y - 2, x, y, p) || priseJouable(x + 2, y - 2, x, y, p) || priseJouable(x - 2, y + 2, x, y, p) || priseJouable(x + 2, y + 2,x ,y ,p))
					{
						Case.coup = true;
						this.BackColor = System.Drawing.Color.Green;
					}
					else
					{
						Case.coup = false;
						Case.test = null;
						Case.j = !Case.j;
					}
				}
				else
				{
					if(priseJouableDame(c,p))
					{
						Case.coup = true;
						this.BackColor = System.Drawing.Color.Green;
					}
					else
					{
						Case.coup = false;
						Case.test = null;
						Case.j = !Case.j; //ligne à enlever pour le multi
					}
				}
				
			}
			//dame, on cherche les coordonnées de la pièce à prendre sur l'une des diagonales et on met à Case.jour le plateau
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
							if(p.getCase(px + i, py + i).getEtat(1) && p.getCase(px + i, py + i).getEtat(0) != Case.test.getEtat(0))
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
							if(p.getCase(px + i, py - i).getEtat(1) && p.getCase(px + i, py - i).getEtat(0) != Case.test.getEtat(0))
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
							if(p.getCase(px - i, py + i).getEtat(1) && p.getCase(px - i, py + i).getEtat(0) != Case.test.getEtat(0))
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
							if(p.getCase(px - i, py - i).getEtat(1) && p.getCase(px - i, py - i).getEtat(0) != Case.test.getEtat(0))
							{
								prise_x = px - i;
								prise_y = py - i;
								prise = true;
							}
							i++;
						}
					}
					p.getCase(prise_x, prise_y).setEtat(false,0);
					p.getCase(prise_x, prise_y).setEtat(false,1);
					p.getCase(prise_x, prise_y).setEtat(false,2);
					p.getCase(prise_x, prise_y).BackColor = System.Drawing.Color.White;
					deplacementCase(c);
					//à rajouter: maj damier adverse prise
					Case.test = c;
					//gestion des prises successives
					if(priseJouableDame(c,p))
					{
						Case.coup = true;
						this.BackColor = System.Drawing.Color.Green;
					}
					else
					{
						Case.test = null;
						Case.j = !Case.j; //ligne à enlever pour le multi
					}
				}		
			}			
		}
		
		//détermine si une dame peut prendre une pièce adverse 
		public bool priseJouableDame(Case c, Plateau p)
		{
			int i = 0;
			bool res = false;
			bool cas1 = false;
			bool cas2 = false;
			bool cas3 = false;
			bool cas4 = false;
			int x = c.getCoordonnees().getX();
			int y = c.getCoordonnees().getY();
			while(!cas1 && !cas2 && !cas3 && !cas4 && i<10)
			{
				if(coordonneesValides(x + i, y + i, 10, 10) && p.getCase(x + i, y + i).getEtat(1) && p.getCase(x + i, y + i).getEtat(0) != c.getEtat(0))
				{
					cas1 = true;
				}
				if(coordonneesValides(x + i, y - i, 10, 10) && p.getCase(x + i, y - i).getEtat(1) && p.getCase(x + i, y - i).getEtat(0) != c.getEtat(0))
				{
					cas2 = true;
				}
				if(coordonneesValides(x - i, y + i, 10, 10) && p.getCase(x - i, y + i).getEtat(1) && p.getCase(x - i, y + i).getEtat(0) != c.getEtat(0))
				{
					cas3 = true;
				}
				if(coordonneesValides(x - i, y - i, 10, 10) && p.getCase(x - i, y - i).getEtat(1) && p.getCase(x - i, y - i).getEtat(0) != c.getEtat(0))
				{
					cas4 = true;
				}
				i++;
			}
			if(cas1)
			{
				if(coordonneesValides(x + i, y + i, 10, 10) && !p.getCase(x + i, y + i).getEtat(1))
				{
					res = true;
				}
			}
			else if(cas2)
			{
				if(coordonneesValides(x + i, y - i, 10, 10) && !p.getCase(x + i, y - i).getEtat(1))
				{
					res = true;
				}
			}
			else if(cas3)
			{
				if(coordonneesValides(x - i,y + i, 10, 10) && !p.getCase(x - i, y + i).getEtat(1))
				{
					res = true;
				}
			}
			else if(cas4)
			{
				if(coordonneesValides(x - i,y - i,10,10) && !p.getCase(x - i, y - i).getEtat(1))
				{
					res = true;
				}
			}
			return res;
		}
		
		//gestion de la pièce selectionnée par le Case.joueur
		public void selectionnerCase(Case c)
		{
			Case.test = c;
			Case.test.BackColor = System.Drawing.Color.Green;
			Case.coup = false;
		}
		
		//déplacement d'une pièce
		public void deplacementCase(Case c)
		{
			if(!Case.test.getEtat(2))
			{
				System.Drawing.Color co;
			    if(Case.j)
				{
			    	if(c.getCoordonnees().getY() == 9)
			    	{
			    		co = System.Drawing.Color.Gray;
			    		c.setEtat(true,2);
			    	}
			    	else
			    	{
			    		co = System.Drawing.Color.Black;
			    		c.setEtat(false,2);
			    	}
					
				}
				else
				{
					if(c.getCoordonnees().getY() == 0)
			    	{
			    		co = System.Drawing.Color.Pink;
			    		c.setEtat(true,2);
			    	}
			    	else
			    	{
			    		co = System.Drawing.Color.Red;
			    		c.setEtat(false,2);
			    	}
					
				}
				c.setCouleur(co);
				c.setEtat(true,1);
				c.setEtat(Case.j,0);
				Case.test.setCouleur(System.Drawing.Color.White);
				Case.test.setEtat(false,1);
				Case.test.setEtat(false,0);
				Case.test = null;
			}
			else
			{
				System.Drawing.Color co;
			    if(Case.j)
				{
					co = System.Drawing.Color.Gray;
				}
				else
				{
					co = System.Drawing.Color.Pink;
				}
				c.setCouleur(co);
				
				c.setEtat(true,2);
				c.setEtat(true,1);
				c.setEtat(Case.j,0);
				Case.test.setCouleur(System.Drawing.Color.White);
				Case.test = null;
			}
			//à rajouter: maj damier adverse
			
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
			if(!Case.test.getEtat(2))
			{
				if(Case.j)
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
							if(p.getCase(px + i, py + i).getEtat(1))
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
							if(p.getCase(px + i, py - i).getEtat(1))
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
							if(p.getCase(px - i, py + i).getEtat(1))
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
							if(p.getCase(px - i, py - i).getEtat(1))
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
