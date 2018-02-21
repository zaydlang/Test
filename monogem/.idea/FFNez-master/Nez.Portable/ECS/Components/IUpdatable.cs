using System.Collections.Generic;


namespace Nez
{
	/// <summary>
	/// interface that when added to a Component lets Nez know that it wants the update method called each frame as long as the Component
	/// and Entity are enabled.
	/// </summary>
	public interface IUpdatable
	{
		/// <summary>
		/// Enables or disables updating this component
		/// </summary>
		bool active { get; set; }
		int updateOrder { get; }

		void update();
	}


	/// <summary>
	/// Comparer for sorting IUpdatables
	/// </summary>
	public class IUpdatableComparer : IComparer<IUpdatable>
	{
		public int Compare( IUpdatable a, IUpdatable b )
		{
			return a.updateOrder.CompareTo( b.updateOrder );
		}
	}
}

