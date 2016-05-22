

public class RandomMoveScript : MoveScript {
	
	void Start() 
	{
		direction.x = (float)GetRandomNumber(-1,1);
	}
	
	private double GetRandomNumber(double minimum, double maximum)
	{ 
		System.Random random = new System.Random();
		return random.NextDouble() * (double)(maximum - minimum) + minimum;
	}
}
