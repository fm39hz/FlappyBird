namespace FlappyBird.Bird;

public interface IBirdRepo : IDisposable {
	/// <summary> Bird flying status </summary>
	public IAutoProp<bool> IsFalling { get; }
	/// <summary> Bird alive status </summary>
	public IAutoProp<bool> IsAlive { get; }
	/// <summary> Bird position </summary>
	public IAutoProp<Vector2> Position { get; }
	/// <summary> Bird rotation </summary>
	public IAutoProp<float> Rotation { get; }

	/// <summary> Event invoked when the bird jumps </summary>
	public event Action? BirdJumped;
	/// <summary> Event invoked when the bird falls </summary>
	public event Action? BirdFalling;
	/// <summary> Event invoked when the bird crashes on pipe or ground </summary>
	public event Action? BirdCrashed;

	/// <summary> Jump the bird </summary>
	public void Jump();
	/// <summary> Set the bird position </summary>
	public void SetPosition(Vector2 position);
	/// <summary> Set the bird rotation </summary>
	public void SetRotation(float rotation);
	/// <summary> Kill the bird </summary>
	public void Die();
	/// <summary> Reset the bird </summary>
	public void Reset();
}
