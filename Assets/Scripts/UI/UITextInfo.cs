using UnityEngine;

namespace UINamespace
{
	public enum UIFontStyle
	{
		NORMAL,
		BOLD,
		ITALIC,
		BOLD_ITALIC
	};

	public class UITextInfo
	{
		private int m_fontSizeInput;
		private int m_fontSizeRelative; //Calculated on a 1280x720 resolution against 48 size Verdana font.
		private UIFontStyle m_uiFontStyle = UIFontStyle.NORMAL;
		private UIAnchorLocation m_uiTextAnchor;
		private bool m_stretchWidth;
		private bool m_stretchHeight;
		private Color m_textColor;

		private FontStyle m_fontStyle;
		private Font m_font;
		private TextAnchor m_textAnchor;

		private GUIStyle m_guiStyle;

		public UITextInfo()
		{
			m_guiStyle = new GUIStyle();
		}

		private const float alpha = 1.25f;
		public UITextInfo SetFontSize(int fontSize)
		{
			m_fontSizeInput = fontSize;
			m_fontSizeRelative = Mathf.RoundToInt(alpha * (m_fontSizeInput * Screen.width / 1280));
			m_guiStyle.fontSize = m_fontSizeRelative;
			return this;
		}

		public UITextInfo SetFont(Font font)
		{
			m_font = font;
			m_guiStyle.font = font;
			return this;
		}

		public UITextInfo SetFontStyle(UIFontStyle fontStyle)
		{
			m_uiFontStyle = fontStyle;
			switch (fontStyle)
			{
			case UIFontStyle.NORMAL:
				m_fontStyle = FontStyle.Normal;
				break;
			case UIFontStyle.BOLD:
				m_fontStyle = FontStyle.Bold;
				break;
			case UIFontStyle.ITALIC:
				m_fontStyle = FontStyle.Italic;
				break;
			case UIFontStyle.BOLD_ITALIC:
				m_fontStyle = FontStyle.BoldAndItalic;
				break;
			}
			m_guiStyle.fontStyle = m_fontStyle;
			return this;
		}

		public UITextInfo SetTextAlignment(UIAnchorLocation textAnchor)
		{
			m_uiTextAnchor = textAnchor;
			switch (textAnchor)
			{
			case UIAnchorLocation.LEFT_TOP:
				m_textAnchor = TextAnchor.UpperLeft;
				break;
			case UIAnchorLocation.LEFT_MID:
				m_textAnchor = TextAnchor.MiddleLeft;
				break;
			case UIAnchorLocation.LEFT_BOT:
				m_textAnchor = TextAnchor.LowerLeft;
				break;
			case UIAnchorLocation.MID_TOP:
				m_textAnchor = TextAnchor.UpperCenter;
				break;
			case UIAnchorLocation.CENTER:
				m_textAnchor = TextAnchor.MiddleCenter;
				break;
			case UIAnchorLocation.MID_BOT:
				m_textAnchor = TextAnchor.LowerCenter;
				break;
			case UIAnchorLocation.RIGHT_TOP:
				m_textAnchor = TextAnchor.UpperRight;
				break;
			case UIAnchorLocation.RIGHT_MID:
				m_textAnchor = TextAnchor.MiddleRight;
				break;
			case UIAnchorLocation.RIGHT_BOT:
				m_textAnchor = TextAnchor.LowerRight;
				break;
			}
			m_guiStyle.alignment = m_textAnchor;
			return this;
		}

		public UITextInfo SetStretchWidth(bool stretchWidth)
		{
			m_stretchWidth = stretchWidth;
			m_guiStyle.stretchWidth = stretchWidth;
			return this;
		}

		public UITextInfo SetStretchHeight(bool stretchHeight)
		{
			m_stretchHeight = stretchHeight;
			m_guiStyle.stretchHeight = stretchHeight;
			return this;
		}

		public UITextInfo SetColor(Color color)
		{
			m_textColor = color;
			m_guiStyle.normal.textColor = color;
			return this;
		}

		public GUIStyle GetGUIStyle()
		{
			return m_guiStyle;
		}

		public int GetFontSizeInput()
		{
			return m_fontSizeInput;
		}
	}
}

