using Godot;

public class Health
{

    public delegate void DepeletedEventHandler();
    public DepeletedEventHandler Depeleted;

    private int max;
    private int current;

    public int Max
    {
        get { return max; }
        init { max = value; }
    }

    public int Current
    {
        get { return current; }
        set 
        { 
            current = value; 
            
            if (current <= 0)
                Depeleted?.Invoke();
        }
    }
    
    public Health(int max)
    {
        Max = max;
        current = max;
    }

    public void TakeDamage(int amount)
    {
        Current -= amount;    
    }
}
