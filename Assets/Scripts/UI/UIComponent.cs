using UnityEngine;
using System.Collections.Generic;

namespace UINamespace
{
	public abstract class UIComponent
	{
		private int m_componentId;

		protected UIAnchor m_anchor;
		protected float m_xStart;
		protected float m_yStart;
		protected float m_xWidth;
		protected float m_yHeight;

		protected UIComponentGroup m_parentComponentGroup = null;

		public int Id
		{
			get { return m_componentId; }
		}

		protected UIComponent(float xStart,
		                      float yStart,
		                      float xWidth,
		                      float yHeight,
		                      UIComponentGroup parentComponentGroup,
		                      UIAnchorLocation anchorLocation)
		{
			m_componentId = UI.GenerateId();

			m_xStart = xStart;
			m_yStart = yStart;
			m_xWidth = xWidth;
			m_yHeight = yHeight;

			m_parentComponentGroup = parentComponentGroup;

			m_anchor = new UIAnchor(anchorLocation);
		}

		public float GetStartX() { return m_xStart; }
		public float GetWidthX() { return m_xWidth; }
		public float GetStartY() { return m_yStart; }
		public float GetHeightY() { return m_yHeight; }

		public abstract void DrawGUI();
		public abstract LinkedList<UIComponent> GetChildComponentsList();
	}
}
