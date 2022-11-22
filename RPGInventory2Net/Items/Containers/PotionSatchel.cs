using RPGInventory.Items.Containers.Restrictions;

namespace RPGInventory.Items.Containers;

public class PotionSatchel : Container
{
    public PotionSatchel() : base(4)
    {
        Name = "A small potion satchel";
        Description = "This container has small loops for a few potions.";
        Type = ItemType.Container;
        Weight = 1;

        AddRestriction(new CapacityRestriction());
        AddRestriction(new ItemTypeRestriction(ItemType.Potion));
    }
}
