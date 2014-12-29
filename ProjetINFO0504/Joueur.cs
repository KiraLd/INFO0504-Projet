/*
 * Created by SharpDevelop.
 * User: Lucas
 * Date: 27/12/2014
 * Time: 16:33
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ProjetINFO0504
{
	/// <summary>
	/// Description of Joueur.
	/// </summary>
	public class Joueur
	{
		
		private String nom;
		private int score;
		
		public Joueur()
		{
			nom = "Toto";
			score = 0;
		}
		
		public Joueur(String n)
		{
			score = 0;
			nom = n;
		}
		
		public String getNom()
		{
			return nom;
		}
		
		public int getScore()
		{
			return score;
		}
		
		public void setScore(int s)
		{
			score = s;
		}
		
		public void ajouterScore(int s)
		{
			score +=s;
		}
		
	}
}
