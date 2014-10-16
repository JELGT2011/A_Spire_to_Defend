using UnityEngine;

namespace UINamespace
{
	public class UIStringLabel : UIRenderable
	{
		private string m_text;
				
		public UIStringLabel(float xStart,
		                     float yStart,
		                     float xWidth,
		                     float yHeight,
		                     UIComponentGroup parentComponentGroup,
		                     UILayoutType layoutType,
		                     UIAnchorLocation anchorLocation,
		                     string text)
			: base(xStart, yStart, xWidth, yHeight, parentComponentGroup, layoutType, anchorLocation)
		{
			m_text = text;
		}
		
		public override void DrawGUI()
		{
			GUI.Label(m_pixelRenderingInfo.rect, m_text);
//			GUI.Label(m_pixelRenderingInfo.rect, m_pixelRenderingInfo.extraData[0] as Texture2D);
//			GUI.Label(m_pixelRenderingInfo.rect, m_text);
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
		
		public override void CalculatePixelRenderingInfo()
		{
			m_pixelRenderingInfo = new UIPixelRenderingInfo();
			
			m_pixelRenderingInfo.rect = new Rect(m_childRenderingInput.xBottomLeft * Screen.width,
			                                     (1f - m_childRenderingInput.yTopRight) * Screen.height,
			                                     m_childRenderingInput.GetWidth() * Screen.width,
			                                     m_childRenderingInput.GetHeight() * Screen.height);
			Texture2D backgroundColor = new Texture2D(1, 1);
			backgroundColor.SetPixel(0, 0, new Color(1, 0, 0));
//			backgroundColor.wrapMode = TextureWrapMode.Repeat;
			backgroundColor.Apply();
//			GUIStyle style = new GUIStyle();
//			style.normal.background = backgroundColor;
			m_pixelRenderingInfo.extraData.Add(backgroundColor);
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

