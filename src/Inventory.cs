class Inventory {
    private int MaxWeight;
    private int CurrentWeight;
    private Dictionary<string, Item> items;
    
    public Inventory(int maxweight) {
        this.MaxWeight = maxweight;
        this.CurrentWeight = 0;
        this.items = new Dictionary<string, Item>();
    }

    public bool Put(string itemName, Item item) {
        if (item.Weight == 0) {
            return false;
        }

        if ((CurrentWeight + item.Weight) >= MaxWeight) {
            CurrentWeight = CurrentWeight - item.Weight;
            return false;
        }

        items.Add(itemName, item);
        CurrentWeight = CurrentWeight + item.Weight;

        return true;
    }

    public Item Get(string itemName) {
        foreach (KeyValuePair<string, Item> item in items) {
            if (item.Key == itemName) {
                items.Remove(item.Key);
                CurrentWeight = CurrentWeight - item.Value.Weight;

                return item.Value;
            }
        }

        return null;
    }

    public int GetCurrentWeight() {
        return CurrentWeight;
    }

    public int GetDiffWeight() {
        return (MaxWeight - CurrentWeight);
    }

    private void AddCurrentWeight(int amount) {
        CurrentWeight = CurrentWeight + amount;
    }

    private void RemoveCurrentWeight(int amount) {
        CurrentWeight = CurrentWeight - amount;
    }

    //public void AddItem(string itemName, Item item) {
        //items.Add(itemName, item);
    //}

    //public void RemoveItem(string itemName, Item item) {
        //items.Remove(itemName, item);
    //}
}