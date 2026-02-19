class Inventory {
    private int MaxWeight;
    private int CurrentWeight;
    private Dictionary<string, Item> items;
    
    public Inventory(int maxWeight) {
        this.MaxWeight = maxWeight;
        this.CurrentWeight = 0;
        this.items = new Dictionary<string, Item>();
    }

    public bool Put(string itemName, Item item) {
        if (item.Weight == 0) {
            return false;
        }

        if ((CurrentWeight + item.Weight) >= MaxWeight) {
            CurrentWeight = 0;
            return false;
        }

        items.Add(itemName, item);

        return true;
    }

    public Item Get(string itemName) {
        foreach (KeyValuePair<string, Item> item in items) {
            if (item.Key == itemName) {
                items.Remove(item.Key);

                return item.Value;
            }
        }

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