class Item {
    public int Weight { get; }
    public string Name { get; }
    public string Desc { get; }

    public Item(int weight, string name, string desc) {
        Weight = weight;
        Name = name;
        Desc = desc;
    }
}