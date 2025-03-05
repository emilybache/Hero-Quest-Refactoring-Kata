<?php

namespace Tests;

use PHPUnit\Framework\TestCase;
use CodingDojo\HeroQuest;

class HeroQuestTest extends TestCase {

    private $playerName;
    private $playerHealth;
    private $playerStrength;
    private $playerMagic;
    private $playerCraftingSkill;
    private $itemName;
    private $itemKind;
    private $itemPower;

    protected function setUp(): void {
        $this->playerName = "Conan";
        $this->playerHealth = 100;
        $this->playerStrength = 20;
        $this->playerMagic = 10;
        $this->playerCraftingSkill = 10;
        $this->itemName = "Amulet of Strength";
        $this->itemKind = "Strength";
        $this->itemPower = 10;
    }

    public function testPlayerToString() {
        $result = HeroQuest::playerToString(
            $this->playerName,
            $this->playerHealth,
            $this->playerStrength,
            $this->playerMagic,
            $this->playerCraftingSkill
        );

        $expected = "Conan's Attributes:\nHealth: 100\nStrength: 20\nMagic: 10\nCrafting Skill: 10\n";
        $this->assertEquals($expected, $result);
    }

    public function testPlayerFallsDown() {
        $this->playerStrength = 3;
        HeroQuest::playerFallsDown($this->playerHealth, $this->playerStrength);
        $this->assertEquals(90, $this->playerHealth);
    }

    public function testPlayerFallsDownNoDamage() {
        HeroQuest::playerFallsDown($this->playerHealth, $this->playerStrength);
        $this->assertEquals(100, $this->playerHealth);
    }

    public function testItemToString() {
        $result = HeroQuest::itemToString(
            $this->itemName,
            $this->itemKind,
            $this->itemPower
        );

        $expected = "Item: Amulet of Strength\nKind: Strength\nPower: 10\n";
        $this->assertEquals($expected, $result);
    }

    public function testItemReduceByUsage() {
        HeroQuest::itemReduceByUsage($this->itemKind, $this->itemPower);
        $this->assertEquals(5, $this->itemPower);
    }

    public function testItemReduceByUsageToJunk() {
        $this->itemPower = 1;
        HeroQuest::itemReduceByUsage($this->itemKind, $this->itemPower);
        $this->assertEquals(0, $this->itemPower);
        $this->assertEquals("Junk", $this->itemKind);
    }

    public function testItemApplyEffectToPlayer() {
        HeroQuest::itemApplyEffectToPlayer(
            $this->itemName,
            $this->itemKind,
            $this->itemPower,
            $this->playerHealth,
            $this->playerStrength,
            $this->playerMagic
        );

        $this->assertEquals(30, $this->playerStrength);
    }

    public function testItemApplyEffectToPlayerJunk() {
        $this->itemKind = "Junk";
        HeroQuest::itemApplyEffectToPlayer(
            $this->itemName,
            $this->itemKind,
            $this->itemPower,
            $this->playerHealth,
            $this->playerStrength,
            $this->playerMagic
        );
        $this->assertEquals(20, $this->playerStrength);
    }

    public function testItemRepair() {
        HeroQuest::itemRepair($this->playerCraftingSkill, $this->itemPower);
        $this->assertEquals(26, $this->itemPower);
    }
}
