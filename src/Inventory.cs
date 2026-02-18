class Inventory {
    private int MaxWeight;
    private Dictionary<string, Item> items;
    
    public Inventory(int maxWeight) {
        this.MaxWeight = maxWeight;
        this.items = new Dictionary<string, Item>();
    }

    public bool Put(string itemName, Item item) {
        return false;
    }

    public Item Get(string itemName) {
        return null;
    }

    public int TotalWeight() {
        int total = 0;
        return total;
    }

    public int FreeWeight() {
        return 1;
    }
}