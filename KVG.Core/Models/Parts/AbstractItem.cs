using N2;

namespace KVG.Core.Models.Parts
{
	/// <summary>
	/// A base class for item parts in the templates project.
	/// </summary>
	public abstract class AbstractItem : ContentItem
	{
		public override bool IsPage
		{
			get { return false; }
		}
	}
}