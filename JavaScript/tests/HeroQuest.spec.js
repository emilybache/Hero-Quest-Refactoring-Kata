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
            itemPower: 10
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
        HeroQuest.playerFallsDown(questData);
        expect(questData.playerHealth).toBe(90);
    });

    it("playerFallsDownNoDamage", () => {
        HeroQuest.playerFallsDown(questData);
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
        HeroQuest.itemReduceByUsage(questData);
        expect(questData.itemPower).toBe(5);
    });

    it("itemReduceByUsageToJunk", () => {
        questData.itemPower = 1;
        HeroQuest.itemReduceByUsage(questData);
        expect(questData.itemPower).toBe(0);
        expect(questData.itemKind).toBe("Junk");
    });

    it("itemApplyEffectToPlayer", () => {
        HeroQuest.itemApplyEffectToPlayer(questData);
        expect(questData.playerStrength).toBe(30);
    });

    it("itemApplyEffectToPlayerJunk", () => {
        questData.itemKind = "Junk";
        HeroQuest.itemApplyEffectToPlayer(questData);
        expect(questData.playerStrength).toBe(20);
    });

    it("itemRepair", () => {
        HeroQuest.itemRepair(questData);
        expect(questData.itemPower).toBe(26);
    });

});
