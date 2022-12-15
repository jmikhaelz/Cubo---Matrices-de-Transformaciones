using System;
using System.Drawing;
using OpenTK;
using OpenTK.Input;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.Collections;

namespace Tarea_Cubo
{
	public class DatosTextura
	{
		readonly int Identificador;
		readonly int Ancho;
		readonly int Alto;
		
		public DatosTextura(int id, int ancho, int alto)
		{
			Identificador = id;
			Ancho = ancho;
			Alto = alto;
			
		}
		
		public int ID {
			get {
				return Identificador;
			}
		}
		
		public int WIDTH {
			get {
				return Ancho;
			}
		}
		
		public int HEIGHT {
			get {
				return Alto;
			}
		}
	}
}
