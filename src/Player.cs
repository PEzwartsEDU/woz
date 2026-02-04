class Player {
    public Room CurrentRoom { get; set; }

    public int health;

    public Player()
    {
        CurrentRoom = null;

        health = 100;
    }
    
    public void Damage() {}

    public void Heal() {}

    public void IsAlive() {}
}