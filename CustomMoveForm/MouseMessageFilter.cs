using System;
using System.Windows.Forms;

namespace CustomMoveForm;

public class MouseMessageFilter : IMessageFilter
{
	public event EventHandler MouseMoved;
	public event EventHandler<MouseButtons> MouseDown;
	public event EventHandler<MouseButtons> MouseUp;

	public bool PreFilterMessage(ref Message m)
	{
		switch (m.Msg)
		{
			case (int)WindowMessage.WM_MOUSEMOVE:
				MouseMoved?.Invoke(this, EventArgs.Empty);
				break;
			case (int)WindowMessage.WM_LBUTTONDOWN:
				MouseDown?.Invoke(this, MouseButtons.Left);
				break;
			case (int)WindowMessage.WM_RBUTTONDOWN:
				MouseDown?.Invoke(this, MouseButtons.Right);
				break;
			case (int)WindowMessage.WM_MBUTTONDOWN:
				MouseDown?.Invoke(this, MouseButtons.Middle);
				break;
			case (int)WindowMessage.WM_LBUTTONUP:
				MouseUp?.Invoke(this, MouseButtons.Left);
				break;
			case (int)WindowMessage.WM_RBUTTONUP:
				MouseUp?.Invoke(this, MouseButtons.Right);
				break;
			case (int)WindowMessage.WM_MBUTTONUP:
				MouseUp?.Invoke(this, MouseButtons.Middle);
				break;
		}

		return false;
	}
}
