using System;
using System.Collections.Generic;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
namespace Tarea_Cubo
{
	public class zbuffer
	{
		List<Triangulo> buffer = new List<Triangulo>();
		public zbuffer()
		{
		}
		public void Agregar(Triangulo fig)
		{
			buffer.Add(fig);
		}
		public void Ordenamiento()
		{
			buffer.Sort(CompararCentros);
		}
		public void Draw(PrimitiveType type)
		{
			if (buffer.Count != 0) {
				buffer.ForEach(delegate(Triangulo element) {
					element.draw(type);
				});		
			}
		}
		public int CompararCentros(Triangulo element1, Triangulo element2)
		{
			if (element1.D > element2.D) {
				return -1;
			} else if (element2.D > element1.D) {
				return 1;
			} else {
				return 0;
			}
		}
		public void Bateria(float escalar, int reflexion, Vector3 translacion, float angulo, int eje, Vector3 camara)
		{
			Transformacion conversion = new Transformacion();
			foreach (Triangulo element in buffer) {
				element.V1 = conversion.Bateria(element.V1, escalar, reflexion, translacion, angulo, eje);
				element.V2 = conversion.Bateria(element.V2, escalar, reflexion, translacion, angulo, eje);
				element.V3 = conversion.Bateria(element.V3, escalar, reflexion, translacion, angulo, eje);
				element.Calcular(camara);
			}
		}
	}
}
