class Inventory {
    private int MaxWeight;
    private int CurrentWeight;
    private Dictionary<string, Item> items;
    
    public Inventory(int maxWeight) {
        this.MaxWeight = maxWeight;
        this.items = new Dictionary<string, Item>();
    }

    public bool Put(string itemName, Item item) {
        if (item.Weight == 0) {
            return false;
        }

        if ((CurrentWeight + item.Weight) >= MaxWeight) {
            return false;
        }

        return true;
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