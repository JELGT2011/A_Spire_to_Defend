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

		private UIComponentGroup m_headComponentGroup;

		private ArrayList m_renderableArrayList;
//		private ArrayList m_layoutArrayList;
		private ArrayList m_buttonArrayList;

		public UIComponentGroupIterator(UIComponentGroup headComponentGroup)
		{
			m_componentDictionary = new HybridDictionary();
			m_componentArrayList = new ArrayList();

			m_headComponentGroup = headComponentGroup;

			m_renderableArrayList = new ArrayList();
//			m_layoutArrayList = new ArrayList();
			m_buttonArrayList = new ArrayList();

			PopulateComponentArrayList();

			PopulateRenderableArrayList();
			PopulateButtonArrayList();

			CalculateRenderingOutput();
		}

		private void PopulateComponentArrayList()
		{
			m_componentArrayList.Clear();

			List<UIComponentGroupIteratorData> componentQueue = new List<UIComponentGroupIteratorData>();
			int parentSlot = -1;
			int componentArrayListIndex = -1;
			componentQueue.Add(new UIComponentGroupIteratorData(m_headComponentGroup, parentSlot));
			while (componentQueue.Count > 0)
			{
				UIComponentGroupIteratorData currentComponentData = componentQueue[0];
				
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

		public void CalculateRenderingOutput()
		{
			for (int n = 0; n < m_componentArrayList.Count; ++n)
				(m_componentArrayList[n] as UIComponentGroupIteratorData).component.CalculateRenderingOutput();
			CalculatePixelRenderingInfo();
		}

		public void CalculatePixelRenderingInfo()
		{
			foreach (UIComponentGroupIteratorData renderableData in m_renderableArrayList)
				(renderableData.component as UIRenderable).CalculatePixelRenderingInfo();
		}

		private void PopulateRenderableArrayList()
		{
			m_renderableArrayList.Clear();

			for (int n = 0; n < m_componentArrayList.Count; ++n)
				if ((m_componentArrayList[n] as UIComponentGroupIteratorData).component.GetComponentType() == UIComponentType.RENDERABLE)
					m_renderableArrayList.Add(m_componentArrayList[n]);
		}

		private void PopulateButtonArrayList()
		{
			m_buttonArrayList.Clear();

			for (int n = 0; n < m_componentArrayList.Count; ++n)
				if ((m_componentArrayList[n] as UIComponentGroupIteratorData).component.GetComponentType() == UIComponentType.BUTTON)
				{
					m_buttonArrayList.Add(m_componentArrayList[n]);
					((m_componentArrayList[n] as UIComponentGroupIteratorData).component as UIButton).SetStartStateIdle();
					
				}
		}

		public void OnGUI()
		{
			foreach (UIComponentGroupIteratorData componentData in m_renderableArrayList)
				(componentData.component as UIRenderable).DrawGUI();
		}

		public void CheckIfInputInButton(int x, int y)
		{
			foreach (UIComponentGroupIteratorData componentData in m_buttonArrayList)
				(componentData.component as UIButton).CheckIfInputInButton(x, y);
		}

		public void CheckIfInputInButton(float x, float y)
		{
			foreach (UIComponentGroupIteratorData componentData in m_buttonArrayList)
				(componentData.component as UIButton).CheckIfInputInButton(x, y);
		}

		public bool AcknowledgeInput(int x, int y)
		{
			bool returnValue = false;
			foreach (UIComponentGroupIteratorData componentData in m_buttonArrayList)
				if ((componentData.component as UIButton).AcknowledgeInput(x, y))
					returnValue = true;
			return returnValue;
		}
		public bool AcknowledgeInput(float x, float y)
		{
			bool returnValue = false;
			foreach (UIComponentGroupIteratorData componentData in m_buttonArrayList)
				if ((componentData.component as UIButton).AcknowledgeInput(x, y))
					returnValue = true;
			return returnValue;
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
