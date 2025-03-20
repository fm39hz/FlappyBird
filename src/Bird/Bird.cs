namespace FlappyBird.Bird;

public interface IBird : ICharacterBody2D, IProvide<IBirdRepo>;

[Id(nameof(Bird))]
[Meta(typeof(IAutoNode))]
public partial class Bird : CharacterBody2D {
}
