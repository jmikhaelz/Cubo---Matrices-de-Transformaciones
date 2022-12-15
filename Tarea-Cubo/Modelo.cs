using System;
using System.Drawing;
using OpenTK;
using OpenTK.Input;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.Collections.Generic;

namespace Tarea_Cubo
{
	public class Modelo
	{
		DatosTextura Imagen;
		float angulo;
		int eje;
		float escalar;
		int reflexion;
		Vector3 posxy;
		Vector3 camara;
		public Modelo()
		{
			angulo = 0;
			eje = -1;
			escalar = 1;
			posxy = new Vector3(0, 0, 0);
			reflexion = 0;
			
		}
		public void Pos(Vector3 posxy, float escalar, float angulo, int eje, int reflexion, Vector3 camara)
		{
			this.angulo = angulo;
			this.eje = eje;
			this.escalar = escalar;
			this.posxy = posxy;
			this.reflexion = reflexion;
			this.camara = camara;
		}
		public void CargarArch(string modelo, string textura)
		{
			Imagen = LoadTexture.LoadTestureFile(textura);
		}
		public void Draw()
		{	
			
			Vector3 p1 = new Vector3(-1, -1, +1);
			Vector3 p2 = new Vector3(-1, +1, +1);
			Vector3 p3 = new Vector3(-1, -1, -1);
			Vector3 p4 = new Vector3(-1, +1, -1);
			Vector3 p5 = new Vector3(+1, -1, +1);
			Vector3 p6 = new Vector3(+1, +1, +1);
			Vector3 p7 = new Vector3(+1, -1, -1);
			Vector3 p8 = new Vector3(+1, +1, -1);
			
			zbuffer listado = new zbuffer();

			listado.Agregar(new Triangulo(p1, p2, p4));
			listado.Agregar(new Triangulo(p1, p3, p4));
			
			listado.Agregar(new Triangulo(p1, p5, p7));
			listado.Agregar(new Triangulo(p1, p3, p7));
			
			listado.Agregar(new Triangulo(p7, p8, p4));
			listado.Agregar(new Triangulo(p7, p3, p4));
			
			listado.Agregar(new Triangulo(p5, p6, p7));
			listado.Agregar(new Triangulo(p6, p7, p8));
			
			listado.Agregar(new Triangulo(p2, p6, p8));
			listado.Agregar(new Triangulo(p2, p4, p8));
			
			listado.Agregar(new Triangulo(p1, p5, p6));
			listado.Agregar(new Triangulo(p1, p2, p6));
			
			listado.Bateria(escalar, reflexion, posxy, angulo, eje, camara);
			listado.Ordenamiento();
			
			listado.Draw(PrimitiveType.Polygon);
		}
	}
}
