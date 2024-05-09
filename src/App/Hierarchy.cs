using Shared;

namespace App;

public abstract class HierarchyRoot(int SomeSharedProperty) : ITypeDiscriminator
{
    public abstract string Type { get; }
}

public class A(int SomeSharedProperty, int SomeASpecificProperty) : HierarchyRoot(SomeSharedProperty)
{
    public override string Type => nameof(A);

    public int SomeSharedProperty { get; } = SomeSharedProperty;
    public int SomeASpecificProperty { get; } = SomeASpecificProperty;

}

public class B(int SomeSharedProperty, int SomeBSpecificProperty) : HierarchyRoot(SomeSharedProperty)
{
    public override string Type=> nameof(B);

    public int SomeSharedProperty { get;  } = SomeSharedProperty;
    public int SomeBSpecificProperty { get; } = SomeBSpecificProperty;

}

public class C(int SomeSharedProperty, int SomeBSpecificProperty, A tull) : HierarchyRoot(SomeSharedProperty)
{
    public override string Type => nameof(C);

    public int SomeSharedProperty { get; } = SomeSharedProperty;
    public int SomeBSpecificProperty { get; } = SomeBSpecificProperty;
    public A Tull { get; } = tull;
}