using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace UINamespace
{
		// Until file reading is a thing, the constructors will just
		// make the menus from enum codes.
	public enum UIEnum
	{
		TEST_UI,
		TEST_MENU1,
		TEST_MENU2
	};

		/// <summary>
		/// UI class to be used from the outside. Holds all of the menus inside.
		/// </summary>
	public class UI
	{
		private UIMenuStack m_menuStack;
		private HybridDictionary m_menuDictionary;

		private LinkedList<UIMenu>.Enumerator m_menuStackEnumerator;

		public UI(UIEnum whichUI)
		{
			m_menuDictionary = new HybridDictionary(4, true);
			m_menuStack = new UIMenuStack();

			switch (whichUI)
			{
			case UIEnum.TEST_UI:
			{
				UIMenu menu1 = new UIMenu(UIEnum.TEST_MENU1);
				UIMenu menu2 = new UIMenu(UIEnum.TEST_MENU2);
				m_menuDictionary.Add(UIEnum.TEST_MENU1, menu1);
				m_menuDictionary.Add(UIEnum.TEST_MENU2, menu2);
			}
				break;
			}
		}

		public void OnGUI()
		{
			m_menuStackEnumerator = m_menuStack.GetEnumerator();
			UIMenu currentMenu = m_menuStackEnumerator.Current;
			int count = 0;
			while (count < m_menuStack.MaxMenusRendered && null != currentMenu)
			{
				currentMenu.OnGUI();
			}
		}

		public void UpdateDeltaTime(float deltaTime)
		{

		}

		public void SetStartMenu(UIEnum whichMenu)
		{
			UIMenu menu = m_menuDictionary[whichMenu] as UIMenu;
			if (null == menu)
				throw new UnassignedReferenceException("Menu does not exist in menuDictionary");
			m_menuStack.PushTop(menu);
		}

		private static int componentId = 0;
		public static int GenerateId()
		{
			return (++componentId);
		}
	}
}
