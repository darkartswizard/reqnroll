Feature: CandyMapper navigation

  Scenario: Visit the CandyMapper home page
    Given the browser is ready for CandyMapper
    When I navigate to the CandyMapper home page
    Then the CandyMapper page should load
