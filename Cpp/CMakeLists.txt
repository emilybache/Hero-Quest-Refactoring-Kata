cmake_minimum_required(VERSION 3.20)

project(HeroQuest VERSION 1.0
        LANGUAGES CXX)

set(CMAKE_VERBOSE_MAKEFILE ON)
set(CMAKE_CXX_STANDARD 20)

enable_testing()

set(SRC_LIB_NAME src)
set(SOURCES quest.cpp)
add_library(${SRC_LIB_NAME} ${SOURCES})
target_sources(${SRC_LIB_NAME} PRIVATE ${SOURCES})
target_include_directories(${SRC_LIB_NAME} PUBLIC ${CMAKE_CURRENT_SOURCE_DIR})

add_executable(quest main.cpp)
target_link_libraries(quest ${SRC_LIB_NAME})

include(FetchContent)

FetchContent_Declare(
        Catch2
        GIT_REPOSITORY https://github.com/catchorg/Catch2.git
        GIT_TAG        v2.13.10
        GIT_SHALLOW    TRUE)
FetchContent_MakeAvailable(Catch2)

FetchContent_Declare(
        ApprovalTests
        GIT_REPOSITORY https://github.com/approvals/ApprovalTests.cpp.git
        GIT_TAG        v.10.13.0
        GIT_SHALLOW    TRUE)
FetchContent_MakeAvailable(ApprovalTests)

add_executable(quest_unit_test)
target_sources(quest_unit_test PRIVATE quest_catch.cpp)
target_link_libraries(quest_unit_test ${SRC_LIB_NAME} Catch2::Catch2)
add_test(NAME quest_unit_test COMMAND quest_unit_test)

add_executable(quest_acceptance_test)
target_sources(quest_acceptance_test PRIVATE quest_acceptance.cpp)
target_link_libraries(quest_acceptance_test ${SRC_LIB_NAME} Catch2::Catch2 ApprovalTests::ApprovalTests)
add_test(NAME quest_acceptance_test COMMAND quest_acceptance_test)
