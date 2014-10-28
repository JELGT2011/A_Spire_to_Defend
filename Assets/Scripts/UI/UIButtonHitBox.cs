using UnityEngine;
using System.Collections;

namespace UINamespace
{
	public class UIButtonHitBox
	{
		private UIAnchor m_anchor;

		private UIButton m_parentComponentGroup;
		private UIComponentRenderingInput m_parentRenderingInput = null;
		private UIComponentRenderingInput m_hitBoxRelative;
		private UIComponentRenderingInput m_hitBoxPixels;

		public UIButtonHitBox(float xStart,
		                      float yStart,
		                      float xWidth,
		                      float yHeight,
		                      UIButton parentComponentGroup,
		                      UILayoutType layoutType,
		                      UIAnchorLocation anchorLocation)
		{
			m_anchor = new UIAnchor(anchorLocation, xStart, yStart, xWidth, yHeight);

			m_parentComponentGroup = parentComponentGroup;
		}

		public void CalculateRenderingOutput()
		{
			if (null == m_parentComponentGroup)
				m_parentRenderingInput = new UIComponentRenderingInput(0f, 0f, 1f, 1f, UILayoutType.RELATIVE_LAYOUT);
			
			if (null == m_parentRenderingInput)
				m_parentRenderingInput = m_parentComponentGroup.GetChildComponentRenderingInput();

			float xBottomLeft = m_parentRenderingInput.xBottomLeft + m_anchor.GetRelativeXLeft() * m_parentRenderingInput.GetWidth();
			float yBottomLeft = m_parentRenderingInput.yBottomLeft + m_anchor.GetRelativeYBottom() * m_parentRenderingInput.GetHeight();
			float xTopRight = m_parentRenderingInput.xBottomLeft + m_anchor.GetRelativeXRight() * m_parentRenderingInput.GetWidth();
			float yTopRight = m_parentRenderingInput.yBottomLeft + m_anchor.GetRelativeYTop() * m_parentRenderingInput.GetHeight();
			
			m_hitBoxRelative = new UIComponentRenderingInput(xBottomLeft, yBottomLeft, xTopRight, yTopRight, UILayoutType.RELATIVE_LAYOUT);

			CalculatePixelOutput();
		}

		public void CalculatePixelOutput()
		{
			m_hitBoxPixels = new UIComponentRenderingInput(m_hitBoxRelative.xBottomLeft * Screen.width,
			                                               m_hitBoxRelative.yBottomLeft * Screen.height,
			                                               m_hitBoxRelative.xTopRight * Screen.width,
			                                               m_hitBoxRelative.yTopRight * Screen.height,
			                                               UILayoutType.RELATIVE_LAYOUT);
		}

		public bool CheckIfInputInButton(float x, float y)
		{
			if (x > m_hitBoxRelative.xBottomLeft && x < m_hitBoxRelative.xTopRight &&
				y > m_hitBoxRelative.yBottomLeft && y < m_hitBoxRelative.yTopRight)
				return true;
			else
				return false;
		}
		public bool CheckIfInputInButton(int x, int y)
		{
			if (x > m_hitBoxPixels.xBottomLeft && x < m_hitBoxPixels.xTopRight &&
				y > m_hitBoxPixels.yBottomLeft && y < m_hitBoxPixels.yTopRight)
				return true;
			else
				return false;
		}
	}
}
