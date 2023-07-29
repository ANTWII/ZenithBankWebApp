Feature:Landing Page 

As a user
    I want to see the landing page with the correct URL and banner
    So that I know I am on the official Zenith Bank site
@Regression
Scenario: Loading the landing page shows the correct URL

    Given I am a new user accessing the Zenith Bank website
    When I load the Zenith Bank landing page
    Then the URL should display the zenith homepage url

    @Regression
Scenario: Loading the landing page shows the Zenith Bank banner

    Given I am a new user accessing the Zenith Bank website
    When I load the Zenith Bank landing page
    Then I should see the Zenith Bank banner on the page