#define APPROVALS_CATCH
#include "ApprovalTests.hpp"
#include "catch2/catch.hpp"

#include "quest.h"
#define UNIT_TEST
#include "main.cpp"
#undef UNIT_TEST

auto defaultReporterDisposer =
    ApprovalTests::Approvals::useAsDefaultReporter(
        std::make_shared<ApprovalTests::TextDiffReporter>());

TEST_CASE("FullScenario")
{
    resetOutput();
    run();
    ApprovalTests::Approvals::verify(outputBuffer);
}
