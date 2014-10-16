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
		                     UIGUIStyle uiGUIStyle,
		                     string text)
			: base(xStart, yStart, xWidth, yHeight, parentComponentGroup, layoutType, anchorLocation, uiGUIStyle)
		{
			m_text = text;
		}
		
		public override void DrawGUI()
		{
			GUI.Label(m_pixelRenderingInfo.rect, m_text, m_guiStyle);
		}
		
		public override void CalculatePixelRenderingInfo()
		{
			m_pixelRenderingInfo = new UIPixelRenderingInfo();
			
			m_pixelRenderingInfo.rect = new Rect(m_childRenderingInput.xBottomLeft * Screen.width,
			                                     (1f - m_childRenderingInput.yTopRight) * Screen.height,
			                                     m_childRenderingInput.GetWidth() * Screen.width,
			                                     m_childRenderingInput.GetHeight() * Screen.height);
		}
	}
}

