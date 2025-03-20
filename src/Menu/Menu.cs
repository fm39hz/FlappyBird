namespace FlappyBird.Menu;

public interface IMenu : IControl;

[Id(nameof(Menu))]
[Meta(typeof(IAutoNode))]
public partial class Menu : Control {
}
