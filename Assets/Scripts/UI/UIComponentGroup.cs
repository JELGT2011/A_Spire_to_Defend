using UnityEngine;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace UINamespace
{
	public enum UILayoutType
	{
		RELATIVE_LAYOUT,
		PIXEL_LAYOUT
	};

	public abstract class UIComponentGroup : UIComponent
	{
		protected HybridDictionary m_componentDictionary;
		protected LinkedList<UIComponent> m_listComponent;

		protected UIComponentGroup()
			: base()
		{
			m_componentDictionary = new HybridDictionary();
			m_listComponent = new LinkedList<UIComponent>();
		}

		public UIComponentGroup AddUIComponent(UIComponent component)
		{
			m_componentDictionary.Add(component.Id, component);
			m_listComponent.AddLast(component);
			
			return this;
		}

		/*public abstract UIComponentGroupSizeInfo GetParentSizeInfo();

		public class UIComponentGroupSizeInfo
		{
			public UILayoutType m_layoutType;
			public UIAnchorLocation m_anchorLocation;
			public float m_xStart;
			public float m_yStart;
			public float m_xEnd;
			public float m_yEnd;
			public int m_anchorX;
			public int m_anchorY;
			public int m_widthX;
			public int m_heightY;
			public UIComponentGroupSizeInfo(float xStart, float yStart, float xEnd, float yEnd, UIAnchorLocation anchorLocation)
			{
				m_layoutType = UILayoutType.RELATIVE_LAYOUT;
				m_anchorLocation = anchorLocation;
				m_xStart = xStart;
				m_yStart = yStart;
				m_xEnd = xEnd;
				m_yEnd = yEnd;
			}
			public UIComponentGroupSizeInfo(int anchorX, int anchorY, int widthX, int heightY, UIAnchorLocation anchorLocation)
			{
				m_layoutType = UILayoutType.PIXEL_LAYOUT;
				m_anchorLocation = anchorLocation;
				m_anchorX = anchorX;
				m_anchorY = anchorY;
				m_widthX = widthX;
				m_heightY = heightY;
			}
			public UIComponentGroupSizeInfo(float xStart, float yStart, float xEnd, float yEnd)
			{
				m_layoutType = UILayoutType.RELATIVE_LAYOUT;
				m_anchorLocation = UIAnchorLocation.LEFT_BOT;
				m_xStart = xStart;
				m_yStart = yStart;
				m_xEnd = xEnd;
				m_yEnd = yEnd;
			}
			public UIComponentGroupSizeInfo(int anchorX, int anchorY, int widthX, int heightY)
			{
				m_layoutType = UILayoutType.PIXEL_LAYOUT;
				m_anchorLocation = UIAnchorLocation.LEFT_TOP;
				m_anchorX = anchorX;
				m_anchorY = anchorY;
				m_widthX = widthX;
				m_heightY = heightY;
			}
		}*/
	}
}
