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

		public UIComponentGroupIterator(UIComponentGroup inputComponentGroup)
		{
			m_componentDictionary = new HybridDictionary();
			m_componentArrayList = new ArrayList();

			m_componentGroup = inputComponentGroup;

			List<UIComponentGroupIteratorData> componentQueue = new List<UIComponentGroupIteratorData>();
			int parentSlot = -1;
			int componentArrayListIndex = -1;
			componentQueue.Add(new UIComponentGroupIteratorData(inputComponentGroup, parentSlot));
			while (componentQueue.Count > 0)
			{
				UIComponentGroupIteratorData currentComponentData = componentQueue[0];
				currentComponentData.component.CalculateRenderingOutput();

				m_componentArrayList.Add(currentComponentData);
				++componentArrayListIndex;

				m_componentDictionary.Add(currentComponentData.component.Id, currentComponentData.component);

				componentQueue.RemoveAt(0);

				if (currentComponentData.component.HasChildComponents())
				{
					LinkedList<UIComponent> childComponents = currentComponentData.component.GetChildComponentsList();

					parentSlot = componentArrayListIndex;
					foreach (UIComponent component in childComponents)
						componentQueue.Add(new UIComponentGroupIteratorData(component, parentSlot));
				}
			}
		}

		public void OnGUI()
		{
			foreach (UIComponent component in m_componentArrayList)
				component.DrawGUI();
		}

		private sealed class UIComponentGroupIteratorData
		{
			public UIComponent component;
			public int parentSlot;
			public UIComponentGroupIteratorData(UIComponent component, int parentSlot)
			{
				this.component = component;
				this.parentSlot = parentSlot;
			}
		}
	}
}
