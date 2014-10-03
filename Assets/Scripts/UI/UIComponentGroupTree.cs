using UnityEngine;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;

namespace UINamespace
{
	public class UIComponentGroupTree
	{
		private HybridDictionary m_componentDictionary;
		private ArrayList m_componentArrayList;

		private UIComponentGroupTreeNode m_head;

		public UIComponentGroupTree(UIComponentGroup inputComponentGroup)
		{

		}

		private class UIComponentGroupTreeNode
		{
			private LinkedList<UIComponentGroupTreeNode> m_nextNodes;
			private UIComponentGroup m_componentGroup;

			public UIComponentGroup GetComponentGroup()
			{
				return m_componentGroup;
			}
			public void SetComponentGroup(UIComponentGroup componentGroup)
			{
				m_componentGroup = componentGroup;
			}
		}

		public void OnGUI()
		{
			foreach (UIComponent component in m_componentArrayList)
				component.DrawGUI();
		}
	}
}
