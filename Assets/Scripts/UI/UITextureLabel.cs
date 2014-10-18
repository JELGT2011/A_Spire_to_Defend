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
		                     Texture2D texture2D)
			: base(xStart, yStart, xWidth, yHeight, parentComponentGroup, layoutType, anchorLocation)
		{
			m_texture2D = texture2D;
			m_guiStyle = new GUIStyle();

//			m_texture2D = new Texture2D(1, 1);
//			m_texture2D.SetPixel(0, 0, new Color(0, 1, 0));
//			m_texture2D.Apply();
		}
		
		public override void DrawGUI()
		{
			GUI.DrawTexture(m_pixelRenderingInfo.rect, m_texture2D, ScaleMode.StretchToFill);
//			GUI.Label(m_pixelRenderingInfo.rect, m_texture2D, m_guiStyle);
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

