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
		                        UIComponentGroup parentComponentGroup,
		                        UIAnchorLocation anchorLocation)
			: base(xStart, yStart, xWidth, yHeight, parentComponentGroup, UILayoutType.RELATIVE_LAYOUT, anchorLocation)
		{
			m_componentType = UIComponentType.LAYOUT;
		}

		public new UIRelativeLayout AddUIComponent(UIComponent component)
		{
			base.AddUIComponent(component);

			return this;
		}

		public override void CalculateRenderingOutput()
		{
			if (null == m_parentComponentGroup)
				m_parentRenderingInput = new UIComponentRenderingInput(0f, 0f, 1f, 1f, UILayoutType.RELATIVE_LAYOUT);

			if (null == m_parentRenderingInput)
				m_parentRenderingInput = m_parentComponentGroup.GetChildComponentRenderingInput();

			float xBottomLeft = m_parentRenderingInput.xBottomLeft + m_anchor.GetRelativeXLeft() * m_parentRenderingInput.GetWidth();
			float yBottomLeft = m_parentRenderingInput.yBottomLeft + m_anchor.GetRelativeYBottom() * m_parentRenderingInput.GetHeight();
			float xTopRight = m_parentRenderingInput.xBottomLeft + m_anchor.GetRelativeXRight() * m_parentRenderingInput.GetWidth();
			float yTopRight = m_parentRenderingInput.yBottomLeft + m_anchor.GetRelativeYTop() * m_parentRenderingInput.GetHeight();

			m_childRenderingInput = new UIComponentRenderingInput(xBottomLeft, yBottomLeft, xTopRight, yTopRight, UILayoutType.RELATIVE_LAYOUT);
		}
	}
}
