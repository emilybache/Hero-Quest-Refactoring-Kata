import unittest
from approvaltests.approvals import verify
from hero_quest import HeroQuest
from main import run


class HeroQuestAcceptanceTest(unittest.TestCase):
    def test_full_scenario(self):
        HeroQuest.output = []
        run()
        verify("".join(HeroQuest.output))


if __name__ == "__main__":
    unittest.main()
