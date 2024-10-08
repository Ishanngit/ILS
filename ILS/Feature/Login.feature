Feature: Login Functionality


  Scenario: Successful login with valid credentials and OTP
    Given I am on the login page
    When I enter valid username
    And I click on the login button
    And I have received an OTP
    When I enter the OTP "123456"
    And I click on the verify OTP button
    Then I should be redirected to the dashboard page
