using UnityEngine;
using System.Collections;

namespace UINamespace
{
	public interface IUIButtonListener
	{
		void OnHighlighted();
		void OnIdle();
		void OnSelected();
	}
}