using OpenTK.Graphics.OpenGL;
using System;

namespace Tarea_Cubo
{
	public class Entorno
	{
		public Entorno()
		{
		}
				public void Ejes()
		{
			GL.Begin(PrimitiveType.Lines);
			GL.Color3(1.0f, 0.0f, 0.0f);
			GL.Vertex3(0, 0, 0);
			GL.Vertex3(1, 0, 0);
			GL.Color4(0.0f, 1.0f, 0.0f, 0.0f);
			GL.Vertex3(0, 0, 0);
			GL.Vertex3(0, 1, 0);
			GL.Color4(1.0f, 1.0f, 0.0f, 0.0f);
			GL.Vertex3(0, 0, 0);
			GL.Vertex3(0, 0, 1);
			GL.End();
		}
		public void Grilla()
		{
			GL.Begin(PrimitiveType.Lines);
			GL.Color3(0.5f, 0.5f, 0.5f);
			for (int i = -10; i < 10; i++) {
				for (int j = -10; j < 10; j++) {
					GL.Vertex3(-10, j, 0);
					GL.Vertex3(10, j, 0);
					GL.Vertex3(j, -10, 0);
					GL.Vertex3(j, 10, 0);
				}
			}
			GL.End();
		}
	}
}
