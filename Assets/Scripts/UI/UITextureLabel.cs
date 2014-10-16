using UnityEngine;

namespace UINamespace
{
	public class UITextureLabel : UIRenderable
	{
		private Texture2D m_texture2D;
		
		public UITextureLabel(float xStart,
		                     float yStart,
		                     float xWidth,
		                     float yHeight,
		                     UIComponentGroup parentComponentGroup,
		                     UILayoutType layoutType,
		                     UIAnchorLocation anchorLocation,
		                     UIGUIStyle uiGUIStyle,
		                     Texture2D texture2D)
			: base(xStart, yStart, xWidth, yHeight, parentComponentGroup, layoutType, anchorLocation, uiGUIStyle)
		{
			m_texture2D = texture2D;
		}
		
		public override void DrawGUI()
		{
			GUI.Label(m_pixelRenderingInfo.rect, m_texture2D, m_guiStyle);
		}
		
		public override void CalculatePixelRenderingInfo()
		{
			m_pixelRenderingInfo = new UIPixelRenderingInfo();
			
			m_pixelRenderingInfo.rect = new Rect(m_childRenderingInput.xBottomLeft * Screen.width,
			                                     (1f - m_childRenderingInput.yTopRight) * Screen.height,
			                                     m_childRenderingInput.GetWidth() * Screen.width,
			                                     m_childRenderingInput.GetHeight() * Screen.height);

//			m_pixelRenderingInfo.extraData.Add(backgroundColor);
		}		
	}
}

