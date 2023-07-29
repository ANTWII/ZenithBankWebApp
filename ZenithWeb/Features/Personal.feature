Feature:Personal Banking

    As a user
    I want to navigate to the Personal  Banking login page from the landing page
    So that I can use Zenith Bank's online services

    Background: 
    Given I am a new user accessing the Zenith Bank website
    When I load the Zenith Bank landing page

@Regression
Scenario: Navigating to the Personal Internet Banking login page

    When I hover over the Internet Banking option
    Then the Personal menu should be displayed

@Regression
Scenario: Redirecting Verifying the Personal Internet Banking login page banner

   When I hover over the Internet Banking option
    And  I click on the Personal menu
    Then I should be redirected to the Personal Internet Banking login page

