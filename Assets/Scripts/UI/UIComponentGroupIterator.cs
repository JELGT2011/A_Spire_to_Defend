using UnityEngine;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;

namespace UINamespace
{
	public class UIComponentGroupIterator
	{
		private HybridDictionary m_componentDictionary;
		private ArrayList m_componentArrayList;

		private UIComponentGroup m_componentGroup;

		public UIComponentGroupIterator(UIComponentGroup inputComponentGroup, bool includeComponentGroups)
		{
			m_componentDictionary = new HybridDictionary();
			m_componentArrayList = new ArrayList();

			m_componentGroup = inputComponentGroup;

			List<UIComponent> componentQueue = new List<UIComponent>();
			componentQueue.Add(inputComponentGroup);
			while (componentQueue.Count > 0)
			{
				UIComponent currentComponent = componentQueue[0];
				if (includeComponentGroups)
				{
					m_componentDictionary.Add(currentComponent.Id, currentComponent);
					m_componentArrayList.Add(currentComponent);
				}
				componentQueue.RemoveAt(0);

				LinkedList<UIComponent> childComponents = currentComponent.GetChildComponentsList();
				if (null != childComponents)
				{
					foreach (UIComponent component in childComponents)
						componentQueue.Add(component);
				}
			}
		}

		public void OnGUI()
		{
			foreach (UIComponent component in m_componentArrayList)
				component.DrawGUI();
		}
	}
}
