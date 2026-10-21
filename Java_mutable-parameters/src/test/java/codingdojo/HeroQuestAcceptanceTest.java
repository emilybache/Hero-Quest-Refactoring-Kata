package codingdojo;

import org.approvaltests.Approvals;
import org.junit.jupiter.api.Test;

public class HeroQuestAcceptanceTest {

    @Test
    public void fullScenario() {
        HeroQuest.output.setLength(0);
        Main.run();
        Approvals.verify(HeroQuest.output.toString());
    }
}
