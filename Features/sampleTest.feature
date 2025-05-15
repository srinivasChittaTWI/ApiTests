Feature: User Login

Scenario: Valid login
    Given I have a valid login payload
    When I send a POST request to "/login"
    Then the response code should be 200