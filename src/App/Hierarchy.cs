using Shared;
using System.Reflection;

namespace App;

public abstract class BObject() : ITypeDiscriminator
{
    public abstract string Type { get; }
    
}

public class A(int SomeSharedProperty, int SomeASpecificProperty) : BObject
{
    public override string Type => MethodBase.GetCurrentMethod().DeclaringType.Name;

    public int SomeSharedProperty { get; } = SomeSharedProperty;
    public int SomeASpecificProperty { get; } = SomeASpecificProperty;

}

public class B(int SomeSharedProperty, int SomeBSpecificProperty) : BObject
{
    public override string Type=> MethodBase.GetCurrentMethod().DeclaringType.Name;

    public int SomeSharedProperty { get;  } = SomeSharedProperty;
    public int SomeBSpecificProperty { get; } = SomeBSpecificProperty;

}

public class C(int SomeSharedProperty, int SomeBSpecificProperty, A tull) : BObject
{
    public override string Type => MethodBase.GetCurrentMethod().DeclaringType.Name;

    public int SomeSharedProperty { get; } = SomeSharedProperty;
    public int SomeBSpecificProperty { get; } = SomeBSpecificProperty;
    public A Tull { get; } = tull;
}