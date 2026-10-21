#define CATCH_CONFIG_MAIN
#include <catch2/catch.hpp>
#include <string>

#include "quest.h"

const char* testPlayerName = "Conan";
int testPlayerHealth = 100;
int testPlayerStrength = 20;
int testPlayerMagic = 10;
int testPlayerCraftingSkill = 12;

const char* testItemName = "Healing Potion";
const char* testItemKind = "Health";
int testItemPower = 20;

const char* testEnemyName = "Goblin";
int testEnemyPower = 5;

TEST_CASE("Quest")
{
    SECTION("playerToString")
    {
        char result[256];
        playerToString(result, testPlayerName, testPlayerHealth, testPlayerStrength,
                       testPlayerMagic, testPlayerCraftingSkill);

        const char* expected =
            "Conan's Attributes:\nHealth: 100\nStrength: 20\nMagic: "
            "10\nCrafting "
            "Skill: 12\n";
        std::string expectedStr = expected;
        std::string actualStr = result;
        REQUIRE(expectedStr == actualStr);
    }

    SECTION("playerFallsDownNoDamage")
    {
        playerFallsDown(&testPlayerHealth, &testPlayerStrength);

        REQUIRE(testPlayerHealth == 100);
    }

    SECTION("playerFallsDown")
    {
        int playerStrength = 3;
        int playerHealth = 100;
        playerFallsDown(&playerHealth, &playerStrength);

        REQUIRE(playerHealth == 90);
    }

    SECTION("itemToString")
    {
        char result[256];
        itemToString(result, testItemName, testItemKind, testItemPower);

        const char* expected =
            "Item: Healing Potion\nKind: Health\nPower: 20\n";
        std::string expectedStr = expected;
        std::string actualStr = result;
        REQUIRE(expectedStr == actualStr);
    }

    SECTION("itemReduceByUsage")
    {
        char itemKind[] = "Health";
        int itemPower = 20;
        itemReduceByUsage(itemKind, &itemPower);

        REQUIRE(itemPower == 10);
        std::string expectedStr = itemKind;
        std::string actualStr = "Health";
        REQUIRE(expectedStr == actualStr);
    }

    SECTION("itemReduceByUsageToJunk")
    {
        char itemKind[16] = "Health";
        int itemPower = 1;
        itemReduceByUsage(itemKind, &itemPower);

        REQUIRE(itemPower == 0);
        std::string expectedStr = itemKind;
        std::string actualStr = "Junk";
        REQUIRE(expectedStr == actualStr);
    }

    SECTION("itemApplyEffectToPlayer")
    {
        int playerHealth = 100;
        int playerStrength = 7;
        int playerMagic = 15;
        itemApplyEffectToPlayer(testItemName, testItemKind, testItemPower, &playerHealth,
                                &playerStrength, &playerMagic);

        REQUIRE(playerHealth == 120);
    }

    SECTION("itemApplyEffectToPlayerJunk")
    {
        int playerHealth = 100;
        int playerStrength = 7;
        int playerMagic = 15;
        itemApplyEffectToPlayer(testItemName, "Junk", testItemPower, &playerHealth,
                                &playerStrength, &playerMagic);

        REQUIRE(playerHealth == 100);
        REQUIRE(playerStrength == 7);
    }

    SECTION("itemRepair")
    {
        int itemPower = 20;
        itemRepair(&itemPower, testPlayerCraftingSkill);

        REQUIRE(itemPower == 40);
    }

    SECTION("enemyToString")
    {
        char result[256];
        enemyToString(result, testEnemyName, testEnemyPower);

        const char* expected = "Enemy: Goblin\nPower: 5\n";
        std::string expectedStr = expected;
        std::string actualStr = result;
        REQUIRE(expectedStr == actualStr);
    }

    SECTION("enemyAttackPlayer")
    {
        int playerHealth = 100;
        int playerStrength = 20;
        enemyAttackPlayer(testEnemyName, testEnemyPower, playerStrength, &playerHealth);

        REQUIRE(playerHealth == 98);
    }

    SECTION("playerChallengeEnemy")
    {
        int playerStrength = 20;
        int itemPower = 10;
        int enemyPower = 5;
        playerChallengeEnemy(testEnemyName, playerStrength, itemPower, &enemyPower);

        REQUIRE(enemyPower == -7);
    }
}
