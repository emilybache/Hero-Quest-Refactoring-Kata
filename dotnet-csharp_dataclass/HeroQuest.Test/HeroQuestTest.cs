namespace CodingDojo.Test;

using CodingDojo;
using System.Text;

public class HeroQuestTest
{
    private QuestData _questData;

    public HeroQuestTest()
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
            EnemyPower = 5
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

    [Fact]
    void EnemyToString()
    {
        var result = HeroQuest.EnemyToString(_questData.EnemyName!, _questData.EnemyPower);
        var expected = "Enemy: Goblin\nPower: 5\n";
        Assert.Equal(expected, result);
    }

    [Fact]
    void EnemyAttackPlayer()
    {
        HeroQuest.EnemyAttackPlayer(_questData);
        Assert.Equal(98, _questData.PlayerHealth);
    }

    [Fact]
    void EnemyAttackPlayerNormalDamage()
    {
        _questData.EnemyPower = 25;
        _questData.PlayerStrength = 5;

        HeroQuest.EnemyAttackPlayer(_questData);

        Assert.Equal(75, _questData.PlayerHealth);
    }

    [Fact]
    void EnemyAttackPlayerReducedDamage()
    {
        _questData.PlayerStrength = 15;

        HeroQuest.EnemyAttackPlayer(_questData);

        Assert.Equal(98, _questData.PlayerHealth);
    }

    [Fact]
    void PlayerChallengeEnemy()
    {
        HeroQuest.PlayerChallengeEnemy(_questData);
        Assert.Equal(-7, _questData.EnemyPower);
    }

    [Fact]
    void PlayerChallengeEnemyWins()
    {
        _questData.PlayerStrength = 25;

        HeroQuest.PlayerChallengeEnemy(_questData);

        Assert.Equal(-10, _questData.EnemyPower);
    }

    [Fact]
    void PlayerChallengeEnemyRetreats()
    {
        _questData.EnemyPower = 50;
        _questData.PlayerStrength = 10;
        _questData.ItemPower = 5;

        HeroQuest.PlayerChallengeEnemy(_questData);

        Assert.Equal(50, _questData.EnemyPower);
    }

    [Fact]
    void PlayerChallengeEnemyNoItem()
    {
        _questData.EnemyPower = 20;
        _questData.PlayerStrength = 22;
        _questData.ItemPower = 0;

        HeroQuest.PlayerChallengeEnemy(_questData);

        Assert.Equal(9, _questData.EnemyPower);
    }

    [Fact]
    void ItemApplyEffectToPlayerMagic()
    {
        _questData.ItemKind = "Magic";
        _questData.ItemPower = 15;

        HeroQuest.ItemApplyEffectToPlayer(_questData);

        Assert.Equal(25, _questData.PlayerMagic);
    }

    [Fact]
    void ItemApplyEffectToPlayerHealth()
    {
        _questData.ItemKind = "Health";
        _questData.ItemPower = 20;

        HeroQuest.ItemApplyEffectToPlayer(_questData);

        Assert.Equal(120, _questData.PlayerHealth);
    }
}
