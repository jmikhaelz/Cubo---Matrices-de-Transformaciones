using OpenTK;
using OpenTK.Input;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.Collections;
using System.Drawing;
using System;

namespace Tarea_Cubo
{
	public class Screen : GameWindow
	{
		//Visualizacion
		Vector3 camara = new Vector3(5, 5, 5);
		Vector3 objetivo = new Vector3(0, 0, 0);
		Vector3 orientacion = new Vector3(0, 0, 1);
		//Modelo
		Modelo objeto = new Modelo();
		//Control del movimiento de la figura
		Vector3 posicion = new Vector3(0, 0, 0);
		float escala = 1;
		float angulo = 0;
		int eje = -1;
		int reflexion = 0;
		bool mov = true;
		//Entorno
		Entorno plano = new Entorno();
		
		public Screen(int ancho, int alto)
			: base(ancho, alto)
		{
			Title = "//***CUBO***//";
		}
		protected override void OnLoad(System.EventArgs e)
		{
			GL.ClearColor(Color.DimGray);
			GL.Enable(EnableCap.Texture2D);
			GL.DepthFunc(DepthFunction.Less);
			objeto.CargarArch("", "textura.png");
			
			//Menu de controles
			Console.WriteLine("\tM\tE\tN\tU");
			Console.WriteLine("\tOpcion a Realizar \tTecla");
			Console.WriteLine("\tSalir del Programa \t[|]");
			Console.WriteLine("\tAumentar Objeto \t[Y]+");
			Console.WriteLine("\tDecrementar Objeto \t[U]-");
			Console.WriteLine("\tEje de Rotacion \t[C]+ [V]-");
			Console.WriteLine("\tReflexion del Objeto \t[O]+ [P]-");
			Console.WriteLine("\tCambio de Movimiento \t[M]\t De Objeto a Camara");
			Console.WriteLine("\tEje X \t[Q]+ [W]-");
			Console.WriteLine("\tEje Y \t[A]+ [S]-");
			Console.WriteLine("\tEje Z \t[Z]+ [X]-");
		}
		protected override void OnUpdateFrame(FrameEventArgs e)
		{
			GL.Clear(ClearBufferMask.ColorBufferBit);
			Matrix4 PuntoDeVision = Matrix4.LookAt(camara, objetivo, orientacion);
			GL.MatrixMode(MatrixMode.Modelview);
			GL.LoadMatrix(ref PuntoDeVision);
			
			//Manejo de la figura
			angulo = (angulo > 360) ? 0 : angulo += 0.1f;
			objeto.Pos(posicion, escala, angulo, eje, reflexion, camara);
		}
		protected override void OnResize(EventArgs e)
		{
			GL.Viewport(0, 0, Width, Height);
			float RelacionAspecto = (float)Width / (float)Height;
			Matrix4 campoVision = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver6, RelacionAspecto, 1, 60);
			GL.MatrixMode(MatrixMode.Projection);
			GL.LoadMatrix(ref campoVision);
		}
		protected override void OnRenderFrame(FrameEventArgs e)
		{
			plano.Grilla();
			objeto.Draw();
			SwapBuffers();
		}
		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			if (e.KeyChar == '|') {
				Exit();
			}
			//Cambio de vista
			if (e.KeyChar == 'm' || e.KeyChar == 'M') {
				mov = (mov) ? false : true;
			}
			//Eje X
			if (e.KeyChar == 'q' || e.KeyChar == 'Q') {
				if (!mov) {
					camara.X += 0.1f;
				} else {
					posicion.X += 0.1f;
				}
			}
			if (e.KeyChar == 'w' || e.KeyChar == 'W') {
				if (!mov) {
					camara.X -= 0.1f;
				} else {
					posicion.X -= 0.1f;
				}
			}
			//Eje Y
			if (e.KeyChar == 'a' || e.KeyChar == 'A') {
				if (!mov) {
					camara.Y += 0.1f;
				} else {
					posicion.Y += 0.1f;
				}
			}
			if (e.KeyChar == 's' || e.KeyChar == 'S') {
				if (!mov) {
					camara.Y -= 0.1f;
				} else {
					posicion.Y -= 0.1f;
				}
			}
			//Eje Z
			if (e.KeyChar == 'z' || e.KeyChar == 'Z') {
				if (!mov) {
					camara.Z += 0.1f;
				} else {
					posicion.Z += 0.1f;
				}
			}
			if (e.KeyChar == 'x' || e.KeyChar == 'X') {
				if (!mov) {
					camara.Z -= 0.1f;
				} else {
					posicion.Z -= 0.1f;
				}
			}
			//Rotacion
			if (e.KeyChar == 'v' || e.KeyChar == 'V') {
				if (eje >= 1) {
					eje--;
				}
			}
			if (e.KeyChar == 'c' || e.KeyChar == 'C') {
				if (eje <= 2) {
					eje++;
				}
			}
			//Escalar
			if (e.KeyChar == 'y' || e.KeyChar == 'Y') {
				if (escala <= 2) {
					escala += 0.1f;
				}
			}
			if (e.KeyChar == 'u' || e.KeyChar == 'U') {
				if (escala >= 0.1f) {
					escala -= 0.1f;
				}
			}
			//Reflexion
			if (e.KeyChar == 'o' || e.KeyChar == 'O') {
				if (reflexion <= 3) {
					reflexion++;
				}
			}
			if (e.KeyChar == 'p' || e.KeyChar == 'P') {
				if (reflexion >= 1) {
					reflexion--;
				}				
				
			}
		}
	}
}
