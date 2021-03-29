using System;
using SubHubT;
using Tests;

namespace PerformanceTests
{
public class TestSubHLocal_SubAll: IPerformanceTest
	, IToTestString
	, IListen<MessageStruct>
{
	public TestSubHLocal_SubAll(Int32 iterations, Int32 subCount)
	{
		_iterations = iterations;
		_subCount = subCount;
	}

	private Int32 _iterations;
	private Int32 _value;
	private readonly Int32 _subCount;
	public Int32 Iterations => _iterations;

	public void Before( )
	{
		SubH.I = IoC.I.CreateSubHLocal();
	}

	void IListen<MessageStruct>.Handle(Object filter, ref MessageStruct message )
	{
		_value = message.Value;
	}

	public void Run( )
	{
		for ( int i = 0; i < _subCount; i++ )
		{
			SubH.I.Sub<MessageStruct>(this);
		}
	}

	public String ToTestString( ) => $"{GetType().Name}:s_{_subCount.ToString("e0")}";
}
}