using UnityEngine;
using System.Collections;

namespace UINamespace
{
	/// <summary>
	/// Abstract Relative Layout. Calculations are a percentage of the parent layout,
	/// or whole screen if no parent. Uses float for screen location, so bottom left
	/// of the screen is (0f,0f) and top right of the screen is (1f,1f).
	/// </summary>
	public class UIRelativeLayout : UIComponentGroup
	{
		protected float m_xStart;
		protected float m_yStart;
		protected float m_xWidth;
		protected float m_yHeight;

		protected UIComponentGroup m_parentComponentGroup = null;

		public UIRelativeLayout(float xStart,
		                        float yStart,
		                        float xWidth,
		                        float yHeight,
		                        UIComponentGroup parentComponentGroup)
			: base()
		{
			m_xStart = xStart;
			m_yStart = yStart;
			m_xWidth = xWidth;
			m_yHeight = yHeight;
			
			m_parentComponentGroup = parentComponentGroup;
		}

		public UIRelativeLayout AddUIComponent(UIComponent component)
		{
			base.AddUIComponent(component);

			return this;
		}

		public float GetStartX() { return m_xStart; }
		public float GetWidthX() { return m_xWidth; }
		public float GetStartY() { return m_yStart; }
		public float GetHeightY() { return m_yHeight; }

		public override void DrawGUI()
		{
			// do nothing;
		}
	}
}
