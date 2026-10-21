namespace CodingDojo.Test;

using System.Text;

public class HeroQuestAcceptanceTest
{
    [Fact]
    public Task FullScenario()
    {
        HeroQuest.Output = new StringBuilder();
        CodingDojo.Program.Run();
        return Verifier.Verify(HeroQuest.Output.ToString());
    }
}
