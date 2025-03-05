<?php

require_once __DIR__ . '/../vendor/autoload.php';

use CodingDojo\HeroQuest;

$playerName = "Conan";
$playerHealth = 100;
$playerStrength = 20;
$playerMagic = 10;
$playerCraftingSkill = 10;
$itemName = "Amulet of Strength";
$itemKind = "Strength";
$itemPower = 10;

$result = HeroQuest::playerToString($playerName, $playerHealth, $playerStrength, $playerMagic, $playerCraftingSkill);
printf("Player at begin\n%s\n", $result);

$result = HeroQuest::itemToString($itemName, $itemKind, $itemPower);
printf("Player found an item\n%s\n", $result);

HeroQuest::itemApplyEffectToPlayer($itemName, $itemKind, $itemPower, $playerHealth, $playerStrength, $playerMagic);
HeroQuest::itemReduceByUsage($itemKind, $itemPower);

$result = HeroQuest::playerToString($playerName, $playerHealth, $playerStrength, $playerMagic, $playerCraftingSkill);
printf("Player now\n%s\n", $result);

$result = HeroQuest::itemToString($itemName, $itemKind, $itemPower);
printf("Item now\n%s\n", $result);

printf("Player tries to repair item...\n");
HeroQuest::itemRepair($playerCraftingSkill, $itemPower);
$result = HeroQuest::itemToString($itemName, $itemKind, $itemPower);
printf("Item now\n%s\n", $result);
