Feature: Create Client Functionality


    Given I am on the login page
    When I enter valid email and password
    And I click on the login button
    And I enter OTP
    And I click on Verify Button

 Scenario: Successfully create client
  Given I am on the login page
    When I enter valid email and password
    And I click on the login button
    And I enter OTP
    And I click on Verify Button
    When I clicks on the "Clients" menu in the side panel
  # And I click on "Add New Client" button
    #And I add client name "Automation Data"
   # And I enter client id "12345"
   # And I select access "Firmwide"
   # Then I should see a confirmation message "Client created successfully."