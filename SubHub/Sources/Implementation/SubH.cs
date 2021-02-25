using System;

namespace SubHubT
{
// Facade for an arguably better API
public partial class SubH : ISubH
{
	public static			ISubH					I						= IoC.I.CreateSubH(  );

	public					ISubscription<T>		Sub<T>					( Action<T> action, Int32 order = 0 )
			where T : IMessage, IPoolable, new()
	{
		return SubHub<T>.I.Sub( action, order);
	}

	public					ISubscription<T>		Sub<T>					( Object filter, Action<T> action, Int32 order=0 )
			where T : IMessage, IPoolable, new()
	{
		return SubHub<T>.I.Sub( filter, action, order);
	}

	public					void					Unsub<T>				( ISubscription<T> subscription )
			where T : IMessage, IPoolable, new()
	{
		SubHub<T>.I.Unsub(subscription);
	}

	public					void					Publish<T>				( T message )
			where T : IMessage, IPoolable, new()
	{
		SubHub<T>.I.Publish(message);
	}

	public					void					Publish<T>				( Object filter, T message )
			where T : IMessage, IPoolable, new()
	{
		SubHub<T>.I.Publish(filter, message);
	}

	public					T						Args<T>					(  )
			where T : IMessage, IPoolable, new()
	{
		return IoC.I.Rent<T>();
	}
}

public partial class SubH : ISubHTests
{
	public					ISubHub<T>				GetSubHubT<T>			(  )
			where T : IMessage, IPoolable, new()
	{
		return SubHub<T>.I;
	}
}
}