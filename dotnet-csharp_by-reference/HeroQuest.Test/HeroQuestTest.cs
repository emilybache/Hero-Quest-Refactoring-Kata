namespace CodingDojo.Test;

using CodingDojo;
using System.Text;

public class HeroQuestTest
{
    private string playerName = "";
    private int playerHealth;
    private int playerStrength;
    private int playerMagic;
    private int playerCraftingSkill;
    private string itemName = "";
    private string itemKind = "";
    private int itemPower;
    private string enemyName = "";
    private int enemyPower;

    public HeroQuestTest()
    {
        SetUp();
    }

    private void SetUp()
    {
        HeroQuest.Output = new StringBuilder();
        playerName = "Conan";
        playerHealth = 100;
        playerStrength = 20;
        playerMagic = 10;
        playerCraftingSkill = 10;
        itemName = "Amulet of Strength";
        itemKind = "Strength";
        itemPower = 10;
        enemyName = "Goblin";
        enemyPower = 5;
    }

    [Fact]
    void PlayerToString()
    {
        string result = HeroQuest.PlayerToString(playerName, playerHealth,
            playerStrength, playerMagic, playerCraftingSkill);

        var expected = "Conan's Attributes:\nHealth: 100\nStrength: 20\nMagic: " +
                       "10\nCrafting " +
                       "Skill: 10\n";

        Assert.Equal(expected, result);
    }

    [Fact]
    void PlayerFallsDown()
    {
        playerStrength = 3;
        HeroQuest.PlayerFallsDown(playerStrength, ref playerHealth);
        Assert.Equal(90, playerHealth);
    }

    [Fact]
    void PlayerFallsDownNoDamage()
    {
        HeroQuest.PlayerFallsDown(playerStrength, ref playerHealth);
        Assert.Equal(100, playerHealth);
    }

    [Fact]
    void ItemToString()
    {
        var result = HeroQuest.ItemToString(itemName, itemKind, itemPower);
        var expected = "Item: Amulet of Strength\nKind: Strength\nPower: 10\n";
        Assert.Equal(expected, result);
    }

    [Fact]
    void ItemReduceByUsage()
    {
        HeroQuest.ItemReduceByUsage(ref itemKind, ref itemPower);
        Assert.Equal(5, itemPower);
    }

    [Fact]
    void ItemReduceByUsageToJunk()
    {
        itemPower = 1;
        HeroQuest.ItemReduceByUsage(ref itemKind, ref itemPower);
        Assert.Equal(0, itemPower);
        Assert.Equal("Junk", itemKind);
    }

    [Fact]
    void ItemApplyEffectToPlayer()
    {
        HeroQuest.ItemApplyEffectToPlayer(itemName, itemKind, itemPower,
                ref playerHealth, ref playerStrength, ref playerMagic);
        Assert.Equal(30, playerStrength);
    }

    [Fact]
    void ItemApplyEffectToPlayerJunk()
    {
        itemKind = "Junk";
        HeroQuest.ItemApplyEffectToPlayer(itemName, itemKind, itemPower,
                ref playerHealth, ref playerStrength, ref playerMagic);
        Assert.Equal(20, playerStrength);
    }

    [Fact]
    void ItemRepair()
    {
        HeroQuest.ItemRepair(playerCraftingSkill, ref itemPower);
        Assert.Equal(26, itemPower);
    }

    [Fact]
    void EnemyToString()
    {
        var result = HeroQuest.EnemyToString(enemyName, enemyPower);
        var expected = "Enemy: Goblin\nPower: 5\n";

        Assert.Equal(expected, result);
    }

    [Fact]
    void EnemyAttackPlayer()
    {
        HeroQuest.EnemyAttackPlayer(enemyName, enemyPower,
            playerStrength, ref playerHealth);

        Assert.Equal(98, playerHealth);
    }

    [Fact]
    void EnemyAttackPlayerNormalDamage()
    {
        enemyPower = 25;
        playerStrength = 5;

        HeroQuest.EnemyAttackPlayer(enemyName, enemyPower,
            playerStrength, ref playerHealth);

        Assert.Equal(75, playerHealth);
    }

    [Fact]
    void EnemyAttackPlayerReducedDamage()
    {
        playerStrength = 15;

        HeroQuest.EnemyAttackPlayer(enemyName, enemyPower,
            playerStrength, ref playerHealth);

        Assert.Equal(98, playerHealth);
    }

    [Fact]
    void PlayerChallengeEnemy()
    {
        HeroQuest.PlayerChallengeEnemy(enemyName, playerStrength,
            itemPower, ref enemyPower);

        Assert.Equal(-7, enemyPower);
    }

    [Fact]
    void PlayerChallengeEnemyWins()
    {
        playerStrength = 25;

        HeroQuest.PlayerChallengeEnemy(enemyName, playerStrength,
            itemPower, ref enemyPower);

        Assert.Equal(-10, enemyPower);
    }

    [Fact]
    void PlayerChallengeEnemyRetreats()
    {
        enemyPower = 50;
        playerStrength = 10;
        itemPower = 5;

        HeroQuest.PlayerChallengeEnemy(enemyName, playerStrength,
            itemPower, ref enemyPower);

        Assert.Equal(50, enemyPower);
    }

    [Fact]
    void PlayerChallengeEnemyNoItem()
    {
        enemyPower = 20;
        playerStrength = 22;
        itemPower = 0;

        HeroQuest.PlayerChallengeEnemy(enemyName, playerStrength,
            itemPower, ref enemyPower);

        Assert.Equal(9, enemyPower);
    }

    [Fact]
    void ItemApplyEffectToPlayerMagic()
    {
        itemKind = "Magic";
        itemPower = 15;

        HeroQuest.ItemApplyEffectToPlayer(itemName, itemKind, itemPower,
                ref playerHealth, ref playerStrength, ref playerMagic);

        Assert.Equal(25, playerMagic);
    }

    [Fact]
    void ItemApplyEffectToPlayerHealth()
    {
        itemKind = "Health";
        itemPower = 20;

        HeroQuest.ItemApplyEffectToPlayer(itemName, itemKind, itemPower,
                ref playerHealth, ref playerStrength, ref playerMagic);

        Assert.Equal(120, playerHealth);
    }
}