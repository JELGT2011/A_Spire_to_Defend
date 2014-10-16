using UnityEngine;

namespace UINamespace
{
	public abstract class UIRenderable : UIComponent
	{
		protected UIPixelRenderingInfo m_pixelRenderingInfo = null;
		protected GUIStyle m_guiStyle = null;
		protected UIGUIStyle m_uiGUIStyle = null;
		
		public UIRenderable(float xStart,
		                    float yStart,
		                    float xWidth,
		                    float yHeight,
		                    UIComponentGroup parentComponentGroup,
		                    UILayoutType layoutType,
		                    UIAnchorLocation anchorLocation,
		                    UIGUIStyle uiGUIStyle)
			: base(xStart, yStart, xWidth, yHeight, parentComponentGroup, layoutType, anchorLocation)
		{
			m_componentType = UIComponentType.RENDERABLE;
		}

		public abstract void DrawGUI();
		public abstract void CalculatePixelRenderingInfo();

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
		
		// There are no child UIComponents
		public override bool HasChildComponents()
		{
			return false;
		}
		public override System.Collections.Generic.LinkedList<UIComponent> GetChildComponentsList()
		{
			return null;
		}
		
	}
}

