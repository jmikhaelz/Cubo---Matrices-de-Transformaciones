using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System;

namespace Tarea_Cubo
{
	public class Triangulo
	{
		private Vector3 v1, v2, v3;
		float distancia;
		public Triangulo()
		{
			v1 = new Vector3();
			v2 = new Vector3();
			v3 = new Vector3();
			distancia = 0;
		}
		public Triangulo(Vector3 p1, Vector3 p2, Vector3 p3)
		{
			v1 = p1;
			v2 = p2;
			v3 = p3;
		}
		public Triangulo(Vector3 p1, Vector3 p2, Vector3 p3, Vector3 camara)
		{
			v1 = p1;
			v2 = p2;
			v3 = p3;
			distancia = Distancia(camara, Centro());
		}
		public Vector3 V1 {
			set{ v1 = value; }
			get{ return v1; }
		}
		public Vector3 V2 {
			set{ v2 = value; }
			get{ return v2; }
		}
		public Vector3 V3 {
			set{ v3 = value; }
			get{ return v3; }
		}
		public float D {
			set{ distancia = value; }
			get{ return distancia; }
		}
		
		public void Calcular(Vector3 camara){
			distancia = Distancia(camara, Centro());
		}
		
		public Vector3 Centro()
		{
			float x = (v1.X + v2.X + v3.X) / 3;
			float y = (v1.Y + v2.Y + v3.Y) / 3;
			float z = (v1.Z + v2.Z + v3.Z) / 3;
			return new Vector3(x, y, z);
		}
		public void draw(PrimitiveType type)
		{
			GL.Begin(type);
			GL.Color3(1.0f, 1.0f, 1.0f);
			GL.TexCoord2(0, 1);
			GL.Vertex3(v1.X, v1.Y, v1.Z);
			GL.TexCoord2(1, 1);
			GL.Vertex3(v2.X, v2.Y, v2.Z);
			GL.TexCoord2(1, 0);
			GL.Vertex3(v3.X, v3.Y, v3.Z);
			GL.End();
		}
		public static float Distancia(Vector3 v1, Vector3 v2)
		{
			float x = (float)Math.Pow((v2.X - v1.X), 2);
			float y = (float)Math.Pow((v2.Y - v1.Y), 2);
			float z = (float)Math.Pow((v2.Z - v1.Z), 2);
			float d = (float)Math.Sqrt(x + y + z);
			return d;
		}
	}
}
