Feature: Login Functionality

  Background:
    Given I am on the login page
    When I enter valid email and password
    And I enter OTP
    And I click on Verify Button

  Scenario Outline: Create Client and Matter, then Delete
    When I clicks on the Clients menu in the side panel
    And I click on "Add New Client" button
    And I add client name "<clientName>"
    And I enter client id "<clientId>"
    And I select access  "Firm"
    And I enter Principal contact email address 
    Then I click on Add client button
    When I clicks on the Matters menu in the side panel
    And I click on Add New Matter button
    And I add Matter name "<matterName>"
    And I enter Matter id "<matterId>"
    Then I select client name "<clientName>"
    And I select Currency "USD"
    And I add Jurisdiction Test
    And Select Matter Type "Firm"
    Then I click on Create Matter button
    When I clicks on the Matters menu in the side panel
    Then I click on delete button
    And I click on delete
    When I clicks on the Clients menu in the side panel
    And I click on delete client button
    And I click on delete button on confirmation model
    When I clicks on the Clients menu in the side panel


  Examples:
    | clientName        | clientId | matterName         | matterId |
    | Automation Data 1 | 123451   | Automation Matter 1 | 1122331  |
    | Automation Data 2 | 123452   | Automation Matter 2 | 1122332  |
    | Automation Data 3 | 123453   | Automation Matter 3 | 1122333  |
    | Automation Data 4 | 123454   | Automation Matter 4 | 1122334  |
    | Automation Data 5 | 123455   | Automation Matter 5 | 1122335  |
