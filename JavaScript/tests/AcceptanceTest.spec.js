const { output } = require('../src/HeroQuest');
const { run } = require('../src/index');

describe('HeroQuestAcceptanceTest', () => {

    it("fullScenario", () => {
        output.splice(0, output.length);
        run();
        expect(output.join("")).toMatchSnapshot();
    });

});
