<?php

namespace Tests;

use PHPUnit\Framework\TestCase;
use CodingDojo\HeroQuest;
use Spatie\Snapshots\MatchesSnapshots;

class HeroQuestAcceptanceTest extends TestCase
{
    use MatchesSnapshots;
    
    public function testFullScenario() {
        HeroQuest::$output = [];

        require_once __DIR__ . '/../src/main.php';
        run();
        
        $actualOutput = implode("", HeroQuest::$output);
        $this->assertMatchesSnapshot($actualOutput);
    }
}