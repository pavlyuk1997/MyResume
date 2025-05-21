Feature: Search on DOU

Scenario: DOU search automation
    Given I open the DOU homepage
    When I search for "Automation"
    Then I should see at least 1 search result