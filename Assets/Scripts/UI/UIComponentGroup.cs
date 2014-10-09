using UnityEngine;
using System.Collections;
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

		protected UIComponentGroup(float xStart,
		                           float yStart,
		                           float xWidth,
		                           float yHeight,
		                           UIComponentGroup parentComponentGroup,
		                           UIAnchorLocation anchorLocation)
			: base(xStart, yStart, xWidth, yHeight, parentComponentGroup, anchorLocation)
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

		public override bool HasChildComponents()
		{
			return true;
		}

		public override LinkedList<UIComponent> GetChildComponentsList()
		{
			return m_listComponent;
		}
	}
}
