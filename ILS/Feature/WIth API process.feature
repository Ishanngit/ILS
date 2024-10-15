Feature: With API Process

  Scenario Outline: With API Process
    Given I am on the login page
    When I enter valid email and password
    And I enter OTP
    And I click on Verify Button
    And the system create Client data through API
    And the system create Matter data through API
    Then the system delete matter data through API
    And the system delete client data through API

  Examples:
    | iteration | email               | clientName    | matterName     |
    | 1         | test1@example.com    | Client Test 1 | Matter Test 1  |
    | 2         | test2@example.com    | Client Test 2 | Matter Test 2  |
    | 3         | test3@example.com    | Client Test 3 | Matter Test 3  |
    | 4         | test4@example.com    | Client Test 4 | Matter Test 4  |
    | 5         | test5@example.com    | Client Test 5 | Matter Test 5  |
