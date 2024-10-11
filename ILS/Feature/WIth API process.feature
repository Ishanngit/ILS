Feature: With API Process

  Scenario: With API Process
    Given I am on the login page
    When I enter valid email and password
    #And I click on the login button
    And I enter OTP
    And I click on Verify Button
    And the system create Client data through API
     And the system create Matter data through API
   