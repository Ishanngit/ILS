Feature: Login Functionality


  Scenario: Successful login with valid credentials and OTP
    Given I am on the login page
    When I enter valid email and password
    And I click on the login button

    Then I should be redirected to the dashboard page
