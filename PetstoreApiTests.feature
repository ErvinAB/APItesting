Feature: Petstore API Testing

Scenario: Create a new pet
    Given I have a pet with the following details:
        | Id | Name   | Status    |
        | 1  | Fluffy | available |
    When I send a request to create the pet
    Then the pet is created successfully

Scenario: Get a pet by ID
    Given I have a pet with the ID 1
    When I send a request to get the pet by ID
    Then the pet details are retrieved successfully

Scenario: Update a pet
    Given I have a pet with the ID 1 and updated details:
        | Id | Name   | Status |
        | 1  | Fluffy | sold   |
    When I send a request to update the pet
    Then the pet is updated successfully

Scenario: Delete a pet by ID
    Given I have a pet with the ID 1
    When I send a request to delete the pet by ID
    Then the pet is deleted successfully
