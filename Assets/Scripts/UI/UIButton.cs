using System;

namespace UINamespace
{
	public class UIButton : UIComponent
	{
		private string m_text;

		public UIButton(float xStart,
		                float yStart,
		                float xWidth,
		                float yHeight,
		                UIComponentGroup parentComponentGroup,
		                UIAnchorLocation anchorLocation,
		                string text)
			: base(xStart, yStart, xWidth, yHeight, parentComponentGroup, anchorLocation)
		{
			m_text = text;
		}

		public override void DrawGUI()
		{

		}

		public override void CalculateRenderingOutput()
		{
			throw new NotImplementedException();
		}

			// There are no child UIComponents
		public override System.Collections.Generic.LinkedList<UIComponent> GetChildComponentsList()
		{
			return null;
		}

	}
}

