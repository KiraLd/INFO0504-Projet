/*
 * Created by SharpDevelop.
 * User: Lucas
 * Date: 21/12/2014
 * Time: 14:16
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ProjetINFO0504
{
	/// <summary>
	/// Représente les coordonnées entières d'un point.
	/// 
	/// </summary>
	
	
	public class Coordonnees
	{
		private int x;
		private int y;
		
		//Constructeurs
		public Coordonnees()
		{
			x = 0;
			y = 0;
		}
		
		public Coordonnees(int x, int y)
		{
			this.x = x;
			this.y = y;
		}
		
		public Coordonnees(ref Coordonnees c)
		{
			x = c.x;
			y = c.y;
		}
		
		
		//Getters
		public int getX()
		{
			return x;
		}
		
		public int getY()
		{
			return y;
		}
		
		
		//Setters
		public void setX(int x)
		{
			this.x = x;
		}
		
		public void setY(int y)
		{
			this.y = y;
		}
	}
}
