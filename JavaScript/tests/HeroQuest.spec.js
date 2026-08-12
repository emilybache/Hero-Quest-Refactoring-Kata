const { HeroQuest } = require('../src/HeroQuest');

describe('HeroQuest', () => {

    let questData;

    beforeEach(() => {
        questData = {
            playerName: "Conan",
            playerHealth: 100,
            playerStrength: 20,
            playerMagic: 10,
            playerCraftingSkill: 10,
            itemName: "Amulet of Strength",
            itemKind: "Strength",
            itemPower: 10,
            enemyName: "Goblin",
            enemyPower: 10
        };
    });

    it("playerToString", () => {
        const result = HeroQuest.playerToString(
            questData.playerName,
            questData.playerHealth,
            questData.playerStrength,
            questData.playerMagic,
            questData.playerCraftingSkill
        );

        const expected = "Conan's Attributes:\nHealth: 100\nStrength: 20\nMagic: 10\nCrafting Skill: 10\n";
        expect(result).toBe(expected);
    });

    it("playerFallsDown", () => {
        questData.playerStrength = 3;
        questData.playerHealth = HeroQuest.playerFallsDown(questData.playerStrength, questData.playerHealth);
        expect(questData.playerHealth).toBe(90);
    });

    it("playerFallsDownNoDamage", () => {
        questData.playerHealth = HeroQuest.playerFallsDown(questData.playerStrength, questData.playerHealth);
        expect(questData.playerHealth).toBe(100);
    });

    it("itemToString", () => {
        const result = HeroQuest.itemToString(
            questData.itemName,
            questData.itemKind,
            questData.itemPower
        );
        const expected = "Item: Amulet of Strength\nKind: Strength\nPower: 10\n";
        expect(result).toBe(expected);
    });

    it("itemReduceByUsage", () => {
        ({ itemKind: questData.itemKind, itemPower: questData.itemPower } =
            HeroQuest.itemReduceByUsage(questData.itemKind, questData.itemPower));
        expect(questData.itemPower).toBe(5);
    });

    it("itemReduceByUsageToJunk", () => {
        questData.itemPower = 1;
        ({ itemKind: questData.itemKind, itemPower: questData.itemPower } =
            HeroQuest.itemReduceByUsage(questData.itemKind, questData.itemPower));
        expect(questData.itemPower).toBe(0);
        expect(questData.itemKind).toBe("Junk");
    });

    it("itemApplyEffectToPlayer", () => {
        ({ playerHealth: questData.playerHealth, playerStrength: questData.playerStrength, playerMagic: questData.playerMagic } =
            HeroQuest.itemApplyEffectToPlayer(questData.itemName, questData.itemKind, questData.itemPower,
                questData.playerHealth, questData.playerStrength, questData.playerMagic));
        expect(questData.playerStrength).toBe(30);
    });

    it("itemApplyEffectToPlayerJunk", () => {
        questData.itemKind = "Junk";
        ({ playerHealth: questData.playerHealth, playerStrength: questData.playerStrength, playerMagic: questData.playerMagic } =
            HeroQuest.itemApplyEffectToPlayer(questData.itemName, questData.itemKind, questData.itemPower,
                questData.playerHealth, questData.playerStrength, questData.playerMagic));
        expect(questData.playerStrength).toBe(20);
    });

    it("itemRepair", () => {
        questData.itemPower = HeroQuest.itemRepair(questData.playerCraftingSkill, questData.itemPower);
        expect(questData.itemPower).toBe(26);
    });

    it("enemyToString", () => {
        const result = HeroQuest.enemyToString(questData.enemyName, questData.enemyPower);
        const expected = "Enemy: Goblin\nPower: 10\n";
        expect(result).toBe(expected);
    });

    it("enemyAttackPlayerNormalDamage", () => {
        questData.enemyPower = 25;
        questData.playerStrength = 5;
        questData.playerHealth = HeroQuest.enemyAttackPlayer(questData.enemyName, questData.enemyPower,
            questData.playerStrength, questData.playerHealth);
        expect(questData.playerHealth).toBe(75);
    });

    it("enemyAttackPlayerReducedDamage", () => {
        questData.playerStrength = 15;
        questData.playerHealth = HeroQuest.enemyAttackPlayer(questData.enemyName, questData.enemyPower,
            questData.playerStrength, questData.playerHealth);
        expect(questData.playerHealth).toBe(95);
    });

    it("playerChallengeEnemyWins", () => {
        questData.playerStrength = 25;
        questData.enemyPower = HeroQuest.playerChallengeEnemy(questData.enemyName, questData.playerStrength,
            questData.itemPower, questData.enemyPower);
        expect(questData.enemyPower).toBe(-5);
    });

    it("playerChallengeEnemyRetreats", () => {
        questData.enemyPower = 50;
        questData.playerStrength = 10;
        questData.itemPower = 5;
        questData.enemyPower = HeroQuest.playerChallengeEnemy(questData.enemyName, questData.playerStrength,
            questData.itemPower, questData.enemyPower);
        expect(questData.enemyPower).toBe(50);
    });

    it("playerChallengeEnemyNoItem", () => {
        questData.enemyPower = 20;
        questData.playerStrength = 22;
        questData.itemPower = 0;
        questData.enemyPower = HeroQuest.playerChallengeEnemy(questData.enemyName, questData.playerStrength,
            questData.itemPower, questData.enemyPower);
        expect(questData.enemyPower).toBe(9);
    });

    it("itemApplyEffectToPlayerMagic", () => {
        questData.itemKind = "Magic";
        questData.itemPower = 15;
        ({ playerHealth: questData.playerHealth, playerStrength: questData.playerStrength, playerMagic: questData.playerMagic } =
            HeroQuest.itemApplyEffectToPlayer(questData.itemName, questData.itemKind, questData.itemPower,
                questData.playerHealth, questData.playerStrength, questData.playerMagic));
        expect(questData.playerMagic).toBe(25);
    });

    it("itemApplyEffectToPlayerHealth", () => {
        questData.itemKind = "Health";
        questData.itemPower = 20;
        ({ playerHealth: questData.playerHealth, playerStrength: questData.playerStrength, playerMagic: questData.playerMagic } =
            HeroQuest.itemApplyEffectToPlayer(questData.itemName, questData.itemKind, questData.itemPower,
                questData.playerHealth, questData.playerStrength, questData.playerMagic));
        expect(questData.playerHealth).toBe(120);
    });

});
