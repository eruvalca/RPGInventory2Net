using RPGInventory.Items.Containers.Restrictions;

namespace RPGInventory.Items.Containers;

public class Backpack : Container
{
    public Backpack() : base(4)
    {
        Name = "A leather backpack";
        Description = "Rustic and roomy";
        Weight = 1;
        Type = ItemType.Container;

        AddRestriction(new CapacityRestriction());
    }
}
