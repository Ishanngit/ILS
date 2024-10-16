Feature: CommonTest
 
Scenario: Common Test for UI and API
  Given I am on the login page
    When I enter valid email and password
    And I enter OTP
    And I click on Verify Button
    And the system create Client data through API
     When I clicks on the Matters menu in the side panel
    And I click on Add New Matter button
    And I add Matter name "<matterName>"
    And I enter Matter id "<matterId>"
    Then I select client name "Automation Data 1"
    And I select Currency "USD"
    And I add Jurisdiction Test
    And Select Matter Type "Firm"
    Then I click on Create Matter button
    When I clicks on the Matters menu in the side panel
    Then I click on delete button
    And I click on delete
   And the system delete client data through API
    

  Examples:
    | matterName           | matterId |
    | Automation Matter 1  | 1122331  |
    | Automation Matter 2  | 1122332  |
    | Automation Matter 3  | 1122333  |
    | Automation Matter 4  | 1122334  |
    | Automation Matter 5  | 1122335  |
    | Automation Matter 6  | 1122336  |
    | Automation Matter 7  | 1122337  |
    | Automation Matter 8  | 1122338  |
    | Automation Matter 9  | 1122339  |
    | Automation Matter 10 | 11223310 |
