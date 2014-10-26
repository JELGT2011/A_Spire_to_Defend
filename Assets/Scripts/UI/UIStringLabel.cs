using UnityEngine;

namespace UINamespace
{
	public class UIStringLabel : UIRenderable
	{
		protected string m_text;
		protected UITextInfo m_textInfo = null;
				
		public UIStringLabel(string componentName,
		                     float xStart,
		                     float yStart,
		                     float xWidth,
		                     float yHeight,
		                     UIComponentGroup parentComponentGroup,
		                     UILayoutType layoutType,
		                     UIAnchorLocation anchorLocation,
		                     UITextInfo textInfo,
		                     string text)
			: base(componentName, xStart, yStart, xWidth, yHeight, parentComponentGroup, layoutType, anchorLocation)
		{
			m_guiStyle = textInfo.GetGUIStyle();
			m_textInfo = textInfo;
			m_text = text;
		}

		public UIStringLabel(float xStart,
		                     float yStart,
		                     float xWidth,
		                     float yHeight,
		                     UIComponentGroup parentComponentGroup,
		                     UILayoutType layoutType,
		                     UIAnchorLocation anchorLocation,
		                     UITextInfo textInfo,
		                     string text)
			: this("", xStart, yStart, xWidth, yHeight, parentComponentGroup, layoutType, anchorLocation, textInfo, text)
		{
			SetName(Id.ToString());
		}
		
		public override void DrawGUI()
		{
			if (m_enabled)
				GUI.Label(m_pixelRenderingInfo.rect, m_text, m_guiStyle);
		}

		public override void CalculateRenderingOutput()
		{
			base.CalculateRenderingOutput();

			m_textInfo.SetFontSize(m_textInfo.GetFontSizeInput());
		}
		
		public override void CalculatePixelRenderingInfo()
		{
			m_pixelRenderingInfo = new UIPixelRenderingInfo();
			
			m_pixelRenderingInfo.rect = new Rect(m_childRenderingInput.xBottomLeft * Screen.width,
			                                     (1f - m_childRenderingInput.yTopRight) * Screen.height,
			                                     m_childRenderingInput.GetWidth() * Screen.width,
			                                     m_childRenderingInput.GetHeight() * Screen.height);
		}

		public string Text
		{
			get { return m_text; }
			set { m_text = value; }
		}
	}
}

