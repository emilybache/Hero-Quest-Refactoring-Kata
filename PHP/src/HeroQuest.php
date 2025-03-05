<?php

namespace CodingDojo;

class HeroQuest {

    public static function playerToString($playerName, $playerHealth, $playerStrength, $playerMagic, $playerCraftingSkill) {
        return sprintf("%s's Attributes:\nHealth: %d\nStrength: %d\nMagic: %d\nCrafting Skill: %d\n",
            $playerName, $playerHealth, $playerStrength, $playerMagic, $playerCraftingSkill);
    }

    public static function playerFallsDown(&$playerHealth, $playerStrength) {
        echo "Player drops off a cliff.\n";

        if ($playerStrength < 5) {
            $playerHealth -= 10;
            echo "Player's strength is too small. Health decreases by 10.\n";
        }
    }

    public static function itemToString($itemName, $itemKind, $itemPower) {
        return sprintf("Item: %s\nKind: %s\nPower: %d\n", $itemName, $itemKind, $itemPower);
    }

    public static function itemReduceByUsage(&$itemKind, &$itemPower) {
        echo sprintf("Using the item with kind '%s' and power %d\n", $itemKind, $itemPower);

        $itemPower = intdiv($itemPower, 2);

        if ($itemPower == 0) {
            $itemKind = "Junk";
        }
    }

    public static function itemApplyEffectToPlayer($itemName, $itemKind, $itemPower, &$playerHealth, &$playerStrength, &$playerMagic) {
        echo sprintf("Applying the effect of %s (%s):\n", $itemName, $itemKind);

        if ($itemKind === "Health") {
            $playerHealth += $itemPower;
        } elseif ($itemKind === "Strength") {
            $playerStrength += $itemPower;
        } elseif ($itemKind === "Magic") {
            $playerMagic += $itemPower;
        } else {
            // ignore unknown item kind
        }
    }

    public static function itemRepair($playerCraftingSkill, &$itemPower) {
        echo "Using the repair skill to fix the item:\n";

        $repairAmount = -5 + (($playerCraftingSkill * 2) + 1);
        $itemPower += $repairAmount;

        echo sprintf("Repaired the item by %d points. Item's Durability: %d\n", $repairAmount, $itemPower);
    }
}
