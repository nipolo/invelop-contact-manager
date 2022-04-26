using System;

namespace INV.Common.Libraries.Exceptions
{
	public class EntityNotFoundException<TId> : Exception
	{
		public EntityNotFoundException(TId id) : base($"Entity with id={id} not found")
		{
		}
	}
}
