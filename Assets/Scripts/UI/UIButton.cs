using System;

namespace UINamespace
{
	public class UIButton : UIComponent
	{
		private string m_text;

		private float m_xStart;
		private float m_yStart;
		private float m_xWidth;
		private float m_yHeight;

		public UIButton(string text)
			: base()
		{
			m_text = text;
		}

		public override void DrawGUI()
		{

		}


	}
}

