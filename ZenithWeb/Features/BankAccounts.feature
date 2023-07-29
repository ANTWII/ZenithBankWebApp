Feature:Bank Account

    As a user
    I want to navigate to the Bank account page from the landing page when i hover on either Personal, Sme or corporate
    So that I can open a bank account online

    Background: 
    Given I am a new user accessing the Zenith Bank website
    When I load the Zenith Bank landing page

@Regression
Scenario: Navigating to the Bank accounts page
    When I hover over the Personal, Sme or corporate options
    Then the Bank account  menu should be displayed

@Regression
Scenario: Redirecting and Verifying the Bank account page

  When I hover over the Personal, Sme or corporate options
    And  I click on the Bank account  menu
    Then I should be redirected to theBank accounts page

