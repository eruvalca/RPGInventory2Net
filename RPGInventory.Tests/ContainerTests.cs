using RPGInventory.Items;
using RPGInventory.Items.Containers;
using RPGInventory.Items.Containers.Restrictions;
using RPGInventory.Items.Potions;
using RPGInventory.Items.Weapons;

namespace RPGInventory.Tests;
public class ContainerTests
{
    [Fact]
    public void CanAddItemToBackpack()
    {
        Backpack b = new();
        HealthPotion p = new();

        AddItemStatus actual = b.AddItem(p);
        Assert.Equal(AddItemStatus.Ok, actual);
    }

    [Fact]
    public void CannotAddItemToFullBackpack()
    {
        Backpack b = new();
        GreatAxe axe = new();

        b.AddItem(axe);
        b.AddItem(axe);
        b.AddItem(axe);
        b.AddItem(axe);

        AddItemStatus actual = b.AddItem(axe);
        Assert.Equal(AddItemStatus.ContainerFull, actual);
    }

    [Fact]
    public void CanRemoveItemFromBackpack()
    {
        Backpack b = new();
        HealthPotion p = new();

        b.AddItem(p);

        Item actual = b.RemoveItem();

        // do these two variables reference the same object
        Assert.Equal(p, actual);
    }

    [Fact]
    public void EmptyBagReturnsNull()
    {
        Backpack b = new();
        Item item = b.RemoveItem();

        Assert.Null(item);
    }

    [Fact]
    public void PotionSatchelRequiresPotions()
    {
        PotionSatchel p = new();

        HealthPotion hp = new();
        GreatAxe ga = new();

        Assert.Equal(AddItemStatus.Ok, p.AddItem(hp));
        Assert.Equal(AddItemStatus.ItemWrongType, p.AddItem(ga));
    }

    [Fact]
    public void ItemTypeRestrictionWorks()
    {
        ItemTypeRestriction restriction = new(ItemType.Weapon);

        AddItemStatus result = restriction.AddItem(new HealthPotion(), null);

        Assert.Equal(AddItemStatus.ItemWrongType, result);
    }

    [Fact]
    public void MaxWeightRestrictionWorks()
    {
        WetPaperBag bag = new();

        AddItemStatus actual = bag.AddItem(new GreatAxe());

        Assert.Equal(AddItemStatus.ContainerOverweight, actual);
    }
}
