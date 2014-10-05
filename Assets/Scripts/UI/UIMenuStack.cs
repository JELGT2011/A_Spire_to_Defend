using System.Collections.Generic;

namespace UINamespace
{
	/// <summary>
	/// Stack implemented with a Linked List. Top of the stack is the First in the L.L.
	/// Bottom of the stack is the Last in the L.L.
	/// </summary>
	public class UIMenuStack
	{
		private LinkedList<UIMenu> m_menuStack;
		private int m_numberMenusRendered;
		private bool m_renderAllMenus;

		public int MenusRendered
		{
			get { return m_numberMenusRendered; }
			set
			{
				if (value < 0)
					value = 0;

				if (value >= m_menuStack.Count)
				{
					m_renderAllMenus = true;
					m_numberMenusRendered = m_menuStack.Count;
				}
				else
				{
					m_renderAllMenus = false;
					m_numberMenusRendered = value;
				}
			}
		}

		public void SetRenderAllMenus()
		{
			m_renderAllMenus = true;
			m_numberMenusRendered = m_menuStack.Count;
		}

		public UIMenuStack()
		{
			m_menuStack = new LinkedList<UIMenu>();
			m_renderAllMenus = true;
			m_numberMenusRendered = 0;
		}

		public void PushTop(UIMenu menu)
		{
			m_menuStack.AddFirst(menu);
		}

		public void PushBottom(UIMenu menu)
		{
			m_menuStack.AddLast(menu);
		}

		public UIMenu PopTop()
		{
			UIMenu menu = m_menuStack.First.Value;
			m_menuStack.RemoveFirst();
			return menu;
		}

		public UIMenu PopBottom()
		{
			UIMenu menu = m_menuStack.Last.Value;
			m_menuStack.RemoveLast();
			return menu;
		}

		public UIMenu Top()
		{
			return m_menuStack.First.Value;
		}

		public UIMenu Bottom()
		{
			return m_menuStack.Last.Value;
		}
	}
}
