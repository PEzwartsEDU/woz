class Inventory {
    private int MaxWeight;
    private int TotalWeight;
    private Dictionary<string, Item> items;
    
    public Inventory(int maxWeight) {
        this.MaxWeight = maxWeight;
        this.TotalWeight = 0;
        this.items = new Dictionary<string, Item>();
    }

    public bool Put(string itemName, Item item) {
        if (item.Weight == 0) {
            return false;
        }

        if ((TotalWeight + item.Weight) >= MaxWeight) {
            TotalWeight = TotalWeight - item.Weight;
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

    // TotalWeight perse nodig? Want er is CurrentWeight waarvan dat al word opgeteld...

    public int ShowTotalWeight() {
        int total = 0;

        return total;
    }

    public void AddTotalWeight(int amount) {
        TotalWeight = TotalWeight + amount;
    }

    public void RemoveTotalWeight(int amount) {
        TotalWeight = TotalWeight - amount;
    }

    public int ShowFreeWeight() {
        return (MaxWeight - TotalWeight);
    }
}