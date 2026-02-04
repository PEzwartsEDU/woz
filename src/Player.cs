class Player {
    public Room CurrentRoom { get; set; }

    public int health;
    private bool alive;

    public Player()
    {
        CurrentRoom = null;

        health = 100;
        alive = true;
    }
    
    public void Damage(int amount) {
        health = health - amount;

        if (health == 0) {
            alive = false;
        }
    }

    public void Heal(int amount) {
        health = health + amount;
    }

    public bool IsAlive() {
        return alive;
    }
}