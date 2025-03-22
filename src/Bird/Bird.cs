namespace FlappyBird.Bird;

using FlappyBird.Game;

public interface IBird : ICharacterBody2D, IProvide<IBirdRepo> {
	public IBirdRepo BirdRepo { get; }
}

[Id(nameof(Bird))]
[Meta(typeof(IAutoNode))]
public partial class Bird : CharacterBody2D, IBird {
	#region DI

	public override void _Notification(int what) => this.Notify(what);

	#endregion DI

	public IBirdRepo BirdRepo => new BirdRepo();
	IBirdRepo IProvide<IBirdRepo>.Value() => BirdRepo;
}
