using RPGInventory.Items.Containers.Restrictions;

namespace RPGInventory.Items.Containers;

public class WetPaperBag : Container
{
    public WetPaperBag() : base(3)
    {
        Name = "Wet paper bag";
        Description = "Who left this out?!";
        Weight = 1;
        Type = ItemType.Container;

        AddRestriction(new CapacityRestriction());
        AddRestriction(new MaxWeightRestriction(2));
    }
}
