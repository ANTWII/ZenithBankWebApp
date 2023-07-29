Feature: Current Account

    As a user
    I want to navigate to the Current account page from the landing page when i hover on either Personal, Sme or corporate
    So that I can open a Current account online

    Background: 
    Given I am a new user accessing the Zenith Bank website
    When I load the Zenith Bank landing page

@Regression
Scenario: Navigating to the Bank accounts page
    When I hover over the Personal, Sme or corporate options
    Then the Current account  menu should be displayed

@Regression
Scenario: Redirecting and Verifying the Current account page

  When I hover over the Personal, Sme or corporate options
    And  I click on the Current account  menu
    Then I should be redirected to the Currdent account page

@Regression
Scenario: Validate the features of the “Individual Current Account”.
 When I hover over the Personal, Sme or corporate options
 And  I click on the Current account  menu
 And  Expand the features and benefits on individual current Account
 Then i should  see the folliowing features and benefits
 | Features_Benefits | 
 | Zero account opening balance        | 
  | Internet Banking        | 
   |Zenith Mobile Banking app        | 
    | *966# Eazybanking       | 
     | MasterCard/Visa/Verve debit card        | 
      | Email/SMS Alertz       | 
       |Cheque book         | 

   @Regression
Scenario: Validate the Requirements of the “Individual Current Account”.
 When I hover over the Personal, Sme or corporate options
 And  I click on the Current account  menu
 And  Expand the Requirements on individual current Account
 Then i should  see the folliowing Requirements
 | Requirements | 
 | Account opening form duly completed        | 
  | One recent clear passport photograph of signatory        | 
   #|Identification of signatories (Driver’s License, International Passport, National Identity Card or Voter’s Card) | 
    | Residence permit (where applicable)      | 
     | Two independent and satisfactory references       | 
      #|Public Utility Receipt dated within the last three months (PHCN bill, water rate bill, tenement rate, rent receipt, telephone bill)      | 
      #

 @Regression
Scenario: Validate the Channels of the “Individual Current Account”.
 When I hover over the Personal, Sme or corporate options
 And  I click on the Current account  menu
 And  Expand the Channels on individual current Account
 Then i should  see the folliowing Channels
 | Channels | 
 | *966# EazyBanking        | 
  | Zenith Internet Banking       | 
   |In-branch at any Zenith Bank branch       | 
    | ZenithDirect – our 24/7 telephone banking       | 
     | Zenith Bank ATM nation-wide – free cash withdrawal       | 
      |Zenith Mobile Banking App – 24/7 on your smart phone       | 
       |Access your account using your Zenith Bank debit card at participating merchant stores for payment of goods and services in Nigeria and anywhere in the world| 

 