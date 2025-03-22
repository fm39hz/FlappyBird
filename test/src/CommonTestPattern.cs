namespace FlappyBird.Test;

using JetBrains.Annotations;
using Shouldly;

public static class CommonTestPattern {
	[UsedImplicitly]
	public static T TestAvailable<T>(this T testObject) where T : class {
		testObject.ShouldNotBeNull();
		testObject.ShouldBeAssignableTo<T>();
		return testObject;
	}
}
