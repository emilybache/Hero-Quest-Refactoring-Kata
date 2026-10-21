<?php

namespace CodingDojo;

class HeroQuest {

    public static $output = [];

    public static function playerToString($playerName, $playerHealth, $playerStrength, $playerMagic, $playerCraftingSkill) {
        return sprintf("%s's Attributes:\nHealth: %d\nStrength: %d\nMagic: %d\nCrafting Skill: %d\n",
            $playerName, $playerHealth, $playerStrength, $playerMagic, $playerCraftingSkill);
    }

    public static function playerFallsDown(&$playerHealth, $playerStrength) {
        self::$output[] = "Player drops off a cliff.\n";

        if ($playerStrength < 5) {
            $playerHealth -= 10;
            self::$output[] = "Player's strength is too small. Health decreases by 10.\n";
        }
    }

    public static function itemToString($itemName, $itemKind, $itemPower) {
        return sprintf("Item: %s\nKind: %s\nPower: %d\n", $itemName, $itemKind, $itemPower);
    }

    public static function itemReduceByUsage(&$itemKind, &$itemPower) {
        self::$output[] = sprintf("Using the item with kind '%s' and power %d\n", $itemKind, $itemPower);

        $itemPower = intdiv($itemPower, 2);

        if ($itemPower == 0) {
            $itemKind = "Junk";
        }
    }

    public static function itemApplyEffectToPlayer($itemName, $itemKind, $itemPower, &$playerHealth, &$playerStrength, &$playerMagic) {
        self::$output[] = sprintf("Applying the effect of %s (%s):\n", $itemName, $itemKind);

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
        self::$output[] = "Using the repair skill to fix the item:\n";

        $repairAmount = -5 + (($playerCraftingSkill * 2) + 1);
        $itemPower += $repairAmount;

        self::$output[] = sprintf("Repaired the item by %d points. Item's Durability: %d\n", $repairAmount, $itemPower);
    }

    public static function enemyToString($enemyName, $enemyPower) {
        return sprintf("Enemy: %s\nPower: %d\n", $enemyName, $enemyPower);
    }

    public static function enemyAttackPlayer($enemyName, $enemyPower, $playerStrength, &$playerHealth) {
        self::$output[] = sprintf("The enemy '%s' attacks!\n", $enemyName);
        $damage = $enemyPower;

        if ($playerStrength > $enemyPower) {
            $damage = intdiv($damage, 2);
            self::$output[] = "Player's strength allows them to reduce the damage!\n";
        }

        $playerHealth = $playerHealth - $damage;
        self::$output[] = sprintf("Player takes %d damage. Health is now: %d\n", $damage, $playerHealth);
    }

    public static function playerChallengeEnemy($enemyName, $playerStrength, $itemPower, &$enemyPower) {
        self::$output[] = sprintf("The player challenges %s!\n", $enemyName);
        $playerAttackPower = $playerStrength + ($itemPower > 0 ? intdiv($itemPower, 2) : 0);

        if ($playerAttackPower > $enemyPower) {
            $enemyPower = $enemyPower - intdiv($playerAttackPower, 2);
            self::$output[] = sprintf("The player defeats the enemy! Enemy power reduced to %d\n", $enemyPower);
        } else {
            self::$output[] = "The enemy is too strong. The player retreats!\n";
        }
    }
}
