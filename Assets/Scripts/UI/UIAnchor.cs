using UnityEngine;
using System.Collections;

namespace UINamespace
{
	public enum UIAnchorLocation
	{
		LEFT_TOP,
		LEFT_MID,
		LEFT_BOT,
		MID_TOP,
		CENTER,
		MID_BOT,
		RIGHT_TOP,
		RIGHT_MID,
		RIGHT_BOT
	};

	public class UIAnchor
	{
		public float m_xStart;
		public float m_yStart;
		public float m_xWidth;
		public float m_yHeight;

		private UIAnchorLocation m_anchorLocation;

		private delegate int pixelDelegate();
		private delegate float relativeDelegate();

		private pixelDelegate pixelXLeft;
		private pixelDelegate pixelXRight;
		private pixelDelegate pixelYBottom;
		private pixelDelegate pixelYTop;

		private relativeDelegate relativeXLeft;
		private relativeDelegate relativeXRight;
		private relativeDelegate relativeYBottom;
		private relativeDelegate relativeYTop;

		public UIAnchor(UIAnchorLocation anchorLocation, float xStart, float yStart, float xWidth, float yHeight)
		{
			switch (anchorLocation)
			{
			case UIAnchorLocation.LEFT_TOP:
				relativeXLeft = XLeft_AnchorLeft;
				relativeXRight = XRight_AnchorLeft;
				relativeYBottom = YBottom_AnchorTop;
				relativeYTop = YTop_AnchorTop;
				break;
			case UIAnchorLocation.LEFT_MID:
				relativeXLeft = XLeft_AnchorLeft;
				relativeXRight = XRight_AnchorLeft;
				relativeYBottom = YBottom_AnchorMid;
				relativeYTop = YTop_AnchorMid;
				break;
			case UIAnchorLocation.LEFT_BOT:
				relativeXLeft = XLeft_AnchorLeft;
				relativeXRight = XRight_AnchorLeft;
				relativeYBottom = YBottom_AnchorBottom;
				relativeYTop = YTop_AnchorBottom;
				break;
			case UIAnchorLocation.MID_TOP:
				relativeXLeft = XLeft_AnchorMid;
				relativeXRight = XRight_AnchorMid;
				relativeYBottom = YBottom_AnchorTop;
				relativeYTop = YTop_AnchorTop;
				break;
			case UIAnchorLocation.CENTER:
				relativeXLeft = XLeft_AnchorMid;
				relativeXRight = XRight_AnchorMid;
				relativeYBottom = YBottom_AnchorMid;
				relativeYTop = YTop_AnchorMid;
				break;
			case UIAnchorLocation.MID_BOT:
				relativeXLeft = XLeft_AnchorMid;
				relativeXRight = XRight_AnchorMid;
				relativeYBottom = YBottom_AnchorBottom;
				relativeYTop = YTop_AnchorBottom;
				break;
			case UIAnchorLocation.RIGHT_TOP:
				relativeXLeft = XLeft_AnchorRight;
				relativeXRight = XRight_AnchorRight;
				relativeYBottom = YBottom_AnchorTop;
				relativeYTop = YTop_AnchorTop;
				break;
			case UIAnchorLocation.RIGHT_MID:
				relativeXLeft = XLeft_AnchorRight;
				relativeXRight = XRight_AnchorRight;
				relativeYBottom = YBottom_AnchorMid;
				relativeYTop = YTop_AnchorMid;
				break;
			case UIAnchorLocation.RIGHT_BOT:
				relativeXLeft = XLeft_AnchorRight;
				relativeXRight = XRight_AnchorRight;
				relativeYBottom = YBottom_AnchorBottom;
				relativeYTop = YTop_AnchorBottom;
				break;
			}

			m_xStart = xStart;
			m_yStart = yStart;
			m_xWidth = xWidth;
			m_yHeight = yHeight;
		}

		public float GetRelativeXLeft()
		{
			return relativeXLeft();
		}

		public float GetRelativeXRight()
		{
			return relativeXRight();
		}

		public float GetRelativeYTop()
		{
			return relativeYTop();
		}

		public float GetRelativeYBottom()
		{
			return relativeYBottom();
		}

		public float GetPixelXLeft()
		{
			throw new System.NotImplementedException();
			return pixelXLeft();
		}
		
		public float GetPixelXRight()
		{
			throw new System.NotImplementedException();
			return pixelXRight();
		}
		
		public float GetPixelYTop()
		{
			throw new System.NotImplementedException();
			return pixelYTop();
		}
		
		public float GetPixelYBottom()
		{
			throw new System.NotImplementedException();
			return pixelYBottom();
		}

		private float XLeft_AnchorLeft()
		{
			return m_xStart;
		}

		private float XLeft_AnchorMid()
		{
			return m_xStart - 0.5f * m_xWidth;
		}

		private float XLeft_AnchorRight()
		{
			return m_xStart - m_xWidth;
		}

		private float XRight_AnchorLeft()
		{
			return m_xStart + m_xWidth;
		}
		
		private float XRight_AnchorMid()
		{
			return m_xStart + 0.5f * m_xWidth;
		}
		
		private float XRight_AnchorRight()
		{
			return m_xStart;
		}

		private float YBottom_AnchorBottom()
		{
			return m_yStart;
		}

		private float YBottom_AnchorMid()
		{
			return m_yStart - 0.5f * m_yHeight;
		}

		private float YBottom_AnchorTop()
		{
			return m_yStart - m_yHeight;
		}

		private float YTop_AnchorBottom()
		{
			return m_yStart + m_yHeight;
		}
		
		private float YTop_AnchorMid()
		{
			return m_yStart + 0.5f * m_yHeight;
		}
		
		private float YTop_AnchorTop()
		{
			return m_yStart;
		}
	}
}
