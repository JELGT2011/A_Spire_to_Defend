using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace UINamespace
{
		/// <summary>
		/// UI class to be used from the outside. Holds all of the menus inside.
		/// </summary>
	public class UI
	{
		private UIMenuStack m_menuStack;
		private HybridDictionary m_menuDictionary;

		public UI(UIComponentGroup headGroup)
		{
			m_menuDictionary = new HybridDictionary(4, true);
			m_menuStack = new UIMenuStack();

			UIMenu menu = new UIMenu(headGroup);

			m_menuDictionary.Add(1, menu);
		}

		public void OnGUI()
		{
			LinkedListNode<UIMenu> menuStackNode = m_menuStack.GetHeadNode();
			int count = 0;
			while (count < m_menuStack.MaxMenusRendered && null != menuStackNode)
			{
				UIMenu menu = menuStackNode.Value;
				menu.OnGUI();
				menuStackNode = menuStackNode.Next;
				++count;
			}
		}

		public void UpdateDeltaTime(float deltaTime)
		{

		}

		public void CalculateRenderingOutput()
		{
			LinkedListNode<UIMenu> menuStackNode = m_menuStack.GetHeadNode();
			int count = 0;
			while (count < m_menuStack.MaxMenusRendered && null != menuStackNode)
			{
				UIMenu menu = menuStackNode.Value;
				menu.CalculateRenderingOutput();
				menuStackNode = menuStackNode.Next;
				++count;
			}
		}

		public void SetStartMenu(int whichMenu)
		{
			UIMenu menu = m_menuDictionary[whichMenu] as UIMenu;
			if (null == menu)
				throw new UnassignedReferenceException("Menu does not exist in menuDictionary");
			m_menuStack.PushTop(menu);
		}

		public void CheckIfInputInButton(int x, int y)
		{
			LinkedListNode<UIMenu> menuStackNode = m_menuStack.GetHeadNode();
			int count = 0;
			while (count < m_menuStack.MaxMenusRendered && null != menuStackNode)
			{
				UIMenu menu = menuStackNode.Value;
				menu.CheckIfInputInButton(x, y);
				menuStackNode = menuStackNode.Next;
				++count;
			}
		}

		public void CheckIfInputInButton(float x, float y)
		{
			LinkedListNode<UIMenu> menuStackNode = m_menuStack.GetHeadNode();
			int count = 0;
			while (count < m_menuStack.MaxMenusRendered && null != menuStackNode)
			{
				UIMenu menu = menuStackNode.Value;
				menu.CheckIfInputInButton(x, y);
				menuStackNode = menuStackNode.Next;
				++count;
			}
		}

		public bool AcknowledgeInput(int x, int y)
		{
			bool returnValue = false;
			LinkedListNode<UIMenu> menuStackNode = m_menuStack.GetHeadNode();
			int count = 0;
			while (count < m_menuStack.MaxMenusRendered && null != menuStackNode)
			{
				UIMenu menu = menuStackNode.Value;
				if (menu.AcknowledgeInput(x, y))
					returnValue = true;
				menuStackNode = menuStackNode.Next;
				++count;
			}
			return returnValue;
		}
		public bool AcknowledgeInput(float x, float y)
		{
			bool returnValue = false;
			LinkedListNode<UIMenu> menuStackNode = m_menuStack.GetHeadNode();
			int count = 0;
			while (count < m_menuStack.MaxMenusRendered && null != menuStackNode)
			{
				UIMenu menu = menuStackNode.Value;
				if (menu.AcknowledgeInput(x, y))
					returnValue = true;
				menuStackNode = menuStackNode.Next;
				++count;
			}
			return returnValue;
		}

		private static int componentId = 0;
		public static int GenerateId()
		{
			return (++componentId);
		}
	}
}
