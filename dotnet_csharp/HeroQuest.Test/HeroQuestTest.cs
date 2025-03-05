namespace CodingDojo.Test;

using CodingDojo;

public class HeroQuestTest
{
    private QuestData _questData;

    public HeroQuestTest()
    {
        _questData = new()
        {
            PlayerName = "Conan",
            PlayerHealth = 100,
            PlayerStrength = 20,
            PlayerMagic = 10,
            PlayerCraftingSkill = 10,
            ItemName = "Amulet of Strength",
            ItemKind = "Strength",
            ItemPower = 10
        };
    }

    [Fact]
    void PlayerToString()
    {
        string result = HeroQuest.PlayerToString(_questData.PlayerName!, _questData.PlayerHealth,
            _questData.PlayerStrength, _questData.PlayerMagic, _questData.PlayerCraftingSkill);

        var expected = "Conan's Attributes:\nHealth: 100\nStrength: 20\nMagic: " +
                       "10\nCrafting " +
                       "Skill: 10\n";

        Assert.Equal(expected, result);
    }

    [Fact]
    void PlayerFallsDown()
    {
        _questData.PlayerStrength = 3;
        HeroQuest.PlayerFallsDown(_questData);
        Assert.Equal(90, _questData.PlayerHealth);
    }

    [Fact]
    void PlayerFallsDownNoDamage()
    {
        HeroQuest.PlayerFallsDown(_questData);
        Assert.Equal(100, _questData.PlayerHealth);
    }

    [Fact]
    void ItemToString()
    {
        var result = HeroQuest.ItemToString(_questData.ItemName, _questData.ItemKind, _questData.ItemPower);
        var expected = "Item: Amulet of Strength\nKind: Strength\nPower: 10\n";
        Assert.Equal(expected, result);
    }

    [Fact]
    void ItemReduceByUsage()
    {
        HeroQuest.ItemReduceByUsage(_questData);
        Assert.Equal(5, _questData.ItemPower);
    }

    [Fact]
    void ItemReduceByUsageToJunk()
    {
        _questData.ItemPower = 1;
        HeroQuest.ItemReduceByUsage(_questData);
        Assert.Equal(0, _questData.ItemPower);
        Assert.Equal("Junk", _questData.ItemKind);
    }

    [Fact]
    void ItemApplyEffectToPlayer()
    {
        HeroQuest.ItemApplyEffectToPlayer(_questData);
        Assert.Equal(30, _questData.PlayerStrength);
    }

    [Fact]
    void ItemApplyEffectToPlayerJunk()
    {
        _questData.ItemKind = "Junk";
        HeroQuest.ItemApplyEffectToPlayer(_questData);
        Assert.Equal(20, _questData.PlayerStrength);
    }

    [Fact]
    void ItemRepair()
    {
        HeroQuest.ItemRepair(_questData);
        Assert.Equal(26, _questData.ItemPower);
    }
}