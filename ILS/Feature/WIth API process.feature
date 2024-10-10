Feature: With API PRocess 


  Scenario: With API Process
    Given I am on the login page
    When I enter valid email and password
    And I click on the login button
    And I enter OTP
    And I click on Verify Button
    And the system fetches the user's additional data from the API in the background
    When I clicks on the Matters menu in the side panel
  