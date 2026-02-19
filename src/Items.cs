class Item {
    public int Weight { get; }
    public string Desc { get; }
    public string Name { get; }

    public Item(int weight, string desc, string name) {
        Weight = weight;
        Desc = desc;
        Name = name;
    }
}