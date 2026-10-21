<?php

require_once __DIR__ . '/../vendor/autoload.php';

use CodingDojo\HeroQuest;

function run() {
    $playerName = "Conan";
    $playerHealth = 100;
    $playerStrength = 7;
    $playerMagic = 15;
    $playerCraftingSkill = 12;
    $itemName = "Healing Potion";
    $itemKind = "Health";
    $itemPower = 20;
    $enemyName = "Goblin Warlord";
    $enemyPower = 12;

    HeroQuest::$output[] = "=== QUEST BEGINNING ===\n\n";

    HeroQuest::$output[] = HeroQuest::playerToString($playerName, $playerHealth, $playerStrength, $playerMagic, $playerCraftingSkill);
    HeroQuest::$output[] = "\n";

    HeroQuest::$output[] = HeroQuest::itemToString($itemName, $itemKind, $itemPower);
    HeroQuest::$output[] = "\n";

    HeroQuest::$output[] = "--- Exploring the dungeon... ---\n\n";

    HeroQuest::playerFallsDown($playerHealth, $playerStrength);
    HeroQuest::$output[] = HeroQuest::playerToString($playerName, $playerHealth, $playerStrength, $playerMagic, $playerCraftingSkill);
    HeroQuest::$output[] = "\n";

    HeroQuest::$output[] = "--- Using the healing item ---\n\n";

    HeroQuest::itemApplyEffectToPlayer($itemName, $itemKind, $itemPower, $playerHealth, $playerStrength, $playerMagic);
    HeroQuest::$output[] = HeroQuest::playerToString($playerName, $playerHealth, $playerStrength, $playerMagic, $playerCraftingSkill);
    HeroQuest::$output[] = "\n";

    HeroQuest::$output[] = HeroQuest::itemToString($itemName, $itemKind, $itemPower);
    HeroQuest::$output[] = "\n";

    HeroQuest::$output[] = "--- Item degradation from repeated use ---\n\n";

    HeroQuest::itemReduceByUsage($itemKind, $itemPower);
    HeroQuest::$output[] = HeroQuest::itemToString($itemName, $itemKind, $itemPower);
    HeroQuest::$output[] = "\n";

    HeroQuest::itemReduceByUsage($itemKind, $itemPower);
    HeroQuest::$output[] = HeroQuest::itemToString($itemName, $itemKind, $itemPower);
    HeroQuest::$output[] = "\n";

    HeroQuest::$output[] = "--- Repairing the damaged item ---\n\n";

    HeroQuest::itemRepair($playerCraftingSkill, $itemPower);
    HeroQuest::$output[] = HeroQuest::itemToString($itemName, $itemKind, $itemPower);
    HeroQuest::$output[] = "\n";

    HeroQuest::$output[] = "=== ENEMY ENCOUNTER ===\n\n";

    HeroQuest::$output[] = HeroQuest::enemyToString($enemyName, $enemyPower);
    HeroQuest::$output[] = "\n";

    HeroQuest::enemyAttackPlayer($enemyName, $enemyPower, $playerStrength, $playerHealth);
    HeroQuest::$output[] = HeroQuest::playerToString($playerName, $playerHealth, $playerStrength, $playerMagic, $playerCraftingSkill);
    HeroQuest::$output[] = "\n";

    HeroQuest::$output[] = "--- Player retaliates ---\n\n";

    HeroQuest::playerChallengeEnemy($enemyName, $playerStrength, $itemPower, $enemyPower);
    HeroQuest::$output[] = HeroQuest::enemyToString($enemyName, $enemyPower);
    HeroQuest::$output[] = "\n";
}

if (php_sapi_name() === 'cli' && basename(__FILE__) === basename($argv[0] ?? '')) {
    HeroQuest::$output = [];
    run();
    echo implode("", HeroQuest::$output);
}
