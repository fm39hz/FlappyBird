namespace FlappyBird.Game;

public interface IGame : INode2D, IProvide<IGameRepo>, IProvide<IGameLogic>;

[Id(nameof(Game))]
[Meta(typeof(IAutoNode))]
public partial class Game : Node2D {
}
