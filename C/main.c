#include <stdio.h>
#include <time.h>

#include "quest.h"

int main(void)
{
    char result[256];
    playerToString(result, playerName, playerHealth, playerStrength,
                   playerMagic, playerCraftingSkill);
    printf("Player at begin\n%s\n", result);

    itemToString(result, amuletItemName, amuletItemKind, amuletItemPower);
    printf("Player found an item\n%s\n", result);

    itemApplyEffectToPlayer(amuletItemName, amuletItemKind, amuletItemPower,
                            &playerHealth, &playerStrength, &playerMagic);
    itemReduceByUsage(amuletItemKind, &amuletItemPower);

    playerToString(result, playerName, playerHealth, playerStrength,
                   playerMagic, playerCraftingSkill);
    printf("Player now\n%s\n", result);

    itemToString(result, amuletItemName, amuletItemKind, amuletItemPower);
    printf("Item now\n%s\n", result);

    printf("Player tries to repair item...\n");
    itemRepair(&amuletItemPower, playerCraftingSkill);
    itemToString(result, amuletItemName, amuletItemKind, amuletItemPower);
    printf("Item now\n%s\n", result);

    return 0;
}
