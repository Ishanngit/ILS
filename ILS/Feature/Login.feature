Feature: Login Functionality


  Scenario: Successfully login
    Given I am on the login page
    When I enter valid email and password
    And I click on the login button
    And I enter OTP
    And I click on Verify Button
   
