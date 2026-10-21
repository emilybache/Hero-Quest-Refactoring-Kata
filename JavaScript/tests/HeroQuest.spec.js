const { HeroQuest, output } = require('../src/HeroQuest');

describe('HeroQuest', () => {

    let playerName;
    let playerHealth;
    let playerStrength;
    let playerMagic;
    let playerCraftingSkill;
    let itemName;
    let itemKind;
    let itemPower;
    let enemyName;
    let enemyPower;

    beforeEach(() => {
        output.splice(0, output.length);
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
    });

    it("playerToString", () => {
        const result = HeroQuest.playerToString(
            playerName,
            playerHealth,
            playerStrength,
            playerMagic,
            playerCraftingSkill
        );

        const expected = "Conan's Attributes:\nHealth: 100\nStrength: 20\nMagic: 10\nCrafting Skill: 10\n";
        expect(result).toBe(expected);
    });

    it("playerFallsDown", () => {
        playerStrength = 3;
        playerHealth = HeroQuest.playerFallsDown(playerStrength, playerHealth);
        expect(playerHealth).toBe(90);
    });

    it("playerFallsDownNoDamage", () => {
        playerHealth = HeroQuest.playerFallsDown(playerStrength, playerHealth);
        expect(playerHealth).toBe(100);
    });

    it("itemToString", () => {
        const result = HeroQuest.itemToString(itemName, itemKind, itemPower);
        const expected = "Item: Amulet of Strength\nKind: Strength\nPower: 10\n";
        expect(result).toBe(expected);
    });

    it("itemReduceByUsage", () => {
        let result = HeroQuest.itemReduceByUsage(itemKind, itemPower);
        itemPower = result.itemPower;
        expect(itemPower).toBe(5);
    });

    it("itemReduceByUsageToJunk", () => {
        itemPower = 1;
        let result = HeroQuest.itemReduceByUsage(itemKind, itemPower);
        itemKind = result.itemKind;
        itemPower = result.itemPower;
        expect(itemPower).toBe(0);
        expect(itemKind).toBe("Junk");
    });

    it("itemApplyEffectToPlayer", () => {
        let result = HeroQuest.itemApplyEffectToPlayer(itemName, itemKind, itemPower,
            playerHealth, playerStrength, playerMagic);
        playerStrength = result.playerStrength;
        expect(playerStrength).toBe(30);
    });

    it("itemApplyEffectToPlayerJunk", () => {
        itemKind = "Junk";
        let result = HeroQuest.itemApplyEffectToPlayer(itemName, itemKind, itemPower,
            playerHealth, playerStrength, playerMagic);
        playerStrength = result.playerStrength;
        expect(playerStrength).toBe(20);
    });

    it("itemRepair", () => {
        itemPower = HeroQuest.itemRepair(playerCraftingSkill, itemPower);
        expect(itemPower).toBe(26);
    });

    it("enemyToString", () => {
        const result = HeroQuest.enemyToString(enemyName, enemyPower);
        const expected = "Enemy: Goblin\nPower: 5\n";
        expect(result).toBe(expected);
    });

    it("enemyAttackPlayerNormalDamage", () => {
        enemyPower = 25;
        playerStrength = 5;
        playerHealth = HeroQuest.enemyAttackPlayer(enemyName, enemyPower,
            playerStrength, playerHealth);
        expect(playerHealth).toBe(75);
    });

    it("enemyAttackPlayer", () => {
        playerHealth = HeroQuest.enemyAttackPlayer(enemyName, enemyPower,
            playerStrength, playerHealth);
        expect(playerHealth).toBe(98);
    });

    it("playerChallengeEnemy", () => {
        enemyPower = HeroQuest.playerChallengeEnemy(enemyName, playerStrength,
            itemPower, enemyPower);
        expect(enemyPower).toBe(-7);
    });

    it("playerChallengeEnemyRetreats", () => {
        enemyPower = 50;
        playerStrength = 10;
        itemPower = 5;
        enemyPower = HeroQuest.playerChallengeEnemy(enemyName, playerStrength,
            itemPower, enemyPower);
        expect(enemyPower).toBe(50);
    });

    it("playerChallengeEnemyNoItem", () => {
        enemyPower = 20;
        playerStrength = 22;
        itemPower = 0;
        enemyPower = HeroQuest.playerChallengeEnemy(enemyName, playerStrength,
            itemPower, enemyPower);
        expect(enemyPower).toBe(9);
    });

    it("itemApplyEffectToPlayerMagic", () => {
        itemKind = "Magic";
        itemPower = 15;
        let result = HeroQuest.itemApplyEffectToPlayer(itemName, itemKind, itemPower,
            playerHealth, playerStrength, playerMagic);
        playerMagic = result.playerMagic;
        expect(playerMagic).toBe(25);
    });

    it("itemApplyEffectToPlayerHealth", () => {
        itemKind = "Health";
        itemPower = 20;
        let result = HeroQuest.itemApplyEffectToPlayer(itemName, itemKind, itemPower,
            playerHealth, playerStrength, playerMagic);
        playerHealth = result.playerHealth;
        expect(playerHealth).toBe(120);
    });

});
