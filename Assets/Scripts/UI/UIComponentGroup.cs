using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace UINamespace
{
	public abstract class UIComponentGroup : UIComponent
	{
		protected HybridDictionary m_componentIdDictionary;
		protected HybridDictionary m_componentNameDictionary;
		protected LinkedList<UIComponent> m_listComponent;

		protected UIComponentGroup(string componentName,
		                           float xStart,
		                           float yStart,
		                           float xWidth,
		                           float yHeight,
		                           UIComponentGroup parentComponentGroup,
		                           UILayoutType layoutType,
		                           UIAnchorLocation anchorLocation)
			: base(componentName, xStart, yStart, xWidth, yHeight, parentComponentGroup, layoutType, anchorLocation)
		{
			m_componentIdDictionary = new HybridDictionary();
			m_componentNameDictionary = new HybridDictionary();
			m_listComponent = new LinkedList<UIComponent>();
		}

		public UIComponentGroup AddUIComponent(UIComponent component)
		{
			m_componentIdDictionary.Add(component.Id, component);
			m_componentNameDictionary.Add(component.Name, component);
			m_listComponent.AddLast(component);

			component.SetParentComponentGroup(this);
			
			return this;
		}

		public override bool HasChildComponents()
		{
			if (m_listComponent.Count > 0)
				return true;
			else
				return false;
		}

		public override LinkedList<UIComponent> GetChildComponentsList()
		{
			return m_listComponent;
		}

		public override void SetChildrenEnabled(bool enabled)
		{
			LinkedListNode<UIComponent> currentNode = m_listComponent.First;
			while (null != currentNode)
			{
				switch (currentNode.Value.GetComponentType())
				{
				case UIComponentType.RENDERABLE:
					currentNode.Value.Enabled = enabled;
					break;
				case UIComponentType.BUTTON:
					(currentNode.Value as UIButton).SetChildrenEnabled(enabled);
					break;
				case UIComponentType.LAYOUT:
					(currentNode.Value as UIComponentGroup).SetChildrenEnabled(enabled);
					break;
				}
				currentNode = currentNode.Next;
			}
		}
	}
}
