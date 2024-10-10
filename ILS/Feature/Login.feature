Feature: Login Functionality


  Scenario: Login Create Matter and CLient
    Given I am on the login page
    When I enter valid email and password
    And I click on the login button
    And I enter OTP
    And I click on Verify Button
    When I clicks on the Clients menu in the side panel
   And I click on "Add New Client" button
   And I add client name "Automation Data"
   And I enter client id "12345"
   And I select access  "Firm"
   And I enter Principal contact email address 
   Then I click on Add client button
   When I clicks on the Matters menu in the side panel
   And I click on Add New Matter button
    And I add Matter name "Automation Matter"
   And I enter Matter id "112233"
   Then I select client name "Automation"
   And I select Currency "USD"
   And I add Jurisdiction Test
   And Select Matter Type "Firm"
   Then I click on Create Matter button
   When I clicks on the Matters menu in the side panel
   # Then I should see a confirmation message "Client created successfully."