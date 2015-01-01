/*
 * Created by SharpDevelop.
 * User: Lucas
 * Date: 21/12/2014
 * Time: 14:39
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ProjetINFO0504
{
	/// <summary>
	/// Description of Jeu.
	/// </summary>
	public class Jeu
	{
		private Joueur j1;
		private Joueur j2;
		private Plateau p;
		
		public Jeu(String a, String b, int x, int y, int nbe,String d, bool je)
		{
			j1 = new Joueur(a);
			j2 = new Joueur(b);
			p = new Plateau(0,0,x,y,nbe,50,50,System.Drawing.Color.White,d, je);
		}
		
		public Plateau getPlateau()
		{
			return p;
		}
		
		public void ajouterScore(bool b, int s)
		{
			if(b)
			{
				j1.ajouterScore(s);
			}
			else
			{
				j2.ajouterScore(s);
			}
		}
		
		public int getScore(bool b)
		{
			if(b)
			{
				return j1.getScore();
			}
			else
			{
				return j2.getScore();
			}
		}
		
		public String getNom(bool b)
		{
			if(b)
			{
				return j1.getNom();
			}
			else
			{
				return j2.getNom();
			}
		}
		
		
	}
}
