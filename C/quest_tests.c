#include <setjmp.h>
#include <stdarg.h>
#include <stddef.h>

#include "quest.h"
#include <cmocka.h>

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

static void test_playerToString(void** state)
{
    (void)state;

    char result[256];
    playerToString(result, testPlayerName, testPlayerHealth, testPlayerStrength,
                   testPlayerMagic, testPlayerCraftingSkill);

    const char* expected =
        "Conan's Attributes:\nHealth: 100\nStrength: 20\nMagic: 10\nCrafting "
        "Skill: 12\n";
    assert_string_equal(result, expected);
}

static void test_playerFallsDown(void** state)
{
    (void)state;

    int playerStrength = 3;
    int playerHealth = 100;
    playerFallsDown(&playerHealth, &playerStrength);

    assert_int_equal(playerHealth, 90);
}

static void test_playerFallsDownNoDamage(void** state)
{
    (void)state;

    int playerStrength = 7;
    int playerHealth = 100;
    playerFallsDown(&playerHealth, &playerStrength);

    assert_int_equal(playerHealth, 100);
}

static void test_itemToString(void** state)
{
    (void)state;

    char result[256];
    itemToString(result, testItemName, testItemKind, testItemPower);

    const char* expected = "Item: Healing Potion\nKind: Health\nPower: 20\n";
    assert_string_equal(result, expected);
}

static void test_itemReduceByUsage(void** state)
{
    (void)state;

    char itemKind[16] = "Health";
    int itemPower = 20;
    itemReduceByUsage(itemKind, &itemPower);

    assert_int_equal(itemPower, 10);
    assert_string_equal(itemKind, "Health");
}

static void test_itemReduceByUsageToJunk(void** state)
{
    (void)state;

    char itemKind[16] = "Health";
    int itemPower = 1;
    itemReduceByUsage(itemKind, &itemPower);

    assert_int_equal(itemPower, 0);
    assert_string_equal(itemKind, "Junk");
}

static void test_itemApplyEffectToPlayer(void** state)
{
    (void)state;

    int playerHealth = 100;
    int playerStrength = 7;
    int playerMagic = 15;
    itemApplyEffectToPlayer(testItemName, testItemKind, testItemPower,
                            &playerHealth, &playerStrength, &playerMagic);

    assert_int_equal(playerHealth, 120);
}

static void test_itemApplyEffectToPlayerJunk(void** state)
{
    (void)state;

    int playerHealth = 100;
    int playerStrength = 7;
    int playerMagic = 15;
    itemApplyEffectToPlayer(testItemName, "Junk", testItemPower, &playerHealth,
                            &playerStrength, &playerMagic);

    assert_int_equal(playerHealth, 100);
    assert_int_equal(playerStrength, 7);
}

static void test_itemRepair(void** state)
{
    (void)state;

    int itemPower = 20;
    itemRepair(&itemPower, testPlayerCraftingSkill);

    assert_int_equal(itemPower, 40);
}

static void test_enemyToString(void** state)
{
    (void)state;

    char result[256];
    enemyToString(result, testEnemyName, testEnemyPower);

    const char* expected = "Enemy: Goblin\nPower: 5\n";
    assert_string_equal(result, expected);
}

static void test_enemyAttackPlayer(void** state)
{
    (void)state;

    int playerHealth = 100;
    int playerStrength = 20;
    enemyAttackPlayer(testEnemyName, testEnemyPower, playerStrength, &playerHealth);

    assert_int_equal(playerHealth, 98);
}

static void test_playerChallengeEnemy(void** state)
{
    (void)state;

    int playerStrength = 20;
    int itemPower = 10;
    int enemyPower = 5;
    playerChallengeEnemy(testEnemyName, playerStrength, itemPower, &enemyPower);

    assert_int_equal(enemyPower, -7);
}

int main(void)
{
    const struct CMUnitTest tests[] = {
        cmocka_unit_test(test_playerToString),
        cmocka_unit_test(test_playerFallsDownNoDamage),
        cmocka_unit_test(test_playerFallsDown),
        cmocka_unit_test(test_itemToString),
        cmocka_unit_test(test_itemReduceByUsage),
        cmocka_unit_test(test_itemReduceByUsageToJunk),
        cmocka_unit_test(test_itemApplyEffectToPlayer),
        cmocka_unit_test(test_itemApplyEffectToPlayerJunk),
        cmocka_unit_test(test_itemRepair),
        cmocka_unit_test(test_enemyToString),
        cmocka_unit_test(test_enemyAttackPlayer),
        cmocka_unit_test(test_playerChallengeEnemy),
    };

    return cmocka_run_group_tests(tests, NULL, NULL);
}
