#include <setjmp.h>
#include <stdarg.h>
#include <stddef.h>

#include "quest.h"
#include <cmocka.h>

const char* testPlayerName = "Conan";
int testPlayerHealth = 100;
int testPlayerStrength = 20;
int testPlayerMagic = 10;
int testPlayerCraftingSkill = 10;

const char* testItemName = "Amulet of Strength";
char* testItemKind = "Strength";
int testItemPower = 10;

static void test_playerToString(void** state)
{
    (void)state;

    char result[256];
    playerToString(result, testPlayerName, testPlayerHealth, testPlayerStrength,
                   testPlayerMagic, testPlayerCraftingSkill);

    const char* expected =
        "Conan's Attributes:\nHealth: 100\nStrength: 20\nMagic: 10\nCrafting "
        "Skill: 10\n";
    assert_string_equal(result, expected);
}

static void test_playerFallsDown(void** state)
{
    (void)state;

    testPlayerStrength = 3;
    playerFallsDown(&testPlayerHealth, &testPlayerStrength);

    assert_int_equal(testPlayerHealth, 90);
    testPlayerStrength = 20; // reset
    testPlayerHealth = 100;  // reset
}

static void test_playerFallsDownNoDamage(void** state)
{
    (void)state;

    playerFallsDown(&testPlayerHealth, &testPlayerStrength);

    assert_int_equal(testPlayerHealth, 100);
}

static void test_itemToString(void** state)
{
    (void)state;

    char result[256];
    itemToString(result, testItemName, testItemKind, testItemPower);

    const char* expected =
        "Item: Amulet of Strength\nKind: Strength\nPower: 10\n";
    assert_string_equal(result, expected);
}

static void test_itemReduceByUsage(void** state)
{
    (void)state;

    itemReduceByUsage(testItemKind, &testItemPower);

    assert_int_equal(testItemPower, 5);
    assert_string_equal(testItemKind, "Strength");
    testItemPower = 10; // reset
}

static void test_itemReduceByUsageToJunk(void** state)
{
    (void)state;

    testItemPower = 1;
    char itemKind[10] = "Strength";
    itemReduceByUsage(itemKind, &testItemPower);

    assert_int_equal(testItemPower, 0);
    assert_string_equal(itemKind, "Junk");
    testItemPower = 10; // reset
}

static void test_itemApplyEffectToPlayer(void** state)
{
    (void)state;

    itemApplyEffectToPlayer(testItemName, testItemKind, testItemPower,
                            &testPlayerHealth, &testPlayerStrength, &testPlayerMagic);

    assert_int_equal(testPlayerStrength, 30);
    testPlayerStrength = 20; // reset
}

static void test_itemApplyEffectToPlayerJunk(void** state)
{
    (void)state;

    itemApplyEffectToPlayer(testItemName, "Junk", testItemPower, &testPlayerHealth,
                            &testPlayerStrength, &testPlayerMagic);

    assert_int_equal(testPlayerStrength, 20);
}

static void test_itemRepair(void** state)
{
    (void)state;

    itemRepair(&testItemPower, testPlayerCraftingSkill);

    assert_int_equal(testItemPower, 26);
    testItemPower = 10; // reset
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
    };

    return cmocka_run_group_tests(tests, NULL, NULL);
}
