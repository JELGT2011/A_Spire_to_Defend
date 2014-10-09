using UnityEngine;
using System.Collections;

namespace UINamespace
{
	/// <summary>
	/// Abstract Relative Layout. Calculations are a percentage of the parent layout,
	/// or whole screen if no parent. Uses float for screen location, so bottom left
	/// of the screen is (0f,0f) and top right of the screen is (1f,1f).
	/// </summary>
	public class UIRelativeLayout : UIComponentGroup
	{
		public UIRelativeLayout(float xStart,
		                        float yStart,
		                        float xWidth,
		                        float yHeight,
		                        UIComponentGroup parentComponentGroup)
			: base(xStart, yStart, xWidth, yHeight, parentComponentGroup, UIAnchorLocation.LEFT_BOT)
		{
			// do nothing
		}

		public new UIRelativeLayout AddUIComponent(UIComponent component)
		{
			base.AddUIComponent(component);

			return this;
		}

		public override void DrawGUI()
		{
			// do nothing;
		}

		public override void CalculateRenderingOutput()
		{
			if (null == m_parentComponentGroup)
				m_parentRenderingInput = new UIComponentRenderingInput(0f, 0f, 1f, 1f, UIAnchorLocation.LEFT_BOT, UILayoutType.RELATIVE_LAYOUT);

			throw new System.NotImplementedException();
		}
	}
}
