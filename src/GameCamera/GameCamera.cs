namespace FlappyBird.GameCamera;

public interface IGameCamera : ICamera2D;

[Id(nameof(GameCamera))]
[Meta(typeof(IAutoNode))]
public partial class GameCamera : Camera2D {
}
