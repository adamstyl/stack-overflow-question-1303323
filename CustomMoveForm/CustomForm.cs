using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomMoveForm;

public partial class CustomForm : Form
{
	private MouseMessageFilter windowMoveHandler = new();
	private Point originalLocation;
	private Point offset;

	private static List<Form> canvases = new(SystemInformation.MonitorCount);

	public CustomForm()
	{
		InitializeComponent();
		
		windowMoveHandler.MouseMoved += (_, _) =>
		{
			Point position = Cursor.Position;
			position.Offset(offset);
			Location = position;
		};
		windowMoveHandler.MouseDown += (_, button) =>
		{
			switch (button)
			{
				case MouseButtons.Left:
					EndMove();
					break;
				case MouseButtons.Middle:
					CancelMove();
					break;
			}
		};
		moveButton.MouseClick += (_, _) =>
		{
			BeginMove();
		};
	}

	private void BeginMove()
	{
		Application.AddMessageFilter(windowMoveHandler);
		originalLocation = Location;
		offset = Invert(PointToClient(Cursor.Position));
		ShowCanvases();
	}
	
	//Normally an extension method in another library of mine but I didn't want to
	//add a dependency just for that
	private static Point Invert(Point p) => new Point(-p.X, -p.Y);

	private void ShowCanvases()
	{
		for (int i = 0; i < Screen.AllScreens.Length; i++)
		{
			Screen screen = Screen.AllScreens[i];
			Form form = new TransparentForm
			{
				Bounds = screen.Bounds,
				Owner = Owner
			};
			canvases.Add(form);
			form.Show();
		}
	}

	private void EndMove()
	{
		DisposeCanvases();
	}

	private void DisposeCanvases()
	{
		Application.RemoveMessageFilter(windowMoveHandler);
		for (var i = 0; i < canvases.Count; i++)
		{
			canvases[i].Close();
		}
		canvases.Clear();
	}

	private void CancelMove()
	{
		EndMove();
		Location = originalLocation;
	}

	//The form used as a "message canvas" for moving the form outside the client area.
	//It practically helps extend the client area. Without it we won't be able to get
	//the events from everywhere
	private class TransparentForm : Form
	{
		public TransparentForm()
		{
			StartPosition = FormStartPosition.Manual;
			FormBorderStyle = FormBorderStyle.None;
			ShowInTaskbar = false;
		}

		protected override void OnPaintBackground(PaintEventArgs e)
		{
			//Draws a white border mostly useful for debugging. For example that's
			//how I realised I needed Screen.Bounds instead of WorkingArea.
			ControlPaint.DrawBorder(e.Graphics, new Rectangle(Point.Empty, Size),
				Color.White, 2, ButtonBorderStyle.Solid,
				Color.White, 2, ButtonBorderStyle.Solid,
				Color.White, 2, ButtonBorderStyle.Solid,
				Color.White, 2, ButtonBorderStyle.Solid);
		}
	}
}
