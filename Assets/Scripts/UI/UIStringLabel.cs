using UnityEngine;

namespace UINamespace
{
	public class UIStringLabel : UIRenderable
	{
		protected string m_text;
		protected UITextInfo m_textInfo = null;
				
		public UIStringLabel(float xStart,
		                     float yStart,
		                     float xWidth,
		                     float yHeight,
		                     UIComponentGroup parentComponentGroup,
		                     UILayoutType layoutType,
		                     UIAnchorLocation anchorLocation,
		                     UITextInfo textInfo,
		                     string text)
			: base(xStart, yStart, xWidth, yHeight, parentComponentGroup, layoutType, anchorLocation)
		{
			m_guiStyle = textInfo.GetGUIStyle();
			m_textInfo = textInfo;
			m_text = text;
		}
		
		public override void DrawGUI()
		{
			GUI.Label(m_pixelRenderingInfo.rect, m_text, m_guiStyle);
//			GUI.Label(m_pixelRenderingInfo.rect, m_text);
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

