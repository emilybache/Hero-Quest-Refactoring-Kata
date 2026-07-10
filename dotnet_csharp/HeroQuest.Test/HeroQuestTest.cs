namespace CodingDojo.Test;

using CodingDojo;
using System.Text;

public class HeroQuestTest
{
    private QuestData _questData = null!;

    public HeroQuestTest()
    {
        SetUp();
    }

    private void SetUp()
    {
        HeroQuest.Output = new StringBuilder();
        _questData = new()
        {
            PlayerName = "Conan",
            PlayerHealth = 100,
            PlayerStrength = 20,
            PlayerMagic = 10,
            PlayerCraftingSkill = 10,
            ItemName = "Amulet of Strength",
            ItemKind = "Strength",
            ItemPower = 10,
            EnemyName = "Goblin",
            EnemyPower = 10
        };
    }

    [Fact]
    void PlayerToString()
    {
        string result = HeroQuest.PlayerToString(_questData.PlayerName, _questData.PlayerHealth,
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
        _questData.PlayerHealth = HeroQuest.PlayerFallsDown(_questData.PlayerStrength, _questData.PlayerHealth);
        Assert.Equal(90, _questData.PlayerHealth);
    }

    [Fact]
    void PlayerFallsDownNoDamage()
    {
        _questData.PlayerHealth = HeroQuest.PlayerFallsDown(_questData.PlayerStrength, _questData.PlayerHealth);
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
        (_questData.ItemKind, _questData.ItemPower) =
            HeroQuest.ItemReduceByUsage(_questData.ItemKind, _questData.ItemPower);
        Assert.Equal(5, _questData.ItemPower);
    }

    [Fact]
    void ItemReduceByUsageToJunk()
    {
        _questData.ItemPower = 1;
        (_questData.ItemKind, _questData.ItemPower) =
            HeroQuest.ItemReduceByUsage(_questData.ItemKind, _questData.ItemPower);
        Assert.Equal(0, _questData.ItemPower);
        Assert.Equal("Junk", _questData.ItemKind);
    }

    [Fact]
    void ItemApplyEffectToPlayer()
    {
        (_questData.PlayerHealth, _questData.PlayerStrength, _questData.PlayerMagic) =
            HeroQuest.ItemApplyEffectToPlayer(_questData.ItemName, _questData.ItemKind, _questData.ItemPower,
                _questData.PlayerHealth, _questData.PlayerStrength, _questData.PlayerMagic);
        Assert.Equal(30, _questData.PlayerStrength);
    }

    [Fact]
    void ItemApplyEffectToPlayerJunk()
    {
        _questData.ItemKind = "Junk";
        (_questData.PlayerHealth, _questData.PlayerStrength, _questData.PlayerMagic) =
            HeroQuest.ItemApplyEffectToPlayer(_questData.ItemName, _questData.ItemKind, _questData.ItemPower,
                _questData.PlayerHealth, _questData.PlayerStrength, _questData.PlayerMagic);
        Assert.Equal(20, _questData.PlayerStrength);
    }

    [Fact]
    void ItemRepair()
    {
        _questData.ItemPower = HeroQuest.ItemRepair(_questData.PlayerCraftingSkill, _questData.ItemPower);
        Assert.Equal(26, _questData.ItemPower);
    }

    [Fact]
    void EnemyToString()
    {
        var result = HeroQuest.EnemyToString(_questData.EnemyName, _questData.EnemyPower);
        var expected = "Enemy: Goblin\nPower: 10\n";

        Assert.Equal(expected, result);
    }

    [Fact]
    void EnemyAttackPlayerNormalDamage()
    {
        _questData.EnemyPower = 25;
        _questData.PlayerStrength = 5;

        _questData.PlayerHealth = HeroQuest.EnemyAttackPlayer(_questData.EnemyName, _questData.EnemyPower,
            _questData.PlayerStrength, _questData.PlayerHealth);

        Assert.Equal(75, _questData.PlayerHealth);
    }

    [Fact]
    void EnemyAttackPlayerReducedDamage()
    {
        _questData.PlayerStrength = 15;

        _questData.PlayerHealth = HeroQuest.EnemyAttackPlayer(_questData.EnemyName, _questData.EnemyPower,
            _questData.PlayerStrength, _questData.PlayerHealth);

        Assert.Equal(95, _questData.PlayerHealth);
    }

    [Fact]
    void PlayerChallengeEnemyWins()
    {
        _questData.PlayerStrength = 25;

        _questData.EnemyPower = HeroQuest.PlayerChallengeEnemy(_questData.EnemyName, _questData.PlayerStrength,
            _questData.ItemPower, _questData.EnemyPower);

        Assert.Equal(-5, _questData.EnemyPower);
    }

    [Fact]
    void PlayerChallengeEnemyRetreats()
    {
        _questData.EnemyPower = 50;
        _questData.PlayerStrength = 10;
        _questData.ItemPower = 5;

        _questData.EnemyPower = HeroQuest.PlayerChallengeEnemy(_questData.EnemyName, _questData.PlayerStrength,
            _questData.ItemPower, _questData.EnemyPower);

        Assert.Equal(50, _questData.EnemyPower);
    }

    [Fact]
    void PlayerChallengeEnemyNoItem()
    {
        _questData.EnemyPower = 20;
        _questData.PlayerStrength = 22;
        _questData.ItemPower = 0;

        _questData.EnemyPower = HeroQuest.PlayerChallengeEnemy(_questData.EnemyName, _questData.PlayerStrength,
            _questData.ItemPower, _questData.EnemyPower);

        Assert.Equal(9, _questData.EnemyPower);
    }

    [Fact]
    void ItemApplyEffectToPlayerMagic()
    {
        _questData.ItemKind = "Magic";
        _questData.ItemPower = 15;

        (_questData.PlayerHealth, _questData.PlayerStrength, _questData.PlayerMagic) =
            HeroQuest.ItemApplyEffectToPlayer(_questData.ItemName, _questData.ItemKind, _questData.ItemPower,
                _questData.PlayerHealth, _questData.PlayerStrength, _questData.PlayerMagic);

        Assert.Equal(25, _questData.PlayerMagic);
    }

    [Fact]
    void ItemApplyEffectToPlayerHealth()
    {
        _questData.ItemKind = "Health";
        _questData.ItemPower = 20;

        (_questData.PlayerHealth, _questData.PlayerStrength, _questData.PlayerMagic) =
            HeroQuest.ItemApplyEffectToPlayer(_questData.ItemName, _questData.ItemKind, _questData.ItemPower,
                _questData.PlayerHealth, _questData.PlayerStrength, _questData.PlayerMagic);

        Assert.Equal(120, _questData.PlayerHealth);
    }
}